using Grpc.Core;
using ON.Authentication;
using ON.Fragments.Content;
using System.Threading.Tasks;
using System;
using ON.Settings;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using ON.SimpleWeb.Models.Asset;

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

        public async Task<CreateAssetResponse> CreateImage(string title, string caption, IFormFile file)
        {
            using var stream = file.OpenReadStream();
            CreateAssetRequest req = new()
            {
                Image = new()
                {
                    Public = new()
                    {
                        Title = title,
                        Caption = caption,
                        MimeType = file.ContentType,
                        Data = await ByteString.FromStreamAsync(stream)
                    }
                }
            };

            var client = new AssetInterface.AssetInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.CreateAssetAsync(req, GetMetadata());

            return res;
        }

        //public async Task<CreateAssetResponse> EditImage(EditImageViewModel vm)
        //{
        //    using var stream = file.OpenReadStream();
        //    CreateAssetRequest req = new()
        //    {
        //        Image = new()
        //        {
        //            Public = new()
        //            {
        //                Title = title,
        //                Caption = caption,
        //                MimeType = file.ContentType,
        //                Data = await ByteString.FromStreamAsync(stream)
        //            }
        //        }
        //    };

        //    var client = new AssetInterface.AssetInterfaceClient(nameHelper.ContentServiceChannel);
        //    var res = await client.ed(req, GetMetadata());

        //    return res;
        //}

        public async Task<SearchAssetResponse> SearchImages(SearchAssetRequest req)
        {
            var client = new AssetInterface.AssetInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.SearchAssetAsync(req, GetMetadata());

            return res;
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
