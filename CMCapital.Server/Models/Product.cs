using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMCapital.Server.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int? ID { get; set; }
        public string? ProductName { get; set; }
        public int? IDCategory { get; set; }
        public DateTime DueDate { get; set; }
        public double? Value { get; set; }
        public int? Amount { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? Active { get; set; }
    }
}
