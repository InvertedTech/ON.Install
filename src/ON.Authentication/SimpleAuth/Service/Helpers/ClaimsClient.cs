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
            channels.Add(nameHelper.PaymentServiceChannel);

            var tasks = channels.Select(c => GetOtherClaims(userId, c));

            await Task.WhenAll(tasks);

            Dictionary<string, ClaimRecord> dict = new Dictionary<string, ClaimRecord>();

            foreach(var t in tasks)
            {
                foreach (var claim in await t)
                {
                    if (!dict.ContainsKey(claim.Name))
                    {
                        dict[claim.Name] = claim;
                        continue;
                    }

                    if (dict[claim.Name].ExpiresOnUTC < claim.ExpiresOnUTC)
                    {
                        dict[claim.Name] = claim;
                    }
                }
            }

            return dict.Values;
        }

        private async Task<IEnumerable<ClaimRecord>> GetOtherClaims(Guid userId, Channel channel)
        {
            if (channel == null)
                return new ClaimRecord[0];

            try
            {
                var client = new ClaimsInterface.ClaimsInterfaceClient(channel);
                var reply = await client.GetClaimsAsync(new GetClaimsRequest()
                {
                    UserID = userId.ToString()
                });

                return reply.Claims;
            }
            catch (Exception)
            {

            }

            return new ClaimRecord[0];
        }
    }
}
