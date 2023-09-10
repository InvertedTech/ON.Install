using Google.Authenticator;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ON.Authentication.SimpleAuth.Service.Data;
using ON.Authentication.SimpleAuth.Service.Helpers;
using ON.Fragments.Authentication;
using ON.Fragments.Authorization;
using ON.Fragments.Content;
using ON.Fragments.Generic;
using ON.Settings;
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
using static Google.Rpc.Context.AttributeContext.Types;

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
        private readonly SettingsClient settingsClient;
        private static readonly HashAlgorithm hasher = SHA256.Create();
        private static readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();

        public UserService(OfflineHelper offlineHelper, ILogger<ServiceOpsService> logger, IUserDataProvider dataProvider, ClaimsClient claimsClient, SettingsClient settingsClient)
        {
            this.offlineHelper = offlineHelper;
            this.logger = logger;
            this.dataProvider = dataProvider;
            this.claimsClient = claimsClient;
            this.settingsClient = settingsClient;

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
            {
                user = await dataProvider.GetByEmail(request.UserName);
                if (user == null)
                    return new AuthenticateUserResponse();
            }

            bool isCorrect = await IsPasswordCorrect(request.Password, user);

            if (!isCorrect)
                return new AuthenticateUserResponse();

            if (!ValidateTotp(user.Server?.TOTPDevices, request.MFACode))
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
                            UserName = request.UserName.ToLower(),
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

            if (await dataProvider.LoginExists(user.Normal.Public.Data.UserName.ToLower()))
                return new CreateUserResponse
                {
                    Error = CreateUserResponse.Types.CreateUserResponseErrorType.UserNameTaken
                };

            if (await dataProvider.EmailsExist(user.Normal.Private.Data.Emails.ToArray()))
                return new CreateUserResponse
                {
                    Error = CreateUserResponse.Types.CreateUserResponseErrorType.EmailTaken
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
        public override async Task<DisableOtherTotpResponse> DisableOtherTotp(DisableOtherTotpRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new();

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new() { Error = "Admin only" };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = "Not logged in" };

                var record = await dataProvider.GetById(request.UserID.ToGuid());
                if (record == null)
                    return new() { Error = "User not found" };

                var totp = record.Server.TOTPDevices.FirstOrDefault(r => r.TotpID == request.TotpID);
                if (totp == null)
                    return new() { Error = "Device not found" };

                totp.DisabledOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in DisableOtherTotp");
                return new();
            }
        }

        public override async Task<DisableOwnTotpResponse> DisableOwnTotp(DisableOwnTotpRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new();

            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = "Not logged in" };

                var record = await dataProvider.GetById(userToken.Id);
                if (record == null)
                    return new() { Error = "Not logged in" };

                var totp = record.Server.TOTPDevices.FirstOrDefault(r => r.TotpID == request.TotpID);
                if (totp == null)
                    return new() { Error = "Device not found" };

                totp.DisabledOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in DisableOwnTotp");
                return new();
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
        public override async Task<GenerateOtherTotpResponse> GenerateOtherTotp(GenerateOtherTotpRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new() { Error = "Offline" };

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new() { Error = "Admin only" };

                var deviceName = request.DeviceName?.Trim();
                if (string.IsNullOrWhiteSpace(deviceName))
                    return new() { Error = "Device Name required" };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = "Not logged in" };

                var record = await dataProvider.GetById(request.UserID.ToGuid());
                if (record == null)
                    return new() { Error = "User not found" };


                if (record.Server.TOTPDevices.Where(r => r.IsValid).Where(r => r.DeviceName.ToLower() == deviceName.ToLower()).Any())
                    return new() { Error = "Device Name already exists" };

                byte[] key = new byte[10];
                rng.GetBytes(key);

                TOTPDevice totp = new()
                {
                    TotpID = Guid.NewGuid().ToString(),
                    DeviceName = deviceName,
                    Key = ByteString.CopyFrom(key),
                    CreatedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow)
                };

                record.Server.TOTPDevices.Add(totp);

                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                SetupCode setupInfo = tfa.GenerateSetupCode(settingsClient.PublicData.Personalization.Title, record.Normal.Public.Data.UserName, key);

                return new()
                {
                    TotpID = totp.TotpID,
                    Key = setupInfo.ManualEntryKey,
                    QRCode = setupInfo.QrCodeSetupImageUrl
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in GenerateOwnTotp");
                return new() { Error = "Unknown Error" };
            }
        }

        public override async Task<GenerateOwnTotpResponse> GenerateOwnTotp(GenerateOwnTotpRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new() { Error = "Offline" };

            try
            {
                var deviceName = request.DeviceName?.Trim();
                if (string.IsNullOrWhiteSpace(deviceName))
                    return new() { Error = "Device Name required" };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = "Not logged in" };

                var record = await dataProvider.GetById(userToken.Id);
                if (record == null)
                    return new() { Error = "Not logged in" };


                if (record.Server.TOTPDevices.Where(r => r.IsValid).Where(r => r.DeviceName.ToLower() == deviceName.ToLower()).Any())
                    return new() { Error = "Device Name already exists" };

                byte[] key = new byte[10];
                rng.GetBytes(key);

                TOTPDevice totp = new()
                {
                    TotpID = Guid.NewGuid().ToString(),
                    DeviceName = deviceName,
                    Key = ByteString.CopyFrom(key),
                    CreatedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow)
                };

                record.Server.TOTPDevices.Add(totp);

                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                SetupCode setupInfo = tfa.GenerateSetupCode(settingsClient.PublicData.Personalization.Title, record.Normal.Public.Data.UserName, key);

                return new()
                {
                    TotpID = totp.TotpID,
                    Key = setupInfo.ManualEntryKey,
                    QRCode = setupInfo.QrCodeSetupImageUrl
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in GenerateOwnTotp");
                return new() { Error = "Unknown Error" };
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

        [AllowAnonymous]
        public override async Task<GetOtherPublicUserByUserNameResponse> GetOtherPublicUserByUserName(GetOtherPublicUserByUserNameRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new();

            var record = await dataProvider.GetByLogin(request.UserName);

            return new() { Record = record?.Normal.Public };
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<GetOtherTotpListResponse> GetOtherTotpList(GetOtherTotpListRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new();

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new();

                var record = await dataProvider.GetById(request.UserID.ToGuid());
                if (record == null)
                    return new();

                var ret = new GetOtherTotpListResponse();
                ret.Devices.AddRange(record.Server.TOTPDevices.Where(r => r.IsValid).Select(r => r.ToLimited()));

                return ret;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in GetOtherTotpList");
                return new();
            }
        }

        public override async Task<GetOwnTotpListResponse> GetOwnTotpList(GetOwnTotpListRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new();

            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new();

                var record = await dataProvider.GetById(userToken.Id);
                if (record == null)
                    return new();

                var ret = new GetOwnTotpListResponse();
                ret.Devices.AddRange(record.Server.TOTPDevices.Where(r => r.IsValid).Select(r => r.ToLimited()));

                return ret;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in GetOwnTotpList");
                return new();
            }
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

                request.UserName = request.UserName.ToLower();

                if (!IsDisplayNameValid(request.DisplayName))
                    return new() { Error = "Display Name not valid" };

                if (record.Normal.Public.Data.UserName != request.UserName)
                {
                    if (!await dataProvider.ChangeLoginIndex(record.Normal.Public.Data.UserName, request.UserName, userId))
                        return new ModifyOtherUserResponse() { Error = "User Name taken" };

                    record.Normal.Public.Data.UserName = request.UserName;
                }


                if (!record.Normal.Private.Data.Emails.SequenceEqual(request.Emails))
                {
                    if (!await dataProvider.ChangeEmailIndex(request.Emails.ToArray(), userId))
                        return new ModifyOtherUserResponse() { Error = "Email address taken" };

                    record.Normal.Private.Data.Emails.Clear();
                    record.Normal.Private.Data.Emails.AddRange(request.Emails);
                }

                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Public.Data.DisplayName = request.DisplayName;
                record.Normal.Public.Data.Bio = request.Bio;

                record.Normal.Private.ModifiedBy = userToken.Id.ToString();

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

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<SearchUsersAdminResponse> SearchUsersAdmin(SearchUsersAdminRequest request, ServerCallContext context)
        {
            var minDateValue = new DateTime(2000, 1, 1);

            var possibleIDs = request.UserIDs.ToList();
            var possibleRoles = request.Roles.ToList();
            var searchSearchString = request.SearchString;
            var searchCreatedBefore = request.CreatedBefore;
            var searchCreatedAfter = request.CreatedAfter;
            var searchIncludeDeleted = request.IncludeDeleted;

            if (!possibleIDs.Any())
                possibleIDs = null;
            if (!possibleRoles.Any())
                possibleRoles = null;
            if (string.IsNullOrWhiteSpace(searchSearchString))
                searchSearchString = null;

            var res = new SearchUsersAdminResponse();

            List<UserSearchRecord> list = new();
            await foreach (var rec in dataProvider.GetAll())
            {
                if (possibleIDs != null)
                    if (!possibleIDs.Contains(rec.Normal.Public.UserID))
                        continue;

                if (possibleRoles != null)
                    if (!possibleRoles.Any(possibleRole => rec.Normal.Private.Roles.Any(role => possibleRole.Contains(role))))
                        continue;

                if (searchCreatedBefore != null)
                    if (rec.Normal.Public.CreatedOnUTC < searchCreatedBefore)
                        continue;

                if (searchCreatedAfter != null)
                    if (rec.Normal.Public.CreatedOnUTC > searchCreatedAfter)
                        continue;

                if (!searchIncludeDeleted)
                    if (rec.Normal.Public.DisabledOnUTC != null)
                        continue;

                if (searchSearchString != null)
                    if (!rec.Normal.Public.Data.UserName.Contains(searchSearchString, StringComparison.InvariantCultureIgnoreCase) && !rec.Normal.Public.Data.DisplayName.Contains(searchSearchString, StringComparison.InvariantCultureIgnoreCase))
                        continue;

                var listRec = rec.Normal.ToUserSearchRecord();

                list.Add(listRec);
            }

            res.Records.AddRange(list.OrderBy(r => r.DisplayName));
            res.PageTotalItems = (uint)res.Records.Count;

            if (request.PageSize > 0)
            {
                res.PageOffsetStart = request.PageOffset;

                var page = res.Records.Skip((int)request.PageOffset).Take((int)request.PageSize).ToList();
                res.Records.Clear();
                res.Records.AddRange(page);
            }

            res.PageOffsetEnd = res.PageOffsetStart + (uint)res.Records.Count;

            return res;
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<VerifyOtherTotpResponse> VerifyOtherTotp(VerifyOtherTotpRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new();

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new() { Error = "Admin only" };

                if (string.IsNullOrWhiteSpace(request?.Code))
                    return new() { Error = "Code is required" };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = "Not logged in" };

                var record = await dataProvider.GetById(request.UserID.ToGuid());
                if (record == null)
                    return new() { Error = "User not found" };

                var totp = record.Server.TOTPDevices.FirstOrDefault(r => r.TotpID == request.TotpID);
                if (totp == null)
                    return new() { Error = "Device not found" };

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                if (!tfa.ValidateTwoFactorPIN(totp.Key.ToByteArray(), request.Code.Trim()))
                    return new() { Error = "Code is not valid" };

                totp.VerifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in VerifyOtherTotp");
                return new();
            }
        }

        public override async Task<VerifyOwnTotpResponse> VerifyOwnTotp(VerifyOwnTotpRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new();

            try
            {
                if (string.IsNullOrWhiteSpace(request?.Code))
                    return new() { Error = "Code is required" };

                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = "Not logged in" };

                var record = await dataProvider.GetById(userToken.Id);
                if (record == null)
                    return new() { Error = "Not logged in" };

                var totp = record.Server.TOTPDevices.FirstOrDefault(r => r.TotpID == request.TotpID);
                if (totp == null)
                    return new() { Error = "Device not found" };

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                if (!tfa.ValidateTwoFactorPIN(totp.Key.ToByteArray(), request.Code.Trim()))
                    return new() { Error = "Code is not valid" };

                totp.VerifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Normal.Private.ModifiedBy = userToken.Id.ToString();

                await dataProvider.Save(record);

                return new();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in VerifyOwnTotp");
                return new();
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

            var regex = new Regex(@"^[a-z0-9]+$");
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

        private bool ValidateTotp(IEnumerable<TOTPDevice> devices, string code)
        {
            var validDevices = devices?.Where(d => d.IsValid) ?? Enumerable.Empty<TOTPDevice>();

            // If there are no TOTP Devices then don't require one
            if (!validDevices.Any())
                return true;

            code = code?.Trim() ?? "";

            foreach (var device in validDevices)
                if (IsValidTotp(device, code))
                    return true;

            return false;
        }

        private bool IsValidTotp(TOTPDevice device, string code)
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            return tfa.ValidateTwoFactorPIN(device.Key.ToByteArray(), code);
        }

        private async Task EnsureDevOwnerLogin()
        {
            if (await dataProvider.LoginExists("owner"))
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
