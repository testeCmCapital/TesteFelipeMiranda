using System.ComponentModel.DataAnnotations.Schema;

namespace CMCapital.Server.Models
{
    [Table("Login")]
    public class Login
    {
        public int? ID { get; set; }
        public string? LoginUser { get; set; }
        public string? Password { get; set; }
        public int? IDClient { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? Active { get; set; }

        [ForeignKey("ID")]
        public Client? Client { get; set; }

    }
}
