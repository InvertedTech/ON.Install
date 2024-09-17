using Google.Protobuf.Collections;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Stripe.Data
{
    public interface IPaymentRecordProvider
    {
        Task Delete(Guid userId, Guid subscriptionId, Guid paymentId);
        Task DeleteAll(Guid userId, Guid subscriptionId);
        Task<bool> Exists(Guid userId, Guid subscriptionId, Guid paymentId);
        Task<StripePaymentRecord?> GetById(Guid userId, Guid subscriptionId, Guid paymentId);
        Task<List<StripePaymentRecord>> GetAllByUserId(Guid userId);
        Task<List<StripePaymentRecord>> GetAllBySubscriptionId(Guid userId, Guid subscriptionId);
        Task Save(StripePaymentRecord record);
        Task SaveAll(IEnumerable<StripePaymentRecord> payments);
    }
}
