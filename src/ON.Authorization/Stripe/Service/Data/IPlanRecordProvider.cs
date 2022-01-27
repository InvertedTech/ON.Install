using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Stripe.Service.Data
{
    public interface IPlanRecordProvider
    {
        Task<PlanList> GetAll();
        Task SaveAll(PlanList list);
    }
}
