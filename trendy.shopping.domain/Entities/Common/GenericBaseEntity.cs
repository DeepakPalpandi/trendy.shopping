using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trendy.shopping.api.Entities.Common;

public abstract class GenericBaseEntity<T>
{
    [Key, Column(Order = 0)]
    public T Id { get; set; } = default!;

    [Required, Column(Order = 100)]
    public bool IsActive { get; set; } = true;
}
