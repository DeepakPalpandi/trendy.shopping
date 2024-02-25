using trendy.shopping.api.Entities.Common;

namespace trendy.shopping.domain.Entities.Customers
{
    public class CustomerAddresses:BaseEntity
    {
        public Guid CustomersId { get; set; }
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set;} = string.Empty;
        public string? PostalCode { get; set; }
        public string? PinCode {  get; set; }
        public string PhoneNumber { get; set; } = string.Empty; 
        public Guid CountryId { get; set; }
        public Guid StateId { get; set; }
        public Guid CityId { get; set; }

    }
}
