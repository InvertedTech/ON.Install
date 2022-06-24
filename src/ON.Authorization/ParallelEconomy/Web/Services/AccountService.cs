using Grpc.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Authorization.ParallelEconomy.Web.Helper;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.ParallelEconomy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.ParallelEconomy.Web.Services
{
    public class AccountService
    {
        private readonly ILogger<AccountService> logger;
        private readonly ServiceNameHelper nameHelper;

        public readonly PlanRecord[] Plans;
        public readonly bool IsTest;

        public AccountService(ServiceNameHelper nameHelper, ILogger<AccountService> logger)
        {
            this.logger = logger;
            this.nameHelper = nameHelper;

            var res = GetDetails();
            Plans = res.Plans.Records.ToArray();
            IsTest = res.IsTest;
        }

        private GetAccountDetailsResponse GetDetails()
        {
            if (nameHelper.PaymentsServiceChannel == null)
                return null;

            var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PaymentsServiceChannel);
            var reply = client.GetAccountDetails(new GetAccountDetailsRequest());
            return reply;
        }
    }
}
