using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.SimpleWeb.Models.Subscription.Stripe;
using ON.SimpleWeb.Services.Stripe;

namespace ON.SimpleWeb.Controllers
{
    [Authorize]
    [Route("/subscription/stripe")]
    public class SubscriptionStripeController : Controller
    {
        private readonly ILogger logger;
        private readonly PaymentsService paymentsService;
        private readonly ONUserHelper userHelper;

        public SubscriptionStripeController(ILogger<SubscriptionStripeController> logger, PaymentsService paymentsService, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.paymentsService = paymentsService;
            this.userHelper = userHelper;
        }

        [HttpGet("cancel/{id}")]
        public async Task<IActionResult> Cancel(string id, string reason = null)
        {
            if (Guid.TryParse(id, out var subscriptionId))
                await paymentsService.CancelSubscription(subscriptionId, reason ?? "No reason");

            return Redirect("/settings/refreshtoken?url=/subscription/");
        }

        [HttpGet("check")]
        public async Task<IActionResult> Check()
        {
            await paymentsService.Check();

            return Redirect("/settings/refreshtoken?url=/subscription/");
        }
    }
}
