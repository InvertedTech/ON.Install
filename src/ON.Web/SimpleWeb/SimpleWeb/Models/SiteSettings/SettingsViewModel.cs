using ON.Fragments.Settings;
using ON.SimpleWeb.Services;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.SiteSettings
{
    public class IndexViewModel
    {
        public SettingsPublicData Public { get; set; }
        public SettingsPrivateData Private { get; set; }
        public SettingsOwnerData Owner { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public IndexViewModel() { }

        public static async Task<IndexViewModel> Load(SettingsService service)
        {
            return new()
            {
                Owner = await service.GetOwnerSettings(),
                Private = await service.GetPrivateSettings(),
                Public = await service.GetPublicSettings(),
            };
        }
    }
}
