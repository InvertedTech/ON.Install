using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.SimpleWeb.Models;
using ON.SimpleWeb.Models.Auth;
using ON.SimpleWeb.Models.CMS;
using ON.SimpleWeb.Models.SiteSettings;
using ON.SimpleWeb.Services;

namespace ON.SimpleWeb.Controllers
{
    [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
    [Route("settings/site")]
    public class SiteSettingsController : Controller
    {
        private readonly ILogger logger;
        private readonly SettingsService settings;

        public SiteSettingsController(ILogger<SiteSettingsController> logger, SettingsService settings)
        {
            this.logger = logger;
            this.settings = settings;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vm = await IndexViewModel.Load(settings);

            return View(vm);
        }

        [HttpPost("personalization/public")]
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
                Response.Cookies.Append(JwtExtensions.JWT_COOKIE_NAME, res.BearerToken, new CookieOptions()
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
