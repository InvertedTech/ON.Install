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
        public string BitcoinBlockchainApiUrlSingleAddress { get; set; }
        public string BitcoinBlockchainApiUrlXPubAddress { get; set; }
        public string BitcoinXPub { get; set; }

        public bool ContainsSecrets
        {
            get
            {
                if (string.IsNullOrWhiteSpace(BitcoinXPub))
                    return false;
                return true;
            }
        }
    }
}
