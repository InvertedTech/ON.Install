using Microsoft.AspNetCore.Mvc.Rendering;
using ON.Fragments.Authorization;
using ON.Settings;
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

            LoadTiers().Wait();
        }

        private async Task LoadTiers()
        {
            Tiers = await subHelper.GetAll();

            SelectListItems = new SelectList(Tiers, nameof(SubscriptionTier.Amount), nameof(SubscriptionTier.Label));

            var list = new List<SubscriptionTier>();
            list.Add(new()
            {
                Amount = 0,
                Name = "None",
                Description = "",
                Color = "#000000",
            });
            list.AddRange(Tiers);
            TiersWithNone = list.ToArray();

            SelectListItemsWithNone = new SelectList(TiersWithNone, nameof(SubscriptionTier.Amount), nameof(SubscriptionTier.Label));

            var list2 = list.Select(t => new InnerTier(t)).ToList();
            list2.Add(new InnerTier()
            {
                Amount = -1,
                Label = "Other",
            });
            TiersWithOther = list2.ToArray();

            SelectListItemsWithOther = new SelectList(TiersWithOther, nameof(InnerTier.Amount), nameof(InnerTier.Label));
        }

        public async Task<SubscriptionTier> FromAmount(uint amount)
        {
            return await subHelper.GetForAmount(amount);
        }

        public class InnerTier
        {
            public int Amount { get; set; } = 0;
            public string Label { get; set; } = "";

            public InnerTier() { }

            public InnerTier(SubscriptionTier tier)
            {
                Amount = (int)tier.Amount;
                Label = tier.Label;
            }
        }
    }
}
