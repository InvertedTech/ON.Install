using ON.Authentication;
using ON.Fragments.Authentication;
using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.SimplePayments.Web.Models
{
    public class HomeViewModel
    {
        public HomeViewModel() { }

        public HomeViewModel(ONUser user)
        {
            SubscriptionLevelLabel = CurrencyLevel.GetLabelFromValue(user.SubscriptionLevel);
        }

        public string SubscriptionLevelLabel { get; set; } = "None";
    }
}
