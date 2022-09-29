using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ON.Authentication.SimpleAuth.Service.Data;
using ON.Authentication.SimpleAuth.Service.Helpers;
using ON.Fragments.Authentication;
using ON.Fragments.Authorization;
using ON.Fragments.Content;
using ON.Fragments.Generic;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ON.Authentication.SimpleAuth.Service.Services
{
    [AllowAnonymous]
    public class ServiceService : ServiceInterface.ServiceInterfaceBase
    {
        private readonly OfflineHelper offlineHelper;
        private readonly ILogger<ServiceOpsService> logger;
        private readonly SigningCredentials creds;
        private readonly IUserDataProvider dataProvider;
        private readonly ClaimsClient claimsClient;
        private static readonly HashAlgorithm hasher = SHA256.Create();

        public ServiceService(OfflineHelper offlineHelper, ILogger<ServiceOpsService> logger, IUserDataProvider dataProvider, ClaimsClient claimsClient)
        {
            this.offlineHelper = offlineHelper;
            this.logger = logger;
            this.dataProvider = dataProvider;
            this.claimsClient = claimsClient;

            creds = new SigningCredentials(JwtExtensions.GetPrivateKey(), SecurityAlgorithms.EcdsaSha256);
        }

        [AllowAnonymous]
        public override Task<AuthenticateServiceResponse> AuthenticateService(AuthenticateServiceRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AuthenticateServiceResponse()
            {
                BearerToken = GenerateToken(),
            });
        }

        private string GenerateToken()
        {
            var onUser = new ONUser()
            {
                Id = Guid.NewGuid(),
                UserName = "service_acct",
                DisplayName = "",
            };

            onUser.Roles.Add(ONUser.ROLE_SERVICE);

            return GenerateToken(onUser);
        }

        private string GenerateToken(ONUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = creds
            };

            tokenDescriptor.Claims = new Dictionary<string, object>();

            foreach (var c in user.ToClaims())
                tokenDescriptor.Claims.Add(c.Type, c.Value);

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
