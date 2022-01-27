using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Authentication;
using ON.Authorization.Stripe.Service.Clients;
using ON.Authorization.Stripe.Service.Data;
using ON.Authorization.Stripe.Service.Models;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.Stripe;
using ON.Fragments.Generic;
using System;
using System.Threading.Tasks;

namespace ON.Authorization.Stripe.Service
{
    public class PaymentsService : PaymentsInterface.PaymentsInterfaceBase
    {
        private readonly ILogger<PaymentsService> logger;
        private readonly ISubscriptionRecordProvider subscriptionProvider;
        private readonly StripeClient client;
        private readonly AppSettings settings;

        public PaymentsService(ILogger<PaymentsService> logger, ISubscriptionRecordProvider subscriptionProvider, StripeClient client, IOptions<AppSettings> settings)
        {
            this.logger = logger;
            this.subscriptionProvider = subscriptionProvider;
            this.client = client;
            this.settings = settings.Value;
        }

        public override async Task<CancelOwnSubscriptionResponse> CancelOwnSubscription(CancelOwnSubscriptionRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new CancelOwnSubscriptionResponse() { Error = "No user token specified" };

                var record = await subscriptionProvider.GetById(userToken.Id);
                if (record == null)
                    return new CancelOwnSubscriptionResponse() { Error = "Record not found" };

                //
                //
                // process cancel request here
                //
                //

                return new CancelOwnSubscriptionResponse() {
                    //
                    //
                    // return updated record here
                    //
                    //
                };
            }
            catch
            {
                return new CancelOwnSubscriptionResponse() { Error = "Unknown error" };
            }
        }

        public override Task<GetAccountDetailsResponse> GetAccountDetails(GetAccountDetailsRequest request, ServerCallContext context)
        {
            var res = new GetAccountDetailsResponse();
            res.Plans = client.Plans;
            res.ClientId = settings.StripeClientID;
            return Task.FromResult(res);
        }

        public override async Task<GetOwnSubscriptionRecordResponse> GetOwnSubscriptionRecord(GetOwnSubscriptionRecordRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new GetOwnSubscriptionRecordResponse();

            return new GetOwnSubscriptionRecordResponse
            {
                Record = await subscriptionProvider.GetById(userToken.Id)
            };
        }

        public override async Task<NewOwnSubscriptionResponse> NewOwnSubscription(NewOwnSubscriptionRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new NewOwnSubscriptionResponse() { Error = "No user token specified" };

                if (request?.SubscriptionId == null)
                    return new NewOwnSubscriptionResponse() { Error = "SubscriptionId not valid" };

                //
                //
                // process request here
                //
                //

                var record = new SubscriptionRecord()
                {
                    UserID = Google.Protobuf.ByteString.CopyFrom(userToken.Id.ToByteArray()),
                    //
                    //
                    // save results here
                    //
                    //
                };

                await subscriptionProvider.Save(record);

                return new NewOwnSubscriptionResponse()
                {
                    Record = record
                };
            }
            catch
            {
                return new NewOwnSubscriptionResponse() { Error = "Unknown error" };
            }
        }
    }
}
