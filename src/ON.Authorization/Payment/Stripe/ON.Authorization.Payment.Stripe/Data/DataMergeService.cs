using Microsoft.Extensions.Logging;
using ON.Authorization.Payment.Stripe.Clients;
using ON.Authorization.Payment.Stripe.Services;
using ON.Fragments.Authorization.Payment.Stripe;
using ON.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Stripe.Data
{
    public class DataMergeService
    {
        private readonly ILogger<DataMergeService> logger;
        private readonly ISubscriptionRecordProvider subscriptionProvider;
        private readonly IPaymentRecordProvider paymentProvider;

        public DataMergeService(ILogger<DataMergeService> logger, ISubscriptionRecordProvider subscriptionProvider, IPaymentRecordProvider paymentProvider)
        {
            this.logger = logger;
            this.subscriptionProvider = subscriptionProvider;
            this.paymentProvider = paymentProvider;
        }

        public async Task<IEnumerable<StripeSubscriptionFullRecord>> GetAllByUserId(Guid userId)
        {
            var subs = await subscriptionProvider.GetAllByUserId(userId);
            var payments = await paymentProvider.GetAllByUserId(userId);

            List<StripeSubscriptionFullRecord> list = new();

            foreach (var sub in subs)
            {
                StripeSubscriptionFullRecord rec = new()
                {
                    Subscription = sub,
                };

                rec.Payments.AddRange(payments.Where(p => p.SubscriptionID == sub.SubscriptionID).OrderByDescending(p => p.PaidOnUTC));

                list.Add(rec);
            }

            return list;
        }

    }
}
