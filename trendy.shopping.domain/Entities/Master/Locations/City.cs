using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using trendy.shopping.api.Entities.Common;

namespace trendy.shopping.domain.Entities.Master.Locations
{
    [Table("city", Schema = "master"), Index(nameof(CityName), IsUnique = true)]
    public class City : AuditEntity
    {
        public Guid StateId { get; set; }
        public string CityName { get; set; } = string.Empty;
        public string CityCode { get; set; } = string.Empty;
        public int Sequence { get; set; }

    }
}
