using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NodeF.Authentication;
using NodeF.Authorization.SimplePayments.Web.Models;
using NodeF.Authorization.SimplePayments.Web.Services;

namespace NodeF.Authorization.SimplePayments.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ILogger<SubscriptionController> logger;
        private readonly PaymentsService paymentsService;

        public SubscriptionController(ILogger<SubscriptionController> logger , PaymentsService paymentsService)
        {
            this.logger = logger;
            this.paymentsService = paymentsService;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            return View("Home", new HomeViewModel());
        }

        [HttpGet("/subscription/change")]
        public async Task<IActionResult> ChangeGet()
        {
            var rec = await paymentsService.GetCurrentRecord();
            return View("Change", new ChangeViewModel((decimal)(rec?.Level ?? 0)));
        }

        [HttpPost("/subscription/change")]
        public async Task<IActionResult> ChangePost(ChangeViewModel vm)
        {
            if (!vm.Validate())
                return View("Change", vm);

            await paymentsService.ChangeCurrentPaymentLevel(vm.LevelCombined);

            return Redirect("/subscription/change");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
