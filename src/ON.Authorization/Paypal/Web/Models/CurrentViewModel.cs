using Microsoft.AspNetCore.Mvc.Rendering;
using ON.Authentication;
using ON.Authorization.Paypal.Web.Services;
using ON.Fragments.Authentication;
using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Paypal.Web.Models
{
    public class CurrentViewModel
    {
        public CurrentViewModel()
        {
        }

        public CurrentViewModel(uint level, AccountService acctService, bool isCancelled)
        {
            Level = level;
            Name = acctService.Plans.OrderBy(t => t.Value).FirstOrDefault(t => t.Value >= level)?.Name ?? "";
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
