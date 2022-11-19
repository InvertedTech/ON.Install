using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Authorization.Payment.Paypal.Data;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment;
using ON.Fragments.Generic;
using System;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Service
{
    public class PaymentService : PaymentInterface.PaymentInterfaceBase
    {
        private readonly ILogger logger;
        private readonly Paypal.Clients.PaypalClient paypalClient;

        public PaymentService(ILogger<PaymentService> logger, Paypal.Clients.PaypalClient paypalClient)
        {
            this.logger = logger;
            this.paypalClient = paypalClient;
        }

        public override async Task<GetNewDetailsResponse> GetNewDetails(GetNewDetailsRequest request, ServerCallContext context)
        {
            var level = request?.Level ?? 0;
            if (level == 0)
                return new();

            return new()
            {
                Paypal = await paypalClient.GetNewDetails(level),
            };
        }
    }
}
