using Microsoft.Extensions.DependencyInjection;

namespace NodeF.Authentication
{
    public static class TokenAuthenticationExtensions
    {
        public static void UseTokenAuthentication(this IServiceCollection services)
        {
            services.AddSingleton<TokenService>();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = TokenAuthenticationSchemeOptions.Name;
                //                options.DefaultSignInScheme
            })
            .AddScheme<TokenAuthenticationSchemeOptions, TokenAuthenticationHandler>(
                TokenAuthenticationSchemeOptions.Name, option => { }
            );
        }
    }
}
