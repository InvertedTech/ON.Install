using Google.Protobuf;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ON.Notification.SimpleNotification.Service.Data;
using ON.Notification.SimpleNotification.Service.Helpers;
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
using ON.Authentication;
using ON.Fragments.Notification;

namespace ON.Notification.SimpleNotification.Service.Services
{
    [Authorize]
    public class UserService : UserNotificationInterface.UserNotificationInterfaceBase
    {
        private readonly ILogger logger;
        private readonly SigningCredentials creds;
        private readonly INotificationUserDataProvider notificationDataProvider;
        private readonly IUserNotificationDataProvider userDataProvider;
        private static readonly HashAlgorithm hasher = SHA256.Create();

        public UserService(ILogger<UserService> logger, INotificationUserDataProvider notificationDataProvider, IUserNotificationDataProvider userDataProvider)
        {
            this.logger = logger;
            this.notificationDataProvider = notificationDataProvider;
            this.userDataProvider = userDataProvider;

            creds = new SigningCredentials(JwtExtensions.GetPrivateKey(), SecurityAlgorithms.EcdsaSha256);
        }

        public override async Task<GetRecordResponse> GetRecord(GetRecordRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new();

            var record = await userDataProvider.GetById(userToken.Id);

            return new() { Record = record };
        }

        public override async Task<ModifyNormalRecordResponse> ModifyNormalRecord(ModifyNormalRecordRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = "No user token specified" };

                var record = await userDataProvider.GetById(userToken.Id);
                if (record == null)
                    return new() { Error = "User not found" };

                record.Normal = request.Record;
                record.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                await userDataProvider.Save(record);

                return new();
            }
            catch
            {
                return new() { Error = "Unknown error" };
            }
        }

        public override async Task<RegisterNewTokenResponse> RegisterNewToken(RegisterNewTokenRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = "No user token specified" };

                if (string.IsNullOrWhiteSpace(request.TokenID))
                    return new() { Error = "TokenID is empty" };

                var record = await notificationDataProvider.GetByTokenId(request.TokenID);
                if (record == null)
                    record = new()
                    {
                        CreatedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow),
                    };

                record.TokenID = request.TokenID;
                record.UserIDGuid = userToken.Id;
                record.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                await notificationDataProvider.Save(record);

                return new();
            }
            catch
            {
                return new() { Error = "Unknown error" };
            }
        }

        public override async Task<UnRegisterNewTokenResponse> UnRegisterNewToken(UnRegisterNewTokenRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = "No user token specified" };

                if (string.IsNullOrWhiteSpace(request.TokenID))
                    return new() { Error = "TokenID is empty" };

                var record = await notificationDataProvider.GetByTokenId(request.TokenID);
                if (record == null)
                    return new();

                if (record.TokenID != request.TokenID)
                    return new();

                if (record.UserIDGuid != userToken.Id)
                    return new();

                await notificationDataProvider.Delete(request.TokenID);

                return new();
            }
            catch
            {
                return new() { Error = "Unknown error" };
            }
        }
    }
}
