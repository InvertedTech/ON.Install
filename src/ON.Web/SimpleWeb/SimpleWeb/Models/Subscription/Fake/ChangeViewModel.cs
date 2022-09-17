using Microsoft.AspNetCore.Mvc.Rendering;
using ON.Authentication;
using ON.Fragments.Authentication;
using ON.Fragments.Content;
using ON.SimpleWeb.Models.Subscription.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.Subscription.Fake
{
    public class ChangeViewModel
    {
        public ChangeViewModel()
        {
        }

        public ChangeViewModel(int level)
        {
            var l = CurrencyLevel.FromValue((uint)level);
            if (l != null)
            {
                Level = level;
            }
            else
            {
                Level = -1;
                LevelOther = level;
            }
        }

        [Display(Name = "Subscription Amount")]
        [DataType(DataType.Currency)]
        public int Level { get; set; }

        [Display(Name = "Other Amount")]
        [DataType(DataType.Currency)]
        public int LevelOther { get; set; }

        public uint LevelCombined
        {
            get
            {
                if (Level == -1)
                {
                    if (LevelOther < 1)
                        return 0;
                    return (uint)LevelOther;
                }

                if (Level < 1)
                    return 0;

                var l = CurrencyLevel.FromValue((uint)Level);
                if (l == null)
                    return 0;

                return (uint)l.Value;
            }
        }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public bool Validate()
        {
            if (Level == -1)
            {
                if (LevelOther < 1)
                {
                    ErrorMessage = "Subscription amount is not valid";
                    return false;
                }
                return true;
            }

            if (Level < 0)
            {
                ErrorMessage = "Subscription amount is not valid";
                return false;
            }

            var l = CurrencyLevel.FromValue((uint)Level);
            if (l == null)
            {
                ErrorMessage = "Subscription amount is not valid";
                return false;
            }

            LevelOther = 0;

            return true;
        }
    }
}
