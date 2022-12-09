using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Settings;
using ON.SimpleWeb.Models.Subscription.Main;
using ON.SimpleWeb.Services;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Controllers
{
    [Authorize]
    [Route("subscription")]
    public class SubscriptionMainController : Controller
    {
        private readonly ILogger<SubscriptionMainController> logger;
        private readonly UserService userService;
        private readonly MainPaymentsService payService;
        private readonly SubscriptionTierHelper subHelper;
        private readonly SettingsClient settingsClient;

        public SubscriptionMainController(ILogger<SubscriptionMainController> logger, UserService userService, MainPaymentsService payService, SubscriptionTierHelper subHelper, SettingsClient settingsClient)
        {
            this.logger = logger;
            this.userService = userService;
            this.payService = payService;
            this.subHelper = subHelper;
            this.settingsClient = settingsClient;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var rec = await payService.GetOwnSubscriptionRecord();
            var v = IndexViewModel.Create(subHelper, rec);

            return View(v);
        }

        [HttpGet("new/{amountCents}")]
        public async Task<IActionResult> New(uint amountCents)
        {
            var v = NewViewModel.Create(amountCents, settingsClient);

            v.Methods = await payService.GetNewDetails(amountCents);

            return View(v);
        }
    }
}
