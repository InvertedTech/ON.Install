namespace ON.Authorization.Payment.Paypal.Clients.Models
{
    public class ProductRecordModel
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? type { get; set; } = "SERVICE";
        public string? category { get; set; } = "SOFTWARE";
    }
}
