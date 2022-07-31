using Microsoft.AspNetCore.Mvc.Rendering;
using ON.Authentication;
using ON.Authorization.ParallelEconomy.Web.Services;
using ON.Fragments.Authentication;
using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.ParallelEconomy.Web.Models
{
    public class NewViewModel
    {
        public NewViewModel()
        {
        }

        public NewViewModel(string clientToken, bool isTest)
        {
            ClientToken = clientToken;
            IsTest = isTest;
        }

        public string ClientToken { get; set; }

        public bool IsTest { get; set; }
    }
}
