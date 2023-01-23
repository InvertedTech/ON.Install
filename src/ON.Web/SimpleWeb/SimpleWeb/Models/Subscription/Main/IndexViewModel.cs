using ON.Authentication;
using ON.Fragments.Authentication;
using ON.Fragments.Authorization.Payment;
using ON.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.Subscription.Main
{
    public class IndexViewModel
    {
        private IndexViewModel()
        {
        }

        public static IndexViewModel Create(SubscriptionTierHelper subHelper, GetOwnSubscriptionRecordsResponse res)
        {
            var vm = new IndexViewModel()
            {
                Records = res,
            };

            vm.Subscriptions.AddRange(res.Paypal.Select(r => new SubscriptionViewModel(r)));


            vm.Subscriptions = vm.Subscriptions.OrderByDescending(s => s.Status == SubscriptionStatus.SubscriptionActive ? 1 : 0).OrderByDescending(s => s.StartedOnUTC).ToList();

            return vm;
        }

        public GetOwnSubscriptionRecordsResponse Records { get; set; }

        public List<SubscriptionViewModel> Subscriptions { get; set; } = new();

        public bool HasActiveSubscription
        {
            get
            {
                if ((Records.Fake?.AmountCents ?? 0) > 0)
                    return true;

                if (Records.Paypal.Any(r => r.Subscription.Status == SubscriptionStatus.SubscriptionActive))
                    return true;

                return false;
            }
        }
    }
}
