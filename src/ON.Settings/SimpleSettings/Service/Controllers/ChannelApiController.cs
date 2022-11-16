using Microsoft.AspNetCore.Mvc;
using System;
using ON.Fragments.Generic;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ON.Authentication;
using ON.Settings.SimpleSettings.Service.Data;
using ON.Settings.SimpleSettings.Service.Models;
using System.Linq;

namespace ON.Settings.SimpleSettings.Service.Controllers
{
    [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
    [Route("/api/settings/channel")]
    [ApiController]
    public class ChannelApiController : Controller
    {
        private readonly ILogger logger;
        private readonly ISettingsDataProvider dataProvider;

        public ChannelApiController(ILogger<ChannelApiController> logger, ISettingsDataProvider dataProvider)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateChannelModel model)
        {
            if (!model.IsValid())
                return NotFound();

            var rec = await dataProvider.Get();

            var chan = model.ToRecord();
            rec.Public.CMS.Channels.Add(chan);

            await dataProvider.Save(rec);

            return Ok(chan);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var rec = await dataProvider.Get();

            var chan = rec.Public.CMS.Channels.FirstOrDefault(c => c.ChannelId == id);
            if (chan == null)
                return NotFound();

            rec.Public.CMS.Channels.Remove(chan);

            await dataProvider.Save(rec);

            return Ok();
        }
    }
}
