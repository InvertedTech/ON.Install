using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Fake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Fake.Data
{
    public interface ISubscriptionRecordProvider
    {
        Task<FakeSubscriptionRecord> GetById(Guid userId);
        Task Save(FakeSubscriptionRecord record);
    }
}
