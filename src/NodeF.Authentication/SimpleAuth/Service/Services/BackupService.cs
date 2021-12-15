using Grpc.Core;
using Microsoft.Extensions.Logging;
using NodeF.Authentication.SimpleAuth.Service.Data;
using NodeF.Authentication.SimpleAuth.Service.Helpers;
using NodeF.Fragments.Authentcation;
using NodeF.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authentication.SimpleAuth.Service.Services
{
    public class BackupService : BackupInterface.BackupInterfaceBase
    {
        private readonly IUserDataProvider dataProvider;
        private readonly ILogger<ServiceOpsService> logger;

        public BackupService(IUserDataProvider dataProvider, ILogger<ServiceOpsService> logger)
        {
            this.dataProvider = dataProvider;
            this.logger = logger;
        }

        public override async Task BackupAllData(BackupAllDataRequest request, IServerStreamWriter<UserBackupDataRecord> responseStream, ServerCallContext context)
        {
            try
            {
                var userToken = NodeUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null || !userToken.Roles.Contains("backup"))
                    return;

                await foreach (var r in dataProvider.GetAll())
                    await responseStream.WriteAsync(new UserBackupDataRecord()
                    {
                        UserID = r.Public.UserID,
                        Data = r
                    });
            }
            catch
            {
            }
        }

        public override async Task ExportUsers(ExportUsersRequest request, IServerStreamWriter<UserRecord.Types.PublicData> responseStream, ServerCallContext context)
        {
            try
            {
                var userToken = NodeUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null || !userToken.Roles.Contains("backup"))
                    return;

                await foreach (var r in dataProvider.GetAll())
                    await responseStream.WriteAsync(r.Public);
            }
            catch
            {
            }
        }

        public override async Task<RestoreAllDataResponse> RestoreAllData(IAsyncStreamReader<UserBackupDataRecord> requestStream, ServerCallContext context)
        {
            RestoreAllDataResponse res = new RestoreAllDataResponse();
            HashSet<Guid> idsLoaded = new HashSet<Guid>();

            if (CurrentRestoreMode == null)
                return res;

            try
            {
                var userToken = NodeUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null || !userToken.Roles.Contains("backup"))
                    return res;

                await foreach (var r in requestStream.ReadAllAsync())
                {
                    Guid id = new Guid(r.Data.Public.UserID.Span);
                    idsLoaded.Add(id);

                    try
                    {
                        if (await dataProvider.Exists(id))
                        {
                            if (CurrentRestoreMode == SetRestoreModeRequest.Types.RestoreMode.MissingOnly)
                            {
                                res.NumUsersSkipped++;
                                continue;
                            }

                            await dataProvider.Save(r.Data);
                            res.NumUsersOverwriten++;
                        }
                        else
                        {
                            await dataProvider.Save(r.Data);
                            res.NumUsersRestored++;
                        }
                    }
                    catch { }
                }

                if (CurrentRestoreMode == SetRestoreModeRequest.Types.RestoreMode.Wipe)
                {
                    await foreach (var r in dataProvider.GetAll())
                    {
                        Guid id = new Guid(r.Public.UserID.Span);
                        if (!idsLoaded.Contains(id))
                        {
                            await dataProvider.Delete(id);
                            res.NumUsersWiped++;
                        }
                    }
                }
            }
            catch
            {
            }

            await dataProvider.ReindexAll();

            return res;
        }

        public static SetRestoreModeRequest.Types.RestoreMode? CurrentRestoreMode = null;
        public override Task<SetRestoreModeResponse> SetRestoreMode(SetRestoreModeRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = NodeUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null || !userToken.Roles.Contains("backup"))
                    return Task.FromResult(new SetRestoreModeResponse());

                CurrentRestoreMode = request.Mode;
            }
            catch
            {
            }

            return Task.FromResult(new SetRestoreModeResponse());
        }
    }
}
