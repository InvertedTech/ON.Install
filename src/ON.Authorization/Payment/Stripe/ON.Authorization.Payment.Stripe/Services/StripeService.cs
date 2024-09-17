using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Authorization.Payment.Stripe.Clients;
using ON.Authorization.Payment.Stripe.Data;
using ON.Fragments.Authorization.Payment;
using ON.Fragments.Authorization.Payment.Stripe;
using ON.Fragments.Generic;
using ON.Settings;

namespace ON.Authorization.Payment.Stripe.Services
{
    public class StripeService : StripeInterface.StripeInterfaceBase
    {
        private readonly ILogger<StripeService> logger;
        private readonly DataMergeService dataMerger;
        private readonly ISubscriptionRecordProvider subscriptionProvider;
        private readonly IPaymentRecordProvider paymentProvider;
        private readonly StripeClient client;
        private readonly SettingsClient settingsClient;

        public StripeService(ILogger<StripeService> logger, DataMergeService dataMerger, ISubscriptionRecordProvider subscriptionProvider, IPaymentRecordProvider paymentProvider, StripeClient client, SettingsClient settingsClient)
        {
            this.logger = logger;
            this.dataMerger = dataMerger;
            this.subscriptionProvider = subscriptionProvider;
            this.paymentProvider = paymentProvider;
            this.client = client;
            this.settingsClient = settingsClient;
        }

        public override async Task<StripeCheckOwnSubscriptionResponse> StripeCheckOwnSubscription(StripeCheckOwnSubscriptionRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = "No user token specified" };

                var customer = await client.GetCustomerByUserId(userToken.Id);
                if (customer == null)
                    return new() { };

                var stripeSubs = await client.GetSubscriptionsByCustomerId(customer.Id);

                var dbSubs = await subscriptionProvider.GetAllByUserId(userToken.Id);

                foreach (var stripeSub in stripeSubs)
                {
                    var dbSub = dbSubs.FirstOrDefault(s => s.StripeSubscriptionID == stripeSub.Id);
                    if (dbSub == null)
                    {
                        dbSub = new()
                        {
                            UserID = userToken.Id.ToString(),
                            SubscriptionID = Guid.NewGuid().ToString(),
                            StripeSubscriptionID = stripeSub.Id.ToString(),
                            CustomerId = customer.Id,
                            CreatedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(stripeSub.Created),
                            ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                            LastPaidUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(stripeSub.CurrentPeriodStart),
                            PaidThruUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(stripeSub.CurrentPeriodEnd.AddDays(5)),
                            RenewsOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(stripeSub.CurrentPeriodEnd),
                            Status = ConvertStatus(stripeSub.Status),
                            AmountCents = (uint)(stripeSub.Items.FirstOrDefault()?.Plan?.Amount ?? 0),
                        };

                        await subscriptionProvider.Save(dbSub);

                        var dbPayment = new StripePaymentRecord()
                        {
                            UserID = userToken.Id.ToString(),
                            SubscriptionID = dbSub.SubscriptionID,
                            PaymentID = Guid.NewGuid().ToString(),
                            StripePaymentID = stripeSub.LatestInvoiceId,
                            AmountCents = dbSub.AmountCents,
                            Status = dbSub.Status == SubscriptionStatus.SubscriptionActive ? PaymentStatus.PaymentComplete : PaymentStatus.PaymentFailed,
                            CreatedOnUTC = dbSub.CreatedOnUTC,
                            ChangedOnUTC = dbSub.ChangedOnUTC,
                            PaidOnUTC = dbSub.LastPaidUTC,
                            PaidThruUTC = dbSub.PaidThruUTC,
                        };

                        await paymentProvider.Save(dbPayment);
                    }
                }

                //dbSubs = await subscriptionProvider.GetAllByUserId(userToken.Id);
                //foreach (var dbSub in dbSubs)
                //    await EnsureAllPayments(dbSub);


                var ret = new StripeCheckOwnSubscriptionResponse();
                ret.Records.AddRange(await dataMerger.GetAllByUserId(userToken.Id));

                return ret;
            }
            catch
            {
                return new() { Error = "Unknown error" };
            }
        }

        //private async Task EnsureAllPayments(ONUser userToken, StripeSubscriptionRecord dbSub)
        //{
        //    var dbPayments = paymentProvider.GetAllBySubscriptionId(userToken.Id, dbSub.SubscriptionID.ToGuid());
        //    var stripePayments = client.GetPaymentsBySubscriptionId(dbSub.StripeSubscriptionID);
        //}

        private SubscriptionStatus ConvertStatus(string status)
        {
            switch (status)
            {
                case "incomplete":
                case "unpaid":
                    return SubscriptionStatus.SubscriptionPending;
                case "incomplete_expired":
                case "canceled":
                    return SubscriptionStatus.SubscriptionStopped;
                case "active":
                    return SubscriptionStatus.SubscriptionActive;
                case "paused":
                case "past_due":
                default:
                    return SubscriptionStatus.SubscriptionPaused;
            }
        }

        //public override async Task<StripeCancelOwnSubscriptionResponse> StripeCancelOwnSubscription(StripeCancelOwnSubscriptionRequest request, ServerCallContext context)
        //{
        //    try
        //    {
        //        var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
        //        if (userToken == null)
        //            return new () { Error = "No user token specified" };

        //        Guid subscriptionId;
        //        if (!Guid.TryParse(request.SubscriptionId, out subscriptionId))
        //            return new() { Error = "No SubscriptionID specified" };

        //        var record = await subscriptionProvider.GetById(userToken.Id, subscriptionId);
        //        if (record == null)
        //            return new () { Error = "Record not found" };

        //        var sub = await client.GetSubscription(record.StripeSubscriptionID);
        //        if (sub == null)
        //            return new () { Error = "SubscriptionId not valid" };

        //        if (sub.status == "ACTIVE")
        //        {
        //            var canceled = await client.CancelSubscription(record.StripeSubscriptionID, request.Reason ?? "None");
        //            if (!canceled)
        //                return new () { Error = "Unable to cancel subscription" };
        //        }

        //        record.ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
        //        record.CanceledOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
        //        record.RenewsOnUTC = null;
        //        record.Status = Fragments.Authorization.Payment.SubscriptionStatus.SubscriptionStopped;

        //        await subscriptionProvider.Save(record);

        //        return new ()
        //        {
        //            Record = record
        //        };
        //    }
        //    catch
        //    {
        //        return new () { Error = "Unknown error" };
        //    }
        //}

        //public override async Task<StripeGetOwnSubscriptionRecordsResponse> StripeGetOwnSubscriptionRecords(StripeGetOwnSubscriptionRecordsRequest request, ServerCallContext context)
        //{
        //    var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
        //    if (userToken == null)
        //        return new ();

        //    var res = new StripeGetOwnSubscriptionRecordsResponse();
        //    res.Records.AddRange(await dataMerger.GetAllByUserId(userToken.Id));

        //    return res;
        //}

        //public override async Task<StripeNewOwnSubscriptionResponse> StripeNewOwnSubscription(StripeNewOwnSubscriptionRequest request, ServerCallContext context)
        //{
        //    try
        //    {
        //        var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
        //        if (userToken == null)
        //            return new () { Error = "No user token specified" };

        //        if (request?.SubscriptionId == null)
        //            return new () { Error = "SubscriptionId not valid" };

        //        var sub = await client.GetSubscription(request.SubscriptionId);
        //        if (sub == null)
        //            return new () { Error = "SubscriptionId not valid" };

        //        var billing_info = sub.billing_info;
        //        if (billing_info == null)
        //            return new () { Error = "SubscriptionId not valid" };

        //        decimal value = 0;
        //        if (!decimal.TryParse(sub.billing_info?.last_payment?.amount?.value ?? "0", out value))
        //            return new () { Error = "Subscription Value not valid" };

        //        var record = new StripeSubscriptionRecord()
        //        {
        //            UserID = userToken.Id.ToString(),
        //            SubscriptionID = Guid.NewGuid().ToString(),
        //            StripeSubscriptionID = request.StripeSubscriptionId,
        //            AmountCents = (uint)(value * 100),
        //            Status = Fragments.Authorization.Payment.SubscriptionStatus.SubscriptionActive,
        //            CreatedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
        //            LastPaidUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(sub.create_time),
        //            ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
        //            PaidThruUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(billing_info.next_billing_time),
        //            RenewsOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(billing_info.next_billing_time),
        //        };

        //        await subscriptionProvider.Save(record);

        //        var payment = new StripePaymentRecord()
        //        {
        //            UserID = userToken.Id.ToString(),
        //            SubscriptionID = record.SubscriptionID,
        //            PaymentID = Guid.NewGuid().ToString(),
        //            StripePaymentID = sub.id,
        //            AmountCents = (uint)(value * 100),
        //            Status = Fragments.Authorization.Payment.PaymentStatus.PaymentComplete,
        //            CreatedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
        //            PaidOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(sub.create_time),
        //            ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
        //            PaidThruUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(billing_info.next_billing_time),
        //        };

        //        await paymentProvider.Save(payment);

        //        return new ()
        //        {
        //            Record = record
        //        };
        //    }
        //    catch
        //    {
        //        return new () { Error = "Unknown error" };
        //    }
        //}
    }
}
