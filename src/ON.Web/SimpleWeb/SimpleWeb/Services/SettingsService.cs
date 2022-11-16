using ON.Fragments.Settings;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.IO.Pipelines;
using ON.Authentication;
using Grpc.Core;
using ON.Settings;

namespace ON.SimpleWeb.Services
{
    public class SettingsService
    {
        private readonly ServiceNameHelper nameHelper;
        private readonly SettingsClient settingsClient;

        public SettingsService(ServiceNameHelper nameHelper, SettingsClient settingsClient)
        {
            this.nameHelper = nameHelper;
            this.settingsClient = settingsClient;
        }

        public async Task<ModifyResponseErrorType> Modify(CMSPublicRecord vm, ONUser user)
        {
            if (vm == null)
                return ModifyResponseErrorType.UnknownError;

            var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
            var res = await client.ModifyCMSPublicDataAsync(new() { Data = vm }, GetMetadata(user));

            return res.Error;
        }

        public async Task<ModifyResponseErrorType> Modify(PersonalizationPublicRecord vm, ONUser user)
        {
            if (vm == null)
                return ModifyResponseErrorType.UnknownError;

            var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
            var res = await client.ModifyPersonalizationPublicDataAsync(new() { Data = vm }, GetMetadata(user));

            return res.Error;
        }

        public async Task<ModifyResponseErrorType> Modify(SubscriptionPublicRecord vm, ONUser user)
        {
            if (vm == null)
                return ModifyResponseErrorType.UnknownError;

            var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
            var res = await client.ModifySubscriptionPublicDataAsync(new() { Data = vm }, GetMetadata(user));

            return res.Error;
        }

        public async Task<ModifyResponseErrorType> Modify(SubscriptionOwnerRecord vm, ONUser user)
        {
            if (vm == null)
                return ModifyResponseErrorType.UnknownError;

            var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
            var res = await client.ModifySubscriptionOwnerDataAsync(new() { Data = vm }, GetMetadata(user));

            return res.Error;
        }

        private Metadata GetMetadata(ONUser user)
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + user.JwtToken);

            return data;
        }
    }
}
