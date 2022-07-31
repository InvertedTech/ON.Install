using Google.Protobuf;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Settings.SimpleSettings.Service.Data;
using ON.Settings.SimpleSettings.Service.Helpers;
using ON.Crypto;
using ON.Fragments.Settings;
using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ON.Authentication;

namespace ON.Settings.SimpleSettings.Service.Services
{
    public class BackupService : BackupInterface.BackupInterfaceBase
    {
        private readonly ISettingsDataProvider dataProvider;
        private readonly ILogger<BackupService> logger;

        public BackupService(ISettingsDataProvider dataProvider, ILogger<BackupService> logger)
        {
            this.dataProvider = dataProvider;
            this.logger = logger;
        }

        public override async Task BackupData(BackupDataRequest request, IServerStreamWriter<BackupDataResponse> responseStream, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null || !userToken.Roles.Contains(ONUser.ROLE_BACKUP))
                    return;

                var encKey = EcdhHelper.DeriveKeyServer(request.ClientPublicJwk.DecodeJsonWebKey(), out string serverPubKey);
                await responseStream.WriteAsync(new BackupDataResponse() { ServerPublicJwk = serverPubKey });

                await foreach (var r in dataProvider.GetAll())
                {
                    AesHelper.Encrypt(encKey, out var iv, r.ToByteString().ToByteArray(), out var encData);

                    await responseStream.WriteAsync(new BackupDataResponse()
                    {
                        EncryptedRecord = new EncryptedBackupDataRecord()
                        {
                            EncryptionIV = ByteString.CopyFrom(iv),
                            VersionNum = r.Public.VersionNum,
                            Data = ByteString.CopyFrom(encData)
                        }
                    });
                }
            }
            catch
            {
            }
        }

        public override async Task<RestoreDataResponse> RestoreData(IAsyncStreamReader<RestoreDataRequest> requestStream, ServerCallContext context)
        {
            logger.LogWarning("*** RestoreData - Entrance ***");

            RestoreDataResponse res = new RestoreDataResponse();
            HashSet<Guid> idsLoaded = new HashSet<Guid>();

            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                {
                    logger.LogWarning("*** RestoreData - token bad ***");
                    logger.LogWarning("*** RestoreData - jwttoken (" + (context.GetHttpContext()?.Request?.Headers["Authorization"] ?? "empty") + ") ***");
                    return res;
                }
                if (!userToken.Roles.Contains(ONUser.ROLE_BACKUP))
                {
                    logger.LogWarning("*** RestoreData - not backup user: (" + String.Join(',', userToken.Roles) + ") ***");
                    logger.LogWarning("*** RestoreData - jwttoken (" + (context.GetHttpContext()?.Request?.Headers["Authorization"] ?? "empty") + ") ***");
                    return res;
                }

                bool isCleared = false;

                await foreach (var r in requestStream.ReadAllAsync())
                {
                    try
                    {
                        if (!isCleared)
                        {
                            isCleared = true;
                            await dataProvider.Clear();
                        }

                        await dataProvider.Save(r.Record);
                        res.NumVersionsRestored++;
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning("*** RestoreData - ERROR ***");
                logger.LogWarning($"*** RestoreData - ERROR: {ex.Message} ***");
            }

            logger.LogWarning("*** RestoreData - Exit ***");

            return res;
        }
    }
}
