using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Fragments.Authorization.Payment.Stripe;
using ON.Settings;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Services.Stripe
{
    public class PaymentsService
    {
        private readonly ILogger<PaymentsService> logger;
        private readonly ServiceNameHelper nameHelper;
        public readonly ONUser User;

        public PaymentsService(ServiceNameHelper nameHelper, ONUserHelper userHelper, ILogger<PaymentsService> logger)
        {
            this.logger = logger;

            User = userHelper.MyUser;

            this.nameHelper = nameHelper;
        }

        public bool IsLoggedIn { get => User != null; }

        public async Task<CancelOwnSubscriptionResponse> CancelSubscription(string reason)
        {
            if (!IsLoggedIn)
                return null;

            var req = new CancelOwnSubscriptionRequest()
            {
                Reason = reason
            };

            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.CancelOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        public async Task<SubscriptionRecord> GetCurrentRecord()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.PaymentServiceChannel == null)
                return null;

            logger.LogWarning($"******Trying to hopefully connect to PaymentService at:({nameHelper.PaymentServiceChannel.Target})******");


            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.GetOwnSubscriptionRecordAsync(new GetOwnSubscriptionRecordRequest(), GetMetadata());
            return reply.Record;
        }

        public async Task<NewOwnSubscriptionResponse> NewSubscription(string subscriptionId, int price, string customerId)
        {
            if (!IsLoggedIn)
                return null;
            price /= 100;

            var req = new NewOwnSubscriptionRequest()
            {
                SubscriptionId = subscriptionId,
                SubscriptionPrice = (uint)price,
                CustomerId = customerId,
            };

            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.NewOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        public async Task<CreateBillingPortalResponse> CreatePortal(string customerId)
        {
            if (!IsLoggedIn)
                return null;

            var req = new CreateBillingPortalRequest()
            {
                CustomerId = customerId
            };
            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.CreateBillingPortalAsync(req, GetMetadata());

            return reply;
        }

        // Fetch JWT Bearer token
        private Metadata GetMetadata()
        {
            var data = new Metadata();
            if (User != null && !string.IsNullOrWhiteSpace(User.JwtToken))
                data.Add("Authorization", "Bearer " + User.JwtToken);

            return data;
        }

        public async Task<CheckoutSessionResponse> CreateCheckoutSession(string priceId)
        {
            if (!IsLoggedIn)
                return null;

            var req = new CheckoutSessionRequest()
            {
                PriceId = priceId
            };
            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.CreateCheckoutSessionAsync(req, GetMetadata());

            return reply;
        }
    }
}
