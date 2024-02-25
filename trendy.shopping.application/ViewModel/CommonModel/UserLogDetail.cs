namespace trendy.shopping.application.ViewModel.CommonModel;

public class UserLogDetail
{
    public long Id { get; set; }
    public int CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string CreatedIp { get; set; } = string.Empty;
    public int CreatedDeptId { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? UpdatedIp { get; set; }
    public int UpdatedDeptId { get; set; }

    public int DeletedBy { get; set; }
    public DateTimeOffset DeletedAt { get; set; }
    public string DeletedIp { get; set; } = string.Empty;
    public int DeletedDeptId { get; set; }
}
