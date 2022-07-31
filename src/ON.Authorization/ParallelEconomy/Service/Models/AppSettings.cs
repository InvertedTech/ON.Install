using Microsoft.IdentityModel.Tokens;
using ON.Fragments.Authorization.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.ParallelEconomy.Service.Models
{
    public class AppSettings
    {
        public string DataStore { get; set; } = "/data";
        public bool ParallelEconomyIsTest { get; set; }
        public string ParallelEconomyLocationId { get; set; }
        public string ParallelEconomyProductId { get; set; }
        public string ParallelEconomyUserId { get; set; }
        public string ParallelEconomyUserApiKey { get; set; }
        public string ParallelEconomyDeveloperId { get; private set; } = "IphR7xVH";

        public bool ContainsSecrets
        {
            get
            {
                if (string.IsNullOrWhiteSpace(ParallelEconomyUserId))
                    return false;
                if (string.IsNullOrWhiteSpace(ParallelEconomyUserApiKey))
                    return false;
                if (string.IsNullOrWhiteSpace(ParallelEconomyDeveloperId))
                    return false;
                return true;
            }
        }
    }
}
