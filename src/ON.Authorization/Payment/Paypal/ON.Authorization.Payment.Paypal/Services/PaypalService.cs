using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Authentication;
using ON.Authorization.Payment.Paypal.Clients;
using ON.Authorization.Payment.Paypal.Clients.Models;
using ON.Authorization.Payment.Paypal.Data;
using ON.Authorization.Payment.Paypal.Models;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Paypal;
using ON.Fragments.Generic;
using ON.Fragments.Settings;
using ON.Settings;
using System;
using System.Threading.Tasks;
using static ON.Authorization.Payment.Paypal.Clients.Models.SubscriptionModel;

namespace ON.Authorization.Payment.Paypal.Services
{
    public class PaypalService : PaypalInterface.PaypalInterfaceBase
    {
        private readonly ILogger<PaypalService> logger;
        private readonly ISubscriptionRecordProvider subscriptionProvider;
        private readonly PaypalClient client;
        private readonly SettingsClient settingsClient;

        public PaypalService(ILogger<PaypalService> logger, ISubscriptionRecordProvider subscriptionProvider, PaypalClient client, SettingsClient settingsClient)
        {
            this.logger = logger;
            this.subscriptionProvider = subscriptionProvider;
            this.client = client;
            this.settingsClient = settingsClient;
        }

        public override async Task<PaypalCancelOwnSubscriptionResponse> PaypalCancelOwnSubscription(PaypalCancelOwnSubscriptionRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new () { Error = "No user token specified" };

                var record = await subscriptionProvider.GetById(userToken.Id);
                if (record == null)
                    return new () { Error = "Record not found" };

                var sub = await client.GetSubscription(record.SubscriptionId);
                if (sub == null)
                    return new () { Error = "SubscriptionId not valid" };

                if (sub.status == "ACTIVE")
                {
                    var canceled = await client.CancelSubscription(record.SubscriptionId, request.Reason ?? "None");
                    if (!canceled)
                        return new () { Error = "Unable to cancel subscription" };
                }

                record.ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.CanceledOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.RenewsOnUTC = null;

                await subscriptionProvider.Save(record);

                return new ()
                {
                    Record = record
                };
            }
            catch
            {
                return new () { Error = "Unknown error" };
            }
        }

        public override async Task<PaypalGetOwnSubscriptionRecordResponse> PaypalGetOwnSubscriptionRecord(PaypalGetOwnSubscriptionRecordRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new ();

            return new ()
            {
                Record = await subscriptionProvider.GetById(userToken.Id)
            };
        }

        public override async Task<PaypalNewOwnSubscriptionResponse> PaypalNewOwnSubscription(PaypalNewOwnSubscriptionRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new () { Error = "No user token specified" };

                if (request?.SubscriptionId == null)
                    return new () { Error = "SubscriptionId not valid" };

                var sub = await client.GetSubscription(request.SubscriptionId);
                if (sub == null)
                    return new () { Error = "SubscriptionId not valid" };

                var billing_info = sub.billing_info;
                if (billing_info == null)
                    return new () { Error = "SubscriptionId not valid" };

                decimal value = 0;
                if (!decimal.TryParse(sub.billing_info?.last_payment?.amount?.value ?? "0", out value))
                    return new () { Error = "Subscription Value not valid" };

                var record = new PaypalSubscriptionRecord()
                {
                    UserID = userToken.Id.ToString(),
                    Level = (uint)(value * 100),
                    ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                    LastPaidUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                    SubscriptionId = request.SubscriptionId,
                    PaidThruUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(billing_info.next_billing_time),
                    RenewsOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(billing_info.next_billing_time),
                };

                await subscriptionProvider.Save(record);

                return new ()
                {
                    Record = record
                };
            }
            catch
            {
                return new () { Error = "Unknown error" };
            }
        }
    }
}
