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
    [Route("/api/settings/category")]
    [ApiController]
    public class CategoryApiController : Controller
    {
        private readonly ILogger logger;
        private readonly ISettingsDataProvider dataProvider;

        public CategoryApiController(ILogger<CategoryApiController> logger, ISettingsDataProvider dataProvider)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCategoryModel model)
        {
            if (!model.IsValid())
                return NotFound();

            var rec = await dataProvider.Get();

            var cat = model.ToRecord();
            rec.Public.CMS.Categories.Add(cat);

            await dataProvider.Save(rec);

            return Ok(cat);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var rec = await dataProvider.Get();

            var cat = rec.Public.CMS.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (cat == null)
                return NotFound();

            rec.Public.CMS.Categories.Remove(cat);

            await dataProvider.Save(rec);

            return Ok();
        }
    }
}
