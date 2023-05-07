using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using FakeD = ON.Authorization.Payment.Fake.Data;
using PaypalD = ON.Authorization.Payment.Paypal.Data;
using ON.Fragments.Authorization;
using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Google.Rpc.Context.AttributeContext.Types;
using System.Linq;
using ON.Fragments.Authorization.Payment.Paypal;

namespace ON.Authorization.Payment.Service
{
    public class ClaimsService : ClaimsInterface.ClaimsInterfaceBase
    {
        private readonly ILogger<ClaimsService> logger;
        private readonly FakeD.ISubscriptionRecordProvider fakeProvider;
        private readonly PaypalD.ISubscriptionRecordProvider paypalProvider;

        public ClaimsService(ILogger<ClaimsService> logger, FakeD.ISubscriptionRecordProvider fakeProvider, PaypalD.ISubscriptionRecordProvider paypalProvider)
        {
            this.logger = logger;
            this.fakeProvider = fakeProvider;
            this.paypalProvider = paypalProvider;
        }

        public override async Task<GetClaimsResponse> GetClaims(GetClaimsRequest request, ServerCallContext context)
        {
            if (request.UserID == null)
                return new GetClaimsResponse();

            Guid userId;
            if (!Guid.TryParse(request.UserID, out userId))
                return new GetClaimsResponse();

            var res = new GetClaimsResponse();

            var tasks = new[]
            {
                GetFakeClaims(userId),
                GetPaypalClaims(userId),
            };

            await Task.WhenAll(tasks);

            res.Claims.AddRange(tasks.SelectMany(t => t.Result));

            return res;
        }

        private async Task<ClaimRecord[]> GetFakeClaims(Guid userId)
        {
            var rec = await fakeProvider.GetById(userId);

            if (rec == null || rec.AmountCents < 1)
                return Array.Empty<ClaimRecord>();

            var claims = new List<ClaimRecord>();

            claims.Add(new ClaimRecord()
            {
                Name = ONUser.SubscriptionLevelType,
                Value = rec.AmountCents.ToString(),
                ExpiresOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow.AddDays(30))
            });

            claims.Add(new ClaimRecord()
            {
                Name = ONUser.SubscriptionProviderType,
                Value = "fake",
                ExpiresOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow.AddDays(30))
            });

            return claims.ToArray();
        }
        private async Task<ClaimRecord[]> GetPaypalClaims(Guid userId)
        {
            var rec = await GetBestSubscription(userId);

            if (rec == null || rec.AmountCents < 1)
                return Array.Empty<ClaimRecord>();

            if (rec.PaidThruUTC.ToDateTime() < DateTime.UtcNow)
                return Array.Empty<ClaimRecord>();

            var claims = new List<ClaimRecord>();

            claims.Add(new ClaimRecord()
            {
                Name = ONUser.SubscriptionLevelType,
                Value = rec.AmountCents.ToString(),
                ExpiresOnUTC = rec.PaidThruUTC
            });
            claims.Add(new ClaimRecord()
            {
                Name = ONUser.SubscriptionProviderType,
                Value = "paypal",
                ExpiresOnUTC = rec.PaidThruUTC
            });

            return claims.ToArray();
        }

        private async Task<PaypalSubscriptionRecord> GetBestSubscription(Guid userId)
        {
            var recs = await paypalProvider.GetAllByUserId(userId);
            return recs.Where(r => r.PaidThruUTC.ToDateTime() > DateTime.UtcNow).OrderByDescending(r => r.PaidThruUTC).OrderByDescending(r => r.AmountCents).FirstOrDefault();
        }
    }
}
