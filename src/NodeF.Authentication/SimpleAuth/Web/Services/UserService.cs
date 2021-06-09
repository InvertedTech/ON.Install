using Grpc.Core;
using Microsoft.AspNetCore.Http;
using NodeF.Authentication.SimpleAuth.Web.Helper;
using NodeF.Authentication.SimpleAuth.Web.Models;
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
                UserName = loginName,
                Password = password,
            });

            return reply.BearerToken;
        }

        public async Task<CreateUserResponse> CreateUser(RegisterViewModel vm)
        {
            var req = new CreateUserRequest
            {
                Password = vm.Password,
                Record = new UserRecord()
                {
                    Private = new UserRecord.Types.PrivateData(),
                    Public = new UserRecord.Types.PublicData()
                    {
                        UserID = Google.Protobuf.ByteString.CopyFrom(Guid.NewGuid().ToByteArray()),
                        UserName = vm.UserName,
                        DisplayName = vm.DisplayName
                    }
                }
            };

            req.Record.Private.Emails.Add(vm.Email);

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.CreateUserAsync(req);

            return reply;
        }
    }
}
