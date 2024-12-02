using Microsoft.Extensions.Logging;
using ON.Fragments.Authorization.Payment.Stripe;
using ON.Settings;
using System.Linq;

namespace ON.SimpleWeb.Services.Stripe
{
    public class AccountService
    {
        private readonly ILogger<AccountService> logger;
        private readonly ServiceNameHelper nameHelper;

        public readonly string AccountId;
        public readonly ProductRecord[] Products;

        public AccountService(ServiceNameHelper nameHelper, ILogger<AccountService> logger)
        {
            this.logger = logger;
            this.nameHelper = nameHelper;

            var res = GetDetails();
            AccountId = res.ClientId;
            Products = res.Products.Records.ToArray();
        }

        private StripeGetAccountDetailsResponse GetDetails()
        {
            if (nameHelper.PaymentServiceChannel == null)
                return null;

            var client = new StripeInterface.StripeInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = client.StripeGetAccountDetails(new StripeGetAccountDetailsRequest());
            return reply;
        }
    }
}
