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
using ON.SimpleWeb.Services;

namespace ON.SimpleWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ContentService contentService;
        private readonly ONUserHelper userHelper;

        public HomeController(ILogger<HomeController> logger, ContentService contentService, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.contentService = contentService;
            this.userHelper = userHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View("Home", new HomeViewModel((await contentService.GetAll()), userHelper.MyUser));
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            return View("Home", new HomeViewModel((await contentService.Search(query ?? "")), userHelper.MyUser));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
