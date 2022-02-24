using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Authorization.Stripe.Service.Models;
using Stripe.BillingPortal;
using BillingService = Stripe.BillingPortal.SessionService;
using BillingSessionOpts = Stripe.BillingPortal.SessionCreateOptions;
using CheckoutSessionOpts = Stripe.Checkout.SessionCreateOptions;
using CheckoutService = Stripe.Checkout.SessionService;
using CheckoutItems = Stripe.Checkout.SessionLineItemOptions;
using CheckoutSession = Stripe.Checkout.Session;
using Stripe;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ON.Authorization.Stripe.Service.Services
{
    public class ONStripeService
    {
        private readonly ILogger<ONStripeService> logger;
        private readonly AppSettings settings;
        private StripeClient stripe;
        private SubscriptionService subService;
        private PriceService priceService;

        public ONStripeService(IOptions<AppSettings> settings)
        { 
            this.settings = settings.Value;

            stripe = new StripeClient(this.settings.StripeClientSecret);
            priceService = new PriceService(stripe);
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
                    SubscriptionCancel = new ConfigurationFeaturesSubscriptionCancelOptions
                    {
                        Enabled= true,
                        Mode = "at_period_end",
                        ProrationBehavior = "none"
                    }
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
            var portalOpts = new BillingSessionOpts
            {
                Customer = customerId,
                Configuration = configId
            };

            var service = new BillingService();
            var session = await service.CreateAsync(portalOpts);

            return session.Url;
        }

        public async Task<string> CreateCheckoutSession(string priceId)
        {
            if (priceId == null) { return string.Empty; };
            try
            {
                StripeConfiguration.ApiKey = this.stripe.ApiKey;
                Price price = await priceService.GetAsync(priceId);

                var chekoutOpts= new CheckoutSessionOpts
                {
                    SuccessUrl = "http://localhost/subscription/",
                    CancelUrl = "https://localhost/subscription/",
                    Mode = "subscription",
                    LineItems = new List<CheckoutItems>
                    {
                        new CheckoutItems
                        {
                            Price = priceId,
                            Quantity = 1,

                        },
                    },
                };

                var service = new CheckoutService();
                var session = await service.CreateAsync(chekoutOpts);
                

                return session.Url.ToString();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

