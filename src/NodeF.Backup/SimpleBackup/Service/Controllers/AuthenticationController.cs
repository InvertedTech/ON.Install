using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NodeF.Authentication;
using NodeF.Backup.SimpleBackup.Service.Services;
using NodeF.Fragments.Authentcation;
using System;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;

namespace NodeF.Backup.SimpleBackup.Service.Controllers
{
    [Authorize(Roles = "backup")]
    [Route("backup/[controller]")]
    public class AuthenticationController : Controller
    {

        private readonly ILogger<AuthenticationController> logger;
        private readonly ServiceNameHelper nameHelper;
        public readonly NodeUserHelper userHelper;

        public AuthenticationController(ILogger<AuthenticationController> logger, NodeUserHelper userHelper, ServiceNameHelper nameHelper)
        {
            this.logger = logger;
            this.nameHelper = nameHelper;
            this.userHelper = userHelper;
        }

        [HttpGet]
        public async Task Get()
        {
            var client = new BackupInterface.BackupInterfaceClient(nameHelper.AuthenticationServiceChannel);
            var stream = client.BackupAllData(new BackupAllDataRequest(), GetMetadata());

            Response.ContentType = "application/octet-stream";

            await foreach (var response in stream.ResponseStream.ReadAllAsync())
            {
                var bytes = response.ToByteString().ToByteArray();
                await Response.Body.WriteAsync(BitConverter.GetBytes(bytes.Length));
                await Response.Body.WriteAsync(bytes);
            }

        }

        [HttpPost]
        public async Task Post()
        {
            byte[] buffer = new byte[1024 * 1024 * 1024];
            var stream = Request.Body;
            var client = new BackupInterface.BackupInterfaceClient(nameHelper.AuthenticationServiceChannel);
            var call = client.RestoreAllData(GetMetadata());

            while (true)
            {
                var numBytes = await stream.ReadAsync(buffer, 0, 4);
                if (numBytes != 4)
                    break;

                numBytes = BitConverter.ToInt32(buffer, 0);
                numBytes = await stream.ReadAsync(buffer, 0, numBytes);
                var rec = UserBackupDataRecord.Parser.ParseFrom(buffer, 0, numBytes);
                await call.RequestStream.WriteAsync(rec);
            }
            await call.RequestStream.CompleteAsync();

            var res = await call;
            await Response.Body.WriteAsync(res.ToByteArray());
        }

        [HttpPost("restore/missing")]
        public async Task SetRestoreModeMissing()
        {
            var client = new BackupInterface.BackupInterfaceClient(nameHelper.AuthenticationServiceChannel);
            await client.SetRestoreModeAsync(new SetRestoreModeRequest()
            {
                Mode = SetRestoreModeRequest.Types.RestoreMode.MissingOnly
            }, GetMetadata());
        }

        [HttpPost("restore/overwrite")]
        public async Task SetRestoreModeOverwrite()
        {
            var client = new BackupInterface.BackupInterfaceClient(nameHelper.AuthenticationServiceChannel);
            await client.SetRestoreModeAsync(new SetRestoreModeRequest()
            {
                Mode = SetRestoreModeRequest.Types.RestoreMode.Overwrite
            }, GetMetadata());
        }

        [HttpPost("restore/wipe")]
        public async Task SetRestoreModeWipe()
        {
            var client = new BackupInterface.BackupInterfaceClient(nameHelper.AuthenticationServiceChannel);
            await client.SetRestoreModeAsync(new SetRestoreModeRequest()
            {
                Mode = SetRestoreModeRequest.Types.RestoreMode.Wipe
            }, GetMetadata());
        }

        public Metadata GetMetadata()
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + userHelper.MyUser.JwtToken);

            return data;
        }
    }
}
