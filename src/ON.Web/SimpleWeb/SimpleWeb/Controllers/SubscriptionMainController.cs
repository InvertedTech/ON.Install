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
        private readonly SubscriptionTierHelper subHelper;

        public SubscriptionMainController(ILogger<SubscriptionMainController> logger, UserService userService, SubscriptionTierHelper subHelper)
        {
            this.logger = logger;
            this.userService = userService;
            this.subHelper = subHelper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var v = await IndexViewModel.Create(subHelper, userService.User);

            return View(v);
        }
    }
}
