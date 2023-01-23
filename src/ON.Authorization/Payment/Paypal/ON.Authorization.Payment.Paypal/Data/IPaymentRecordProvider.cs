using Google.Protobuf.Collections;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Paypal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Paypal.Data
{
    public interface IPaymentRecordProvider
    {
        Task Delete(Guid userId, Guid subscriptionId, Guid paymentId);
        Task DeleteAll(Guid userId, Guid subscriptionId);
        Task<bool> Exists(Guid userId, Guid subscriptionId, Guid paymentId);
        Task<PaypalPaymentRecord?> GetById(Guid userId, Guid subscriptionId, Guid paymentId);
        Task<List<PaypalPaymentRecord>> GetAllByUserId(Guid userId);
        Task<List<PaypalPaymentRecord>> GetAllBySubscriptionId(Guid userId, Guid subscriptionId);
        Task Save(PaypalPaymentRecord record);
        Task SaveAll(IEnumerable<PaypalPaymentRecord> payments);
    }
}
