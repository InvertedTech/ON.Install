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
using ON.SimpleWeb.Models.Subscriptions.Fake;
using ON.SimpleWeb.Services;

namespace ON.SimpleWeb.Controllers
{
    [Authorize]
    [Route("/subscription/fake")]
    public class SubscriptionFakeController : Controller
    {
        private readonly ILogger<SubscriptionController> logger;
        private readonly FakePaymentsService paymentsService;
        private readonly ONUserHelper userHelper;

        public SubscriptionFakeController(ILogger<SubscriptionController> logger, FakePaymentsService paymentsService, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.paymentsService = paymentsService;
            this.userHelper = userHelper;
        }

        [HttpGet]
        public async Task<IActionResult> ChangeGet()
        {
            var rec = await paymentsService.GetCurrentRecord();
            return View("Change", new ChangeViewModel((int)(rec?.Level ?? 0)));
        }

        [HttpPost]
        public async Task<IActionResult> ChangePost(ChangeViewModel vm)
        {
            if (!vm.Validate())
                return View("Change", vm);

            await paymentsService.ChangeCurrentSubscriptionLevel(vm.LevelCombined);

            return Redirect("/settings/refreshtoken?url=/subscription/");
        }
    }
}
