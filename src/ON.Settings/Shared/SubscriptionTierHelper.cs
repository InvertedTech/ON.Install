using ON.Authentication;
using ON.Fragments.Authorization;
using ON.Fragments.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON.Settings
{
    public class SubscriptionTierHelper
    {
        private readonly SettingsClient settingsClient;

        public SubscriptionTierHelper(SettingsClient settingsClient)
        {
            this.settingsClient = settingsClient;
        }

        public bool AllowOther()
        {
            return settingsClient.PublicData?.Subscription?.AllowOther ?? false;
        }

        public SubscriptionTier[] GetAll()
        {
            return settingsClient.PublicData?.Subscription?.Tiers?.OrderBy(t => t.Amount)?.ToArray() ?? new SubscriptionTier[0];
        }

        public SubscriptionTier GetForAmount(uint amount, bool strict = false)
        {
            if (amount < 1)
                return null;

            var tiers = GetAll();

            var tier = tiers.FirstOrDefault(c => c.Amount == amount);
            if (tier != null)
                return tier;

            if (strict)
                return null;

            return new()
            {
                Amount = amount,
                Color = "#000000",
                Name = "Other",
                Description = "Other",
            };
        }

        public SubscriptionTier GetForUser(ONUser user)
        {
            if (user == null || user.SubscriptionLevel < 1)
                return null;

            return GetForAmount(user.SubscriptionLevel);
        }
    }
}
