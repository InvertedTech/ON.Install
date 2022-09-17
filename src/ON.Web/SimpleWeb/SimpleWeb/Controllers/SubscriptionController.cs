using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.SimpleWeb.Models.Auth.Subscription;
using ON.SimpleWeb.Services;

namespace ON.SimpleWeb.Controllers
{
    [Authorize]
    [Route("subscription")]
    public class SubscriptionController : Controller
    {
        private readonly ILogger<SubscriptionController> logger;
        private readonly UserService userService;

        public SubscriptionController(ILogger<SubscriptionController> logger, UserService userService)
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
