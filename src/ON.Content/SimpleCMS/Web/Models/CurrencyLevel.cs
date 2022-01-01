using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace ON.Content.SimpleCMS.Web.Models
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
            };

            PositiveList = List.Where(c => c.Value > 0).ToArray();

            SelectListItems = new SelectList(List, nameof(Value), nameof(Label));

        }

        public CurrencyLevel(int value, string name)
        {
            Value = value;
            Name = name;
            Label = $"{name} - ${value}";
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
