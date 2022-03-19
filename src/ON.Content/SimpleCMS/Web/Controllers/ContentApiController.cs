using Microsoft.AspNetCore.Mvc;
using ON.Content.SimpleCMS.Web.Models;
using ON.Content.SimpleCMS.Web.Services;
using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Content.SimpleCMS.Web.Controllers
{
    [Route("api/content")]
    [ApiController]
    public class ContentApiController : ControllerBase
    {
        ContentService service;

        public ContentApiController(ContentService service)
        {
            this.service = service;
        }

        // Get All
        [HttpGet]
        public async Task<IEnumerable<ContentItem>> Get()
        {
            var res = await service.GetAll();

            return res.Records.Select(r => new ContentItem() {
                Id = r.ContentID.ToGuid().ToString(),
                Title = r.Title,
                Subtitle = r.Subtitle,
                Date = r.CreatedOnUTC.ToDateTime(),
                Body = "",
            });
        }

        [HttpGet("{id}")]
        public async Task<ContentItem> Get(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
                return new();

            var r = await service.GetContent(guid);

            return new ContentItem()
            {
                Id = r.Content.Public.ContentID.ToGuid().ToString(),
                Title = r.Content.Public.Title,
                Subtitle = r.Content.Public.Subtitle,
                Date = r.Content.Public.CreatedOnUTC.ToDateTime(),
                Body = r.Content.Public.Body,
            };
        }
    }
}
