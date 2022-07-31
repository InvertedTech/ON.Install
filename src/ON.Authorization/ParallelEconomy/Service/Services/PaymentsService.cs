using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Authentication;
using ON.Authorization.ParallelEconomy.Service.Clients;
using ON.Authorization.ParallelEconomy.Service.Clients.Models;
using ON.Authorization.ParallelEconomy.Service.Data;
using ON.Authorization.ParallelEconomy.Service.Models;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.ParallelEconomy;
using ON.Fragments.Generic;
using System;
using System.Threading.Tasks;

namespace ON.Authorization.ParallelEconomy.Service
{
    public class PaymentsService : PaymentsInterface.PaymentsInterfaceBase
    {
        private readonly ILogger<PaymentsService> logger;
        private readonly ISubscriptionRecordProvider subscriptionProvider;
        private readonly ParallelEconomyClient client;
        private readonly AppSettings settings;

        public PaymentsService(ILogger<PaymentsService> logger, ISubscriptionRecordProvider subscriptionProvider, ParallelEconomyClient client, IOptions<AppSettings> settings)
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

                var res = await client.GetSubscription(record.SubscriptionId);
                if (res == null)
                    return new CancelOwnSubscriptionResponse() { Error = "SubscriptionId not valid" };

                if (res.Data.Status == FortisAPI.Standard.Models.StatusEnum.Active)
                {
                    var canceled = await client.CancelSubscription(record.SubscriptionId, request.Reason ?? "None");
                    if (!canceled)
                        return new CancelOwnSubscriptionResponse() { Error = "Unable to cancel subscription" };
                }

                record.ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.CanceledOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.RenewsOnUTC = null;

                await subscriptionProvider.Save(record);

                return new CancelOwnSubscriptionResponse()
                {
                    Record = record
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
            res.IsTest = settings.ParallelEconomyIsTest;
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

                if (request?.TransactionId == null)
                    return new NewOwnSubscriptionResponse() { Error = "TransactionId not valid" };

                var trans = await client.GetTransaction(request.TransactionId);
                if (trans == null)
                    return new NewOwnSubscriptionResponse() { Error = "TransactionId not valid" };

                //decimal value = 0;
                //if (!decimal.TryParse(sub.billing_info?.last_payment?.amount?.value ?? "0", out value))
                //    return new NewOwnSubscriptionResponse() { Error = "Subscription Value not valid" };

                //var record = new SubscriptionRecord()
                //{
                //    UserID = Google.Protobuf.ByteString.CopyFrom(userToken.Id.ToByteArray()),
                //    Level = (uint)value,
                //    ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                //    LastPaidUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                //    SubscriptionId = request.SubscriptionId,
                //    PaidThruUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(sub.billing_info.next_billing_time),
                //    RenewsOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(sub.billing_info.next_billing_time),
                //};

                //await subscriptionProvider.Save(record);

                //return new NewOwnSubscriptionResponse()
                //{
                //    Record = record
                //};
            }
            catch
            {
            }

            return new NewOwnSubscriptionResponse() { Error = "Unknown error" };
        }

        public override async Task<StartNewSubscriptionResponse> StartNewSubscription(StartNewSubscriptionRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new StartNewSubscriptionResponse() { Error = "No user token specified" };

                if ((request?.Level ?? 0) < 1)
                    return new StartNewSubscriptionResponse() { Error = "Level not valid" };

                var intentToken = await client.GetNewPaymentIntent(request.Level);

                return new StartNewSubscriptionResponse()
                {
                    ClientToken = intentToken
                };
            }
            catch
            {
                return new StartNewSubscriptionResponse() { Error = "Unknown error" };
            }
        }
    }
}
