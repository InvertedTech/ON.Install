using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NodeF.Fragments.Authentcation;
using NodeF.Fragments.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authentication.SimpleAuth.Service.Helpers
{
    public class ClaimsClient
    {
        private readonly ILogger<ClaimsClient> logger;
        private readonly ServiceNameHelper nameHelper;
        public readonly NodeUser User;

        public ClaimsClient(ServiceNameHelper nameHelper, NodeUserHelper userHelper, ILogger<ClaimsClient> logger)
        {
            this.logger = logger;

            User = userHelper.MyUser;

            this.nameHelper = nameHelper;
        }

        public async Task<IEnumerable<ClaimRecord>> GetOtherClaims(Guid userId)
        {
            var client = new ClaimsInterface.ClaimsInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.GetClaimsAsync(new GetClaimsRequest()
            {
                UserID = Google.Protobuf.ByteString.CopyFrom(userId.ToByteArray())
            });

            return reply.Claims;
        }
    }
}
