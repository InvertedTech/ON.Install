using Grpc.Core;
using Microsoft.Extensions.Logging;
using NodeF.Fragments.Authorization;
using NodeF.Fragments.Generic;
using System;
using System.Threading.Tasks;

namespace NodeF.Authorization.SimplePayments.Service
{
    public class ClaimsService : ClaimsInterface.ClaimsInterfaceBase
    {
        private readonly ILogger<ClaimsService> logger;
        public ClaimsService(ILogger<ClaimsService> logger)
        {
            this.logger = logger;
        }

        public override Task<GetClaimsResponse> GetClaims(GetClaimsRequest request, ServerCallContext context)
        {
            var res = new GetClaimsResponse();

            res.Claims.Add(new ClaimRecord()
            {
                Name = "a",
                Value = "b",
                ExpiresOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow.AddDays(30))
            });

            return Task.FromResult(res);
        }
    }
}
