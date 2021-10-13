using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace NodeF.Authentication
{
    public class TokenAuthenticationHandler : AuthenticationHandler<TokenAuthenticationSchemeOptions>
    {
        public const string JWT_COOKIE_NAME = "token";

        public TokenAuthenticationHandler(IOptionsMonitor<TokenAuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            TokenService tokenService
            ) : base(options, logger, encoder, clock)
        {
            _tokenService = tokenService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string authToken = GetTokenFromHeaderOrCookie();
            if (string.IsNullOrEmpty(authToken))
            {
                return Task.FromResult(AuthenticateResult.Fail("Authorization header not found"));
            }

            AuthenticationTicket authTicket = _tokenService.ValidateToken(authToken);
            if (authTicket == null)
            {
                return Task.FromResult(AuthenticateResult.Fail(""));
            }

            return Task.FromResult(AuthenticateResult.Success(authTicket));
        }

        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Redirect("/login");
            return Task.CompletedTask;
        }

        private string GetTokenFromHeaderOrCookie()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")?.Last();
            if (token != null)
                return token;

            return Request.Cookies[JWT_COOKIE_NAME];
        }

        private TokenService _tokenService;
        private const string AUTHORIZATION_TOKEN_HEADER = "AuthToken";
    }
}