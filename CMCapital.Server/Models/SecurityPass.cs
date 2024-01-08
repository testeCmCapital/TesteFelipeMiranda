using System.ComponentModel.DataAnnotations.Schema;

namespace CMCapital.Server.Models
{
    [Table("SecurityPass")]
    public class SecurityPass
    {
        public int? ID { get; set; }
        public string? NamePass { get; set; }
        public string? Pass { get; set; }
        public int? Active { get; set; }
    }
}
