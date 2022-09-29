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

        public async Task<bool> AllowOther()
        {
            return (await settingsClient.GetPublicData()).Subscription.AllowOther;
        }

        public async Task<SubscriptionTier[]> GetAll()
        {
            return (await settingsClient.GetPublicData()).Subscription.Tiers.OrderBy(t => t.Amount).ToArray();
        }

        public async Task<SubscriptionTier> GetForAmount(uint amount, bool strict = false)
        {
            if (amount < 1)
                return null;

            var tiers = await GetAll();

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

        public async Task<SubscriptionTier> GetForUser(ONUser user)
        {
            if (user == null || user.SubscriptionLevel < 1)
                return null;

            return await GetForAmount(user.SubscriptionLevel);
        }
    }
}
