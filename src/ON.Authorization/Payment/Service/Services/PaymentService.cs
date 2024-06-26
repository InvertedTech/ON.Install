﻿using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using FakeD = ON.Authorization.Payment.Fake.Data;
using PaypalD = ON.Authorization.Payment.Paypal.Data;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment;
using ON.Fragments.Generic;
using System;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Service
{
    [Authorize]
    public class PaymentService : PaymentInterface.PaymentInterfaceBase
    {
        private readonly ILogger logger;
        private readonly Paypal.Clients.PaypalClient paypalClient;
        private readonly FakeD.ISubscriptionRecordProvider fakeProvider;
        private readonly PaypalD.DataMergeService paypalProvider;

        public PaymentService(ILogger<PaymentService> logger, Paypal.Clients.PaypalClient paypalClient, FakeD.ISubscriptionRecordProvider fakeProvider, PaypalD.DataMergeService paypalProvider)
        {
            this.logger = logger;
            this.paypalClient = paypalClient;
            this.fakeProvider = fakeProvider;
            this.paypalProvider = paypalProvider;
        }

        public override async Task<GetNewDetailsResponse> GetNewDetails(GetNewDetailsRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new();

            var level = request?.Level ?? 0;
            if (level == 0)
                return new();

            return new()
            {
                Paypal = await paypalClient.GetNewDetails(level),
            };
        }

        public override async Task<GetOwnSubscriptionRecordsResponse> GetOwnSubscriptionRecords(GetOwnSubscriptionRecordsRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new();

            var fakeT = fakeProvider.GetById(userToken.Id);
            var paypalT = paypalProvider.GetAllByUserId(userToken.Id);

            await Task.WhenAll(fakeT, paypalT);

            var res = new GetOwnSubscriptionRecordsResponse();

            if (fakeT.Result != null)
                if (fakeT.Result.AmountCents > 0)
                    res.Fake = fakeT.Result;

            if (paypalT.Result != null)
                res.Paypal.AddRange(paypalT.Result);

            return res;
        }
    }
}
