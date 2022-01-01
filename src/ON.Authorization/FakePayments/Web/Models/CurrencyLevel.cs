using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.FakePayments.Web.Models
{
    public class CurrencyLevel
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Label { get; set; }

        static CurrencyLevel()
        {
            List = new CurrencyLevel[] {
                new CurrencyLevel(0, "None"),
                new CurrencyLevel(5, "Member"),
                new CurrencyLevel(10, "Awesome Member"),
                new CurrencyLevel(20, "Big spender"),
                new CurrencyLevel(50, "The Best!"),
                new CurrencyLevel(100, "Lord of the Manor"),
                new CurrencyLevel(-1,  "Other"),
            };

            PositiveList = List.Where(c => c.Value > 0).ToArray();

            SelectListItems = new SelectList(List, nameof(Value), nameof(Label));

        }

        public CurrencyLevel(int value, string name)
        {
            Value = value;
            Name = name;
            if (value > 1)
                Label = $"{name} - ${value}";
            else
                Label = name;
        }

        public static CurrencyLevel[] List { get; private set; }

        public static CurrencyLevel[] PositiveList { get; private set; }

        public static SelectList SelectListItems { get; private set; }

        public static CurrencyLevel FromValue(uint val)
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
