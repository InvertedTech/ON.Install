using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.SimpleWeb.Models.Subscription.PE;
using ON.SimpleWeb.Services.PE;

namespace ON.Authorization.ParallelEconomy.Web.Controllers
{
    [Authorize]
    [Route("/subscription/paralleleconomy")]
    public class SubscriptionPEController : Controller
    {
        private readonly ILogger<SubscriptionPEController> logger;
        private readonly PaymentsService paymentsService;
        private readonly AccountService acctsService;
        private readonly ONUserHelper userHelper;

        public SubscriptionPEController(ILogger<SubscriptionPEController> logger, PaymentsService paymentsService, AccountService acctsService, ONUserHelper userHelper)
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
