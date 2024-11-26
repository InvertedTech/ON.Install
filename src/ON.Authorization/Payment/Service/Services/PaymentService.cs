using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment;
using ON.Fragments.Generic;
using FakeD = ON.Authorization.Payment.Fake.Data;
using PaypalD = ON.Authorization.Payment.Paypal.Data;
using StripeD = ON.Authorization.Payment.Stripe.Data;

namespace ON.Authorization.Payment.Service
{
    [Authorize]
    public class PaymentService : PaymentInterface.PaymentInterfaceBase
    {
        private readonly ILogger logger;
        private readonly Paypal.Clients.PaypalClient paypalClient;
        private readonly Stripe.Clients.StripeClient stripeClient;
        private readonly FakeD.ISubscriptionRecordProvider fakeProvider;
        private readonly PaypalD.DataMergeService paypalProvider;
        private readonly StripeD.DataMergeService stripeProvider;

        public PaymentService(
            ILogger<PaymentService> logger,
            Paypal.Clients.PaypalClient paypalClient,
            Stripe.Clients.StripeClient stripeClient,
            FakeD.ISubscriptionRecordProvider fakeProvider,
            PaypalD.DataMergeService paypalProvider,
            StripeD.DataMergeService stripeProvider
        )
        {
            this.logger = logger;
            this.paypalClient = paypalClient;
            this.stripeClient = stripeClient;
            this.fakeProvider = fakeProvider;
            this.paypalProvider = paypalProvider;
            this.stripeProvider = stripeProvider;
        }

        public override async Task<GetNewDetailsResponse> GetNewDetails(
            GetNewDetailsRequest request,
            ServerCallContext context
        )
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new();

            var level = request?.Level ?? 0;
            if (level == 0)
                return new();

            return new()
            {
                //Paypal = await paypalClient.GetNewDetails(level),
                Stripe = await stripeClient.GetNewDetails(level, userToken, request.DomainName),
            };
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER_OR_SERVICE_OR_BOT)]
        public override async Task<GetOtherSubscriptionRecordsResponse> GetOtherSubscriptionRecords(
            GetOtherSubscriptionRecordsRequest request,
            ServerCallContext context
        )
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new();

            var fakeT = fakeProvider.GetById(request.UserID.ToGuid());
            var paypalT = paypalProvider.GetAllByUserId(request.UserID.ToGuid());
            var stripeT = stripeProvider.GetAllByUserId(request.UserID.ToGuid());

            await Task.WhenAll(fakeT, paypalT, stripeT);

            var res = new GetOtherSubscriptionRecordsResponse();

            if (fakeT.Result != null)
                if (fakeT.Result.AmountCents > 0)
                    res.Fake = fakeT.Result;

            if (paypalT.Result != null)
                res.Paypal.AddRange(paypalT.Result);

            if (stripeT.Result != null)
                res.Stripe.AddRange(stripeT.Result);

            return res;
        }

        public override async Task<GetOwnSubscriptionRecordsResponse> GetOwnSubscriptionRecords(
            GetOwnSubscriptionRecordsRequest request,
            ServerCallContext context
        )
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new();

            var fakeT = fakeProvider.GetById(userToken.Id);
            var paypalT = paypalProvider.GetAllByUserId(userToken.Id);
            var stripeT = stripeProvider.GetAllByUserId(userToken.Id);

            await Task.WhenAll(fakeT, paypalT, stripeT);

            var res = new GetOwnSubscriptionRecordsResponse();

            if (fakeT.Result != null)
                if (fakeT.Result.AmountCents > 0)
                    res.Fake = fakeT.Result;

            if (paypalT.Result != null)
                res.Paypal.AddRange(paypalT.Result);

            if (stripeT.Result != null)
                res.Stripe.AddRange(stripeT.Result);

            return res;
        }

        public override async Task<GetNewOneTimeDetailsResponse> GetNewOneTimeDetails(
            GetNewOneTimeDetailsRequest request,
            ServerCallContext context
        )
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new();

            if (string.IsNullOrEmpty(request.InternalId))
            {
                return new();
            }

            var details = await stripeClient.GetNewOneTimeDetails(
                request.InternalId,
                userToken,
                request.DomainName
            );

            return new() { Stripe = details };
        }

        // TODO: Implement
        public override async Task<GetOwnOneTimeRecordsResponse> GetOwnOneTimeRecords(
            GetOwnOneTimeRecordsRequest request,
            ServerCallContext context
        )
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new();

            var res = new GetOwnOneTimeRecordsResponse();

            throw new NotImplementedException();
        }
    }
}
