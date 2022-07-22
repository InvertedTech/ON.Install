using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Crypto.Service.Data
{
    public interface IBitcoinSubscriptionRecordProvider
    {
        Task<BitcoinSubscriptionRecord> GetById(Guid userId);
        Task<List<BitcoinSubscriptionRecord>> GetAllById(Guid userId);
        Task Save(BitcoinSubscriptionRecord record);
    }
}
