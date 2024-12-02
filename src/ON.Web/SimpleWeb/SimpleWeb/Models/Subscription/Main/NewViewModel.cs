using ON.Authentication;
using ON.Fragments.Authentication;
using ON.Fragments.Authorization.Payment;
using ON.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.Subscription.Main
{
    public class NewViewModel
    {
        private readonly SettingsClient settingsClient;

        private NewViewModel(uint amountCents, SettingsClient settingsClient)
        {
            AmountCents = amountCents;
            this.settingsClient = settingsClient;
        }

        public static NewViewModel Create(uint amountCents, SettingsClient settingsClient) => new NewViewModel(amountCents, settingsClient);

        public uint AmountCents { get; set; }
        public GetNewDetailsResponse Methods { get; internal set; }

        public bool ShowFake => settingsClient?.PublicData?.Subscription?.Fake?.Enabled ?? false;
        public bool ShowPaypal => (settingsClient?.PublicData?.Subscription?.Paypal?.Enabled ?? false) && Methods?.Paypal != null;
        public bool ShowStripe => (settingsClient?.PublicData?.Subscription?.Stripe?.Enabled ?? false) && Methods?.Stripe != null;
    }
}
