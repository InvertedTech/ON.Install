using Microsoft.Extensions.Logging;
using ON.Fragments.Authorization.Payment.ParallelEconomy;
using ON.Settings;
using System.Linq;

namespace ON.SimpleWeb.Services.PE
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
            if (nameHelper.PaymentServiceChannel == null)
                return null;

            return null;
            //var client = new PaymentsInterface.PaymentsInterfaceClient(nameHelper.PEPaymentsServiceChannel);
            //var reply = client.GetAccountDetails(new GetAccountDetailsRequest());
            //return reply;
        }
    }
}
