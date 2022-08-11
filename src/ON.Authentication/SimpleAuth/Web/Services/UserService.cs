using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ON.Authentication.SimpleAuth.Web.Helper;
using ON.Authentication.SimpleAuth.Web.Models;
using ON.Fragments.Authentication;
using ON.Fragments.Generic;
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

        public async Task<ChangeOwnPasswordResponse.Types.ChangeOwnPasswordResponseErrorType> ChangePasswordCurrentUser(ChangePasswordViewModel vm)
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
                UserName = vm.UserName,
                DisplayName = vm.DisplayName,
                Password = vm.Password,
            };

            req.Emails.Add(vm.Email);

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.CreateUserAsync(req);

            return reply;
        }

        public async Task<UserNormalRecord> GetCurrentUser()
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

        public async Task<UserNormalRecord> GetOtherUser(Guid userId)
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.UserServiceChannel == null)
                return null;

            if (!User.IsAdminOrHigher)
                return null;

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.GetOtherUserAsync(new GetOtherUserRequest() { UserID = userId.ToString() }, GetMetadata());
            return reply.Record;
        }

        public async Task<IEnumerable<UserNormalRecord>> GetUserList()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.UserServiceChannel == null)
                return null;

            if (!User.IsAdminOrHigher)
                return null;

            var list = new List<UserNormalRecord>();

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            using var call = client.GetAllUsers(new(), GetMetadata());

            await foreach (var r in call.ResponseStream.ReadAllAsync())
            {
                list.Add(r.Record);
            }

            return list;
        }

        public async Task<ModifyOwnUserResponse> ModifyCurrentUser(SettingsViewModel vm)
        {
            if (!IsLoggedIn)
                return null;

            var res = await GetCurrentUser();

            var req = new ModifyOwnUserRequest()
            {
                UserID = res.Public.UserID,
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

            var res = await GetOtherUser(userId);

            var req = new ModifyOtherUserRequest()
            {
                UserID = res.Public.UserID,
                UserName = vm.UserName,
                DisplayName = vm.DisplayName,
            };
            req.Emails.Clear();
            req.Emails.Add(vm.Email);

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.ModifyOtherUserAsync(req, GetMetadata());
            if (reply.Error != "")
                return reply;

            List<string> roles = new();

            if (vm.IsOwner)
                roles.Add(ONUser.ROLE_OWNER);
            if (vm.IsAdmin)
                roles.Add(ONUser.ROLE_ADMIN);
            if (vm.IsContentPublisher)
                roles.Add(ONUser.ROLE_CONTENT_PUBLISHER);
            if (vm.IsContentWriter)
                roles.Add(ONUser.ROLE_CONTENT_WRITER);
            if (vm.IsCommentModerator)
                roles.Add(ONUser.ROLE_COMMENT_MODERATOR);
            if (vm.IsCommentAppelateJudge)
                roles.Add(ONUser.ROLE_COMMENT_APPELLATE_JUDGE);

            var req2 = new ModifyOtherUserRolesRequest()
            {
                UserID = res.Public.UserID,
            };
            req2.Roles.AddRange(roles);

            var reply2 = await client.ModifyOtherUserRolesAsync(req2, GetMetadata());

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
