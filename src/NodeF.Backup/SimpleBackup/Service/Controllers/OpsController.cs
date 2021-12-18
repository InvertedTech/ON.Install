using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NodeF.Authentication;
using NodeF.Backup.SimpleBackup.Service.Services;
using NodeF.Fragments.Authentcation;
using NodeF.Fragments.Generic;
using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace NodeF.Backup.SimpleBackup.Service.Controllers
{
    [Authorize(Roles = "ops")]
    [Route("ops")]
    public class OpsController : Controller
    {

        private readonly ILogger<OpsController> logger;
        private readonly ServiceNameHelper nameHelper;
        public readonly NodeUserHelper userHelper;

        public OpsController(ILogger<OpsController> logger, NodeUserHelper userHelper, ServiceNameHelper nameHelper)
        {
            this.logger = logger;
            this.nameHelper = nameHelper;
            this.userHelper = userHelper;
        }

        [HttpGet("status")]
        public async Task GetStatus()
        {
            var tasks = nameHelper.ChannelList.Select(c => GetStatus(c));
            await Task.WhenAll(tasks);

            Response.ContentType = "application/octet-stream";

            foreach (var t in tasks)
                t.Result.WriteDelimitedTo(Response.Body);
        }

        [HttpPost("offline")]
        public async Task Offline()
        {
            var tasks = nameHelper.ChannelList.Select(c => ServiceOp(ServiceOperationRequest.Types.ServiceOperation.Offline, c));
            await Task.WhenAll(tasks);
        }

        [HttpPost("online")]
        public async Task Online()
        {
            var tasks = nameHelper.ChannelList.Select(c => ServiceOp(ServiceOperationRequest.Types.ServiceOperation.Online, c));
            await Task.WhenAll(tasks);
        }

        [HttpPost("restart")]
        public async Task Restart()
        {
            var tasks = nameHelper.ChannelList.Select(c => ServiceOp(ServiceOperationRequest.Types.ServiceOperation.Restart, c));
            await Task.WhenAll(tasks);
        }

        private async Task<ServiceStatusResponse> GetStatus(Channel channel)
        {
            var client = new ServiceOpsInterface.ServiceOpsInterfaceClient(channel);
            return await client.ServiceStatusAsync(new(), GetMetadata());
        }

        private async Task ServiceOp(ServiceOperationRequest.Types.ServiceOperation op, Channel channel)
        {
            var client = new ServiceOpsInterface.ServiceOpsInterfaceClient(channel);
            var res = await client.ServiceOperationAsync(new ServiceOperationRequest()
            {
                Operation = op
            }, GetMetadata());

            Response.ContentType = "application/octet-stream";
            res.WriteTo(Response.Body);
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + userHelper.MyUser.JwtToken);

            return data;
        }
    }
}
