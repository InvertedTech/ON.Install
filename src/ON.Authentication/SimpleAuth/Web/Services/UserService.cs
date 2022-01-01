using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ON.Authentication.SimpleAuth.Web.Helper;
using ON.Authentication.SimpleAuth.Web.Models;
using ON.Fragment.Protos.ON.Fragments.Generic;
using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authentication.SimpleAuth.Web.Services
{
    public class UserService
    {
        private readonly ILogger<UserService> logger;
        private readonly ServiceNameHelper nameHelper;
        public readonly ONUser User;

        public UserService(ServiceNameHelper nameHelper, ONUserHelper userHelper, ILogger<UserService> logger)
        {
            this.logger = logger;

            User = userHelper.MyUser;

            this.nameHelper = nameHelper;
        }

        public bool IsLoggedIn { get => User != null; }

        public async Task<string> AuthenticateUser(string loginName, string password)
        {
            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.AuthenticateUserAsync(new AuthenticateUserRequest {
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

        public async Task<UserRecord> GetOtherUser(Guid userId)
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.UserServiceChannel == null)
                return null;

            if (!User.IsAdmin)
                return null;

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.GetOtherUserAsync(new GetOtherUserRequest() { UserID = userId.ToByteString() }, GetMetadata());
            return reply.Record;
        }

        public async Task<UserRecord.Types.PublicData[]> GetUserList()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.UserServiceChannel == null)
                return null;

            if (!User.IsAdmin)
                return null;

            var list = new List<UserRecord.Types.PublicData>();

            var client = new BackupInterface.BackupInterfaceClient(nameHelper.UserServiceChannel);
            using var call = client.ExportUsers(new ExportUsersRequest(), GetMetadata());

            await foreach (var r in call.ResponseStream.ReadAllAsync())
            {
                list.Add(r.ContentRecord);
            }

            return list.ToArray();
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

        public async Task<ModifyOtherUserResponse> ModifyOtherUser(Guid userId, Models.Admin.EditUserViewModel vm)
        {
            if (!IsLoggedIn)
                return null;

            var req = new ModifyOtherUserRequest()
            {
                UserID = userId.ToByteString(),
                UserName = vm.UserName,
                DisplayName = vm.DisplayName,
            };
            req.Emails.Add(vm.Email);

            if (vm.IsAdmin)
                req.Roles.Add(ONUser.ROLE_ADMIN);
            if (vm.IsPublisher)
                req.Roles.Add(ONUser.ROLE_PUBLISHER);
            if (vm.IsWriter)
                req.Roles.Add(ONUser.ROLE_WRITER);

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.ModifyOtherUserAsync(req, GetMetadata());
            return reply;
        }

        public async Task<string> RenewToken()
        {
            if (!IsLoggedIn)
                return null;

            var req = new RenewTokenRequest();

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.RenewTokenAsync(req, GetMetadata());
            return reply?.BearerToken;
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + User.JwtToken);

            return data;
        }
    }
}
