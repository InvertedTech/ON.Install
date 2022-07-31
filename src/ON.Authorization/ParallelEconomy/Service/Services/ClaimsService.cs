using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Authorization.ParallelEconomy.Service.Data;
using ON.Fragments.Authorization;
using ON.Fragments.Generic;
using System;
using System.Threading.Tasks;

namespace ON.Authorization.ParallelEconomy.Service
{
    public class ClaimsService : ClaimsInterface.ClaimsInterfaceBase
    {
        private readonly ILogger<ClaimsService> logger;
        private readonly ISubscriptionRecordProvider paymentProvider;

        public ClaimsService(ILogger<ClaimsService> logger, ISubscriptionRecordProvider paymentProvider)
        {
            this.logger = logger;
            this.paymentProvider = paymentProvider;
        }

        public override async Task<GetClaimsResponse> GetClaims(GetClaimsRequest request, ServerCallContext context)
        {
            if (request.UserID == null)
                return new GetClaimsResponse();

            var rec = await paymentProvider.GetById(new Guid(request.UserID.Span));

            if (rec == null || rec.Level < 1)
                return new GetClaimsResponse();

            if (rec.PaidThruUTC.ToDateTime() < DateTime.UtcNow)
                return new GetClaimsResponse();

            var res = new GetClaimsResponse();

            res.Claims.Add(new ClaimRecord()
            {
                Name = ONUser.SubscriptionLevelType,
                Value = rec.Level.ToString(),
                ExpiresOnUTC = rec.PaidThruUTC
            });
            res.Claims.Add(new ClaimRecord()
            {
                Name = ONUser.SubscriptionProviderType,
                Value = "paralleleconomy",
                ExpiresOnUTC = rec.PaidThruUTC
            });

            return res;
        }
    }
}
