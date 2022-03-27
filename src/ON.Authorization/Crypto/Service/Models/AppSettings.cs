using Microsoft.IdentityModel.Tokens;
using ON.Fragments.Authorization.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Crypto.Service.Models
{
    public class AppSettings
    {
        public string DataStore { get; set; } = "/data";
        public string BitcoinBlockchainUrl { get; set; }

        public bool ContainsSecrets
        {
            get
            {
                if (string.IsNullOrWhiteSpace(BitcoinBlockchainUrl))
                    return false;
                return true;
            }
        }
    }
}
