using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.SimpleWeb.Models.Subscription.Paypal;
using ON.SimpleWeb.Services.Paypal;

namespace ON.SimpleWeb.Controllers
{
    [Authorize]
    [Route("/subscription/paypal")]
    public class SubscriptionPaypalController : Controller
    {
        private readonly ILogger<SubscriptionPaypalController> logger;
        private readonly PaymentsService paymentsService;
        private readonly ONUserHelper userHelper;

        public SubscriptionPaypalController(ILogger<SubscriptionPaypalController> logger, PaymentsService paymentsService, ONUserHelper userHelper)
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

        [HttpGet("new")]
        public async Task<IActionResult> New(string subId)
        {
            if (string.IsNullOrWhiteSpace(subId))
                return Redirect("/settings/refreshtoken?url=/subscription/");

            await paymentsService.NewSubscription(subId);

            return Redirect("/settings/refreshtoken?url=/subscription/");
        }
    }
}
