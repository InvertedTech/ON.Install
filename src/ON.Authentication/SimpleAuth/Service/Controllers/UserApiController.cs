using Microsoft.AspNetCore.Mvc;
using System;
using ON.Fragments.Generic;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ON.Authentication.SimpleAuth.Service.Data;
using ON.Authentication;

namespace ON.Content.SimpleCMS.Service.Controllers
{
    [AllowAnonymous]
    [Route("/api/auth/user")]
    [ApiController]
    public class UserApiController : Controller
    {
        private readonly ILogger logger;
        private readonly IUserDataProvider dataProvider;

        public UserApiController(ILogger<UserApiController> logger, IUserDataProvider dataProvider)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
        }

        [HttpGet("{userID}/profileimage")]
        public async Task<IActionResult> GetUserProfileImage(string userID)
        {
            if (!Guid.TryParse(userID, out Guid recordId))
                return Redirect("/api/auth/noprofile.png");

            var rec = await dataProvider.GetById(recordId);
            if (rec == null)
                return Redirect("/api/auth/noprofile.png");

            if (rec.Normal.Public.Data.ProfileImagePNG.IsEmpty)
                return Redirect("/api/auth/noprofile.png");

            return File(rec.Normal.Public.Data.ProfileImagePNG.ToByteArray(), "image/png");
        }

        [HttpGet("/api/auth/profileimage")]
        public async Task<IActionResult> GetMyUserProfileImage([FromServices] ONUserHelper userHelper)
        {
            Guid contentId = userHelper.MyUserId;
            if (contentId == Guid.Empty)
                return Redirect("/api/auth/noprofile.png");

            var rec = await dataProvider.GetById(contentId);
            if (rec == null)
                return Redirect("/api/auth/noprofile.png");

            if (rec.Normal.Public.Data.ProfileImagePNG.IsEmpty)
                return Redirect("/api/auth/noprofile.png");

            return File(rec.Normal.Public.Data.ProfileImagePNG.ToByteArray(), "image/png");
        }
    }
}
