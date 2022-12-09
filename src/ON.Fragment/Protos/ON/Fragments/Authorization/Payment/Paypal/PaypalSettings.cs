using System;
using pb = global::Google.Protobuf;

namespace ON.Fragments.Authorization.Payment.Paypal
{
    public sealed partial class PaypalPublicSettings : pb::IMessage<PaypalPublicSettings>
    {
        public bool IsValid =>
            (!string.IsNullOrWhiteSpace(Url)) &&
            (!string.IsNullOrWhiteSpace(ClientID));
    }
    public sealed partial class PaypalOwnerSettings : pb::IMessage<PaypalOwnerSettings>
    {
        public bool IsValid => !string.IsNullOrWhiteSpace(ClientSecret);
    }
}
