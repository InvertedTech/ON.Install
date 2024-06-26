﻿using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Crypto.Service.Data
{
    public interface IBitcoinServiceRecordProvider
    {
        Task<int> GetNextAddressNumber();
    }
}
