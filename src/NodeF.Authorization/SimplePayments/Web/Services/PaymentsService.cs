﻿using Grpc.Core;
using Microsoft.Extensions.Logging;
using NodeF.Authentication;
using NodeF.Authorization.SimplePayments.Web.Helper;
using NodeF.Fragments.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authorization.SimplePayments.Web.Services
{
    public class PaymentsService
    {
        private readonly ILogger<PaymentsService> logger;
        private readonly ServiceNameHelper nameHelper;
        public readonly NodeUser User;

        public PaymentsService(ServiceNameHelper nameHelper, NodeUserHelper userHelper, ILogger<PaymentsService> logger)
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

            if (nameHelper.PaymentsServiceChannel == null)
                return null;

            logger.LogWarning($"******Trying to hopefully connect to PaymentService at:({nameHelper.PaymentsServiceChannel.Target})******");


            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaymentsServiceChannel);
            var reply = await client.GetOwnSubscriptionRecordAsync(new GetOwnSubscriptionRecordRequest(), GetMetadata());
            return reply.Record;
        }

        public async Task<IEnumerable<SubscriptionRecord>> GetAllCurrentRecord()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.PaymentsServiceChannel == null)
                return null;

            logger.LogWarning($"******Trying to hopefully connect to PaymentService at:({nameHelper.PaymentsServiceChannel.Target})******");


            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaymentsServiceChannel);
            var reply = await client.GetAllOwnSubscriptionRecordsAsync(new GetOwnSubscriptionRecordRequest(), GetMetadata());
            return reply.Records;
        }

        public async Task<ChangeOwnSubscriptionRecordResponse> ChangeCurrentSubscriptionLevel(uint level)
        {
            if (!IsLoggedIn)
                return null;

            var req = new ChangeOwnSubscriptionRecordRequest()
            {
                Level = level
            };

            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaymentsServiceChannel);
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