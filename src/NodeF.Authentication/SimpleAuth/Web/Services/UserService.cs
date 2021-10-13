using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UserService> logger;
        private readonly ServiceNameHelper nameHelper;
        public readonly NodeUser User;

        public UserService(ServiceNameHelper nameHelper, NodeUserHelper userHelper, ILogger<UserService> logger)
        {
            this.logger = logger;

            User = userHelper.MyUser;

            this.nameHelper = nameHelper;
        }

        public bool IsLoggedIn { get => User != null; }

        public async Task<string> AuthenticateUser(string loginName, string password)
        {
            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.AuthenticatUserAsync(new AuthenticatUserRequest {
                UserName = loginName,
                Password = password,
            });

            return reply.BearerToken;
        }

        public async Task<ChangeOwnPasswordResponse.Types.ErrorType> ChangePasswordCurrentUser(ChangePasswordViewModel vm)
        {
            var req = new ChangeOwnPasswordRequest()
            {
                OldPassword = vm.OldPassword,
                NewPassword = vm.NewPassword
            };

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.ChangeOwnPasswordAsync(req, GetMetadata());
            return reply.Error;
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

        public async Task<UserRecord> GetCurrentUser()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.UserServiceChannel == null)
                return null;

            logger.LogWarning($"******Trying to hopefully connect to AuthService at:({nameHelper.UserServiceChannel.Target})******");


            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.GetOwnUserAsync(new GetOwnUserRequest(), GetMetadata());
            return reply.Record;
        }

        public async Task<ModifyOwnUserResponse> ModifyCurrentUser(SettingsViewModel vm)
        {
            if (!IsLoggedIn)
                return null;

            var req = new ModifyOwnUserRequest()
            {
                DisplayName = vm.DisplayName,
            };
            req.Emails.Add(vm.Email);

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.ModifyOwnUserAsync(req, GetMetadata());
            return reply;
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + User.JwtToken);

            return data;
        }
    }
}
