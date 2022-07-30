using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ON.Authentication.SimpleAuth.Service.Data;
using ON.Authentication.SimpleAuth.Service.Helpers;
using ON.Fragments.Authentication;
using ON.Fragments.Authorization;
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
                EnsureDevAdminLogin().Wait();
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

            var hash = ComputeSaltedHash(request.Password, user.Private.PasswordSalt.Span);
            if (!CryptographicOperations.FixedTimeEquals(user.Private.PasswordHash.Span, hash))
                return new AuthenticateUserResponse();

            var otherClaims = await claimsClient.GetOtherClaims(user.Public.UserID.ToGuid());

            return new AuthenticateUserResponse()
            {
                BearerToken = GenerateToken(user, otherClaims)
            };
        }

        public override async Task<ChangeOtherPasswordResponse> ChangeOtherPassword(ChangeOtherPasswordRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new ChangeOtherPasswordResponse { Error = ChangeOtherPasswordResponse.Types.ChangeOtherPasswordResponseErrorType.UnknownError };

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new ChangeOtherPasswordResponse { Error = ChangeOtherPasswordResponse.Types.ChangeOtherPasswordResponseErrorType.UnknownError };

                var record = await dataProvider.GetById(request.UserID.ToGuid());
                if (record == null)
                    return new ChangeOtherPasswordResponse { Error = ChangeOtherPasswordResponse.Types.ChangeOtherPasswordResponseErrorType.UserNotFound };

                byte[] salt = RandomNumberGenerator.GetBytes(16);
                record.Private.PasswordSalt = ByteString.CopyFrom(salt);
                record.Private.PasswordHash = ByteString.CopyFrom(ComputeSaltedHash(request.NewPassword, salt));

                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                await dataProvider.Save(record);

                return new ChangeOtherPasswordResponse { Error = ChangeOtherPasswordResponse.Types.ChangeOtherPasswordResponseErrorType.NoError };
            }
            catch
            {
                return new ChangeOtherPasswordResponse { Error = ChangeOtherPasswordResponse.Types.ChangeOtherPasswordResponseErrorType.UnknownError };
            }
        }

        public override async Task<ChangeOtherProfileImageResponse> ChangeOtherProfileImage(ChangeOtherProfileImageRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new ChangeOtherProfileImageResponse { Error = ChangeOtherProfileImageResponse.Types.ChangeOtherProfileImageResponseErrorType.UnknownError };

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new ChangeOtherProfileImageResponse { Error = ChangeOtherProfileImageResponse.Types.ChangeOtherProfileImageResponseErrorType.UnknownError };

                var record = await dataProvider.GetById(request.UserID.ToGuid());
                if (record == null)
                    return new ChangeOtherProfileImageResponse { Error = ChangeOtherProfileImageResponse.Types.ChangeOtherProfileImageResponseErrorType.UnknownError };

                if (request?.ProfileImage == null || request.ProfileImage.IsEmpty)
                    return new ChangeOtherProfileImageResponse { Error = ChangeOtherProfileImageResponse.Types.ChangeOtherProfileImageResponseErrorType.BadFormat };



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

                record.Public.ProfileImagePNG = ByteString.CopyFrom(memStream.ToArray());

                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                await dataProvider.Save(record);


                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

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

                var hash = ComputeSaltedHash(request.OldPassword, record.Private.PasswordSalt.Span);
                if (!CryptographicOperations.FixedTimeEquals(record.Private.PasswordHash.Span, hash))
                    return new ChangeOwnPasswordResponse { Error = ChangeOwnPasswordResponse.Types.ChangeOwnPasswordResponseErrorType.BadOldPassword };

                byte[] salt = RandomNumberGenerator.GetBytes(16);
                record.Private.PasswordSalt = ByteString.CopyFrom(salt);
                record.Private.PasswordHash = ByteString.CopyFrom(ComputeSaltedHash(request.NewPassword, salt));

                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

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
                return new ChangeOwnProfileImageResponse { Error = ChangeOwnProfileImageResponse.Types.ChangeOwnProfileImageResponseErrorType.UnknownError };

            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new ChangeOwnProfileImageResponse { Error = ChangeOwnProfileImageResponse.Types.ChangeOwnProfileImageResponseErrorType.UnknownError };

                var record = await dataProvider.GetById(userToken.Id);
                if (record == null)
                    return new ChangeOwnProfileImageResponse { Error = ChangeOwnProfileImageResponse.Types.ChangeOwnProfileImageResponseErrorType.UnknownError };

                using var ms = new MemoryStream();
                ms.Write(request.ProfileImage.ToArray());
                ms.Position = 0;
                using var image = SKBitmap.Decode(ms);

                if (image == null)
                    return new ChangeOwnProfileImageResponse { Error = ChangeOwnProfileImageResponse.Types.ChangeOwnProfileImageResponseErrorType.BadFormat };

                var newInfo = image.Info;
                newInfo.Width = 200;
                newInfo.Height = 200;
                using var newImage = image.Resize(newInfo, SKFilterQuality.Medium);


                using MemoryStream memStream = new MemoryStream();
                using SKManagedWStream wstream = new SKManagedWStream(memStream);

                newImage.Encode(wstream, SKEncodedImageFormat.Png, 50);

                record.Public.ProfileImagePNG = ByteString.CopyFrom(memStream.ToArray());

                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                await dataProvider.Save(record);

                return new ChangeOwnProfileImageResponse { Error = ChangeOwnProfileImageResponse.Types.ChangeOwnProfileImageResponseErrorType.NoError };
            }
            catch
            {
                return new ChangeOwnProfileImageResponse { Error = ChangeOwnProfileImageResponse.Types.ChangeOwnProfileImageResponseErrorType.BadFormat };
            }
        }

        [AllowAnonymous]
        public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new CreateUserResponse()
                {
                    Error = CreateUserResponse.Types.CreateUserResponseErrorType.UnknownError
                };

            if (request == null)
                return new CreateUserResponse()
                {
                    Error = CreateUserResponse.Types.CreateUserResponseErrorType.UnknownError
                };

            var user = new UserRecord()
            {
                Public = new UserRecord.Types.PublicData()
                {
                    UserID = Guid.NewGuid().ToString(),
                    UserName = request.UserName,
                    DisplayName = request.DisplayName,
                },
                Private = new UserRecord.Types.PrivateData()
            };
            user.Private.Emails.AddRange(request.Emails);

            byte[] salt = RandomNumberGenerator.GetBytes(16);
            user.Private.PasswordSalt = ByteString.CopyFrom(salt);
            user.Private.PasswordHash = ByteString.CopyFrom(ComputeSaltedHash(request.Password, salt));
            user.Public.CreatedOnUTC = user.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

            if (!IsValid(user))
                return new CreateUserResponse
                {
                    Error = CreateUserResponse.Types.CreateUserResponseErrorType.UnknownError
                };

            if (await dataProvider.Exists(user.Public.UserName))
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
                BearerToken = GenerateToken(user, null)
            };
        }

        public override async Task<DisableEnableOtherUserResponse> DisableOtherUser(DisableEnableOtherUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };

                var record = await dataProvider.GetById(request.UserID.ToGuid());
                if (record == null)
                    return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };

                record.Public.DisabledOnUTC = record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                await dataProvider.Save(record);

                return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.NoError };
            }
            catch
            {
                return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };
            }
        }

        public override async Task<DisableEnableOtherUserResponse> EnableOtherUser(DisableEnableOtherUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };

                var record = await dataProvider.GetById(request.UserID.ToGuid());
                if (record == null)
                    return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };

                record.Public.DisabledOnUTC = null;
                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                await dataProvider.Save(record);

                return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.NoError };
            }
            catch
            {
                return new DisableEnableOtherUserResponse { Error = DisableEnableOtherUserResponse.Types.DisableEnableOtherUserResponseErrorType.UnknownError };
            }
        }

        public override async Task<GetAllUsersResponse> GetAllUsers(GetAllUsersRequest request, ServerCallContext context)
        {
            var ret = new GetAllUsersResponse();
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null || !(userToken.Roles.Contains(ONUser.ROLE_BACKUP) || userToken.Roles.Contains(ONUser.ROLE_ADMIN)))
                    return new GetAllUsersResponse();

                await foreach (var r in dataProvider.GetAll())
                    ret.Records.Add(r.Public);
            }
            catch
            {
            }

            return ret;
        }

        public override async Task<GetOtherUserResponse> GetOtherUser(GetOtherUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new GetOtherUserResponse();

            if (!await AmIReallyAdmin(context))
                return new GetOtherUserResponse();

            var record = await dataProvider.GetById(request.UserID.ToGuid());
            if (record == null)
                return new GetOtherUserResponse();

            record.Private.PasswordHash = ByteString.Empty;
            record.Private.PasswordSalt = ByteString.Empty;

            return new GetOtherUserResponse
            {
                Record = record
            };
        }

        public override async Task<GetOwnUserResponse> GetOwnUser(GetOwnUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new GetOwnUserResponse();

            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new GetOwnUserResponse();

            var record = await dataProvider.GetById(userToken.Id);
            if (record == null)
                return new GetOwnUserResponse();

            record.Private.PasswordHash = ByteString.Empty;
            record.Private.PasswordSalt = ByteString.Empty;

            return new GetOwnUserResponse
            {
                Record = record
            };
        }

        public override async Task<ModifyOtherUserResponse> ModifyOtherUser(ModifyOtherUserRequest request, ServerCallContext context)
        {
            if (offlineHelper.IsOffline)
                return new ModifyOtherUserResponse() { Error = "Service Offline" };

            try
            {
                if (!await AmIReallyAdmin(context))
                    return new ModifyOtherUserResponse { Error = "Not an admin" };

                var userId = request.UserID.ToGuid();
                var record = await dataProvider.GetById(userId);
                if (record == null)
                    return new ModifyOtherUserResponse { Error = "User not found" };


                if (!IsUserNameValid(request.UserName))
                    return new ModifyOtherUserResponse() { Error = "User Name not valid" };

                if (!IsDisplayNameValid(request.DisplayName))
                    return new ModifyOtherUserResponse() { Error = "Display Name not valid" };

                if (record.Public.UserName != request.UserName)
                {
                    if (!await dataProvider.ChangeLogin(record.Public.UserName, request.UserName, userId))
                        return new ModifyOtherUserResponse() { Error = "User Name taken" };
                    record.Public.UserName = request.UserName;
                }

                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Public.DisplayName = request.DisplayName;

                record.Private.Emails.Clear();
                record.Private.Emails.AddRange(request.Emails);

                record.Public.Roles.Clear();
                record.Public.Roles.AddRange(request.Roles);

                await dataProvider.Save(record);

                return new ModifyOtherUserResponse();
            }
            catch
            {
                return new ModifyOtherUserResponse() { Error = "Unknown error" };
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

                bool needNewToken = false;

                if (record.Public.DisplayName != request.DisplayName)
                    needNewToken = true;

                record.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);
                record.Public.DisplayName = request.DisplayName;

                record.Public.Identities.Clear();
                record.Public.Identities.AddRange(request.Identities);

                record.Private.Emails.Clear();
                record.Private.Emails.AddRange(request.Emails);

                await dataProvider.Save(record);
                var otherClaims = await claimsClient.GetOtherClaims(userToken.Id);

                string token = "";
                if (needNewToken)
                    token = GenerateToken(record, otherClaims);

                return new ModifyOwnUserResponse()
                {
                    BearerToken = token
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
                    BearerToken = GenerateToken(record, otherClaims)
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

            if (!record.Public.Roles.Contains(ONUser.ROLE_ADMIN))
                return false;

            return true;
        }

        private bool IsValid(UserRecord user)
        {
            if (user.Public.UserID.ToGuid() == Guid.Empty)
                return false;

            user.Public.DisplayName = user.Public.DisplayName?.Trim() ?? "";
            if (!IsDisplayNameValid(user.Public.DisplayName))
                return false;


            user.Public.UserName = user.Public.UserName?.Trim() ?? "";
            if (!IsUserNameValid(user.Public.UserName))
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

        private string GenerateToken(UserRecord user, IEnumerable<ClaimRecord> otherClaims)
        {
            var onUser = new ONUser()
            {
                Id = user.Public.UserID.ToGuid(),
                UserName = user.Public.UserName,
                DisplayName = user.Public.DisplayName,
            };

            onUser.Idents.AddRange(user.Public.Identities);
            onUser.Roles.AddRange(user.Public.Roles);

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

        private async Task EnsureDevAdminLogin()
        {
            if (await dataProvider.Exists("admin"))
                return;

            var date = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

            var record = new UserRecord()
            {
                Public = new UserRecord.Types.PublicData()
                {
                    UserID = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    DisplayName = "Admin",
                    CreatedOnUTC = date,
                    ModifiedOnUTC = date,
                },
                Private = new UserRecord.Types.PrivateData()
            };
            record.Public.Roles.Add(ONUser.ROLE_ADMIN);

            byte[] salt = RandomNumberGenerator.GetBytes(16);
            record.Private.PasswordSalt = ByteString.CopyFrom(salt);
            record.Private.PasswordHash = ByteString.CopyFrom(ComputeSaltedHash("admin", salt));

            await dataProvider.Create(record);
        }
    }
}
