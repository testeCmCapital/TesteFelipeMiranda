namespace CMCapital.Server.Models
{
    public class PurchaseHistory
    {
        public int? ID { get; set; }
        public int? IDClient { get; set; }
        public int? IDProduct { get; set; }
        public int? Quantities { get; set; }
        public double? PurchaseValue { get; set; }
        public DateTime? PurchaseDate { get; set; }
    }
}
