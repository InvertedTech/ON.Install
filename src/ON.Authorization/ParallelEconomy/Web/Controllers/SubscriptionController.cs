using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FortisAPI.Standard.Controllers;
using FortisAPI.Standard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Authorization.ParallelEconomy.Web.Models;
using ON.Authorization.ParallelEconomy.Web.Services;

namespace ON.Authorization.ParallelEconomy.Web.Controllers
{
    [Authorize]
    [Route("/subscription/paralleleconomy")]
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

        [HttpGet("newintent")]
        public async Task<IActionResult> NewIntent(int level)
        {
            var res = await paymentsService.StartNewSubscription((uint)level);

            return View("New", new NewViewModel(res.ClientToken, acctsService.IsTest));
        }

        [HttpGet("cancel")]
        public async Task<IActionResult> Cancel(string reason = null)
        {
            await paymentsService.CancelSubscription(reason ?? "No reason");

            return RedirectToAction(nameof(OverviewGet));
        }

        [HttpGet("new")]
        public async Task<IActionResult> New(string tranId)
        {
            if (string.IsNullOrWhiteSpace(tranId))
                return RedirectToAction(nameof(OverviewGet));

            await paymentsService.NewSubscription(tranId);

            return Redirect("/settings/refreshtoken?url=/subscription/paralleleconomy");
        }
    }
}
