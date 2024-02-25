using trendy.shopping.api.Entities.Common;

namespace trendy.shopping.domain.Entities.Customers;

public class Customers : AuditEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string DateOfBirth { get; set; } = string.Empty;
    public string Alias { get; set; } = string.Empty;
    public string Sex {  get; set; } = string.Empty;
    public string? UserId { get; set; }
    public ICollection<CustomerAddresses>? CustomerAddresses {  get; set; }

}
