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
using ON.Fragments.Generic;
using ON.SimpleWeb.Models;
using ON.SimpleWeb.Models.Auth.Admin;
using ON.SimpleWeb.Services;

namespace ON.SimpleWeb.Controllers
{
    [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
    [Route("auth/admin")]
    public class AuthAdminController : Controller
    {
        private readonly ILogger<AuthAdminController> logger;
        private readonly UserService userService;

        public AuthAdminController(ILogger<AuthAdminController> logger, UserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        [HttpGet("")]
        public async Task<IActionResult> ListUsers()
        {
            var v = new ListUsersViewModel
            {
                UserRecords = await userService.GetUserList()
            };

            return View(v);
        }

        [HttpGet("{id}/password")]
        public async Task<IActionResult> ChangeOtherPassword(string id)
        {
            var userId = Guid.Parse(id);
            var r = await userService.GetOtherUser(userId);
            if (r == null)
                return RedirectToAction(nameof(ListUsers));

            var vm = new ChangeOtherPasswordViewModel();

            return View(vm);
        }

        [HttpPost("{id}/password")]
        public async Task<IActionResult> ChangeOtherPasswordPost(string id, ChangeOtherPasswordViewModel vm)
        {
            await userService.ChangePasswordOtherUser(id.ToGuid(), vm);

            return RedirectToAction(nameof(EditUser), new { id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EditUser(string id)
        {
            var userId = Guid.Parse(id);
            var r = await userService.GetOtherUser(userId);

            var vm = new EditUserViewModel(r);

            var totps = await userService.GetOtherTotp(userId);
            vm.TotpDevices = totps?.Devices?.ToList() ?? new();

            return View(vm);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> EditUserPost(string id, EditUserViewModel vm)
        {
            var userId = Guid.Parse(id);

            var totps = await userService.GetOtherTotp(userId);
            vm.TotpDevices = totps?.Devices?.ToList() ?? new();

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

        [HttpGet("{id}/totp/{totpid}/disable")]
        public async Task<IActionResult> DisableTotp(string id, string totpid)
        {
            await userService.DisableOtherTotp(id.ToGuid(), totpid.ToGuid());

            return RedirectToAction(nameof(EditUser), new { id });
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
