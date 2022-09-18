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

        private SettingsPublicData publicData = null;
        private SettingsPrivateData privateData = null;
        private SettingsOwnerData ownerData = null;

        public SettingsService(ServiceNameHelper nameHelper)
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

        public async Task<CategoryRecord> GetCategoryById(string id)
        {
            await LoadSettingsIfMissing();

            return publicData.CMS.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public async Task<CategoryRecord> GetCategoryBySlug(string slug)
        {
            await LoadSettingsIfMissing();

            return publicData.CMS.Categories.FirstOrDefault(c => c.UrlStub == slug);
        }

        public async Task<ChannelRecord> GetChannelById(string id)
        {
            await LoadSettingsIfMissing();

            return publicData.CMS.Channels.FirstOrDefault(c => c.ChannelId == id);
        }

        public async Task<ChannelRecord> GetChannelBySlug(string slug)
        {
            await LoadSettingsIfMissing();

            return publicData.CMS.Channels.FirstOrDefault(c => c.UrlStub == slug);
        }

        public async Task<ModifyResponseErrorType> Modify(PersonalizationPublicRecord vm, ONUser user)
        {
            if (vm == null)
                return ModifyResponseErrorType.UnknownError;

            var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
            var res = await client.ModifyPersonalizationPublicDataAsync(new() { Data = vm }, GetMetadata(user));

            Flush();

            return res.Error;
        }

        public async Task<ModifyResponseErrorType> Modify(SubscriptionPublicRecord vm, ONUser user)
        {
            if (vm == null)
                return ModifyResponseErrorType.UnknownError;

            var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
            var res = await client.ModifySubscriptionPublicDataAsync(new() { Data = vm }, GetMetadata(user));

            Flush();

            return res.Error;
        }

        public async Task<ModifyResponseErrorType> Modify(SubscriptionOwnerRecord vm, ONUser user)
        {
            if (vm == null)
                return ModifyResponseErrorType.UnknownError;

            var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
            var res = await client.ModifySubscriptionOwnerDataAsync(new() { Data = vm }, GetMetadata(user));

            Flush();

            return res.Error;
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

        private Metadata GetMetadata(ONUser user)
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + user.JwtToken);

            return data;
        }
    }
}
