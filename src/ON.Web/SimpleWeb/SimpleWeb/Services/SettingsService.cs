using ON.Fragments.Settings;
using ON.SimpleWeb.Helper;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.IO.Pipelines;
using ON.Authentication;
using Grpc.Core;

namespace ON.SimpleWeb.Services
{
    public class SettingsService
    {
        private readonly ServiceNameHelper nameHelper;
        private readonly ONUserHelper userHelper;

        private SettingsPublicData publicData = null;
        private SettingsPrivateData privateData = null;
        private SettingsOwnerData ownerData = null;

        public SettingsService(ServiceNameHelper nameHelper, ONUserHelper userHelper)
        {
            this.nameHelper = nameHelper;
            this.userHelper = userHelper;
        }

        public void Flush()
        {
            publicData = null;
            privateData = null;
            ownerData = null;
        }

        public async Task<SettingsPublicData> GetPublicSettings()
        {
            if (publicData != null)
                return publicData;

            var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
            var res = await client.GetPublicDataAsync(new());

            publicData = res.Public;

            return publicData;
        }

        public async Task<SettingsPrivateData> GetPrivateSettings()
        {
            if (privateData != null)
                return privateData;

            var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
            var res = await client.GetAdminDataAsync(new());

            publicData = res.Public;
            privateData = res.Private;

            return privateData;
        }

        public async Task<SettingsOwnerData> GetOwnerSettings()
        {
            if (ownerData != null)
                return ownerData;

            var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
            var res = await client.GetOwnerDataAsync(new());

            publicData = res.Public;
            privateData = res.Private;
            ownerData = res.Owner;

            return ownerData;
        }

        public async Task<CategoryRecord> GetCategoryById(string id)
        {
            var settings = await GetPublicSettings();

            return settings.CMS.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public async Task<CategoryRecord> GetCategoryBySlug(string slug)
        {
            var settings = await GetPublicSettings();

            return settings.CMS.Categories.FirstOrDefault(c => c.UrlStub == slug);
        }

        public async Task<ChannelRecord> GetChannelById(string id)
        {
            var settings = await GetPublicSettings();

            return settings.CMS.Channels.FirstOrDefault(c => c.ChannelId == id);
        }

        public async Task<ChannelRecord> GetChannelBySlug(string slug)
        {
            var settings = await GetPublicSettings();

            return settings.CMS.Channels.FirstOrDefault(c => c.UrlStub == slug);
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + userHelper.MyUser.JwtToken);

            return data;
        }
    }
}
