using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Fragments.Authentication;
using ON.SimpleWeb.Models.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ON.Settings;
using Google.Protobuf;
using System.IO;
using ON.SimpleWeb.Models.Auth.Admin;

namespace ON.SimpleWeb.Services
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

        public async Task<string> AuthenticateUser(string loginName, string password, string mfaCode)
        {
            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.AuthenticateUserAsync(new AuthenticateUserRequest
            {
                UserName = loginName ?? "",
                Password = password ?? "",
                MFACode = mfaCode ?? "",
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

        public async Task<ChangeOtherPasswordResponse.Types.ChangeOtherPasswordResponseErrorType> ChangePasswordOtherUser(Guid userId, ChangeOtherPasswordViewModel vm)
        {
            var req = new ChangeOtherPasswordRequest()
            {
                UserID = userId.ToString(),
                NewPassword = vm.NewPassword,
            };

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.ChangeOtherPasswordAsync(req, GetMetadata());
            return reply.Error;
        }

        public async Task<ChangeOwnProfileImageResponse> ChangeProfilePicture(Stream stream)
        {
            var req = new ChangeOwnProfileImageRequest()
            {
                ProfileImage = await ByteString.FromStreamAsync(stream)
            };

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.ChangeOwnProfileImageAsync(req, GetMetadata());

            return reply;
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

        public async Task<DisableOtherTotpResponse> DisableOtherTotp(Guid userId, Guid totpId)
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.UserServiceChannel == null)
                return null;

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.DisableOtherTotpAsync(new() { UserID = userId.ToString(), TotpID = totpId.ToString() }, GetMetadata());
            return reply;
        }

        public async Task<DisableOwnTotpResponse> DisableOwnTotp(Guid totpId)
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.UserServiceChannel == null)
                return null;

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.DisableOwnTotpAsync(new() { TotpID = totpId.ToString() }, GetMetadata());
            return reply;
        }

        public async Task<GenerateOtherTotpResponse> GenerateOtherTotp(string deviceName)
        {
            var req = new GenerateOtherTotpRequest
            {
                DeviceName = deviceName,
            };

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.GenerateOtherTotpAsync(req, GetMetadata());

            return reply;
        }

        public async Task<GenerateOwnTotpResponse> GenerateOwnTotp(string deviceName)
        {
            var req = new GenerateOwnTotpRequest
            {
                DeviceName = deviceName,
            };

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.GenerateOwnTotpAsync(req, GetMetadata());

            return reply;
        }

        public async Task<GetOtherTotpListResponse> GetOtherTotp(Guid userId)
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.UserServiceChannel == null)
                return null;

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.GetOtherTotpListAsync(new() { UserID = userId.ToString() }, GetMetadata());
            return reply;
        }

        public async Task<GetOwnTotpListResponse> GetOwnTotp()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.UserServiceChannel == null)
                return null;

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.GetOwnTotpListAsync(new(), GetMetadata());
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

        public async Task<UserNormalRecord> GetOtherUser(string userId)
        {
            if (Guid.TryParse(userId, out var id))
                return await GetOtherUser(id);

            return null;
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

        public async Task<UserPublicRecord> GetUserPublic(string userId)
        {
            try
            {
                var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
                var reply = await client.GetOtherPublicUserAsync(new() { UserID = userId }, GetMetadata());
                return reply.Record;
            }
            catch
            {
                return null;
            }
        }

        public async Task<UserIdRecord[]> GetUserIdList()
        {
            var list = new List<UserIdRecord>();

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var res = await client.GetUserIdListAsync(new(), GetMetadata());

            foreach (var r in res.Records)
                list.Add(r);

            return list.ToArray();
        }

        public async Task<UserNormalRecord[]> GetUserList()
        {
            if (!IsLoggedIn)
                return null;

            if (nameHelper.UserServiceChannel == null)
                return null;

            if (!User.IsAdminOrHigher)
                return null;

            var list = new List<UserNormalRecord>();

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var res = await client.GetAllUsersAsync(new(), GetMetadata());

            foreach (var r in res.Records)
                list.Add(r);

            return list.ToArray();
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

        public async Task<ModifyOtherUserResponse> ModifyOtherUser(Guid userId, Models.Auth.Admin.EditUserViewModel vm)
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

            await client.ModifyOtherUserRolesAsync(req2, GetMetadata());

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

        public async Task<VerifyOtherTotpResponse> VerifyOtherTotp(Guid userID, Guid totpID, string code)
        {
            var req = new VerifyOtherTotpRequest
            {
                UserID = userID.ToString(),
                TotpID = totpID.ToString(),
                Code = code,
            };

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.VerifyOtherTotpAsync(req, GetMetadata());

            return reply;
        }

        public async Task<VerifyOwnTotpResponse> VerifyOwnTotp(Guid totpID, string code)
        {
            var req = new VerifyOwnTotpRequest
            {
                TotpID = totpID.ToString(),
                Code = code,
            };

            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = await client.VerifyOwnTotpAsync(req, GetMetadata());

            return reply;
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            if (User != null && !string.IsNullOrWhiteSpace(User.JwtToken))
                data.Add("Authorization", "Bearer " + User.JwtToken);

            return data;
        }
    }
}
