using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NodeF.Fragments.Authentcation;
using NodeF.Fragments.Generic;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace NodeF.Authentication.SimpleAuth.Service.Services
{
    public class UserService : UserInterface.UserInterfaceBase
    {
        private readonly ILogger<ServiceOpsService> logger;
        private readonly SigningCredentials creds;
        public UserService(ILogger<ServiceOpsService> logger)
        {
            this.logger = logger;

            creds = new SigningCredentials(JwtValidatorMiddleware.GetPrivateKey(), SecurityAlgorithms.EcdsaSha256);
        }

        public override Task<AuthenticatUserResponse> AuthenticatUser(AuthenticatUserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AuthenticatUserResponse()
            {
                BearerToken = GenerateToken(new NodeUser() {
                    Id = Guid.NewGuid(),
                    DisplayName = "Test User",
                })
            });;
        }

        private string GenerateToken(NodeUser user)
        {
            user.ToClaims();

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
        };
            foreach (var c in user.ToClaims())
                tokenDescriptor.Claims.Add(c.Type, c.Value);

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
