using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization
{
    public class SubscriptionTier
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Label { get; set; }

        static SubscriptionTier()
        {
            List = new SubscriptionTier[] {
                new SubscriptionTier(0, "None"),
                new SubscriptionTier(5, "Member"),
                new SubscriptionTier(10, "Awesome Member"),
                new SubscriptionTier(20, "Big spender"),
                new SubscriptionTier(50, "The Best!"),
                new SubscriptionTier(100, "Lord of the Manor"),
                new SubscriptionTier(-1,  "Other"),
            };

            PositiveList = List.Where(c => c.Value > 0).ToArray();

            SelectListItems = new SelectList(List, nameof(Value), nameof(Label));

        }

        public SubscriptionTier(int value, string name)
        {
            Value = value;
            Name = name;
            if (value > 1)
                Label = $"{name} - ${value}";
            else
                Label = name;
        }

        public static SubscriptionTier[] List { get; private set; }

        public static SubscriptionTier[] PositiveList { get; private set; }

        public static SelectList SelectListItems { get; private set; }

        public static SubscriptionTier FromValue(uint val)
        {
            return List.FirstOrDefault(c => c.Value == val);
        }

        public static string GetLabelFromValue(uint val)
        {
            var c = List.FirstOrDefault(c => c.Value == val);
            if (c != null)
                return c.Label;

            c = PositiveList.LastOrDefault(c => c.Value <= val);
            if (c != null)
                return $"{c.Name} - ${val}";

            return $"${val}";
        }
    }
}
