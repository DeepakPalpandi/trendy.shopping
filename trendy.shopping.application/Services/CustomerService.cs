using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;
using trendy.shopping.application.CommonMethods;
using trendy.shopping.application.ViewModel.CommonModel;
using trendy.shopping.domain.Data;
using trendy.shopping.domain.Dto.Customers;
using trendy.shopping.domain.Entities.Customers;
using trendy.shopping.domain.UnitOfWork;

namespace trendy.shopping.application.Services
{
    public interface ICustomerService
    {
        Task<ResponseModel> SignupCustomer(CustomersDto customersDto, string myIp);
        Task<ResponseModel> LoginCustomer(string loginBy, string password);
        Task<ResponseModel> UpdateCustomer(string customerId, CustomersDto updatedCustomerDto, string myIp);
        Task<ResponseModel> DeleteCustomer(string customerId);
    }
    public class CustomerService : ICustomerService
    {
        private readonly IConfiguration _configuration;
        private readonly TrendyShoppingContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly ITrendyShoppingUnitOfWork _uow;

        public CustomerService(IConfiguration configuration,
            TrendyShoppingContext context,
            IPasswordHasher passwordHasher,
            IMapper mapper, ITrendyShoppingUnitOfWork uow)
        {
            _configuration = configuration;
            _context = context;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<ResponseModel> LoginCustomer(string loginBy, string password)
        {
            if (string.IsNullOrEmpty(loginBy) || string.IsNullOrEmpty(password))
            {
                return new ResponseModel { Message = "Invalid Request", Success = false };
            }

            var user = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == loginBy || x.UserName.ToLower() == loginBy.ToLower());

            var userDto = _mapper.Map<CustomersDto>(user);

            if (user == null)
            {
                return new ResponseModel { Message = "User Not Found", Success = false };
            }

            if (!_passwordHasher.Verify(user.Password, password))
            {
                return new ResponseModel { Message = "Password or User Name is Incorrect!", Success = false };
            }

            return new ResponseModel
            {
                Message = "Login Success",
                Success = true,
                UserName = user.UserName,
                UserId = user.Id,
                Token = GetToken(userDto)
            };
        }

        public async Task<ResponseModel> SignupCustomer(CustomersDto customersDto, string myIp)
        {
            if (customersDto is null || string.IsNullOrWhiteSpace(customersDto.UserName) ||
                string.IsNullOrWhiteSpace(customersDto.Email) || string.IsNullOrWhiteSpace(customersDto.Password))
                return new ResponseModel { Message = "Invalid Request", Success = false };

            if (await _context.Customers.AnyAsync(x => x.UserName.ToLower() == customersDto.UserName.ToLower() ||
                                                       x.Email.ToLower() == customersDto.Email.ToLower()))
                return new ResponseModel { Message = "Customer Already Exists!", Success = false };

            var user = _mapper.Map<Customers>(customersDto);
            user.Password = _passwordHasher.Hash(user.Password);
            user.CreatedAt = DateTime.UtcNow;
            user.Id = Guid.NewGuid();
            user.UserId = "TS" + (await _context.Customers.CountAsync() + 1);

            user.CustomerAddresses = customersDto.customerAddresses?
                .Select(addressDto => _mapper.Map<CustomerAddresses>(addressDto, opt =>
                {
                    opt.Items["CustomersId"] = user.Id;
                }))
                .ToList();

            user.IsActive = true;
            user.CreatedIp = myIp ?? string.Empty;

            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _context.Customers.Add(user);
                await _uow.SaveChanges();
                transactionScope.Complete();
            }

            return new ResponseModel
            {
                Message = "Registration Success",
                Success = true,
                UserName = user.UserName,
                UserId = user.Id,
                Token = GetToken(customersDto)
            };
        }

        public async Task<ResponseModel> UpdateCustomer(string customerId, CustomersDto updatedCustomerDto, string myIp)
        {
            var existingCustomer = await _context.Customers.Include(a => a.CustomerAddresses).
                Where(x => x.UserId!.Equals(customerId)).FirstOrDefaultAsync();

            if (existingCustomer == null)
                return new ResponseModel { Message = "Customer not found", Success = false };

            // Check if updated email or username already exists for another customer
            if (await _context.Customers.AnyAsync(x => (x.UserName.ToLower() == updatedCustomerDto.UserName.ToLower() ||
                                                       x.Email.ToLower() == updatedCustomerDto.Email.ToLower()) && x.UserId != customerId))
                return new ResponseModel { Message = "Email or Username already exists for another customer", Success = false };

            // Update existing customer with the new information
            _mapper.Map(updatedCustomerDto, existingCustomer);
            existingCustomer.UpdatedAt = DateTime.UtcNow;
            existingCustomer.UpdatedIp = myIp ?? string.Empty;
            existingCustomer.Password = _passwordHasher.Hash(updatedCustomerDto.Password);

            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _context.Customers.Update(existingCustomer);
                await _uow.SaveChanges();
                transactionScope.Complete();
            }

            return new ResponseModel
            {
                Message = "Customer updated successfully",
                Success = true,
                UserName = existingCustomer.UserName,
                UserId = existingCustomer.Id,
                Token = GetToken(updatedCustomerDto)
            };
        }

        public async Task<ResponseModel> DeleteCustomer(string customerId)
        {
            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(x => x.UserId == customerId);

            if (existingCustomer == null)
                return new ResponseModel { Message = "Customer not found", Success = false };

            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _context.Customers.Remove(existingCustomer);
                await _uow.SaveChanges();
                transactionScope.Complete();
            }
            return new ResponseModel
            {
                Message = "Customer deleted successfully",
                Success = true
            };
        }


        #region Private Methods
        public string GetToken(CustomersDto customers)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["jwt:Subject"]!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim("UserId",customers.UserId!.ToString()!),
                new Claim("UserName",customers.UserName),
                new Claim("Email",customers.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:Key"]!));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["jwt:Issuer"]!,
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return token.ToString();
        }
        #endregion
    }
}
