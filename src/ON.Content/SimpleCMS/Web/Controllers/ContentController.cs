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
using ON.Content.SimpleCMS.Web.Helper;
using ON.Content.SimpleCMS.Web.Models;
using ON.Content.SimpleCMS.Web.Services;

namespace ON.Content.SimpleCMS.Web.Controllers
{
    [Authorize(Roles = ONUser.ROLE_ADMIN + "," + ONUser.ROLE_PUBLISHER + "," + ONUser.ROLE_WRITER)]
    public class ContentController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ContentService contentService;
        private readonly ONUserHelper userHelper;

        public ContentController(ILogger<HomeController> logger, ContentService contentService, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.contentService = contentService;
            this.userHelper = userHelper;
        }

        [AllowAnonymous]
        [HttpGet("/content/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return NotFound();

            var res = await contentService.GetContent(contentId);
            if (res?.Content == null)
                return NotFound();

            return View("View", res.Content);
        }

        [HttpGet("/content/manage")]
        public async Task<IActionResult> Manage()
        {
            return View("Manage", new ManageViewModel((await contentService.GetAll()).Records));
        }

        [HttpGet("/content/new")]
        public IActionResult NewGet()
        {
            return View("New", new NewViewModel(userHelper.MyUser));
        }

        [HttpPost("/content/new")]
        public async Task<IActionResult> NewPost(NewViewModel vm)
        {
            vm.ErrorMessage = vm.SuccessMessage = "";
            if (!ModelState.IsValid)
            {
                vm.ErrorMessage = ModelState.Values.FirstOrDefault(v => v.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                                        ?.Errors?.FirstOrDefault()?.ErrorMessage;
                return View("New", vm);
            }

            var res = await contentService.CreateContent(vm);

            return Redirect("/content/" + res.Content.Public.ContentID);
        }

        [HttpGet("/content/{id}/edit")]
        public async Task<IActionResult> EditGet(string id)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return NotFound();

            var res = await contentService.GetContent(contentId);
            if (res?.Content == null)
                return NotFound();

            EditViewModel vm = new()
            {
                Title = res.Content.Public.Title,
                Subtitle = res.Content.Public.Subtitle,
                Author = res.Content.Public.Author,
                Body = res.Content.Public.Body,
                Level = res.Content.Public.SubscriptionLevel,
            };

            return View("Edit", vm);
        }

        [HttpPost("/content/{id}/edit")]
        public async Task<IActionResult> EditPost(string id, EditViewModel vm)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return NotFound();

            var res = await contentService.GetContent(contentId);
            if (res?.Content == null)
                return NotFound();

            vm.ErrorMessage = vm.SuccessMessage = "";
            if (!ModelState.IsValid)
            {
                vm.ErrorMessage = ModelState.Values.FirstOrDefault(v => v.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                                        ?.Errors?.FirstOrDefault()?.ErrorMessage;
                return View("New", vm);
            }

            var rec = res.Content;
            rec.Public.Title = vm.Title;
            rec.Public.Subtitle = vm.Subtitle;
            rec.Public.Author = vm.Author;
            rec.Public.Body = vm.Body ?? "";
            rec.Public.SubscriptionLevel = vm.Level;

            var res2 = await contentService.UpdateContent(rec);

            return Redirect("/content/" + res2.Content.Public.ContentID);
        }

        [Authorize(Roles = ONUser.ROLE_ADMIN + "," + ONUser.ROLE_PUBLISHER)]
        [HttpGet("/content/{id}/publish")]
        public async Task<IActionResult> Publish(string id)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return NotFound();

            await contentService.PublishContent(contentId);

            return Redirect("/content/manage");
        }

        [Authorize(Roles = ONUser.ROLE_ADMIN + "," + ONUser.ROLE_PUBLISHER)]
        [HttpGet("/content/{id}/unpublish")]
        public async Task<IActionResult> Unpublish(string id)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return NotFound();

            await contentService.UnpublishContent(contentId);

            return Redirect("/content/manage");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
