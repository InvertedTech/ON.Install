using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Api;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Content.SimpleCMS.Service.Data;
using ON.Fragments.Content;
using ON.Fragments.Generic;

namespace ON.Content.SimpleCMS.Service
{
    [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
    public class AssetService : AssetInterface.AssetInterfaceBase
    {
        private readonly ILogger logger;
        private readonly IAssetDataProvider dataProvider;

        public AssetService(ILogger<AssetService> logger, IAssetDataProvider dataProvider)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
        }

        [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
        public override async Task<CreateAssetResponse> CreateAsset(CreateAssetRequest request, ServerCallContext context)
        {
            if (!IsValid(request))
                return new();

            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new();

            AssetRecord record = new();

            switch (request.CreateAssetRequestOneofCase)
            {
                case CreateAssetRequest.CreateAssetRequestOneofOneofCase.Audio:
                    break;
                case CreateAssetRequest.CreateAssetRequestOneofOneofCase.Image:
                    return await CreateImage(request.Image, user);
                default:
                    return new();
            }

            return new() {  };
        }

        private async Task<CreateAssetResponse> CreateImage(ImageAssetData image, ONUser user)
        {
            AssetRecord record = new()
            {
                Image = new()
                {
                    Public = new()
                    {
                        AssetID = Guid.NewGuid().ToString(),
                        CreatedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
                        Data = image.Public
                    },
                    Private = new()
                    {
                        CreatedBy = user.Id.ToString(),
                        Data = image.Private
                    }
                }
            };

            await dataProvider.Save(record);

            return new()
            {
                Record = new()
                {
                    Image = record.Image,
                }
            };
        }

        [AllowAnonymous]
        public override async Task<GetAssetResponse> GetAsset(GetAssetRequest request, ServerCallContext context)
        {
            Guid contentId = request.AssetID.ToGuid();
            if (contentId == Guid.Empty)
                return new();

            var rec = await dataProvider.GetById(contentId);
            if (rec == null)
                return new();

            switch (rec.AssetRecordOneofCase)
            {
                case AssetRecord.AssetRecordOneofOneofCase.Audio:
                    return new() { Audio = rec.Audio.Public };
                case AssetRecord.AssetRecordOneofOneofCase.Image:
                    return new() { Image = rec.Image.Public };
                default:
                    return new();
            }
        }

        [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
        public override async Task<GetAssetAdminResponse> GetAssetAdmin(GetAssetAdminRequest request, ServerCallContext context)
        {
            Guid contentId = request.AssetID.ToGuid();
            if (contentId == Guid.Empty)
                return new();

            var rec = await dataProvider.GetById(contentId);
            if (rec == null)
                return new();

            return new() { Record = rec };
        }

        public async override Task<GetAssetByOldContentIDResponse> GetAssetByOldContentID(GetAssetByOldContentIDRequest request, ServerCallContext context)
        {
            var oldId = request.OldAssetID;
            if (oldId == "")
                return new();

            var rec = await dataProvider.GetByOldAssetId(oldId);
            if (rec == null)
                return new();

            return new() { Record = rec };
        }

        public async override Task GetListOfOldContentIDs(GetListOfOldContentIDsRequest request, IServerStreamWriter<GetListOfOldContentIDsResponse> responseStream, ServerCallContext context)
        {
            try
            {
                await foreach (var r in dataProvider.GetAll())
                {
                    switch (r.AssetRecordOneofCase)
                    {
                        case AssetRecord.AssetRecordOneofOneofCase.Audio:
                            await responseStream.WriteAsync(new()
                            {
                                AssetID = r.Audio.Public.AssetID,
                                OldAssetID = r.Audio.Private.Data.OldAssetID,
                                ModifiedOnUTC = r.Audio.Public.ModifiedOnUTC,
                            });
                            break;
                        case AssetRecord.AssetRecordOneofOneofCase.Image:
                            await responseStream.WriteAsync(new()
                            {
                                AssetID = r.Image.Public.AssetID,
                                OldAssetID = r.Image.Private.Data.OldAssetID,
                                ModifiedOnUTC = r.Image.Public.ModifiedOnUTC,
                            });
                            break;
                    }
                }
            }
            catch
            {
            }
        }

        private bool IsValid(CreateAssetRequest request)
        {
            if (request == null)
                return false;

            switch (request.CreateAssetRequestOneofCase)
            {
                case CreateAssetRequest.CreateAssetRequestOneofOneofCase.Audio:
                    if (!IsValid(request.Audio))
                        return false;
                    break;
                case CreateAssetRequest.CreateAssetRequestOneofOneofCase.Image:
                    if (!IsValid(request.Image))
                        return false;
                    break;
                default:
                    return false;
            }

            return true;
        }

        private bool IsValid(AudioAssetData audio)
        {
            return false;
        }

        private bool IsValid(ImageAssetData image)
        {
            if (image.Public == null)
                return false;
            if (image.Private == null)
                return false;

            return true;
        }
    }
}
