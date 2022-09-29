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
using ON.Authentication.SimpleAuth.Web.Services;

namespace ON.Authentication.SimpleAuth.Web.Controllers
{
    [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
    [Route("auth/admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> logger;
        private readonly UserService userService;

        public AdminController(ILogger<AdminController> logger, UserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        [HttpGet("")]
        public async Task<IActionResult> ListUsers()
        {
            var v = new ListUsersViewModel
            {
                UserRecords = (await userService.GetUserList()).ToArray(),
            };

            return View(v);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EditUser(string id)
        {
            var userId = Guid.Parse(id);
            var r = await userService.GetOtherUser(userId);

            var v = new EditUserViewModel(r);

            return View(v);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> EditUserPost(string id, EditUserViewModel vm)
        {
            var userId = Guid.Parse(id);

            vm.ErrorMessage = vm.SuccessMessage = "";
            if (!ModelState.IsValid)
            {
                vm.ErrorMessage = ModelState.Values.FirstOrDefault(v => v.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                                        ?.Errors?.FirstOrDefault()?.ErrorMessage;
                return View("EditUser", vm);
            }

            var res = await userService.ModifyOtherUser(userId, vm);
            if (!string.IsNullOrEmpty(res.Error))
            {
                vm.ErrorMessage = res.Error;
                return View("EditUser", vm);
            }

            var user = await userService.GetOtherUser(userId);
            if (user == null)
                return RedirectToAction(nameof(Error));

            vm = new EditUserViewModel(user)
            {
                SuccessMessage = "Settings updated Successfully"
            };

            return View("EditUser", vm);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
