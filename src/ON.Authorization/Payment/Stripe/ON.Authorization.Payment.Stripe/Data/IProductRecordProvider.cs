using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Stripe.Data
{
    public interface IProductRecordProvider
    {
        Task<ProductList> GetAll();
        Task SaveAll(ProductList list);
    }
}