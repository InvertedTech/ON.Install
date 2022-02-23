using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Authorization.Stripe.Service.Models;
using Stripe;
using System.Threading.Tasks;

namespace ON.Authorization.Stripe.Service.Services
{
    public class StripeService
    {
        private readonly ILogger<StripeService> logger;
        private readonly AppSettings settings;
        private StripeClient stripe;
        private SubscriptionService subService;

        public StripeService(ILogger<StripeService> logger, IOptions<AppSettings> settings)
        { 
            this.logger = logger;
            this.settings = settings.Value;
            this.stripe = new StripeClient(this.settings.StripeClientSecret);
        }

        public async Task<bool> CancelSubscription(string subId)
        {
            StripeConfiguration.ApiKey = this.stripe.ApiKey;
            subService = new SubscriptionService(stripe);

            var cancelledSub = await subService.CancelAsync(subId);

            if (cancelledSub != null)
            {
                return true;
            }
            
            return false;
        }
    }
}

