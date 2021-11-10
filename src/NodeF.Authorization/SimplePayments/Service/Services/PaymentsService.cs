using Grpc.Core;
using Microsoft.Extensions.Logging;
using NodeF.Authentication;
using NodeF.Authorization.SimplePayments.Service.Data;
using NodeF.Fragments.Authorization;
using NodeF.Fragments.Generic;
using System;
using System.Threading.Tasks;

namespace NodeF.Authorization.SimplePayments.Service
{
    public class PaymentsService : PaymentsInterface.PaymentsInterfaceBase
    {
        private readonly ILogger<PaymentsService> logger;
        private readonly IPaymentRecordProvider paymentProvider;

        public PaymentsService(ILogger<PaymentsService> logger, IPaymentRecordProvider paymentProvider)
        {
            this.logger = logger;
            this.paymentProvider = paymentProvider;
        }

        public override async Task<GetOwnPaymentRecordResponse> GetOwnPaymentRecord(GetOwnPaymentRecordRequest request, ServerCallContext context)
        {
            var userToken = NodeUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new GetOwnPaymentRecordResponse();

            return new GetOwnPaymentRecordResponse
            {
                Record = await paymentProvider.GetById(userToken.Id)
            };
        }

        public override async Task<GetAllOwnPaymentRecordsResponse> GetAllOwnPaymentRecords(GetOwnPaymentRecordRequest request, ServerCallContext context)
        {
            var userToken = NodeUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new GetAllOwnPaymentRecordsResponse();

            var res = new GetAllOwnPaymentRecordsResponse();
            res.Records.AddRange(await paymentProvider.GetAllById(userToken.Id));

            return res;
        }

        public override async Task<ChangeOwnPaymentRecordResponse> ChangeOwnPaymentRecord(ChangeOwnPaymentRecordRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = NodeUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new ChangeOwnPaymentRecordResponse() { Error = "No user token specified" };

                if ((request?.Level ?? -1) < 1)
                    return new ChangeOwnPaymentRecordResponse() { Error = "Level not valid" };

                var record = new PaymentRecord()
                {
                    UserID = Google.Protobuf.ByteString.CopyFrom(userToken.Id.ToByteArray()),
                    Level = request.Level,
                    ChangedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow)
                };

                await paymentProvider.Save(record);

                return new ChangeOwnPaymentRecordResponse()
                {
                    Record = record
                };
            }
            catch
            {
                return new ChangeOwnPaymentRecordResponse() { Error = "Unknown error" };
            }
        }
    }
}
