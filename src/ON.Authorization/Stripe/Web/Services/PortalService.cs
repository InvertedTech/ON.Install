using Stripe;
using Stripe.BillingPortal;
using System.Threading.Tasks;

namespace ON.Authorization.Stripe.Web.Services
{
    public class PortalService
    {
        private StripeClient _stripeClient;

        public PortalService(StripeClient client)
        {
            this._stripeClient = client;
        }

        private async Task<string> CreatePortalConfig()
        {
            StripeConfiguration.ApiKey = this._stripeClient.ApiKey;
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
        
        public async Task<string> CreatePortal(string customerId)
        {
            StripeConfiguration.ApiKey = this._stripeClient.ApiKey;

            var configId = await this.CreatePortalConfig();
            var portalOpts = new SessionCreateOptions
            {
                Customer = customerId,
                Configuration = configId,
            };

            var service = new SessionService();
            var session = await service.CreateAsync(portalOpts);
            return session.Url;
        }
    }
}
