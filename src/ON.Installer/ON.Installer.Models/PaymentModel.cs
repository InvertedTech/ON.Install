using System;
using System.Collections.Generic;
using System.Linq;

namespace ON.Installer.Models
{
    public class PaymentModel
    {
        public string StripeApiKey { get; set; } = "";
        public string PayPalApiKey { get; set; } = "";

        public SubscriptionTier[] SubscriptionTiers { get; set; } = new SubscriptionTier[] {
            new SubscriptionTier(0, "None"),
            new SubscriptionTier(5, "Member"),
            new SubscriptionTier(10, "Awesome Member"),
            new SubscriptionTier(20, "Big spender"),
            new SubscriptionTier(50, "The Best!"),
            new SubscriptionTier(100, "Lord of the Manor"),
        };

        public class SubscriptionTier
        {
            public SubscriptionTier(int value, string name)
            {
                Value = value;
                Name = name;
            }

            public string Name { get; set; }
            public int Value { get; set; }
        }
    }
}
