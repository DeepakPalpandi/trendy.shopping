using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using trendy.shopping.api.Entities.Common;

namespace trendy.shopping.domain.Entities.Master.Locations
{
    [Table("countries", Schema = "master"),Index(nameof(CountryName), IsUnique = true)]
    public class Country : AuditEntity
    {
        public string CountryName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public int Sequence { get; set; }
        public ICollection<State>? States { get; set; }
    }
}
