using ON.Authentication;
using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.Auth.Subscription
{
    public class IndexViewModel
    {
        public IndexViewModel(ONUser user)
        {
            IsSubscribed = user.SubscriptionLevel > 0;
            SubscriptionLevelLabel = CurrencyLevel.GetLabelFromValue(user.SubscriptionLevel);
            SubscriptionProvider = user.SubscriptionProvider;
        }

        public bool IsSubscribed { get; set; }

        public string SubscriptionLevelLabel { get; set; } = "None";
        public string SubscriptionProvider { get; set; }
    }
}
