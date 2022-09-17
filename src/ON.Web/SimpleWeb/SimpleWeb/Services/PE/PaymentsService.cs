using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Fragments.Authorization.Payments.ParallelEconomy;
using ON.SimpleWeb.Helper;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Services.PE
{
    public class PaymentsService
    {
        private readonly ILogger<PaymentsService> logger;
        private readonly ServiceNameHelper nameHelper;
        public readonly ONUser User;

        public PaymentsService(ServiceNameHelper nameHelper, ONUserHelper userHelper, ILogger<PaymentsService> logger)
        {
            this.logger = logger;

            User = userHelper.MyUser;

            this.nameHelper = nameHelper;
        }

        public bool IsLoggedIn { get => User != null; }

        public async Task<CancelOwnSubscriptionResponse> CancelSubscription(string reason)
        {
            if (!IsLoggedIn)
                return null;

            var req = new CancelOwnSubscriptionRequest()
            {
                Reason = reason
            };

            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PEPaymentsServiceChannel);
            var reply = await client.CancelOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        public async Task<SubscriptionRecord> GetCurrentRecord()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.PEPaymentsServiceChannel == null)
                return null;

            logger.LogWarning($"******Trying to hopefully connect to PaymentService at:({nameHelper.PEPaymentsServiceChannel.Target})******");


            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PEPaymentsServiceChannel);
            var reply = await client.GetOwnSubscriptionRecordAsync(new GetOwnSubscriptionRecordRequest(), GetMetadata());
            return reply.Record;
        }

        public async Task<NewOwnSubscriptionResponse> NewSubscription(string tranId)
        {
            if (!IsLoggedIn)
                return null;

            var req = new NewOwnSubscriptionRequest()
            {
                TransactionId = tranId
            };

            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PEPaymentsServiceChannel);
            var reply = await client.NewOwnSubscriptionAsync(req, GetMetadata());
            return reply;
        }

        public async Task<StartNewSubscriptionResponse> StartNewSubscription(uint level)
        {
            if (!IsLoggedIn)
                return null;

            var req = new StartNewSubscriptionRequest()
            {
                Level = level
            };

            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PEPaymentsServiceChannel);
            var reply = await client.StartNewSubscriptionAsync(req, GetMetadata());
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
