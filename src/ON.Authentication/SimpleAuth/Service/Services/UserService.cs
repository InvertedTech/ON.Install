using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ON.Authentication.SimpleAuth.Service.Data;
using ON.Authentication.SimpleAuth.Service.Helpers;
using ON.Fragments.Authentication;
using ON.Fragments.Authorization;
using ON.Fragments.Content;
using ON.Fragments.Generic;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ON.Authentication.SimpleAuth.Service.Services
{
    [Authorize]
    public class UserService : UserInterface.UserInterfaceBase
    {
        private readonly OfflineHelper offlineHelper;
        private readonly ILogger<ServiceOpsService> logger;
        private readonly SigningCredentials creds;
        private readonly IUserDataProvider dataProvider;
        private readonly ClaimsClient claimsClient;
        private static readonly HashAlgorithm hasher = SHA256.Create();

        public UserService(OfflineHelper offlineHelper, ILogger<ServiceOpsService> logger, IUserDataProvider dataProvider, ClaimsClient claimsClient)
        {
            this.offlineHelper = offlineHelper;
            this.logger = logger;
            this.dataProvider = dataProvider;
            this.claimsClient = claimsClient;

            creds = new SigningCredentials(JwtExtensions.GetPrivateKey(), SecurityAlgorithms.EcdsaSha256);

            if (Program.IsDevelopment)
            {
                EnsureDevOwnerLogin().Wait();
            }
        }

        [AllowAnonymous]
        public override async Task<AuthenticateUserResponse> AuthenticateUser(AuthenticateUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new AuthenticateUserResponse();

            if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
                return new AuthenticateUserResponse();

            var user = await dataProvider.GetByLogin(request.UserName);
            if (user == null)
                return new AuthenticateUserResponse();

            bool isCorrect = await IsPasswordCorrect(request.Password, user);

            if (!isCorrect)
                return new AuthenticateUserResponse();

            var otherClaims = await claimsClient.GetOtherClaims(user.UserIDGuid);

            return new AuthenticateUserResponse()
            {
                BearerToken = GenerateToken(user.Normal, otherClaims),
                UserRecord = user.Normal,
            };
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<ChangeOtherPasswordResponse> ChangeOtherPassword(ChangeOtherPasswordRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new ChangeOtherPasswordResponse { Error = ChangeOtherPasswordResponse.Types.ChangeOtherPasswordResponseErrorType.UnknownError };

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new ChangeOtherPasswordResponse { Error = ChangeOtherPasswordResponse.Types.ChangeOtherPasswordResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.GetById(request.UserID.ToGuid());
                if (record == null)
                    return new ChangeOtherPasswordResponse { Error = ChangeOtherPasswordResponse.Types.ChangeOtherPasswordResponseErrorType.UserNotFound };

                byte[] salt = RandomNumberGenerator.GetBytes(16);
                record.Server.PasswordSalt = ByteString.CopyFrom(salt);
                record.Server.PasswordHash = ByteString.CopyFrom(ComputeSaltedHash(request.NewPassword, salt));

                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new ChangeOtherPasswordResponse { Error = ChangeOtherPasswordResponse.Types.ChangeOtherPasswordResponseErrorType.NoError };
            }
            catch
            {
                return new ChangeOtherPasswordResponse { Error = ChangeOtherPasswordResponse.Types.ChangeOtherPasswordResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<ChangeOtherProfileImageResponse> ChangeOtherProfileImage(ChangeOtherProfileImageRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new ChangeOtherProfileImageResponse { Error = ChangeOtherProfileImageResponse.Types.ChangeOtherProfileImageResponseErrorType.UnknownError };

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new() { Error = ChangeOtherProfileImageResponse.Types.ChangeOtherProfileImageResponseErrorType.UnknownError };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.GetById(request.UserID.ToGuid());
                if (record == null)
                    return new() { Error = ChangeOtherProfileImageResponse.Types.ChangeOtherProfileImageResponseErrorType.UnknownError };

                if (request?.ProfileImage == null || request.ProfileImage.IsEmpty)
                    return new() { Error = ChangeOtherProfileImageResponse.Types.ChangeOtherProfileImageResponseErrorType.BadFormat };



                using var ms = new MemoryStream();
                ms.Write(request.ProfileImage.ToArray());
                ms.Position = 0;
                using var image = SKBitmap.Decode(ms);

                if (image == null)
                    return new ChangeOtherProfileImageResponse { Error = ChangeOtherProfileImageResponse.Types.ChangeOtherProfileImageResponseErrorType.BadFormat };

                var newInfo = image.Info;
                newInfo.Width = 200;
                newInfo.Height = 200;
                using var newImage = image.Resize(newInfo, SKFilterQuality.Medium);


                using MemoryStream memStream = new MemoryStream();
                using SKManagedWStream wstream = new SKManagedWStream(memStream);

                newImage.Encode(wstream, SKEncodedImageFormat.Png, 50);

                record.Normal.Public.Data.ProfileImagePNG = ByteString.CopyFrom(memStream.ToArray());

                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new ChangeOtherProfileImageResponse { Error = ChangeOtherProfileImageResponse.Types.ChangeOtherProfileImageResponseErrorType.NoError };
            }
            catch
            {
                return new ChangeOtherProfileImageResponse { Error = ChangeOtherProfileImageResponse.Types.ChangeOtherProfileImageResponseErrorType.BadFormat };
            }
        }

        public override async Task<ChangeOwnPasswordResponse> ChangeOwnPassword(ChangeOwnPasswordRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new ChangeOwnPasswordResponse { Error = ChangeOwnPasswordResponse.Types.ChangeOwnPasswordResponseErrorType.UnknownError };

            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new ChangeOwnPasswordResponse { Error = ChangeOwnPasswordResponse.Types.ChangeOwnPasswordResponseErrorType.UnknownError };

                var record = await dataProvider.GetById(userToken.Id);
                if (record == null)
                    return new ChangeOwnPasswordResponse { Error = ChangeOwnPasswordResponse.Types.ChangeOwnPasswordResponseErrorType.UnknownError };

                var hash = ComputeSaltedHash(request.OldPassword, record.Server.PasswordSalt.Span);
                if (!CryptographicOperations.FixedTimeEquals(record.Server.PasswordHash.Span, hash))
                    return new ChangeOwnPasswordResponse { Error = ChangeOwnPasswordResponse.Types.ChangeOwnPasswordResponseErrorType.BadOldPassword };

                byte[] salt = RandomNumberGenerator.GetBytes(16);
                record.Server.PasswordSalt = ByteString.CopyFrom(salt);
                record.Server.PasswordHash = ByteString.CopyFrom(ComputeSaltedHash(request.NewPassword, salt));

                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new ChangeOwnPasswordResponse { Error = ChangeOwnPasswordResponse.Types.ChangeOwnPasswordResponseErrorType.NoError };
            }
            catch
            {
                return new ChangeOwnPasswordResponse { Error = ChangeOwnPasswordResponse.Types.ChangeOwnPasswordResponseErrorType.UnknownError };
            }
        }

        public override async Task<ChangeOwnProfileImageResponse> ChangeOwnProfileImage(ChangeOwnProfileImageRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new() { Error = ChangeOwnProfileImageResponse.Types.ChangeOwnProfileImageResponseErrorType.UnknownError };

            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = ChangeOwnProfileImageResponse.Types.ChangeOwnProfileImageResponseErrorType.UnknownError };

                var record = await dataProvider.GetById(userToken.Id);
                if (record == null)
                    return new() { Error = ChangeOwnProfileImageResponse.Types.ChangeOwnProfileImageResponseErrorType.UnknownError };

                using var ms = new MemoryStream();
                ms.Write(request.ProfileImage.ToArray());
                ms.Position = 0;
                using var image = SKBitmap.Decode(ms);

                if (image == null)
                    return new() { Error = ChangeOwnProfileImageResponse.Types.ChangeOwnProfileImageResponseErrorType.BadFormat };

                var newInfo = image.Info;
                newInfo.Width = 200;
                newInfo.Height = 200;
                using var newImage = image.Resize(newInfo, SKFilterQuality.Medium);


                using MemoryStream memStream = new MemoryStream();
                using SKManagedWStream wstream = new SKManagedWStream(memStream);

                newImage.Encode(wstream, SKEncodedImageFormat.Png, 50);

                record.Normal.Public.Data.ProfileImagePNG = ByteString.CopyFrom(memStream.ToArray());

                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = ChangeOwnProfileImageResponse.Types.ChangeOwnProfileImageResponseErrorType.NoError };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in ChangeOwnProfileImage");
                return new() { Error = ChangeOwnProfileImageResponse.Types.ChangeOwnProfileImageResponseErrorType.BadFormat };
            }
        }

        [AllowAnonymous]
        public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new() { Error = CreateUserResponse.Types.CreateUserResponseErrorType.UnknownError };

            if (request == null)
                return new() { Error = CreateUserResponse.Types.CreateUserResponseErrorType.UnknownError };

            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

            var newGuid = Guid.NewGuid();
            var now = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

            var user = new UserRecord()
            {
                Normal = new()
                {
                    Public = new()
                    {
                        UserID = newGuid.ToString(),
                        CreatedOnUTC = now,
                        ModifiedOnUTC = now,
                        Data = new()
                        {
                            UserName = request.UserName,
                            DisplayName = request.DisplayName,
                            Bio = request.Bio,
                        },
                    },
                    Private = new()
                    {
                        CreatedBy = (userToken?.Id ?? newGuid).ToString(),
                        ModifiedBy = (userToken?.Id ?? newGuid).ToString(),
                        Data = new()
                        {
                        },
                    },
                },
                Server = new()
                {
                }
            };
            user.Normal.Private.Data.Emails.AddRange(request.Emails);

            byte[] salt = RandomNumberGenerator.GetBytes(16);
            user.Server.PasswordSalt = ByteString.CopyFrom(salt);
            user.Server.PasswordHash = ByteString.CopyFrom(ComputeSaltedHash(request.Password, salt));

            if (!IsValid(user.Normal))
                return new CreateUserResponse
                {
                    Error = CreateUserResponse.Types.CreateUserResponseErrorType.UnknownError
                };

            if (await dataProvider.Exists(user.Normal.Public.Data.UserName))
                return new CreateUserResponse
                {
                    Error = CreateUserResponse.Types.CreateUserResponseErrorType.UserNameTaken
                };

            var res = await dataProvider.Create(user);
            if (!res)
                return new CreateUserResponse
                {
                    Error = CreateUserResponse.Types.CreateUserResponseErrorType.UnknownError
                };

            return new CreateUserResponse
            {
                BearerToken = GenerateToken(user.Normal, null)
            };
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<DisableEnableOtherUserResponse> DisableOtherUser(DisableEnableOtherUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new() { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new() { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.GetById(request.UserID.ToGuid());
                if (record == null)
                    return new() { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };

                record.Normal.Public.DisabledOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Private.DisabledBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new() { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.NoError };
            }
            catch
            {
                return new() { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<DisableEnableOtherUserResponse> EnableOtherUser(DisableEnableOtherUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var record = await dataProvider.GetById(request.UserID.ToGuid());
                if (record == null)
                    return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };

                record.Normal.Public.DisabledOnUTC = null;
                record.Normal.Private.DisabledBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.NoError };
            }
            catch
            {
                return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<GetAllUsersResponse> GetAllUsers(GetAllUsersRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new();

            List<UserNormalRecord> list = new();

            var ret = new GetAllUsersResponse();
            try
            {
                if (!await AmIReallyAdmin(context))
                    return ret;
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                await foreach (var r in dataProvider.GetAll())
                    list.Add(r.Normal);
            }
            catch
            {
            }

            ret.Records.AddRange(list.OrderByDescending(r => r.Public.Data.UserName));
            ret.PageTotalItems = (uint)ret.Records.Count;

            if (request.PageSize > 0)
            {
                var page = ret.Records.Skip((int)request.PageOffset).Take((int)request.PageSize).ToList();
                ret.Records.Clear();
                ret.Records.AddRange(page);
            }

            ret.PageOffsetStart = request.PageOffset;
            ret.PageOffsetEnd = ret.PageOffsetStart + (uint)ret.Records.Count;


            return ret;
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task GetListOfOldUserIDs(GetListOfOldUserIDsRequest request, IServerStreamWriter<GetListOfOldUserIDsResponse> responseStream, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return;

            if (!await AmIReallyAdmin(context))
                return;

            try
            {
                await foreach (var r in dataProvider.GetAll())
                {
                    if (r.Normal.Private.Data.OldUserID != "")
                        await responseStream.WriteAsync(new()
                        {
                            UserID = r.Normal.Public.UserID,
                            OldUserID = r.Normal.Private.Data.OldUserID,
                            ModifiedOnUTC = r.Normal.Public.ModifiedOnUTC,
                        });
                }
            }
            catch
            {
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<GetOtherUserResponse> GetOtherUser(GetOtherUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new();

            if (!await AmIReallyAdmin(context))
                return new();

            var record = await dataProvider.GetById(request.UserID.ToGuid());

            return new() { Record = record?.Normal };
        }

        [AllowAnonymous]
        public override async Task<GetOtherPublicUserResponse> GetOtherPublicUser(GetOtherPublicUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new();

            var record = await dataProvider.GetById(request.UserID.ToGuid());

            return new() { Record = record?.Normal.Public };
        }

        public override async Task<GetOwnUserResponse> GetOwnUser(GetOwnUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new();

            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new();

            var record = await dataProvider.GetById(userToken.Id);

            return new() { Record = record?.Normal };
        }

        [AllowAnonymous]
        public async override Task<GetUserIdListResponse> GetUserIdList(GetUserIdListRequest request, ServerCallContext context)
        {
            var ret = new GetUserIdListResponse();
            try
            {
                await foreach (var r in dataProvider.GetAll())
                    ret.Records.Add(new UserIdRecord()
                    {
                        UserID = r.Normal.Public.UserID,
                        DisplayName = r.Normal.Public.Data.DisplayName,
                        UserName = r.Normal.Public.Data.UserName,
                    });
            }
            catch
            {
            }

            return ret;
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<ModifyOtherUserResponse> ModifyOtherUser(ModifyOtherUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new() { Error = "Service Offline" };

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new() { Error = "Not an admin" };
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var userId = request.UserID.ToGuid();
                var record = await dataProvider.GetById(userId);
                if (record == null)
                    return new() { Error = "User not found" };


                if (!IsUserNameValid(request.UserName))
                    return new() { Error = "User Name not valid" };

                if (!IsDisplayNameValid(request.DisplayName))
                    return new() { Error = "Display Name not valid" };

                if (record.Normal.Public.Data.UserName != request.UserName)
                {
                    if (!await dataProvider.ChangeLoginIndex(record.Normal.Public.Data.UserName, request.UserName, userId))
                        return new ModifyOtherUserResponse() { Error = "User Name taken" };

                    record.Normal.Public.Data.UserName = request.UserName;
                }

                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Public.Data.DisplayName = request.DisplayName;
                record.Normal.Public.Data.Bio = request.Bio;

                record.Normal.Private.ModifiedBy = userToken.Id.ToString();
                record.Normal.Private.Data.Emails.Clear();
                record.Normal.Private.Data.Emails.AddRange(request.Emails);

                await dataProvider.Save(record);

                return new();
            }
            catch
            {
                return new() { Error = "Unknown error" };
            }
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<ModifyOtherUserRolesResponse> ModifyOtherUserRoles(ModifyOtherUserRolesRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new() { Error = "Service Offline" };

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new() { Error = "Not an admin" };
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

                var userId = request.UserID.ToGuid();
                var record = await dataProvider.GetById(userId);
                if (record == null)
                    return new() { Error = "User not found" };


                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                record.Normal.Private.ModifiedBy = userToken.Id.ToString();
                record.Normal.Private.Roles.Clear();
                record.Normal.Private.Roles.AddRange(request.Roles);

                await dataProvider.Save(record);

                return new();
            }
            catch
            {
                return new() { Error = "Unknown error" };
            }
        }

        public override async Task<ModifyOwnUserResponse> ModifyOwnUser(ModifyOwnUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new ModifyOwnUserResponse() { Error = "Service Offline" };

            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new ModifyOwnUserResponse() { Error = "No user token specified" };

                var record = await dataProvider.GetById(userToken.Id);
                if (record == null)
                    return new ModifyOwnUserResponse() { Error = "User not found" };

                if (!IsDisplayNameValid(request.DisplayName))
                    return new ModifyOwnUserResponse() { Error = "Display Name not valid" };

                record.Normal.Public.Data.DisplayName = request.DisplayName;
                record.Normal.Public.Data.Bio = request.Bio;
                record.Normal.Private.Data.Emails.Clear();
                record.Normal.Private.Data.Emails.AddRange(request.Emails);

                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);
                var otherClaims = await claimsClient.GetOtherClaims(userToken.Id);

                return new ModifyOwnUserResponse()
                {
                    BearerToken = GenerateToken(record.Normal, otherClaims)
                };
            }
            catch
            {
                return new ModifyOwnUserResponse() { Error = "Unknown error" };
            }
        }

        public override async Task<RenewTokenResponse> RenewToken(RenewTokenRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new RenewTokenResponse();

            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new RenewTokenResponse();

                var record = await dataProvider.GetById(userToken.Id);
                if (record == null)
                    return new RenewTokenResponse();

                var otherClaims = await claimsClient.GetOtherClaims(userToken.Id);

                return new RenewTokenResponse()
                {
                    BearerToken = GenerateToken(record.Normal, otherClaims)
                };
            }
            catch
            {
                return new RenewTokenResponse();
            }
        }

        private async Task<bool> AmIReallyAdmin(ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return false;

            var record = await dataProvider.GetById(userToken.Id);
            if (record == null)
                return false;

            var roles = record.Normal.Private.Roles;
            if (!(roles.Contains(ONUser.ROLE_OWNER) || roles.Contains(ONUser.ROLE_ADMIN)))
                return false;

            return true;
        }

        private async Task<bool> IsPasswordCorrect(string password, UserRecord user)
        {
            var hash = ComputeSaltedHash(password, user.Server.PasswordSalt.Span);
            if (CryptographicOperations.FixedTimeEquals(user.Server.PasswordHash.Span, hash))
                return true;

            if (string.IsNullOrEmpty(user.Server.OldPasswordAlgorithm) || string.IsNullOrEmpty(user.Server.OldPassword))
                return false;

            if (user.Server.OldPasswordAlgorithm == "Wordpress")
            {
                if (!CryptSharp.Core.PhpassCrypter.CheckPassword(password, user.Server.OldPassword))
                    return false;

                byte[] salt = RandomNumberGenerator.GetBytes(16);
                user.Server.PasswordSalt = ByteString.CopyFrom(salt);
                user.Server.PasswordHash = ByteString.CopyFrom(ComputeSaltedHash(password, salt));

                user.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                user.Normal.Private.ModifiedBy = user.Normal.Public.UserID;

                await dataProvider.Save(user);

                return true;
            }

            return false;
        }

        private bool IsValid(UserNormalRecord user)
        {
            if (user.Public.UserID.ToGuid() == Guid.Empty)
                return false;

            user.Public.Data.DisplayName = user.Public.Data.DisplayName?.Trim() ?? "";
            if (!IsDisplayNameValid(user.Public.Data.DisplayName))
                return false;


            user.Public.Data.UserName = user.Public.Data.UserName?.Trim() ?? "";
            if (!IsUserNameValid(user.Public.Data.UserName))
                return false;

            return true;
        }

        private bool IsDisplayNameValid(string displayName)
        {
            if (string.IsNullOrWhiteSpace(displayName))
                return false;

            if (displayName.Length < 4 || displayName.Length > 20)
                return false;

            return true;
        }

        private bool IsUserNameValid(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return false;

            if (userName.Length < 4 || userName.Length > 20)
                return false;

            var regex = new Regex(@"^[a-zA-Z0-9]+$");
            if (!regex.IsMatch(userName))
                return false;

            return true;
        }

        private byte[] ComputeSaltedHash(string plainText, ReadOnlySpan<byte> salt)
        {
            return ComputeSaltedHash(Encoding.UTF8.GetBytes(plainText), salt);
        }

        private byte[] ComputeSaltedHash(ReadOnlySpan<byte> plainText, ReadOnlySpan<byte> salt)
        {
            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            plainText.CopyTo(plainTextWithSaltBytes.AsSpan());
            salt.CopyTo(plainTextWithSaltBytes.AsSpan(plainText.Length));

            return hasher.ComputeHash(plainTextWithSaltBytes);
        }

        private string GenerateToken(UserNormalRecord user, IEnumerable<ClaimRecord> otherClaims)
        {
            var onUser = new ONUser()
            {
                Id = user.Public.UserID.ToGuid(),
                UserName = user.Public.Data.UserName,
                DisplayName = user.Public.Data.DisplayName,
            };

            onUser.Idents.AddRange(user.Public.Data.Identities);
            onUser.Roles.AddRange(user.Private.Roles);

            if (otherClaims != null)
            {
                onUser.ExtraClaims.AddRange(otherClaims.Select(c => new Claim(c.Name, c.Value)));
                onUser.ExtraClaims.AddRange(otherClaims.Select(c => new Claim(c.Name + "Exp", c.ExpiresOnUTC.Seconds.ToString())));
            }

            return GenerateToken(onUser);
        }

        private string GenerateToken(ONUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            tokenDescriptor.Claims = new Dictionary<string, object>();

            foreach (var c in user.ToClaims())
                tokenDescriptor.Claims.Add(c.Type, c.Value);

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private async Task EnsureDevOwnerLogin()
        {
            if (await dataProvider.Exists("owner"))
                return;

            var date = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
            var newId = Guid.NewGuid().ToString();

            var record = new UserRecord()
            {
                Normal = new()
                {
                    Public = new()
                    {
                        UserID = newId,
                        CreatedOnUTC = date,
                        ModifiedOnUTC = date,
                        Data = new()
                        {
                            UserName = "owner",
                            DisplayName = "Owner",
                        }
                    },
                    Private = new()
                    {
                        CreatedBy = newId,
                        ModifiedBy = newId,
                        Data = new(),
                    },
                },
                Server = new(),
            };

            record.Normal.Private.Roles.Add(ONUser.ROLE_OWNER);

            byte[] salt = RandomNumberGenerator.GetBytes(16);
            record.Server.PasswordSalt = ByteString.CopyFrom(salt);
            record.Server.PasswordHash = ByteString.CopyFrom(ComputeSaltedHash("owner", salt));

            await dataProvider.Create(record);
        }
    }
}
