using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Fragments.Authorization.Payments.Paypal;
using ON.Settings;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Services.Paypal
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

            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaypalPaymentsServiceChannel);
            var reply = await client.CancelOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        public async Task<SubscriptionRecord> GetCurrentRecord()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.PaypalPaymentsServiceChannel == null)
                return null;

            logger.LogWarning($"******Trying to hopefully connect to PaymentService at:({nameHelper.PaypalPaymentsServiceChannel.Target})******");


            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaypalPaymentsServiceChannel);
            var reply = await client.GetOwnSubscriptionRecordAsync(new GetOwnSubscriptionRecordRequest(), GetMetadata());
            return reply.Record;
        }

        public async Task<NewOwnSubscriptionResponse> NewSubscription(string subscriptionId)
        {
            if (!IsLoggedIn)
                return null;

            var req = new NewOwnSubscriptionRequest()
            {
                SubscriptionId = subscriptionId
            };

            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaypalPaymentsServiceChannel);
            var reply = await client.NewOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            if (User != null && !string.IsNullOrWhiteSpace(User.JwtToken))
                data.Add("Authorization", "Bearer " + User.JwtToken);

            return data;
        }
    }
}
