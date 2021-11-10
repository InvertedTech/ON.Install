using Microsoft.AspNetCore.Mvc.Rendering;
using NodeF.Authentication;
using NodeF.Fragments.Authentcation;
using NodeF.Fragments.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authorization.SimplePayments.Web.Models
{
    public class ChangeViewModel
    {
        public ChangeViewModel()
        {
        }

        public ChangeViewModel(decimal level)
        {
            var l = CurrencyLevel.FromValue(level);
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
        public decimal Level { get; set; }

        [Display(Name = "Other Amount")]
        [DataType(DataType.Currency)]
        public decimal LevelOther { get; set; }

        public decimal LevelCombined
        {
            get
            {
                if (Level == -1)
                {
                    if (LevelOther < 1)
                        return 0;
                    return LevelOther;
                }

                if (Level < 1)
                    return 0;

                var l = CurrencyLevel.FromValue(Level);
                if (l == null)
                    return 0;

                return l.Value;
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

            if (Level < 1)
            {
                ErrorMessage = "Subscription amount is not valid";
                return false;
            }

            var l = CurrencyLevel.FromValue(Level);
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
