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

        public CategoryRecord GetCategoryById(string id)
        {
            return settingsClient.PublicData?.CMS?.Categories?.FirstOrDefault(c => c.CategoryId == id);
        }

        public CategoryRecord GetCategoryBySlug(string slug)
        {
            return settingsClient.PublicData?.CMS?.Categories?.FirstOrDefault(c => c.UrlStub == slug);
        }
    }
}
