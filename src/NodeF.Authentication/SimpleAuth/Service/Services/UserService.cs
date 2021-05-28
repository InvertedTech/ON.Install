using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NodeF.Authentication.SimpleAuth.Service.Data;
using NodeF.Fragments.Authentcation;
using NodeF.Fragments.Generic;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NodeF.Authentication.SimpleAuth.Service.Services
{
    public class UserService : UserInterface.UserInterfaceBase
    {
        private readonly ILogger<ServiceOpsService> logger;
        private readonly SigningCredentials creds;
        private readonly IUserDataProvider dataProvider;
        private static readonly HashAlgorithm hasher = new SHA256Managed();
        private static readonly RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        public UserService(ILogger<ServiceOpsService> logger, IUserDataProvider dataProvider)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;

            creds = new SigningCredentials(JwtValidatorMiddleware.GetPrivateKey(), SecurityAlgorithms.EcdsaSha256);
        }

        public override async Task<AuthenticatUserResponse> AuthenticatUser(AuthenticatUserRequest request, ServerCallContext context)
        {
            if (string.IsNullOrWhiteSpace(request.LoginName) || string.IsNullOrWhiteSpace(request.Password))
                return new AuthenticatUserResponse();

            var user = await dataProvider.GetByLogin(request.LoginName);
            if (user == null)
                return new AuthenticatUserResponse();

            var hash = ComputeSaltedHash(request.Password, user.Private.PasswordSalt.Span);
            if (!CryptographicOperations.FixedTimeEquals(user.Private.PasswordHash.Span, hash))
                return new AuthenticatUserResponse();

            return new AuthenticatUserResponse()
            {
                BearerToken = GenerateToken(user)
            };
        }

        public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            var user = request.Record;
            if (user == null)
                return new CreateUserResponse()
                {
                    Error = CreateUserResponse.Types.ErrorType.UnknownError
                };

            byte[] salt = new byte[16];
            rngCsp.GetBytes(salt);
            user.Private.PasswordSalt = Google.Protobuf.ByteString.CopyFrom(salt);
            user.Private.PasswordHash = Google.Protobuf.ByteString.CopyFrom(ComputeSaltedHash(request.Password, salt));
            user.Public.CreatedOnUTC = user.Public.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

            if (!IsValid(user))
                return new CreateUserResponse()
                {
                    Error = CreateUserResponse.Types.ErrorType.UnknownError
                };

            if (await dataProvider.Exists(request.Record.Private.LoginName))
                return new CreateUserResponse()
                {
                    Error = CreateUserResponse.Types.ErrorType.LoginTaken
                };

            var res = await dataProvider.Create(user);
            if (!res)
                return new CreateUserResponse()
                {
                    Error = CreateUserResponse.Types.ErrorType.UnknownError
                };

            return new CreateUserResponse()
            {
                BearerToken = GenerateToken(user)
            };
        }

        public override async Task<GetUserResponse> GetUser(GetUserRequest request, ServerCallContext context)
        {
            var user = context.GetHttpContext().User as NodeUser;
            if (user == null)
                return new GetUserResponse();

            return new GetUserResponse()
            {
                Record = await dataProvider.GetById(user.Id)
            };
        }

        private bool IsValid(UserRecord user)
        {
            if (new Guid(user.Public.UserID.Span) == Guid.Empty)
                return false;

            user.Public.DisplayName = user.Public.DisplayName?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(user.Public.DisplayName))
                return false;

            if (user.Public.DisplayName.Length < 4 || user.Public.DisplayName.Length > 20)
                return false;

            user.Private.LoginName = user.Private.LoginName?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(user.Private.LoginName))
                return false;

            if (user.Private.LoginName.Length < 4 || user.Private.LoginName.Length > 20)
                return false;

            var regex = new Regex(@"^[a-zA-Z0-9]+$");
            if (!regex.IsMatch(user.Private.LoginName))
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

        private string GenerateToken(UserRecord user)
        {
            var node = new NodeUser()
            {
                Id = new Guid(user.Public.UserID.Span),
                DisplayName = user.Public.DisplayName,
            };
            node.Idents.AddRange(user.Public.Identities);

            return GenerateToken(node);
        }

        private string GenerateToken(NodeUser user)
        {
            user.ToClaims();

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };
            foreach (var c in user.ToClaims())
                tokenDescriptor.Claims.Add(c.Type, c.Value);

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
