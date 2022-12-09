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

        public static IndexViewModel Create(SubscriptionTierHelper subHelper, GetOwnSubscriptionRecordResponse record)
        {
            uint amount = 0;
            var vm = new IndexViewModel();

            if (record?.Fake != null)
            {
                vm.IsSubscribed = true;
                vm.SubscriptionProvider = "fake";
                amount = record.Fake.Level;
            }
            else if (record?.Paypal != null)
            {
                vm.IsSubscribed = true;
                vm.SubscriptionProvider = "paypal";
                amount = record.Paypal.Level;
            }

            var t = subHelper.GetForAmount(amount);
            if (t != null)
            {
                vm.SubscriptionLevelLabel = t.Label;
            }
            else if (amount > 0)
            {
                vm.SubscriptionLevelLabel = $"${amount} - Other";
            }

            return vm;
        }

        public bool IsSubscribed { get; set; } = false;

        public string SubscriptionLevelLabel { get; set; } = "None";
        public string SubscriptionProvider { get; set; }
    }
}
