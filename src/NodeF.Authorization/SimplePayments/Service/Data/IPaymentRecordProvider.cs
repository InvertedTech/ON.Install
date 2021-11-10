using NodeF.Fragments.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authorization.SimplePayments.Service.Data
{
    public interface IPaymentRecordProvider
    {
        Task<PaymentRecord> GetById(Guid userId);
        Task<IEnumerable<PaymentRecord>> GetAllById(Guid userId);
        Task Save(PaymentRecord record);
    }
}
