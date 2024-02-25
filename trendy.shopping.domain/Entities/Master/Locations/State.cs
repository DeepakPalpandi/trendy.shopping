using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using trendy.shopping.api.Entities.Common;

namespace trendy.shopping.domain.Entities.Master.Locations
{
    [Table("state", Schema = "master"), Index(nameof(StateName), IsUnique = true)]
    public class State : AuditEntity
    {
        public Guid CountryId { get; set; }
        public string StateName { get; set; } = string.Empty;
        public string StateCode { get; set; } = string.Empty;
        public int Sequence { get; set; }
        public ICollection<City>? Cities { get; set; }
    }
}
