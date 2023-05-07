using System;
using System.Collections.Generic;
using System.Linq;

namespace ON.SimpleWeb.Models.Subscription.Main
{
    public class SubscriptionViewModel
    {
        public Guid UserId { get; set; }
        public Guid SubscriptionId { get; set; }
        public string OtherSubscriptionId { get; set; }
        public ON.Fragments.Authorization.Payment.SubscriptionStatus Status { get; set; }
        public uint AmountCents { get; set; }
        public DateTime StartedOnUTC { get; set; }
        public DateTime LastPaymentOnUTC { get; set; }
        public DateTime? NextPaymentOnUTC { get; set; }

        public List<PaymentViewModel> Payments { get; set; }

        public SubscriptionViewModel(ON.Fragments.Authorization.Payment.Paypal.PaypalSubscriptionFullRecord record)
        {
            if (Guid.TryParse(record.Subscription.UserID, out var id))
                UserId = id;
            if (Guid.TryParse(record.Subscription.SubscriptionID, out var id2))
                SubscriptionId = id2;

            OtherSubscriptionId = record.Subscription.PaypalSubscriptionID;
            Status = record.Subscription.Status;
            AmountCents = record.Subscription.AmountCents;

            StartedOnUTC = record.Subscription.CreatedOnUTC.ToDateTime();
            LastPaymentOnUTC = record.Subscription.LastPaidUTC.ToDateTime();
            NextPaymentOnUTC = record.Subscription.RenewsOnUTC?.ToDateTime();

            Payments = record.Payments.Select(p => new PaymentViewModel(p)).ToList();
        }

        public string StatusPretty
        {
            get
            {
                switch (Status)
                {
                    case Fragments.Authorization.Payment.SubscriptionStatus.SubscriptionActive:
                        return "Active";
                    case Fragments.Authorization.Payment.SubscriptionStatus.SubscriptionPending:
                        return "Pending";
                    case Fragments.Authorization.Payment.SubscriptionStatus.SubscriptionPaused:
                        return "Paused";
                    case Fragments.Authorization.Payment.SubscriptionStatus.SubscriptionStopped:
                        return "Stopped";
                    default:
                        return "None";
                }
            }
        }
    }
}
