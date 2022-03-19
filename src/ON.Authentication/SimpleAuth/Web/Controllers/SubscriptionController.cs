using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Authentication.SimpleAuth.Web.Models;
using ON.Authentication.SimpleAuth.Web.Models.Admin;
using ON.Authentication.SimpleAuth.Web.Models.Subscription;
using ON.Authentication.SimpleAuth.Web.Services;

namespace ON.Authentication.SimpleAuth.Web.Controllers
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

        [HttpGet("pick")]
        public IActionResult Index()
        {
            var v = new IndexViewModel(userService.User);

            return View(v);
        }
    }
}
