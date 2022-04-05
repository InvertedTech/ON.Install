using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NBitcoin;
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
        private readonly IBitcoinServiceRecordProvider serviceProvider;
        private readonly IBitcoinSubscriptionRecordProvider subscriptionProvider;
        private readonly AppSettings settings;
        private readonly ExtPubKey pubParent;

        public BitcoinService(ILogger<BitcoinService> logger, IBitcoinPaymentHistoryRecordProvider paymentProvider, IBitcoinServiceRecordProvider serviceProvider, IBitcoinSubscriptionRecordProvider subscriptionProvider, IOptions<AppSettings> settings)
        {
            this.logger = logger;
            this.paymentProvider = paymentProvider;
            this.serviceProvider = serviceProvider;
            this.subscriptionProvider = subscriptionProvider;
            this.settings = settings.Value;

            pubParent = ExtPubKey.Parse(this.settings.BitcoinXPub, Network.Main);
        }

        public override async Task<CheckForPaymentResponse> CheckForPayment(CheckForPaymentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new CheckForPaymentResponse();

            /// TODO Check for new payment, if new payment(s) found create records.
            /// Use: https://blockchain.info/rawaddr/$bitcoin_address
            /// use settings.BitcoinBlockchainApiUrlSingleAddress

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
            /// Use: https://blockchain.info/multiaddr?active={settings.BitcoinXPub}
            /// use settings.BitcoinBlockchainApiUrlXPubAddress

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

            var subscription = await subscriptionProvider.GetById(user.Id);
            if (subscription == null)
            {
                subscription = await CreateSubscriptionRecord(user.Id);

            }

            return new GetPaymentStatusResponse()
            {
                Subscription = subscription,
                LastPayment = await paymentProvider.GetById(user.Id),
            };
        }

        public override async Task<GetPaymentStatusResponse> SetSubscriptionLevel(SetSubscriptionLevelRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new GetPaymentStatusResponse();

            var subscription = await subscriptionProvider.GetById(user.Id);
            if (subscription == null)
            {
                subscription = await CreateSubscriptionRecord(user.Id);

            }

            subscription.CurrentLevel = request.Level;
            await subscriptionProvider.Save(subscription);

            return new GetPaymentStatusResponse()
            {
                Subscription = subscription,
                LastPayment = await paymentProvider.GetById(user.Id),
            };
        }

        private async Task<BitcoinSubscriptionRecord> CreateSubscriptionRecord(Guid id)
        {
            BitcoinSubscriptionRecord r = new()
            {
                UserID = id.ToString(),
                AddressNumber = await serviceProvider.GetNextAddressNumber(),
                CreatedOnUTC = Timestamp.FromDateTime(DateTime.UtcNow),
                CurrentLevel = 0,
            };

            r.Address = GetAddress(r.AddressNumber);

            await subscriptionProvider.Save(r);

            return r;
        }

        private string GetAddress(int addressNumber)
        {
            var myaddr = pubParent.Derive(new KeyPath("0/" + addressNumber.ToString()));
            return myaddr.GetPublicKey().GetAddress(ScriptPubKeyType.Legacy, Network.Main).ToString();
        }
    }
}
