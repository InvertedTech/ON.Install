using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Fragments.Authorization.Payment.Stripe;
using ON.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<StripeCancelOwnSubscriptionResponse> CancelSubscription(Guid id, string reason)
        {
            if (!IsLoggedIn)
                return null;

            var req = new StripeCancelOwnSubscriptionRequest()
            {
                SubscriptionId = id.ToString(),
                Reason = reason
            };

            var client = new StripeInterface.StripeInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.StripeCancelOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        public async Task<StripeCheckOwnSubscriptionResponse> Check()
        {
            if (!IsLoggedIn)
                return null;

            var req = new StripeCheckOwnSubscriptionRequest()
            {
            };

            var client = new StripeInterface.StripeInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.StripeCheckOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        public async Task<List<StripeSubscriptionRecord>> GetRecords()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.PaymentServiceChannel == null)
                return null;

            logger.LogWarning($"******Trying to hopefully connect to PaymentService at:({nameHelper.PaymentServiceChannel.Target})******");


            var client = new StripeInterface.StripeInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.StripeGetOwnSubscriptionRecordsAsync(new StripeGetOwnSubscriptionRecordsRequest(), GetMetadata());
            return reply.Records.ToList();
        }

        public async Task<StripeNewOwnSubscriptionResponse> NewSubscription(string subscriptionId, int price, string customerId)
        {
            if (!IsLoggedIn)
                return null;
            price /= 100;

            var req = new StripeNewOwnSubscriptionRequest()
            {
                SubscriptionId = subscriptionId,
                SubscriptionPrice = (uint)price,
                CustomerId = customerId,
            };

            var client = new StripeInterface.StripeInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.StripeNewOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        public async Task<StripeCreateBillingPortalResponse> CreatePortal(string customerId)
        {
            if (!IsLoggedIn)
                return null;

            var req = new StripeCreateBillingPortalRequest()
            {
                CustomerId = customerId
            };
            var client = new StripeInterface.StripeInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.StripeCreateBillingPortalAsync(req, GetMetadata());

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

        public async Task<StripeCheckoutSessionResponse> CreateCheckoutSession(string priceId)
        {
            if (!IsLoggedIn)
                return null;

            var req = new StripeCheckoutSessionRequest()
            {
                PriceId = priceId
            };
            var client = new StripeInterface.StripeInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.StripeCreateCheckoutSessionAsync(req, GetMetadata());

            return reply;
        }
    }
}
