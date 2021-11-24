using Microsoft.AspNetCore.Http;
using System;

namespace NodeF.Authentication
{
    public class NodeUserHelper
    {
        public readonly NodeUser MyUser;
        public readonly bool IsLoggedIn;
        public readonly Guid MyUserId;

        public NodeUserHelper(IHttpContextAccessor httpContextAccessor)
        {
            MyUser = ParseUser(httpContextAccessor.HttpContext);
            IsLoggedIn = MyUser != null;
            MyUserId = MyUser?.Id ?? Guid.Empty;
        }

        public static NodeUser ParseUser(HttpContext context)
        {
            var user = NodeUser.Parse(context.User.Claims);
            if (user != null)
                user.JwtToken = GrabToken(context);

            return user;
        }

        private static string GrabToken(HttpContext context)
        {
            string authorization = context.Request.Headers["Authorization"];

            if (string.IsNullOrWhiteSpace(authorization))
                return "";

            if (!authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                return "";

            return authorization.Substring(7).Trim();
        }
    }
}
