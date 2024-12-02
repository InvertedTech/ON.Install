using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Stripe.Data
{
    public interface ISubscriptionRecordProvider
    {
        Task Delete(Guid userId, Guid subscriptionId);
        Task<bool> Exists(Guid userId, Guid subscriptionId);
        IAsyncEnumerable<StripeSubscriptionRecord> GetAll();
        Task<StripeSubscriptionRecord?> GetById(Guid userId, Guid subscriptionId);
        Task<List<StripeSubscriptionRecord>> GetAllByUserId(Guid userId);
        Task Save(StripeSubscriptionRecord record);
    }
}
