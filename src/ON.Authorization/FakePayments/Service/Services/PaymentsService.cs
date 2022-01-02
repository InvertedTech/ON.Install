using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Authorization.FakePayments.Service.Data;
using ON.Fragments.Authorization;
using ON.Fragments.Generic;
using System;
using System.Threading.Tasks;

namespace ON.Authorization.FakePayments.Service
{
    public class PaymentsService : PaymentsInterface.PaymentsInterfaceBase
    {
        private readonly ILogger<PaymentsService> logger;
        private readonly ISubscriptionRecordProvider subscriptionProvider;

        public PaymentsService(ILogger<PaymentsService> logger, ISubscriptionRecordProvider subscriptionProvider)
        {
            this.logger = logger;
            this.subscriptionProvider = subscriptionProvider;
        }

        public override async Task<GetOwnSubscriptionRecordResponse> GetOwnSubscriptionRecord(GetOwnSubscriptionRecordRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new GetOwnSubscriptionRecordResponse();

            return new GetOwnSubscriptionRecordResponse
            {
                Record = await subscriptionProvider.GetById(userToken.Id)
            };
        }

        public override async Task<ChangeOwnSubscriptionRecordResponse> ChangeOwnSubscriptionRecord(ChangeOwnSubscriptionRecordRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new ChangeOwnSubscriptionRecordResponse() { Error = "No user token specified" };

                if (request?.Level == null)
                    return new ChangeOwnSubscriptionRecordResponse() { Error = "Level not valid" };

                var record = new SubscriptionRecord()
                {
                    UserID = Google.Protobuf.ByteString.CopyFrom(userToken.Id.ToByteArray()),
                    Level = request.Level,
                    ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow)
                };

                await subscriptionProvider.Save(record);

                return new ChangeOwnSubscriptionRecordResponse()
                {
                    Record = record
                };
            }
            catch
            {
                return new ChangeOwnSubscriptionRecordResponse() { Error = "Unknown error" };
            }
        }
    }
}
