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

        [HttpGet("new")]
        public async Task<IActionResult> New(uint level)
        {
            if (level > 0)
                await paymentsService.ChangeCurrentSubscriptionLevel(level);

            return Redirect("/settings/refreshtoken?url=/subscription/");
        }

        [HttpGet("cancel")]
        public async Task<IActionResult> Cancel(string reason = null)
        {
            await paymentsService.CancelSubscription(reason ?? "No reason");

            return Redirect("/settings/refreshtoken?url=/subscription/");
        }
    }
}
