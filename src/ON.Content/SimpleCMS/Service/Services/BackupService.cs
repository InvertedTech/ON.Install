using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Content.SimpleCMS.Service.Data;
using ON.Crypto;
using ON.Fragments.Content;
using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ON.Content.SimpleCMS.Service.Services
{
    [Authorize(Roles = ONUser.ROLE_CAN_BACKUP)]
    public class BackupService : BackupInterface.BackupInterfaceBase
    {
        private readonly IContentDataProvider dataProvider;
        private readonly ILogger<BackupService> logger;

        public BackupService(IContentDataProvider dataProvider, ILogger<BackupService> logger)
        {
            this.dataProvider = dataProvider;
            this.logger = logger;
        }

        public override async Task BackupAllData(BackupAllDataRequest request, IServerStreamWriter<BackupAllDataResponse> responseStream, ServerCallContext context)
        {
            try
            {
                var encKey = EcdhHelper.DeriveKeyServer(request.ClientPublicJwk.DecodeJsonWebKey(), out string serverPubKey);
                await responseStream.WriteAsync(new BackupAllDataResponse() { ServerPublicJwk = serverPubKey });

                await foreach (var r in dataProvider.GetAll())
                {
                    var dr = new ContentBackupDataRecord()
                    {
                        Data = r
                    };

                    AesHelper.Encrypt(encKey, out var iv, dr.ToByteString().ToByteArray(), out var encData);

                    await responseStream.WriteAsync(new BackupAllDataResponse()
                    {
                        EncryptedRecord = new EncryptedContentBackupDataRecord()
                        {
                            EncryptionIV = ByteString.CopyFrom(iv),
                            Data = ByteString.CopyFrom(encData)
                        }
                    });
                }
            }
            catch
            {
            }
        }

        public override async Task ExportContent(ExportContentRequest request, IServerStreamWriter<ExportContentResponse> responseStream, ServerCallContext context)
        {
            try
            {
                await foreach (var r in dataProvider.GetAll())
                    await responseStream.WriteAsync(new ExportContentResponse() { ContentRecord = r.Public });
            }
            catch
            {
            }
        }

        public override async Task<RestoreAllDataResponse> RestoreAllData(IAsyncStreamReader<RestoreAllDataRequest> requestStream, ServerCallContext context)
        {
            RestoreAllDataResponse res = new RestoreAllDataResponse();
            HashSet<Guid> idsLoaded = new HashSet<Guid>();

            await requestStream.MoveNext();
            if (requestStream.Current.RequestOneofCase != RestoreAllDataRequest.RequestOneofOneofCase.Mode)
                return res;

            var restoreMode = requestStream.Current.Mode;

            try
            {
                await foreach (var r in requestStream.ReadAllAsync())
                {
                    Guid id = r.Record.Data.Public.ContentID.ToGuid();
                    idsLoaded.Add(id);

                    try
                    {
                        if (await dataProvider.Exists(id))
                        {
                            if (restoreMode == RestoreAllDataRequest.Types.RestoreMode.MissingOnly)
                            {
                                res.NumRecordsSkipped++;
                                continue;
                            }

                            await dataProvider.Save(r.Record.Data);
                            res.NumRecordsOverwriten++;
                        }
                        else
                        {
                            await dataProvider.Save(r.Record.Data);
                            res.NumRecordsRestored++;
                        }
                    }
                    catch { }
                }

                if (restoreMode == RestoreAllDataRequest.Types.RestoreMode.Wipe)
                {
                    await foreach (var r in dataProvider.GetAll())
                    {
                        Guid id = r.Public.ContentID.ToGuid();
                        if (!idsLoaded.Contains(id))
                        {
                            await dataProvider.Delete(id);
                            res.NumRecordsWiped++;
                        }
                    }
                }
            }
            catch
            {
            }

            return res;
        }
    }
}
