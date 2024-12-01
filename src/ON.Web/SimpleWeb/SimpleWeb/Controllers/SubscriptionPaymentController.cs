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
    [Route("/payment/stripe")]
    public class SubscriptionPaymentController : Controller
    {
        private readonly ILogger logger;
        private readonly PaymentsService paymentsService;
        private readonly ONUserHelper userHelper;

        public SubscriptionPaymentController(ILogger<SubscriptionPaymentController> logger, PaymentsService paymentsService, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.paymentsService = paymentsService;
            this.userHelper = userHelper;
        }

        [HttpGet("check")]
        public async Task<IActionResult> Check()
        {
            await paymentsService.CheckOneTime();

            return Redirect("/");
        }
    }
}
