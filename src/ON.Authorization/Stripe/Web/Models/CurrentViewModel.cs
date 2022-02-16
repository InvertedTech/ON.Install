using Microsoft.AspNetCore.Mvc.Rendering;
using ON.Authentication;
using ON.Authorization.Stripe.Web.Services;
using ON.Fragments.Authentication;
using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Stripe.Web.Models
{
    public class CurrentViewModel
    {
        public CurrentViewModel()
        {
        }

        public CurrentViewModel(uint level, AccountService acctService, bool isCancelled)
        {
            Level = level;

            switch (Level )
            {
                case 100:
                    Name =  "Lord of the Manor";
                    break;
                case 50:
                    Name = "The Best!";
                    break;
                case 20:
                    Name = "Big Spender";
                    break;
                case 10:
                    Name = "Awesome Member";
                    break;
                case 5:
                    Name = "Member";
                    break;
                default:
                    Name = "No Name";
                    break;
            }
            IsCancelled = isCancelled;
        }

        [Display(Name = "Subscription Amount")]
        [DataType(DataType.Currency)]
        public uint Level { get; set; }

        [Display(Name = "Subscription Name")]
        public string Name { get; set; }

        public bool IsCancelled { get; set; }
    }
}
