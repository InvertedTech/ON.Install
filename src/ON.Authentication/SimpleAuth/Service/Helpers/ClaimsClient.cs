using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ON.Fragments.Authentication;
using ON.Fragments.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authentication.SimpleAuth.Service.Helpers
{
    public class ClaimsClient
    {
        private readonly ILogger<ClaimsClient> logger;
        private readonly ServiceNameHelper nameHelper;
        public readonly ONUser User;

        public ClaimsClient(ServiceNameHelper nameHelper, ONUserHelper userHelper, ILogger<ClaimsClient> logger)
        {
            this.logger = logger;

            User = userHelper.MyUser;

            this.nameHelper = nameHelper;
        }

        public async Task<IEnumerable<ClaimRecord>> GetOtherClaims(Guid userId)
        {
            List<Channel> channels = new List<Channel>();
            channels.Add(nameHelper.FakePaymentServiceChannel);
            channels.Add(nameHelper.PaypalServiceChannel);
            channels.Add(nameHelper.StripeServiceChannel);

            var tasks = channels.Select(c => GetOtherClaims(userId, c));

            await Task.WhenAll(tasks);

            return tasks.SelectMany(t => t.Result);
        }

        private async Task<IEnumerable<ClaimRecord>> GetOtherClaims(Guid userId, Channel channel)
        {
            try
            {
                var client = new ClaimsInterface.ClaimsInterfaceClient(channel);
                var reply = await client.GetClaimsAsync(new GetClaimsRequest()
                {
                    UserID = Google.Protobuf.ByteString.CopyFrom(userId.ToByteArray())
                });

                return reply.Claims;
            }
            catch (Exception ex)
            {

            }

            return new ClaimRecord[0];
        }
    }
}
