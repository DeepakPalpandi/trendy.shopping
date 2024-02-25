using System.ComponentModel.DataAnnotations;

namespace trendy.shopping.application.Dto.CommonDto;

public abstract class GenericBaseDto<T>
{
    [Required]
    public T Id { get; set; } = default!;

    [Required] public bool IsActive { get; set; }
}