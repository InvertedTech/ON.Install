using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Authentication;
using ON.Authorization.Crypto.Service.Data;
using ON.Authorization.Crypto.Service.Models;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.Crypto;
using ON.Fragments.Generic;
using System;
using System.Threading.Tasks;

namespace ON.Authorization.Crypto.Service
{
    public class BitcoinService : BitcoinInterface.BitcoinInterfaceBase
    {
        private readonly ILogger<BitcoinService> logger;
        private readonly IBitcoinPaymentHistoryRecordProvider paymentProvider;
        private readonly IBitcoinSubscriptionRecordProvider subscriptionProvider;
        private readonly AppSettings settings;

        public BitcoinService(ILogger<BitcoinService> logger, IBitcoinPaymentHistoryRecordProvider paymentProvider, IBitcoinSubscriptionRecordProvider subscriptionProvider, IOptions<AppSettings> settings)
        {
            this.logger = logger;
            this.paymentProvider = paymentProvider;
            this.subscriptionProvider = subscriptionProvider;
            this.settings = settings.Value;
        }

        public override async Task<CheckForPaymentResponse> CheckForPayment(CheckForPaymentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new CheckForPaymentResponse();

            /// TODO Check for new payment, if new payment(s) found create records.

            return new CheckForPaymentResponse();
        }

        public override async Task<GetAdminBalanceResponse> GetAdminBalance(GetAdminBalanceRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new GetAdminBalanceResponse();

            if (!user.IsAdmin)
                return new GetAdminBalanceResponse();

            /// TODO Check current balance and return

            return new GetAdminBalanceResponse()
            {
                Satoshis = 1000,
                ValueUSD = 1,
            };
        }

        public override async Task<GetHistoryRecordsResponse> GetHistoryRecords(GetHistoryRecordsRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new GetHistoryRecordsResponse();

            /// TODO 
            return new GetHistoryRecordsResponse();
        }

        public override async Task<GetPaymentStatusResponse> GetPaymentStatus(GetPaymentStatusRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new GetPaymentStatusResponse();

            

            return new GetPaymentStatusResponse()
            {
                Subscription = await subscriptionProvider.GetById(user.Id),
                LastPayment = await paymentProvider.GetById(user.Id),
            };
        }
    }
}
