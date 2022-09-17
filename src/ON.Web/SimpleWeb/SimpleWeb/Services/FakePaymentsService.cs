using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Fragments.Authorization.Payments.Fake;
using ON.SimpleWeb.Helper;
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

        public async Task<SubscriptionRecord> GetCurrentRecord()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.FakePaymentsServiceChannel == null)
                return null;

            logger.LogWarning($"******Trying to hopefully connect to PaymentService at:({nameHelper.FakePaymentsServiceChannel.Target})******");


            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.FakePaymentsServiceChannel);
            var reply = await client.GetOwnSubscriptionRecordAsync(new GetOwnSubscriptionRecordRequest(), GetMetadata());
            return reply.Record;
        }

        public async Task<ChangeOwnSubscriptionRecordResponse> ChangeCurrentSubscriptionLevel(uint level)
        {
            if (!IsLoggedIn)
                return null;

            var req = new ChangeOwnSubscriptionRecordRequest()
            {
                Level = level
            };

            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.FakePaymentsServiceChannel);
            var reply = await client.ChangeOwnSubscriptionRecordAsync(req, GetMetadata());
            return reply;
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + User.JwtToken);

            return data;
        }
    }
}
