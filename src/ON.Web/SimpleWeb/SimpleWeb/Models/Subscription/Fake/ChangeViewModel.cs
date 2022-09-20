using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc.Rendering;
using ON.Authentication;
using ON.Fragments.Authentication;
using ON.Fragments.Authorization;
using ON.Fragments.Content;
using ON.Settings;
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

        public static ChangeViewModel Create(SubscriptionTierHelper subHelper, uint amount)
        {
            var t = subHelper.GetForAmount(amount, true);
            var vm = new ChangeViewModel();
            vm.LoadTiers(subHelper);


            if (t != null)
            {
                vm.Level = (int)amount;
            }
            else
            {
                if (amount == 0)
                {
                    vm.Level = 0;
                }
                else
                {
                    vm.Level = -1;
                    vm.LevelOther = (int)amount;
                }
            }

            return vm;
        }

        public void LoadTiers(SubscriptionTierHelper subHelper)
        {
            Tiers = subHelper.GetAll();
        }

        public SubscriptionTier[] Tiers { get; private set; }


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

                var t = Tiers?.FirstOrDefault(t => t.Amount == (uint)Level);
                if (t == null)
                    return 0;

                return t.Amount;
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

            if (Level == 0)
                return true;

            var t = Tiers.FirstOrDefault(t => t.Amount == (uint)Level);
            if (t == null)
            {
                ErrorMessage = "Subscription amount is not valid";
                return false;
            }

            LevelOther = 0;

            return true;
        }
    }
}
