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
using ON.Settings;
using ON.SimpleWeb.Models.Subscription.Fake;
using ON.SimpleWeb.Services;

namespace ON.SimpleWeb.Controllers
{
    [Authorize]
    [Route("/subscription/fake")]
    public class SubscriptionFakeController : Controller
    {
        private readonly ILogger<SubscriptionMainController> logger;
        private readonly FakePaymentsService paymentsService;
        private readonly ONUserHelper userHelper;
        private readonly SubscriptionTierHelper subHelper;

        public SubscriptionFakeController(ILogger<SubscriptionMainController> logger, FakePaymentsService paymentsService, SubscriptionTierHelper subHelper, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.paymentsService = paymentsService;
            this.subHelper = subHelper;
            this.userHelper = userHelper;
        }

        [HttpGet]
        public async Task<IActionResult> ChangeGet()
        {
            var rec = await paymentsService.GetCurrentRecord();
            var vm = await ChangeViewModel.Create(subHelper, (rec?.Level ?? 0));
            return View("Change", vm);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePost(ChangeViewModel vm)
        {
            await vm.LoadTiers(subHelper);
            if (!vm.Validate())
                return View("Change", vm);

            await paymentsService.ChangeCurrentSubscriptionLevel(vm.LevelCombined);

            return Redirect("/settings/refreshtoken?url=/subscription/");
        }
    }
}
