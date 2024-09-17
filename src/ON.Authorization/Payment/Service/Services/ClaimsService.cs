using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using FakeD = ON.Authorization.Payment.Fake.Data;
using PaypalD = ON.Authorization.Payment.Paypal.Data;
using StripeD = ON.Authorization.Payment.Stripe.Data;
using ON.Fragments.Authorization;
using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Google.Rpc.Context.AttributeContext.Types;
using System.Linq;
using ON.Fragments.Authorization.Payment.Paypal;
using ON.Fragments.Authorization.Payment.Stripe;

namespace ON.Authorization.Payment.Service
{
    public class ClaimsService : ClaimsInterface.ClaimsInterfaceBase
    {
        private readonly ILogger<ClaimsService> logger;
        private readonly FakeD.ISubscriptionRecordProvider fakeProvider;
        private readonly PaypalD.ISubscriptionRecordProvider paypalProvider;
        private readonly StripeD.ISubscriptionRecordProvider stripeProvider;

        public ClaimsService(ILogger<ClaimsService> logger, FakeD.ISubscriptionRecordProvider fakeProvider, PaypalD.ISubscriptionRecordProvider paypalProvider, StripeD.ISubscriptionRecordProvider stripeProvider)
        {
            this.logger = logger;
            this.fakeProvider = fakeProvider;
            this.paypalProvider = paypalProvider;
            this.stripeProvider = stripeProvider;
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
                GetPaidClaims(userId),
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
        private async Task<ClaimRecord[]> GetPaidClaims(Guid userId)
        {
            var paypalRecs = await GetBestSubscription(userId);

            if (paypalRecs == null || paypalRecs.AmountCents < 1)
                return Array.Empty<ClaimRecord>();

            if (paypalRecs.PaidThruUTC.ToDateTime() < DateTime.UtcNow)
                return Array.Empty<ClaimRecord>();

            var claims = new List<ClaimRecord>();

            claims.Add(new ClaimRecord()
            {
                Name = ONUser.SubscriptionLevelType,
                Value = paypalRecs.AmountCents.ToString(),
                ExpiresOnUTC = paypalRecs.PaidThruUTC
            });
            claims.Add(new ClaimRecord()
            {
                Name = ONUser.SubscriptionProviderType,
                Value = "paypal",
                ExpiresOnUTC = paypalRecs.PaidThruUTC
            });

            return claims.ToArray();
        }

        private async Task<UnifiedSubscriptionRecord> GetBestSubscription(Guid userId)
        {
            var paypalRecs = await paypalProvider.GetAllByUserId(userId);
            var stripeRecs = await stripeProvider.GetAllByUserId(userId);

            var recs = new List<UnifiedSubscriptionRecord>();
            recs.AddRange(paypalRecs.Select(r => new UnifiedSubscriptionRecord(r)));
            recs.AddRange(stripeRecs.Select(r => new UnifiedSubscriptionRecord(r)));

            return recs.Where(r => r.PaidThruUTC.ToDateTime() > DateTime.UtcNow).OrderByDescending(r => r.PaidThruUTC).OrderByDescending(r => r.AmountCents).FirstOrDefault();
        }

        public class UnifiedSubscriptionRecord
        {
            public UnifiedSubscriptionRecord(PaypalSubscriptionRecord r)
            {
                PaidThruUTC = r.PaidThruUTC;
                AmountCents = r.AmountCents;
            }

            public UnifiedSubscriptionRecord(StripeSubscriptionRecord r)
            {
                PaidThruUTC = r.PaidThruUTC;
                AmountCents = r.AmountCents;
            }

            public Google.Protobuf.WellKnownTypes.Timestamp PaidThruUTC { get; set; }
            public uint AmountCents { get; set; }
        }
    }
}
