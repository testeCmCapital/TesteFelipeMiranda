using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMCapital.Server.Models
{
    [Table("Category")]
    public class Category
    {
        public int ID { get; set; }
        public string? NameCategory { get; set; }
        public int Active { get; set; }
    }
}
