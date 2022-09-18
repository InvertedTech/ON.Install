using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.ParallelEconomy;
using ON.Fragments.Authorization.Payments.Paypal;
using ON.Fragments.Authorization.Payments.Stripe;
using ON.Fragments.Settings;
using ON.SimpleWeb.Models;
using ON.SimpleWeb.Models.Auth;
using ON.SimpleWeb.Models.CMS;
using ON.SimpleWeb.Models.SiteSettings;
using ON.SimpleWeb.Services;

namespace ON.SimpleWeb.Controllers
{
    [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
    [Route("settings/site")]
    public class SiteSettingsController : Controller
    {
        private readonly ILogger logger;
        private readonly SettingsService settings;
        private readonly ONUserHelper userHelper;

        public SiteSettingsController(ILogger<SiteSettingsController> logger, SettingsService settings, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.settings = settings;
            this.userHelper = userHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string errorMsg = "", string successMsg = "")
        {
            var vm = await IndexViewModel.Load(settings, userHelper.MyUser);
            vm.ErrorMessage = errorMsg;
            vm.SuccessMessage = successMsg;

            return View(vm);
        }

        [HttpPost("personalization/public")]
        public async Task<IActionResult> ModifyPersonalizationPublic(PersonalizationPublicRecord vm)
        {
            if (vm == null)
                return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });

            var data = await settings.GetPublicData();
            var record = data.Personalization;

            record.Title = vm.Title;
            record.MetaDescription = vm.MetaDescription;
            record.DefaultToDarkMode = vm.DefaultToDarkMode;

            var res = await settings.Modify(record, userHelper.MyUser);

            if (res == ModifyResponseErrorType.NoError)
                return RedirectToAction(nameof(Index), new { successMsg = "Settings updated successfully." });

            return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });
        }

        [HttpPost("subscription/public/tier/add")]
        public async Task<IActionResult> SubscriptionTierAdd(SubscriptionTier vm)
        {
            if (vm == null)
                return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });

            if (!IsValid(vm))
                return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });

            vm.Color = "#000000";

            var data = await settings.GetPublicData();
            var record = data.Subscription;

            var tier = record.Tiers.FirstOrDefault(t => t.Amount == vm.Amount);
            if (tier != null)
                return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });

            record.Tiers.Add(vm);

            var res = await settings.Modify(record, userHelper.MyUser);

            if (res == ModifyResponseErrorType.NoError)
                return RedirectToAction(nameof(Index), new { successMsg = "Settings updated successfully." });

            return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });
        }

        [HttpPost("subscription/public/tier/delete")]
        public async Task<IActionResult> SubscriptionTierDelete(SubscriptionTier vm)
        {
            if (vm == null)
                return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });

            var data = await settings.GetPublicData();
            var record = data.Subscription;

            var tier = record.Tiers.FirstOrDefault(t => t.Amount == vm.Amount);
            if (tier == null)
                return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });
            record.Tiers.Remove(tier);

            var res = await settings.Modify(record, userHelper.MyUser);

            if (res == ModifyResponseErrorType.NoError)
                return RedirectToAction(nameof(Index), new { successMsg = "Settings updated successfully." });

            return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });
        }

        [HttpPost("subscription/owner/paypal")]
        public async Task<IActionResult> ModifySubscriptionOwnerPaypal(PaypalSettings vm)
        {
            if (vm == null)
                return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });

            var data = await settings.GetOwnerData();
            var record = data.Subscription;

            record.Paypal = vm;

            var res = await settings.Modify(record, userHelper.MyUser);

            if (res == ModifyResponseErrorType.NoError)
                return RedirectToAction(nameof(Index), new { successMsg = "Settings updated successfully." });

            return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });
        }

        [HttpPost("subscription/owner/pe")]
        public async Task<IActionResult> ModifySubscriptionOwnerPE(ParallelEconomySettings vm)
        {
            if (vm == null)
                return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });

            var data = await settings.GetOwnerData();
            var record = data.Subscription;

            record.ParallelEconomy = vm;

            var res = await settings.Modify(record, userHelper.MyUser);

            if (res == ModifyResponseErrorType.NoError)
                return RedirectToAction(nameof(Index), new { successMsg = "Settings updated successfully." });

            return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });
        }

        [HttpPost("subscription/owner/stripe")]
        public async Task<IActionResult> ModifySubscriptionOwnerStripe(StripeSettings vm)
        {
            if (vm == null)
                return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });

            var data = await settings.GetOwnerData();
            var record = data.Subscription;

            record.Stripe = vm;

            var res = await settings.Modify(record, userHelper.MyUser);

            if (res == ModifyResponseErrorType.NoError)
                return RedirectToAction(nameof(Index), new { successMsg = "Settings updated successfully." });

            return RedirectToAction(nameof(Index), new { errorMsg = "An error occured!" });
        }

        private bool IsValid(SubscriptionTier vm)
        {
            if (vm.Amount < 1)
                return false;
            if (string.IsNullOrWhiteSpace(vm.Name))
                return false;
            if (string.IsNullOrWhiteSpace(vm.Description))
                return false;

            return true;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
