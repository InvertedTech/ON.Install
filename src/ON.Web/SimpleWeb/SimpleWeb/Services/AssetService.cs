using Grpc.Core;
using ON.Authentication;
using ON.Fragments.Content;
using System.Threading.Tasks;
using System;
using ON.Settings;

namespace ON.SimpleWeb.Services
{
    public class AssetService
    {
        private readonly ServiceNameHelper nameHelper;
        public readonly ONUser User;

        public AssetService(ServiceNameHelper nameHelper, ONUserHelper userHelper)
        {
            User = userHelper.MyUser;

            this.nameHelper = nameHelper;
        }

        public async Task<ImageAssetPublicRecord> GetImage(Guid contentId)
        {
            var req = new GetAssetRequest
            {
                AssetID = contentId.ToString(),
            };

            var client = new AssetInterface.AssetInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetAssetAsync(req, GetMetadata());

            return res?.Image;
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            if (User != null && !string.IsNullOrWhiteSpace(User.JwtToken))
                data.Add("Authorization", "Bearer " + User.JwtToken);

            return data;
        }
    }
}
