using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.Paypal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Paypal.Service.Data
{
    public interface IPlanRecordProvider
    {
        Task<PlanList> GetAll();
        Task SaveAll(PlanList list);
    }
}
