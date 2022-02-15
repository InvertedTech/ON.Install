using Microsoft.IdentityModel.Tokens;
using ON.Fragments.Authorization.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Paypal.Service.Models
{
    public class AppSettings
    {
        public string DataStore { get; set; } = "/data";
        public string PaypalUrl { get; set; }
        public string PaypalAccount { get; set; }
        public string PaypalClientID { get; set; }
        public string PaypalClientSecret { get; set; }

        public bool ContainsSecrets
        {
            get
            {
                if (string.IsNullOrWhiteSpace(PaypalUrl))
                    return false;
                if (string.IsNullOrWhiteSpace(PaypalAccount))
                    return false;
                if (string.IsNullOrWhiteSpace(PaypalClientID))
                    return false;
                if (string.IsNullOrWhiteSpace(PaypalClientSecret))
                    return false;
                return true;
            }
        }
    }
}
