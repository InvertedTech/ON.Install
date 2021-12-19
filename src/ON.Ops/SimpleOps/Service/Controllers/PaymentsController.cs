using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Backup.SimpleBackup.Service.Services;
using ON.Fragments.Authorization;
using System;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ON.Backup.SimpleBackup.Service.Controllers
{
    [Authorize(Roles = "backup")]
    [Route("backup/[controller]")]
    public class PaymentsController : Controller
    {

        private readonly ILogger<PaymentsController> logger;
        private readonly ServiceNameHelper nameHelper;
        public readonly ONUserHelper userHelper;

        public PaymentsController(ILogger<PaymentsController> logger, ONUserHelper userHelper, ServiceNameHelper nameHelper)
        {
            this.logger = logger;
            this.nameHelper = nameHelper;
            this.userHelper = userHelper;
        }

        [HttpGet]
        public async Task Get(string key)
        {
            var client = new BackupInterface.BackupInterfaceClient(nameHelper.PaymentsServiceChannel);
            var stream = client.BackupAllData(new BackupAllDataRequest() { ClientPublicJwk = key }, GetMetadata());

            Response.ContentType = "application/octet-stream";

            await foreach (var response in stream.ResponseStream.ReadAllAsync())
            {
                response.WriteDelimitedTo(Response.Body);
            }
        }

        [HttpPost("restore/missing")]
        public async Task RestoreMissing()
        {
            await Restore(RestoreAllDataRequest.Types.RestoreMode.MissingOnly);
        }

        [HttpPost("restore/overwrite")]
        public async Task RestoreOverwrite()
        {
            await Restore(RestoreAllDataRequest.Types.RestoreMode.Overwrite);
        }

        [HttpPost("restore/wipe")]
        public async Task RestoreWipe()
        {
            await Restore(RestoreAllDataRequest.Types.RestoreMode.Wipe);
        }

        private async Task Restore(RestoreAllDataRequest.Types.RestoreMode mode)
        {
            using MemoryStream mem = new();
            await Request.Body.CopyToAsync(mem);
            mem.Position = 0;

            var client = new BackupInterface.BackupInterfaceClient(nameHelper.PaymentsServiceChannel);
            var call = client.RestoreAllData(GetMetadata());

            await call.RequestStream.WriteAsync(new RestoreAllDataRequest() { Mode = mode });

            while (mem.Position != mem.Length)
            {
                var rec = RestoreAllDataRequest.Parser.ParseDelimitedFrom(mem);
                await call.RequestStream.WriteAsync(rec);
            }
            await call.RequestStream.CompleteAsync();

            var res = await call;
            await Response.Body.WriteAsync(res.ToByteArray());
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + userHelper.MyUser.JwtToken);

            return data;
        }
    }
}
