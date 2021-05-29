using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NodeF.Authentication.SimpleAuth.Web.Models;
using NodeF.Authentication.SimpleAuth.Web.Services;

namespace NodeF.Authentication.SimpleAuth.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly UserService userService;

        public HomeController(ILogger<HomeController> logger, UserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        public async Task<IActionResult> Index(LoginViewModel vm)
        {
            vm.ErrorMessage = "";

            if (string.IsNullOrWhiteSpace(vm.LoginName) || string.IsNullOrWhiteSpace(vm.Password))
                return View();

            var token = await userService.AuthenticateUser(vm.LoginName, vm.Password);
            if (string.IsNullOrEmpty(token))
            {
                vm.ErrorMessage = "Your login/password is not correct.";
                return View(vm);
            }

            return RedirectToAction(nameof(Success));
        }

        public IActionResult Success()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
