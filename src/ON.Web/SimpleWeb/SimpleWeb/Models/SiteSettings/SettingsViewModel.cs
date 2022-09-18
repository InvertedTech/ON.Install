using ON.Authentication;
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

        public static async Task<IndexViewModel> Load(SettingsService service, ONUser user)
        {
            if (!user.IsAdminOrHigher)
                return new();

            var vm = new IndexViewModel()
            {
                Private = await service.GetPrivateData(),
                Public = await service.GetPublicData(),
            };

            if (user.IsOwner)
                vm.Owner = await service.GetOwnerData();

            return vm;
        }
    }
}
