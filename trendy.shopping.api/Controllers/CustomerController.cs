using Microsoft.AspNetCore.Mvc;
using trendy.shopping.application.Services;
using trendy.shopping.domain.Dto.Customers;
using trendy.shopping.domain.Exceptions;
using trendy.shopping.domain.Helpers;

namespace trendy.shopping.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet("log-in/{loginBy}/{password}")]
        public async Task<IActionResult> LoginCustomer(string loginBy, string password)
        {
            try
            {
                var response = await _customerService.LoginCustomer(loginBy,password);

                return Ok(response);
            }
            catch (BadRequestException brex)
            {
                _logger.LogWarning(brex, brex.Message);
                return BadRequest(new { Message = brex.Message });
            }
            catch (NotFoundException nfx)
            {
                _logger.LogWarning(nfx, nfx.Message);
                return NotFound(new { Source = nfx.Source, Message = nfx.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(417, new { Message = ex.Message });
            }
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignupCustomer(CustomersDto request)
        {
            try
            {
                string myIP = CommonHelper.GetIPAddress(HttpContext) ?? string.Empty;

                var response = await _customerService.SignupCustomer(request, myIP);

                return Ok(response);
            }
            catch (BadRequestException brex)
            {
                _logger.LogWarning(brex, brex.Message);
                return BadRequest(new { Message = brex.Message });
            }
            catch (NotFoundException nfx)
            {
                _logger.LogWarning(nfx, nfx.Message);
                return NotFound(new { Source = nfx.Source, Message = nfx.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(417, new { Message = ex.Message });
            }
        }

        [HttpPut("update-customer")]
        public async Task<IActionResult> UpdateCustomer(string customerId, CustomersDto request)
        {
            try
            {
                string myIP = CommonHelper.GetIPAddress(HttpContext) ?? string.Empty;

                var response = await _customerService.UpdateCustomer(customerId,request, myIP);

                return Ok(response);
            }
            catch (BadRequestException brex)
            {
                _logger.LogWarning(brex, brex.Message);
                return BadRequest(new { Message = brex.Message });
            }
            catch (NotFoundException nfx)
            {
                _logger.LogWarning(nfx, nfx.Message);
                return NotFound(new { Source = nfx.Source, Message = nfx.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(417, new { Message = ex.Message });
            }
        }

        [HttpDelete("delete-customer")]
        public async Task<IActionResult> DeleteCustomer(string customerId)
        {
            try
            {
                var response = await _customerService.DeleteCustomer(customerId);

                return Ok(response);
            }
            catch (BadRequestException brex)
            {
                _logger.LogWarning(brex, brex.Message);
                return BadRequest(new { Message = brex.Message });
            }
            catch (NotFoundException nfx)
            {
                _logger.LogWarning(nfx, nfx.Message);
                return NotFound(new { Source = nfx.Source, Message = nfx.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(417, new { Message = ex.Message });
            }
        }
    }
}
