using System.ComponentModel.DataAnnotations.Schema;

namespace CMCapital.Server.Models
{
    [Table("Client")]
    public class Client
    {
        public int ID { get; set; }
        public string? ClientName { get; set; }
        public double? Balance { get; set; }  
        public int Active { get; set; }
    }
}
