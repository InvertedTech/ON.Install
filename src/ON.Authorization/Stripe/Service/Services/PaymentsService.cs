using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Authentication;
using ON.Authorization.Stripe.Service.Clients;
using ON.Authorization.Stripe.Service.Data;
using ON.Authorization.Stripe.Service.Models;
using ON.Authorization.Stripe.Service.Services;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.Stripe;
using ON.Fragments.Generic;
using Stripe;
using System;
using System.Threading.Tasks;

// TODO: Handle ALL stripe calls here
namespace ON.Authorization.Stripe.Service
{
    public class PaymentsService : PaymentsInterface.PaymentsInterfaceBase
    {
        private readonly ILogger<PaymentsService> logger;
        private readonly ISubscriptionRecordProvider subscriptionProvider;
        private readonly Clients.StripeClient client;
        private readonly AppSettings settings;
        private ONStripeService stripeService;

        public PaymentsService(ILogger<PaymentsService> logger, ISubscriptionRecordProvider subscriptionProvider, Clients.StripeClient client, IOptions<AppSettings> settings)
        {
            this.logger = logger;
            this.subscriptionProvider = subscriptionProvider;
            this.client = client;
            this.settings = settings.Value;
            this.stripeService = new ONStripeService(settings);
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

                record.ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.CanceledOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.RenewsOnUTC = null;

                await subscriptionProvider.Save(record);

                return new CancelOwnSubscriptionResponse() {
                    Record = record,
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
            res.Products = client.Products;
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

                // TODO: Set values from the sub
                var record = new SubscriptionRecord()
                {
                    UserID = Google.Protobuf.ByteString.CopyFrom(userToken.Id.ToByteArray()),
                    Level = request.SubscriptionPrice,
                    ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                    LastPaidUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                    SubscriptionId = request?.SubscriptionId,
                    PaidThruUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                    RenewsOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                    CustomerId = request?.CustomerId,
                };

                logger.LogWarning($"***SUBID: {record}");

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

        public override async Task<CreateBillingPortalResponse> CreateBillingPortal(CreateBillingPortalRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new CreateBillingPortalResponse() { Error = "No user token specified" };

            if (request?.CustomerId == null)
            {
                return new CreateBillingPortalResponse() { Error = "Invalid Customer Id" };
            }

            var portalUrl = await stripeService.CreateBillingPortal(request.CustomerId);

            if (portalUrl == null)
            {
                return new CreateBillingPortalResponse() { Error = "Error creating portal" };
            }

            return new CreateBillingPortalResponse()
            {
                Url = portalUrl,
            };
        }

        public override async Task<CheckoutSessionResponse> CreateCheckoutSession(CheckoutSessionRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new CheckoutSessionResponse() { Error = "No user token specified" };

            if (request?.PriceId == null)
            {
                return new CheckoutSessionResponse() { Error = "Invalid Price Id" };
            }

            var url = await stripeService.CreateCheckoutSession(request.PriceId);
            logger.LogWarning($"### URL: {url}");
            if (url == null)
            {
                return new CheckoutSessionResponse() { Error = "No URL Found" };
            }

            return new CheckoutSessionResponse()
            {
                SessionUrl = url,
            };
        }
    }
}
