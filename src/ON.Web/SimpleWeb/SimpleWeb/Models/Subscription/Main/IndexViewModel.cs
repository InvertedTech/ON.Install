using ON.Authentication;
using ON.Fragments.Authentication;
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

        public static async Task<IndexViewModel> Create(SubscriptionTierHelper subHelper, ONUser user)
        {
            var vm = new IndexViewModel()
            {
                IsSubscribed = user.SubscriptionLevel > 0,
                SubscriptionProvider = user.SubscriptionProvider,
            };

            var t = (await subHelper.GetForUser(user));
            if (t != null)
            {
                vm.SubscriptionLevelLabel = t.Label;
            }
            else if (user.SubscriptionLevel > 0)
            {
                vm.SubscriptionLevelLabel = $"${user.SubscriptionLevel} - Other";
            }

            return vm;
        }

        public bool IsSubscribed { get; set; }

        public string SubscriptionLevelLabel { get; set; } = "None";
        public string SubscriptionProvider { get; set; }
    }
}
