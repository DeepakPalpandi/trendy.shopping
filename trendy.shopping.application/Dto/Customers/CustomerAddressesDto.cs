using trendy.shopping.application.Dto.CommonDto;

namespace trendy.shopping.domain.Dto.Customers;

public class CustomerAddressesDto
{
    public Guid CustomersId { get; set; }
    public string AddressLine1 { get; set; } = string.Empty;
    public string AddressLine2 { get; set; } = string.Empty;
    public string? PostalCode { get; set; }
    public string? PinCode { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public Guid CountryId { get; set; }
    public Guid StateId { get; set; }
    public Guid CityId { get; set; }
}
