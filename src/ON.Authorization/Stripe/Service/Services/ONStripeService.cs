using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Authorization.Stripe.Service.Models;
using Stripe;
using Stripe.BillingPortal;
using System.Threading.Tasks;

namespace ON.Authorization.Stripe.Service.Services
{
    public class ONStripeService
    {
        private readonly ILogger<ONStripeService> logger;
        private readonly AppSettings settings;
        private StripeClient stripe;
        private SubscriptionService subService;

        public ONStripeService(IOptions<AppSettings> settings)
        { 
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

        private async Task<string> ConfigurePortal()
        {
            // TODO: Check for existing portal config
            StripeConfiguration.ApiKey = this.stripe.ApiKey;
            var options = new ConfigurationCreateOptions
            {
                Features = new ConfigurationFeaturesOptions
                {
                    CustomerUpdate = new ConfigurationFeaturesCustomerUpdateOptions
                    {
                        AllowedUpdates = new System.Collections.Generic.List<string>
                        {
                            "email",
                            "address",
                        },
                        Enabled = true,
                    },
                    InvoiceHistory = new ConfigurationFeaturesInvoiceHistoryOptions
                    {
                        Enabled = true,
                    },
                    PaymentMethodUpdate = new ConfigurationFeaturesPaymentMethodUpdateOptions
                    {
                        Enabled = true,
                    },
                },
                BusinessProfile = new ConfigurationBusinessProfileOptions
                {
                    PrivacyPolicyUrl = "https://localhost",
                    TermsOfServiceUrl = "https://localhost",
                },
                DefaultReturnUrl = "http://localhost/subscription",
            };

            var configService = new ConfigurationService();
            var config = await configService.CreateAsync(options);

            return config.Id;
        }

        public async Task<string> CreateBillingPortal(string customerId)
        {
            StripeConfiguration.ApiKey = this.stripe.ApiKey;
            var configId = await ConfigurePortal();
            var portalOpts = new SessionCreateOptions
            {
                Customer = customerId,
                Configuration = configId
            };

            var service = new SessionService();
            var session = await service.CreateAsync(portalOpts);

            return session.Url;
        }
    }
}

