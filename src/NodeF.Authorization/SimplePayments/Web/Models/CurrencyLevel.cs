using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authorization.SimplePayments.Web.Models
{
    public class CurrencyLevel
    {
        public string Label { get; set; }
        public decimal Value { get; set; }

        static CurrencyLevel()
        {
            List = new CurrencyLevel[] {
                new CurrencyLevel() {Value = 0, Label = "None"},
                new CurrencyLevel() {Value = 5, Label = "Member"},
                new CurrencyLevel() {Value = 10, Label = "Awesome Member"},
                new CurrencyLevel() {Value = 20, Label = "Big spender"},
                new CurrencyLevel() {Value = 50, Label = "The Best!"},
                new CurrencyLevel() {Value = 100, Label = "Lord of the Manor"},
                new CurrencyLevel() {Value = -1, Label = "Other"},
            };

            SelectListItems = new SelectList(List, nameof(Value), nameof(Label));

        }

        public static CurrencyLevel[] List { get; private set; }

        public static SelectList SelectListItems { get; private set; }

        public static CurrencyLevel FromValue(decimal val)
        {
            return List.FirstOrDefault(c => c.Value == val);
        }
    }
}
