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
            return RedirectToAction(nameof(SettingsGet));
        }

        [Authorize]
        [HttpGet("/changepassword")]
        public IActionResult ChangePasswordGet()
        {
            var vm = new ChangePasswordViewModel();

            return View("ChangePassword", vm);
        }

        [Authorize]
        [HttpPost("/changepassword")]
        public async Task<IActionResult> ChangePasswordPost(ChangePasswordViewModel vm)
        {
            vm.ErrorMessage = vm.SuccessMessage = "";
            if (!ModelState.IsValid)
            {
                vm.ErrorMessage = ModelState.Values.FirstOrDefault(v => v.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                                        ?.Errors?.FirstOrDefault()?.ErrorMessage;
                return View("ChangePassword", vm);
            }

            if (vm.OldPassword == vm.NewPassword)
                return View("ChangePassword", new ChangePasswordViewModel { ErrorMessage = "Old password and new password are the same" });

            var error = await userService.ChangePasswordCurrentUser(vm);
            switch (error)
            {
                case Fragments.Authentcation.ChangeOwnPasswordResponse.Types.ErrorType.NoError:
                    return View("ChangePassword", new ChangePasswordViewModel { SuccessMessage = "Settings updated Successfully" });
                case Fragments.Authentcation.ChangeOwnPasswordResponse.Types.ErrorType.BadOldPassword:
                    return View("ChangePassword", new ChangePasswordViewModel { ErrorMessage = "Old password is not correct" });
                case Fragments.Authentcation.ChangeOwnPasswordResponse.Types.ErrorType.BadNewPassword:
                    return View("ChangePassword", new ChangePasswordViewModel { ErrorMessage = "New password is not valid" });
                case Fragments.Authentcation.ChangeOwnPasswordResponse.Types.ErrorType.UnknownError:
                default:
                    return RedirectToAction(nameof(Error));
            }
        }

        [HttpGet("/login")]
        public IActionResult LoginGet()
        {
            return View("Login");
        }

        [HttpPost("/login")]
        public async Task<IActionResult> LoginPost(LoginViewModel vm)
        {
            vm.ErrorMessage = "";

            if (!ModelState.IsValid)
            {
                return View("Login", vm);
            }

            var token = await userService.AuthenticateUser(vm.LoginName, vm.Password);
            if (string.IsNullOrEmpty(token))
            {
                vm.ErrorMessage = "Your login/password is not correct.";
                return View("Login", vm);
            }

            Response.Cookies.Append(JwtValidatorMiddleware.JWT_COOKIE_NAME, token, new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTimeOffset.UtcNow.AddDays(21)
            });
            return RedirectToAction(nameof(SettingsGet));
        }

        [Authorize]
        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(JwtValidatorMiddleware.JWT_COOKIE_NAME);
            return RedirectToAction(nameof(LoginGet));
        }

        [HttpGet("/register")]
        public IActionResult RegisterGet()
        {
            return View("Register");
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.ErrorMessage = ModelState.Values.FirstOrDefault()?.Errors?.FirstOrDefault()?.ErrorMessage;
                return View(vm);
            }

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

            Response.Cookies.Append(JwtValidatorMiddleware.JWT_COOKIE_NAME, res.BearerToken, new CookieOptions()
            {
                HttpOnly = true
            });
            return RedirectToAction(nameof(SettingsGet));
        }

        [Authorize]
        [HttpGet("/settings")]
        public async Task<IActionResult> SettingsGet()
        {
            var user = await userService.GetCurrentUser();
            if (user == null)
                return RedirectToAction(nameof(Error));

            var vm = new SettingsViewModel(user);

            return View("Settings", vm);
        }

        [Authorize]
        [HttpPost("/settings")]
        public async Task<IActionResult> SettingsPost(SettingsViewModel vm)
        {
            vm.ErrorMessage = vm.SuccessMessage = "";
            if (!ModelState.IsValid)
            {
                vm.ErrorMessage = ModelState.Values.FirstOrDefault(v => v.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                                        ?.Errors?.FirstOrDefault()?.ErrorMessage;
                return View("Settings", vm);
            }

            var res = await userService.ModifyCurrentUser(vm);
            if (!string.IsNullOrEmpty(res.Error))
            {
                vm.ErrorMessage = res.Error;
                return View("Settings", vm);
            }

            if (!string.IsNullOrEmpty(res.BearerToken))
            {
                Response.Cookies.Append(JwtValidatorMiddleware.JWT_COOKIE_NAME, res.BearerToken, new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddDays(21)
                });
            }


            var user = await userService.GetCurrentUser();
            if (user == null)
                return RedirectToAction(nameof(Error));

            vm = new SettingsViewModel(user)
            {
                SuccessMessage = "Settings updated Successfully"
            };

            return View("Settings", vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
