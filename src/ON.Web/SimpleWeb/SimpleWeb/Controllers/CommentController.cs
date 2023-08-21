﻿using System;
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
    [Authorize]
    [Route("comment")]
    public class CommentController : Controller
    {
        private readonly ILogger logger;
        private readonly ContentService contentService;
        private readonly CommentService commentService;
        private readonly ONUserHelper userHelper;

        public CommentController(ILogger<CommentController> logger, ContentService contentService, CommentService commentService, ONUserHelper userHelper)
        {
            this.logger = logger;
            this.contentService = contentService;
            this.commentService = commentService;
            this.userHelper = userHelper;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddComment(AddCommentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/content/" + vm.ContentID);
            }

            var res = await commentService.CreateComment(vm);

            return Redirect("/content/" + vm.ContentID);
        }

    }
}
