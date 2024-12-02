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
using ON.SimpleWeb.Models.CMS;
using ON.SimpleWeb.Models.Comment;
using ON.SimpleWeb.Services;

namespace ON.SimpleWeb.Controllers
{
    [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
    public class ContentController : Controller
    {
        private readonly ILogger logger;
        private readonly ContentService contentService;
        private readonly CommentService commentService;
        private readonly MainPaymentsService paymentsService;
        private readonly StatsService statsService;
        private readonly ONUserHelper userHelper;

        public ContentController(ILogger<ContentController> logger, ContentService contentService, CommentService commentService, StatsService statsService, ONUserHelper userHelper, MainPaymentsService paymentsService)
        {
            this.logger = logger;
            this.contentService = contentService;
            this.commentService = commentService;
            this.statsService = statsService;
            this.userHelper = userHelper;
            this.paymentsService = paymentsService;
        }

        [AllowAnonymous]
        [HttpGet("/content/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return NotFound();

            var resContent = await contentService.GetContent(contentId);
            if (resContent == null)
                return NotFound();

            var resStats = await statsService.GetContentStats(contentId);
            var resComment = await commentService.GetAllForContent(contentId);

            var vm = new ViewContentViewModel()
            {
                Record = resContent,
                Comments = new()
                {
                    Records = resComment.ToList(),
                    NewComment = new()
                    {
                        ContentID = resContent.ContentID,
                    }
                },
                Stats = resStats ?? new(),
            };

            if (resContent.Data.ContentDataOneofCase == Fragments.Content.ContentPublicData.ContentDataOneofOneofCase.Video)
                return View("ViewVideo", vm);
            if (resContent.Data.ContentDataOneofCase == Fragments.Content.ContentPublicData.ContentDataOneofOneofCase.Written)
                return View("ViewWritten", vm);
            return NotFound();
        }

        [HttpGet("/content/manage")]
        public async Task<IActionResult> Manage()
        {
            return View("Manage", new ManageViewModel(await contentService.GetAllAdmin()));
        }

        [HttpGet("/content/video/new")]
        public IActionResult NewVideoGet()
        {
            return View("NewVideo", new NewVideoViewModel(userHelper.MyUser));
        }

        [HttpPost("/content/video/new")]
        public async Task<IActionResult> NewVideoPost(NewVideoViewModel vm)
        {
            vm.ErrorMessage = vm.SuccessMessage = "";
            if (!ModelState.IsValid)
            {
                vm.ErrorMessage = ModelState.Values.FirstOrDefault(v => v.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                                        ?.Errors?.FirstOrDefault()?.ErrorMessage;
                return View("NewVideo", vm);
            }

            var res = await contentService.CreateContent(vm);

            return Redirect("/content/" + res.Public.ContentID);
        }

        [HttpGet("/content/written/new")]
        public IActionResult NewWrittenGet()
        {
            return View("NewWritten", new NewWrittenViewModel(userHelper.MyUser));
        }

        [HttpPost("/content/written/new")]
        public async Task<IActionResult> NewWrittenPost(NewWrittenViewModel vm)
        {
            vm.ErrorMessage = vm.SuccessMessage = "";
            if (!ModelState.IsValid)
            {
                vm.ErrorMessage = ModelState.Values.FirstOrDefault(v => v.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                                        ?.Errors?.FirstOrDefault()?.ErrorMessage;
                return View("NewWritten", vm);
            }

            var res = await contentService.CreateContent(vm);

            return Redirect("/content/" + res.Public.ContentID);
        }

        [HttpGet("/content/{id}/edit")]
        public async Task<IActionResult> EditGet(string id)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return NotFound();

            var res = await contentService.GetContentAdmin(contentId);
            if (res == null)
                return NotFound();

            if (res.Public.Data.ContentDataOneofCase == Fragments.Content.ContentPublicData.ContentDataOneofOneofCase.Video)
                return RedirectToAction(nameof(EditVideoGet), new { id });

            if (res.Public.Data.ContentDataOneofCase == Fragments.Content.ContentPublicData.ContentDataOneofOneofCase.Written)
                return RedirectToAction(nameof(EditWrittenGet), new { id });

            return NotFound();
        }

        [HttpGet("/content/{id}/video/edit")]
        public async Task<IActionResult> EditVideoGet(string id)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return NotFound();

            var res = await contentService.GetContentAdmin(contentId);
            if (res == null)
                return NotFound();

            EditVideoViewModel vm = new()
            {
                Title = res.Public.Data.Title,
                Subtitle = res.Public.Data.Description,
                Author = res.Public.Data.Author,
                RumbleVideoId = res.Public.Data.Video.RumbleVideoId,
                YoutubeVideoId = res.Public.Data.Video.YoutubeVideoId,
                Body = res.Public.Data.Video.HtmlBody,
                Level = res.Public.Data.SubscriptionLevel,
                OneTimeAmountCents = res.Public.Data.OneTimeAmountCents,
            };

            return View("EditVideo", vm);
        }

        [HttpPost("/content/{id}/video/edit")]
        public async Task<IActionResult> EditVideoPost(string id, EditVideoViewModel vm)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return NotFound();

            var res = await contentService.GetContentAdmin(contentId);
            if (res == null)
                return NotFound();

            vm.ErrorMessage = vm.SuccessMessage = "";
            if (!ModelState.IsValid)
            {
                vm.ErrorMessage = ModelState.Values.FirstOrDefault(v => v.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                                        ?.Errors?.FirstOrDefault()?.ErrorMessage;
                return View("EditVideo", vm);
            }

            var res2 = await contentService.UpdateContent(contentId, vm);

            return Redirect("/content/" + res2.Public.ContentID);
        }

        [HttpGet("/content/{id}/written/edit")]
        public async Task<IActionResult> EditWrittenGet(string id)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return NotFound();

            var res = await contentService.GetContentAdmin(contentId);
            if (res == null)
                return NotFound();

            EditWrittenViewModel vm = new()
            {
                Title = res.Public.Data.Title,
                Subtitle = res.Public.Data.Description,
                Author = res.Public.Data.Author,
                Body = res.Public.Data.Written.HtmlBody,
                Level = res.Public.Data.SubscriptionLevel,
                OneTimeAmountCents = res.Public.Data.OneTimeAmountCents,
            };

            return View("EditWritten", vm);
        }

        [HttpPost("/content/{id}/written/edit")]
        public async Task<IActionResult> EditWrittenPost(string id, EditWrittenViewModel vm)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return NotFound();

            var res = await contentService.GetContentAdmin(contentId);
            if (res == null)
                return NotFound();

            vm.ErrorMessage = vm.SuccessMessage = "";
            if (!ModelState.IsValid)
            {
                vm.ErrorMessage = ModelState.Values.FirstOrDefault(v => v.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                                        ?.Errors?.FirstOrDefault()?.ErrorMessage;
                return View("EditWritten", vm);
            }

            var res2 = await contentService.UpdateContent(contentId, vm);

            return Redirect("/content/" + res2.Public.ContentID);
        }

        [AllowAnonymous]
        [HttpGet("/content/{id}/purchase")]
        public async Task<IActionResult> Purchase(string id)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return NotFound();

            var domainName = Request.Host.Host == "localhost" ? "http" : "https";
            domainName += "://" + Request.Host.Host;

            var res = await paymentsService.GetNewOneTimeDetails(contentId, domainName);
            if (res?.Stripe?.PaymentLink != null)
                return Redirect(res.Stripe.PaymentLink);

            return Redirect("/content/" + id.ToString());
        }

        [Authorize(Roles = ONUser.ROLE_CAN_PUBLISH)]
        [HttpGet("/content/{id}/publish")]
        public async Task<IActionResult> Publish(string id)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return Redirect("/content/manage");

            await contentService.PublishContent(contentId);

            return Redirect("/content/manage");
        }

        [Authorize(Roles = ONUser.ROLE_CAN_PUBLISH)]
        [HttpGet("/content/{id}/unpublish")]
        public async Task<IActionResult> Unpublish(string id)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return Redirect("/content/manage");

            await contentService.UnpublishContent(contentId);

            return Redirect("/content/manage");
        }

        [Authorize()]
        [HttpGet("/content/{id}/save")]
        public async Task<IActionResult> Save(string id)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return RedirectToAction(nameof(Get), new { id });

            var resContent = await contentService.GetContent(contentId);
            if (resContent == null)
                return RedirectToAction(nameof(Get), new { id });

            var resSave = await statsService.Save(resContent);

            return RedirectToAction(nameof(Get), new { id });
        }

        [Authorize()]
        [HttpGet("/content/{id}/unsave")]
        public async Task<IActionResult> Unsave(string id)
        {
            Guid contentId;
            if (!Guid.TryParse(id, out contentId))
                return RedirectToAction(nameof(Get), new { id });

            var resContent = await contentService.GetContent(contentId);
            if (resContent == null)
                return RedirectToAction(nameof(Get), new { id });

            var resSave = await statsService.Unsave(resContent);

            return RedirectToAction(nameof(Get), new { id });
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
