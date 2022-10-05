using pb = global::Google.Protobuf;

namespace ON.Fragments.Authorization.Payments.Paypal
{
    public sealed partial class PaypalSettings : pb::IMessage<PaypalSettings>
    {
        public bool IsValid =>
            (!string.IsNullOrWhiteSpace(Url)) &&
            (!string.IsNullOrWhiteSpace(ClientID)) &&
            (!string.IsNullOrWhiteSpace(ClientSecret));
    }
}
