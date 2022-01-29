namespace ON.Authorization.Stripe.Service.Clients.Models
{
    public class ProductRecordModel
    {
        public string productId { get; set; }
        public string priceId { get; set; }
        public string checkoutUrl { get; set; }
    }
}
