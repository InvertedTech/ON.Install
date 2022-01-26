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
using ON.Authorization.Paypal.Web.Models;
using ON.Authorization.Paypal.Web.Services;

namespace ON.Authorization.Paypal.Web.Controllers
{
    [Authorize]
    [Route("/subscription/paypal")]
    public class SubscriptionController : Controller
    {
        private readonly ILogger<SubscriptionController> logger;
        private readonly PaymentsService paymentsService;
        private readonly AccountService acctsService;
        private readonly ONUserHelper userHelper;

        public SubscriptionController(ILogger<SubscriptionController> logger, PaymentsService paymentsService, AccountService acctsService, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.paymentsService = paymentsService;
            this.acctsService = acctsService;
            this.userHelper = userHelper;
        }

        [HttpGet("")]
        public async Task<IActionResult> OverviewGet()
        {
            var rec = await paymentsService.GetCurrentRecord();
            if (rec == null)
                return View("Main", null);
            return View("Main", new CurrentViewModel(rec.Level, acctsService, rec.CanceledOnUTC != null));
        }

        [HttpGet("cancel")]
        public async Task<IActionResult> Cancel(string reason = null)
        {
            await paymentsService.CancelSubscription(reason ?? "No reason");

            return RedirectToAction(nameof(OverviewGet));
        }

        [HttpGet("new")]
        public async Task<IActionResult> New(string subId)
        {
            if (string.IsNullOrWhiteSpace(subId))
                return RedirectToAction(nameof(OverviewGet));

            await paymentsService.NewSubscription(subId);

            return Redirect("/settings/refreshtoken?url=/subscription/paypal");
        }
    }
}
