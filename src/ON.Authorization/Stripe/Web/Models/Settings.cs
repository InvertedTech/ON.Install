using Microsoft.IdentityModel.Tokens;
using ON.Fragments.Authorization.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Stripe.Web.Models
{
    public class AppSettings
    {
        public string DataStore { get; set; } = "/data";
        public string StripeUrl { get; set; }
        public string StripeAccount { get; set; }
        public string StripeClientID { get; set; }
        public string StripeClientSecret { get; set; }
        public string StripeWebhookSecret { get; set; }

        public bool ContainsSecrets
        {
            get
            {
                if (string.IsNullOrWhiteSpace(StripeUrl))
                    return false;
                if (string.IsNullOrWhiteSpace(StripeAccount))
                    return false;
                if (string.IsNullOrWhiteSpace(StripeClientID))
                    return false;
                if (string.IsNullOrWhiteSpace(StripeClientSecret))
                    return false;
                if (string.IsNullOrWhiteSpace(StripeWebhookSecret))
                    return false;
                return true;
            }
        }
    }
}