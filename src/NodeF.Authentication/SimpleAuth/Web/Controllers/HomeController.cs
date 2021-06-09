using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Settings));
        }

        [HttpGet("/Login")]
        public IActionResult LoginGet()
        {
            return View("Index");
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> LoginPost(LoginViewModel vm)
        {
            vm.ErrorMessage = "";

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var token = await userService.AuthenticateUser(vm.LoginName, vm.Password);
            if (string.IsNullOrEmpty(token))
            {
                vm.ErrorMessage = "Your login/password is not correct.";
                return View(vm);
            }

            Response.Cookies.Append(JwtValidatorMiddleware.JWT_COOKIE_NAME, token, new CookieOptions()
            {
                HttpOnly = true
            });
            return RedirectToAction(nameof(Settings));
        }

        [Authorize]
        [HttpGet("/Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(JwtValidatorMiddleware.JWT_COOKIE_NAME);
            return RedirectToAction(nameof(LoginGet));
        }

        [HttpGet("/Register")]
        public IActionResult RegisterGet()
        {
            return View("Register");
        }

        [HttpPost("/Register")]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var res = await userService.CreateUser(vm);

            if (res.Error == Fragments.Authentcation.CreateUserResponse.Types.ErrorType.UserNameTaken)
            {
                vm.ErrorMessage = "The User Name is already taken.";
                return View(vm);
            }

            if (res.Error == Fragments.Authentcation.CreateUserResponse.Types.ErrorType.UnknownError)
            {
                vm.ErrorMessage = "An error occured creating your account.";
                return View(vm);
            }

            Response.Cookies.Append(JwtValidatorMiddleware.JWT_COOKIE_NAME, res.BearerToken, new CookieOptions() {
                HttpOnly = true
            });
            return RedirectToAction(nameof(Settings));
        }

        [Authorize]
        [HttpGet("/Settings")]
        public IActionResult Settings()
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
