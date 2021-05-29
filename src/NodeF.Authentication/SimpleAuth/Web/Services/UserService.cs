using Grpc.Core;
using Microsoft.AspNetCore.Http;
using NodeF.Authentication.SimpleAuth.Web.Helper;
using NodeF.Fragments.Authentcation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authentication.SimpleAuth.Web.Services
{
    public class UserService
    {
        private readonly HttpContext httpContext;
        private readonly ServiceNameHelper nameHelper;
        private readonly NodeUser user;

        public UserService(IHttpContextAccessor httpContextAccessor, ServiceNameHelper nameHelper)
        {
            httpContext = httpContextAccessor.HttpContext;
            user = httpContextAccessor.HttpContext.User as NodeUser;

            this.nameHelper = nameHelper;
        }

        public async Task<string> AuthenticateUser(string loginName, string password)
        {
            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.AuthenticatUserAsync(new AuthenticatUserRequest {
                LoginName = loginName,
                Password = password,
            });

            return reply.BearerToken;
        }
    }
}
