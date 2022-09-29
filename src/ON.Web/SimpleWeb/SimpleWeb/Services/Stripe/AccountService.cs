using Microsoft.Extensions.Logging;
using ON.Fragments.Authorization.Payments.Stripe;
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

        private GetAccountDetailsResponse GetDetails()
        {
            if (nameHelper.StripePaymentsServiceChannel == null)
                return null;

            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.StripePaymentsServiceChannel);
            var reply = client.GetAccountDetails(new GetAccountDetailsRequest());
            return reply;
        }
    }
}
