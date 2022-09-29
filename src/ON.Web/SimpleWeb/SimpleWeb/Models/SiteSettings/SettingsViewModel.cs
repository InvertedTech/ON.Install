using ON.Authentication;
using ON.Fragments.Settings;
using ON.Settings;
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

        public static async Task<IndexViewModel> Load(SettingsClient settingsClient, ONUser user)
        {
            if (!user.IsAdminOrHigher)
                return new();

            var vm = new IndexViewModel()
            {
                Private = await settingsClient.GetPrivateData(),
                Public = await settingsClient.GetPublicData(),
            };

            if (user.IsOwner)
                vm.Owner = await settingsClient.GetOwnerData();

            return vm;
        }
    }
}
