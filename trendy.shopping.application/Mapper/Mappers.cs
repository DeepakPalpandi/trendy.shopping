using AutoMapper;
using trendy.shopping.domain.Dto.Customers;
using trendy.shopping.domain.Entities.Customers;

namespace trendy.shopping.application.Mapper;

public class Mappers:Profile
{
    public Mappers()
    {
        CreateMap<Customers,CustomersDto>().ReverseMap();

        CreateMap<CustomerAddresses,CustomerAddressesDto>().ReverseMap();
    }
}
