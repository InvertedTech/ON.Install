using Microsoft.Extensions.Logging;
using ON.Authorization.Payment.Paypal.Clients;
using ON.Authorization.Payment.Paypal.Services;
using ON.Fragments.Authorization.Payment.Paypal;
using ON.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Paypal.Data
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

        public async Task<IEnumerable<PaypalSubscriptionFullRecord>> GetAllByUserId(Guid userId)
        {
            var subs = await subscriptionProvider.GetAllByUserId(userId);
            var payments = await paymentProvider.GetAllByUserId(userId);

            List<PaypalSubscriptionFullRecord> list = new();

            foreach (var sub in subs)
            {
                PaypalSubscriptionFullRecord rec = new()
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
