using ON.Fragments.Settings;
using System.Threading.Tasks;
using System.Linq;
using ON.Authentication;
using Grpc.Core;
using System.Timers;
using PubSub;

namespace ON.Settings
{
    public class SettingsClient
    {
        private readonly ServiceNameHelper nameHelper;
        private Timer pollingTimer;

        private SettingsPublicData publicData = null;
        private SettingsPrivateData privateData = null;
        private SettingsOwnerData ownerData = null;

        public uint CurrentSettingsId => publicData?.VersionNum ?? 0;

        public SettingsClient(ServiceNameHelper nameHelper)
        {
            this.nameHelper = nameHelper;

            pollingTimer = new Timer(10000);
            pollingTimer.AutoReset = true;
            pollingTimer.Elapsed += new ElapsedEventHandler(PollingTimer_Elapsed);
            pollingTimer.Start();
        }

        private async void PollingTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
                var res = await client.GetOwnerNewerDataAsync(new() { VersionNum = CurrentSettingsId }, GetMetadata());

                if ((res?.Public?.VersionNum ?? 0) == 0)
                    return;

                publicData = res.Public;
                privateData = res.Private;
                ownerData = res.Owner;

                await Hub.Default.PublishAsync(publicData);
                await Hub.Default.PublishAsync(privateData);
                await Hub.Default.PublishAsync(ownerData);
            }
            catch { }
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

            await Hub.Default.PublishAsync(publicData);
            await Hub.Default.PublishAsync(privateData);
            await Hub.Default.PublishAsync(ownerData);
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + nameHelper.ServiceToken);

            return data;
        }
    }
}
