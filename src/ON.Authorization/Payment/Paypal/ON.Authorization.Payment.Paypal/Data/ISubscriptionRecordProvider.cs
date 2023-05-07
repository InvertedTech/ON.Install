using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Paypal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Paypal.Data
{
    public interface ISubscriptionRecordProvider
    {
        Task Delete(Guid userId, Guid subscriptionId);
        Task<bool> Exists(Guid userId, Guid subscriptionId);
        IAsyncEnumerable<PaypalSubscriptionRecord> GetAll();
        Task<PaypalSubscriptionRecord?> GetById(Guid userId, Guid subscriptionId);
        Task<List<PaypalSubscriptionRecord>> GetAllByUserId(Guid userId);
        Task Save(PaypalSubscriptionRecord record);
    }
}
