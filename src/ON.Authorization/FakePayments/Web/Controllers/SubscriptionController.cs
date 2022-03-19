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
using ON.Authorization.FakePayments.Web.Models;
using ON.Authorization.FakePayments.Web.Services;

namespace ON.Authorization.FakePayments.Web.Controllers
{
    [Authorize]
    [Route("/subscription/fake")]
    public class SubscriptionController : Controller
    {
        private readonly ILogger<SubscriptionController> logger;
        private readonly PaymentsService paymentsService;
        private readonly ONUserHelper userHelper;

        public SubscriptionController(ILogger<SubscriptionController> logger, PaymentsService paymentsService, ONUserHelper userHelper)
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

            return Redirect("/settings/refreshtoken?url=/subscription/pick");
        }
    }
}
