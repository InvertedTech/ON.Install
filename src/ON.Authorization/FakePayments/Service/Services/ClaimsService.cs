﻿using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Authorization.FakePayments.Service.Data;
using ON.Fragments.Authorization;
using ON.Fragments.Generic;
using System;
using System.Threading.Tasks;

namespace ON.Authorization.FakePayments.Service
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

            var res = new GetClaimsResponse();

            res.Claims.Add(new ClaimRecord()
            {
                Name = ONUser.SubscriptionLevelType,
                Value = rec.Level.ToString(),
                ExpiresOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow.AddDays(30))
            });
            res.Claims.Add(new ClaimRecord()
            {
                Name = ONUser.SubscriptionProviderType,
                Value = "fake",
                ExpiresOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow.AddDays(30))
            });

            return res;
        }
    }
}
