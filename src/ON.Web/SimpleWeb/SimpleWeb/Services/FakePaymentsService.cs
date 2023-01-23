using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Fragments.Authorization.Payment.Fake;
using ON.Settings;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Services
{
    public class FakePaymentsService
    {
        private readonly ILogger<FakePaymentsService> logger;
        private readonly ServiceNameHelper nameHelper;
        public readonly ONUser User;

        public FakePaymentsService(ServiceNameHelper nameHelper, ONUserHelper userHelper, ILogger<FakePaymentsService> logger)
        {
            this.logger = logger;

            User = userHelper.MyUser;

            this.nameHelper = nameHelper;
        }

        public bool IsLoggedIn { get => User != null; }

        public async Task<FakeSubscriptionRecord> GetCurrentRecord()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.PaymentServiceChannel == null)
                return null;

            logger.LogWarning($"******Trying to hopefully connect to PaymentService at:({nameHelper.PaymentServiceChannel.Target})******");


            var client = new FakeInterface.FakeInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.FakeGetOwnSubscriptionRecordAsync(new FakeGetOwnSubscriptionRecordRequest(), GetMetadata());
            return reply.Record;
        }

        public async Task<FakeCancelOwnSubscriptionResponse> CancelSubscription(string reason)
        {
            if (!IsLoggedIn)
                return null;

            var req = new FakeCancelOwnSubscriptionRequest()
            {
                Reason = reason
            };

            var client = new FakeInterface.FakeInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.FakeCancelOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        public async Task<FakeNewOwnSubscriptionResponse> ChangeCurrentSubscriptionLevel(uint level)
        {
            if (!IsLoggedIn)
                return null;

            var req = new FakeNewOwnSubscriptionRequest()
            {
                AmountCents = level
            };

            var client = new FakeInterface.FakeInterfaceClient(nameHelper.PaymentServiceChannel);
            var reply = await client.FakeNewOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            if (User != null && !string.IsNullOrWhiteSpace(User.JwtToken))
                data.Add("Authorization", "Bearer " + User.JwtToken);

            return data;
        }
    }
}
