using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.SimpleWeb.Models;
using ON.SimpleWeb.Models.Page;
using ON.SimpleWeb.Services;

namespace ON.SimpleWeb.Controllers
{
    [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
    public class PageController : Controller
    {
        private readonly ILogger logger;
        private readonly PageService pageService;
        private readonly StatsService statsService;
        private readonly ONUserHelper userHelper;

        public PageController(ILogger<PageController> logger, PageService pageService, StatsService statsService, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.pageService = pageService;
            this.statsService = statsService;
            this.userHelper = userHelper;
        }

        [AllowAnonymous]
        [HttpGet("/page/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Guid pageId;
            if (!Guid.TryParse(id, out pageId))
                return NotFound();

            var resPage = await pageService.Get(pageId);
            if (resPage == null)
                return NotFound();

            var vm = new ViewViewModel()
            {
                Record = resPage,
            };

            return View("View", vm);
        }

        [HttpGet("/page/manage")]
        public async Task<IActionResult> Manage()
        {
            return View("Manage", new ManageViewModel(await pageService.GetAllAdmin()));
        }

        [HttpGet("/page/new")]
        public IActionResult NewGet()
        {
            return View("New", new NewViewModel(userHelper.MyUser));
        }

        [HttpPost("/page/new")]
        public async Task<IActionResult> NewPost(NewViewModel vm)
        {
            vm.ErrorMessage = vm.SuccessMessage = "";
            if (!ModelState.IsValid)
            {
                vm.ErrorMessage = ModelState.Values.FirstOrDefault(v => v.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                                        ?.Errors?.FirstOrDefault()?.ErrorMessage;
                return View("New", vm);
            }

            var res = await pageService.Create(vm);

            return Redirect("/page/" + res.Public.PageID);
        }

        [HttpGet("/page/{id}/edit")]
        public async Task<IActionResult> EditGet(string id)
        {
            Guid pageId;
            if (!Guid.TryParse(id, out pageId))
                return NotFound();

            var res = await pageService.GetAdmin(pageId);
            if (res == null)
                return NotFound();

            EditViewModel vm = new()
            {
                Title = res.Public.Data.Title,
                Subtitle = res.Public.Data.Description,
                Author = res.Public.Data.Author,
                Body = res.Public.Data.HtmlBody,
                Level = res.Public.Data.SubscriptionLevel,
            };

            return View("Edit", vm);
        }

        [HttpPost("/page/{id}/edit")]
        public async Task<IActionResult> EditPost(string id, EditViewModel vm)
        {
            Guid pageId;
            if (!Guid.TryParse(id, out pageId))
                return NotFound();

            var res = await pageService.GetAdmin(pageId);
            if (res == null)
                return NotFound();

            vm.ErrorMessage = vm.SuccessMessage = "";
            if (!ModelState.IsValid)
            {
                vm.ErrorMessage = ModelState.Values.FirstOrDefault(v => v.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                                        ?.Errors?.FirstOrDefault()?.ErrorMessage;
                return View("Edit", vm);
            }

            var res2 = await pageService.Update(pageId, vm);

            return Redirect("/page/" + res2.Public.PageID);
        }

        [Authorize(Roles = ONUser.ROLE_CAN_PUBLISH)]
        [HttpGet("/page/{id}/publish")]
        public async Task<IActionResult> Publish(string id)
        {
            Guid pageId;
            if (!Guid.TryParse(id, out pageId))
                return RedirectToAction(nameof(Manage));

            await pageService.Publish(pageId);

            return RedirectToAction(nameof(Manage));
        }

        [Authorize(Roles = ONUser.ROLE_CAN_PUBLISH)]
        [HttpGet("/page/{id}/unpublish")]
        public async Task<IActionResult> Unpublish(string id)
        {
            Guid pageId;
            if (!Guid.TryParse(id, out pageId))
                return RedirectToAction(nameof(Manage));

            await pageService.Unpublish(pageId);

            return RedirectToAction(nameof(Manage));
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
