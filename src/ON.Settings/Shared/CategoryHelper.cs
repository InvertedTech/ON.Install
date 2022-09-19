using ON.Fragments.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON.Settings
{
    public class CategoryHelper
    {
        private readonly SettingsClient settingsClient;

        public CategoryHelper(SettingsClient settingsClient)
        {
            this.settingsClient = settingsClient;
        }

        public async Task<CategoryRecord> GetCategoryById(string id)
        {
            return (await settingsClient.GetPublicData()).CMS.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public async Task<CategoryRecord> GetCategoryBySlug(string slug)
        {
            return (await settingsClient.GetPublicData()).CMS.Categories.FirstOrDefault(c => c.UrlStub == slug);
        }
    }
}
