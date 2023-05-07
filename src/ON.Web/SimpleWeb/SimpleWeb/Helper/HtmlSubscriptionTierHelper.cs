using Microsoft.AspNetCore.Mvc.Rendering;
using ON.Fragments.Authorization;
using ON.Fragments.Settings;
using ON.Settings;
using PubSub;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Helper
{
    public class HtmlSubscriptionTierHelper
    {
        private readonly SubscriptionTierHelper subHelper;

        public SubscriptionTier[] Tiers { get; private set; }
        public SubscriptionTier[] TiersWithNone { get; private set; }
        public InnerTier[] TiersWithOther { get; private set; }
        public SelectList SelectListItems { get; private set; }
        public SelectList SelectListItemsWithNone { get; private set; }
        public SelectList SelectListItemsWithOther { get; private set; }

        public HtmlSubscriptionTierHelper(SubscriptionTierHelper subHelper)
        {
            this.subHelper = subHelper;

            LoadTiers();

            Hub.Default.Subscribe<SettingsRecord>(r => LoadTiers());
        }

        private void LoadTiers()
        {
            Tiers = subHelper.GetAll();

            SelectListItems = new SelectList(Tiers, nameof(SubscriptionTier.AmountCents), nameof(SubscriptionTier.Label));

            var list = new List<SubscriptionTier>();
            list.Add(new()
            {
                AmountCents = 0,
                Name = "None",
                Description = "",
                Color = "#000000",
            });
            list.AddRange(Tiers);
            TiersWithNone = list.ToArray();

            SelectListItemsWithNone = new SelectList(TiersWithNone, nameof(SubscriptionTier.AmountCents), nameof(SubscriptionTier.Label));

            var list2 = list.Select(t => new InnerTier(t)).ToList();
            list2.Add(new InnerTier()
            {
                Amount = -1,
                Label = "Other",
            });
            TiersWithOther = list2.ToArray();

            SelectListItemsWithOther = new SelectList(TiersWithOther, nameof(InnerTier.Amount), nameof(InnerTier.Label));
        }

        public SubscriptionTier FromAmount(uint amount)
        {
            return subHelper.GetForAmount(amount);
        }

        public class InnerTier
        {
            public int Amount { get; set; } = 0;
            public string Label { get; set; } = "";

            public InnerTier() { }

            public InnerTier(SubscriptionTier tier)
            {
                Amount = (int)tier.AmountCents;
                Label = tier.Label;
            }
        }
    }
}
