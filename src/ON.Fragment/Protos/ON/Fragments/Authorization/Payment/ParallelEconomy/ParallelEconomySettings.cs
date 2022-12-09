using System;
using pb = global::Google.Protobuf;

namespace ON.Fragments.Authorization.Payment.ParallelEconomy
{
    public sealed partial class ParallelEconomyPublicSettings : pb::IMessage<ParallelEconomyPublicSettings>
    {
        public bool IsValid => true;
    }
    public sealed partial class ParallelEconomyOwnerSettings : pb::IMessage<ParallelEconomyOwnerSettings>
    {
        public bool IsValid => !string.IsNullOrWhiteSpace(UserId)
                            && !string.IsNullOrWhiteSpace(UserApiKey)
                            && !string.IsNullOrWhiteSpace(LocationId)
                            && !string.IsNullOrWhiteSpace(ProductId);
    }
}
