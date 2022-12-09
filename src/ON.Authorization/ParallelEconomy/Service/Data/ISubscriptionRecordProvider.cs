using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.ParallelEconomy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.ParallelEconomy.Service.Data
{
    public interface ISubscriptionRecordProvider
    {
        Task<SubscriptionRecord> GetById(Guid userId);
        Task Save(SubscriptionRecord record);
    }
}
