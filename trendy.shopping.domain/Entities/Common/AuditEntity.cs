using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trendy.shopping.api.Entities.Common;

public abstract class AuditEntity : BaseEntity
{
    [Column(Order = 101)]
    public bool IsDeleted { get; set; }

    [Required, Column(Order = 103)]
    public DateTimeOffset CreatedAt { get; set; }

    [StringLength(30), Column(Order = 104)]
    public string CreatedIp { get; set; } = string.Empty;

    [Column(Order = 107)]
    public DateTimeOffset? UpdatedAt { get; set; }

    [StringLength(30), Column(Order = 108)]
    public string? UpdatedIp { get; set; }

    [Column(Order = 111)]
    public DateTimeOffset? DeletedAt { get; set; }

    [StringLength(30), Column(Order = 112)]
    public string? DeletedIp { get; set; }

}