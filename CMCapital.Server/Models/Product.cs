namespace CMCapital.Server.Models
{
    public class Product
    {
        public int? ID { get; set; }
        public string? ProductName { get; set; }
        public int? IDCategory { get; set; }
        public DateTime? DueDate { get; set; }
        public double? Value { get; set; }
        public int? Amount { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? Active { get; set; }
    }
}
