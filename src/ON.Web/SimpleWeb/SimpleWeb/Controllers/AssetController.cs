using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Fragments.Content;
using ON.SimpleWeb.Models;
using ON.SimpleWeb.Models.Asset;
using ON.SimpleWeb.Models.CMS;
using ON.SimpleWeb.Models.Comment;
using ON.SimpleWeb.Services;

namespace ON.SimpleWeb.Controllers
{
    [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
    public class AssetController : Controller
    {
        private readonly ILogger logger;
        private readonly AssetService assetService;
        private readonly ONUserHelper userHelper;
        private const int ITEMS_PER_PAGE = 20;

        public AssetController(ILogger<AssetController> logger, AssetService assetService, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.assetService = assetService;
            this.userHelper = userHelper;
        }

        [AllowAnonymous]
        [HttpGet("/image/{id}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<IActionResult> Get(string id)
        {
            Guid assetId;
            if (!Guid.TryParse(id, out assetId))
                return NotFound();

            var res = await assetService.GetImage(assetId);
            if (res == null)
                return NotFound();

            return File(res.Data.Data.ToByteArray(), res.Data.MimeType);
        }

        [HttpGet("/image/{id}/detail")]
        public async Task<IActionResult> ImageDetail(string id)
        {
            Guid assetId;
            if (!Guid.TryParse(id, out assetId))
                return NotFound();

            var res = await assetService.GetImage(assetId);
            if (res == null)
                return NotFound();

            return View(new ImageDetailViewModel(res));
        }

        //[HttpGet("/image/{id}/edit")]
        //public async Task<IActionResult> EditImage(EditImageViewModel vm)
        //{
        //    if (Request.Method == "POST")
        //    {
        //        vm.ErrorMessage = vm.SuccessMessage = "";
        //        if (!ModelState.IsValid)
        //        {
        //            vm.ErrorMessage = ModelState.Values.FirstOrDefault(v => v.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
        //                                    ?.Errors?.FirstOrDefault()?.ErrorMessage;
        //            return View(vm);
        //        }

        //        await assetService.EditImage(vm);

        //        return RedirectToAction(nameof(ImageLibrary));
        //    }

        //    Guid assetId;
        //    if (!Guid.TryParse(vm.Id, out assetId))
        //        return NotFound();

        //    var res = await assetService.GetImage(assetId);
        //    if (res == null)
        //        return NotFound();

        //    vm = new(res);

        //    return View(vm);
        //}

        [HttpGet("/image/new")]
        [HttpPost("/image/new")]
        public async Task<IActionResult> NewImage(NewImageViewModel vm)
        {
            if (Request.Method == "POST")
            {
                vm.ErrorMessage = vm.SuccessMessage = "";
                if (!ModelState.IsValid)
                {
                    vm.ErrorMessage = ModelState.Values.FirstOrDefault(v => v.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                                            ?.Errors?.FirstOrDefault()?.ErrorMessage;
                    return View(vm);
                }

                var res = await assetService.CreateImage(vm.Title, vm.Caption, vm.File);

                return RedirectToAction(nameof(ImageLibrary));
            }
            return View(vm);
        }

        [HttpGet("/image/search")]
        [HttpPost("/image/search")]
        public async Task<IActionResult> ImageLibrary(string s, int pageNum = 1)
        {
            var res = await assetService.SearchImages(new()
            {
                AssetType = AssetType.Image,
                PageSize = ITEMS_PER_PAGE,
                PageOffset = (uint)((pageNum - 1) * ITEMS_PER_PAGE),
                Query = s ?? "",
            });

            var model = new ImageSearchViewModel(res)
            {
                PageVM = new(pageNum, ((int)res.PageTotalItems + ITEMS_PER_PAGE - 1) / ITEMS_PER_PAGE, $"/image/search/?s={s}&pageNum="),
            };

            return View("ImageLibrary", model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
