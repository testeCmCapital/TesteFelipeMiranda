using System.ComponentModel.DataAnnotations.Schema;

namespace CMCapital.Server.Models
{
    [Table("Fees")]
    public class Fees
    {
        public int? ID { get; set; }
        public double? InitialValue { get; set; }
        public double? FinalValue { get; set; }
        public double? Percentage { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? Active { get; set; }
    }
}
