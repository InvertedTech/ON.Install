using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Authorization.Paypal.Web.Helper;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.Paypal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Paypal.Web.Services
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

            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaymentsServiceChannel);
            var reply = await client.CancelOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        public async Task<SubscriptionRecord> GetCurrentRecord()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.PaymentsServiceChannel == null)
                return null;

            logger.LogWarning($"******Trying to hopefully connect to PaymentService at:({nameHelper.PaymentsServiceChannel.Target})******");


            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaymentsServiceChannel);
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

            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaymentsServiceChannel);
            var reply = await client.NewOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + User.JwtToken);

            return data;
        }
    }
}
