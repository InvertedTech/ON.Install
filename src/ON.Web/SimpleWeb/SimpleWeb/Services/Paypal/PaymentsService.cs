using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Fragments.Authorization.Payment.Paypal;
using ON.Settings;
using System;
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

        public async Task<PaypalCancelOwnSubscriptionResponse> CancelSubscription(Guid subscriptionId, string reason)
        {
            if (!IsLoggedIn)
                return null;

            var req = new PaypalCancelOwnSubscriptionRequest()
            {
                SubscriptionID = subscriptionId.ToString(),
                Reason = reason
            };

            var client = new PaypalInterface.PaypalInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.PaypalCancelOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        public async Task<PaypalGetOwnSubscriptionRecordsResponse> GetRecords()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.PaymentServiceChannel == null)
                return null;

            logger.LogWarning($"******Trying to hopefully connect to PaymentService at:({nameHelper.PaymentServiceChannel.Target})******");


            var client = new PaypalInterface.PaypalInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.PaypalGetOwnSubscriptionRecordsAsync(new PaypalGetOwnSubscriptionRecordsRequest(), GetMetadata());
            return reply;
        }

        public async Task<PaypalNewOwnSubscriptionResponse> NewSubscription(string subscriptionId)
        {
            if (!IsLoggedIn)
                return null;

            var req = new PaypalNewOwnSubscriptionRequest()
            {
                PaypalSubscriptionId = subscriptionId
            };

            var client = new PaypalInterface.PaypalInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.PaypalNewOwnSubscriptionAsync(req, GetMetadata());
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
