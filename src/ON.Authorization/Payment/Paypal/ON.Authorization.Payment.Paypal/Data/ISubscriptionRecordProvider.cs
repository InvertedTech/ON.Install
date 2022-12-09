﻿using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Paypal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Paypal.Data
{
    public interface ISubscriptionRecordProvider
    {
        Task<PaypalSubscriptionRecord?> GetById(Guid userId);
        Task Save(PaypalSubscriptionRecord record);
    }
}