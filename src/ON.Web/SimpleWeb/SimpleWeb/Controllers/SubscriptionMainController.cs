using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.SimpleWeb.Models.Subscription.Main;
using ON.SimpleWeb.Services;

namespace ON.SimpleWeb.Controllers
{
    [Authorize]
    [Route("subscription")]
    public class SubscriptionMainController : Controller
    {
        private readonly ILogger<SubscriptionMainController> logger;
        private readonly UserService userService;

        public SubscriptionMainController(ILogger<SubscriptionMainController> logger, UserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var v = new IndexViewModel(userService.User);

            return View(v);
        }
    }
}
