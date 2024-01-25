using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Fragments.Generic;
using ON.SimpleWeb.Models;
using ON.SimpleWeb.Models.Auth;
using ON.SimpleWeb.Models.CMS;
using ON.SimpleWeb.Services;

namespace ON.SimpleWeb.Controllers
{
    public class StatsController : Controller
    {
        private readonly ILogger<StatsController> logger;
        private readonly ContentService contentService;
        private readonly StatsService statsService;
        private readonly ONUserHelper userHelper;

        public StatsController(ILogger<StatsController> logger, ContentService contentService, StatsService statsService, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.contentService = contentService;
            this.statsService = statsService;
            this.userHelper = userHelper;
        }

        [HttpGet("/saves")]
        public async Task<IActionResult> SavesGet()
        {
            var savesRes = await statsService.GetSaves(contentService);
            if (savesRes == null)
                return RedirectToAction(nameof(Error));

            var vm = new HomeViewModel(savesRes, userHelper.MyUser);

            return View("Saves", vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
