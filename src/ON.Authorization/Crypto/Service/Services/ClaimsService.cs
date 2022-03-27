using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Authorization.Crypto.Service.Data;
using ON.Fragments.Authorization;
using ON.Fragments.Generic;
using System;
using System.Threading.Tasks;

namespace ON.Authorization.Crypto.Service
{
    public class ClaimsService : ClaimsInterface.ClaimsInterfaceBase
    {
        private readonly ILogger<ClaimsService> logger;
        private readonly IBitcoinSubscriptionRecordProvider bitcoinSubscriptionProvider;

        public ClaimsService(ILogger<ClaimsService> logger, IBitcoinSubscriptionRecordProvider bitcoinSubscriptionProvider)
        {
            this.logger = logger;
            this.bitcoinSubscriptionProvider = bitcoinSubscriptionProvider;
        }

        public override async Task<GetClaimsResponse> GetClaims(GetClaimsRequest request, ServerCallContext context)
        {
            if (request.UserID == null)
                return new GetClaimsResponse();

            uint level = 5; /// TODO - set to chosen subscription level
            DateTime PaidThruUTC = DateTime.MinValue; // TODO - calculate based off of payments and subscription level

            /// TODO - Pull user details.  See if they have made bitcoin payments.  If so calcualte Paid Thru datetime and compare to currect time

            var res = new GetClaimsResponse();

            if (PaidThruUTC > DateTime.UtcNow)
            {
                res.Claims.Add(new ClaimRecord()
                {
                    Name = ONUser.SubscriptionLevelType,
                    Value = level.ToString(),
                    ExpiresOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(PaidThruUTC),
                });
                res.Claims.Add(new ClaimRecord()
                {
                    Name = ONUser.SubscriptionProviderType,
                    Value = "bitcoin",
                    ExpiresOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(PaidThruUTC),
                });
            }

            return res;
        }
    }
}
