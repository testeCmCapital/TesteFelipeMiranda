using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMCapital.Server.Models
{
    [Table("PurchaseHistory")]
    public class PurchaseHistory
    {
        [Key]
        public int? ID { get; set; }
        public int? IDClient { get; set; }
        public int? IDProduct { get; set; }
        public int? Quantities { get; set; }
        public double? PurchaseValue { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? Active { get; set; }
    }
}
