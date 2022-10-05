using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Authentication;
using ON.Authorization.Paypal.Service.Clients;
using ON.Authorization.Paypal.Service.Clients.Models;
using ON.Authorization.Paypal.Service.Data;
using ON.Authorization.Paypal.Service.Models;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.Paypal;
using ON.Fragments.Generic;
using ON.Fragments.Settings;
using ON.Settings;
using System;
using System.Threading.Tasks;

namespace ON.Authorization.Paypal.Service
{
    public class PaymentsService : PaymentsInterface.PaymentsInterfaceBase
    {
        private readonly ILogger<PaymentsService> logger;
        private readonly ISubscriptionRecordProvider subscriptionProvider;
        private readonly PaypalClient client;
        private readonly SettingsClient settingsClient;

        public PaymentsService(ILogger<PaymentsService> logger, ISubscriptionRecordProvider subscriptionProvider, PaypalClient client, SettingsClient settingsClient)
        {
            this.logger = logger;
            this.subscriptionProvider = subscriptionProvider;
            this.client = client;
            this.settingsClient = settingsClient;
        }

        public override async Task<CancelOwnSubscriptionResponse> CancelOwnSubscription(CancelOwnSubscriptionRequest request, ServerCallContext context)
        {
            if (await ServiceOpsService.ServiceStatus(settingsClient) != ServiceStatusResponse.Types.OnlineStatus.Online)
                return new() { Error = "Service Offline." };

            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new CancelOwnSubscriptionResponse() { Error = "No user token specified" };

                var record = await subscriptionProvider.GetById(userToken.Id);
                if (record == null)
                    return new CancelOwnSubscriptionResponse() { Error = "Record not found" };

                SubscriptionModel sub = await client.GetSubscription(record.SubscriptionId);
                if (sub == null)
                    return new CancelOwnSubscriptionResponse() { Error = "SubscriptionId not valid" };

                if (sub.status == "ACTIVE")
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

        public override async Task<GetAccountDetailsResponse> GetAccountDetails(GetAccountDetailsRequest request, ServerCallContext context)
        {
            if (await ServiceOpsService.ServiceStatus(settingsClient) != ServiceStatusResponse.Types.OnlineStatus.Online)
                return new();

            var res = new GetAccountDetailsResponse();
            res.Plans = client.Plans;
            res.ClientId = (await settingsClient.GetOwnerData()).Subscription.Paypal.ClientID;
            return res;
        }

        public override async Task<GetOwnSubscriptionRecordResponse> GetOwnSubscriptionRecord(GetOwnSubscriptionRecordRequest request, ServerCallContext context)
        {
            if (await ServiceOpsService.ServiceStatus(settingsClient) != ServiceStatusResponse.Types.OnlineStatus.Online)
                return new();

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
            if (await ServiceOpsService.ServiceStatus(settingsClient) != ServiceStatusResponse.Types.OnlineStatus.Online)
                return new() { Error = "Service Offline." };

            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new NewOwnSubscriptionResponse() { Error = "No user token specified" };

                if (request?.SubscriptionId == null)
                    return new NewOwnSubscriptionResponse() { Error = "SubscriptionId not valid" };

                SubscriptionModel sub = await client.GetSubscription(request.SubscriptionId);
                if (sub == null)
                    return new NewOwnSubscriptionResponse() { Error = "SubscriptionId not valid" };

                decimal value = 0;
                if (!decimal.TryParse(sub.billing_info?.last_payment?.amount?.value ?? "0", out value))
                    return new NewOwnSubscriptionResponse() { Error = "Subscription Value not valid" };

                var record = new SubscriptionRecord()
                {
                    UserID = Google.Protobuf.ByteString.CopyFrom(userToken.Id.ToByteArray()),
                    Level = (uint)value,
                    ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                    LastPaidUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                    SubscriptionId = request.SubscriptionId,
                    PaidThruUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(sub.billing_info.next_billing_time),
                    RenewsOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(sub.billing_info.next_billing_time),
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
