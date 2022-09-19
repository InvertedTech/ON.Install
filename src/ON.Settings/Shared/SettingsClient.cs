using ON.Fragments.Settings;
using System.Threading.Tasks;
using System.Linq;
using ON.Authentication;
using Grpc.Core;

namespace ON.Settings
{
    public class SettingsClient
    {
        private readonly ServiceNameHelper nameHelper;

        private SettingsPublicData publicData = null;
        private SettingsPrivateData privateData = null;
        private SettingsOwnerData ownerData = null;

        public SettingsClient(ServiceNameHelper nameHelper)
        {
            this.nameHelper = nameHelper;
        }

        public void Flush()
        {
            publicData = null;
            privateData = null;
            ownerData = null;
        }

        public async Task<SettingsOwnerData> GetOwnerData()
        {
            await LoadSettingsIfMissing();
            return ownerData;
        }

        public async Task<SettingsPrivateData> GetPrivateData()
        {
            await LoadSettingsIfMissing();
            return privateData;
        }

        public async Task<SettingsPublicData> GetPublicData()
        {
            await LoadSettingsIfMissing();
            return publicData;
        }

        private async Task LoadSettingsIfMissing()
        {
            if (ownerData != null)
                return;

            var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
            var res = await client.GetOwnerDataAsync(new(), GetMetadata());

            publicData = res.Public;
            privateData = res.Private;
            ownerData = res.Owner;
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + nameHelper.ServiceToken);

            return data;
        }
    }
}
