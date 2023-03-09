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
        private readonly IUserNotificationDataProvider dataProvider;
        private static readonly HashAlgorithm hasher = SHA256.Create();

        public UserService(ILogger<UserService> logger, IUserNotificationDataProvider dataProvider)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;

            creds = new SigningCredentials(JwtExtensions.GetPrivateKey(), SecurityAlgorithms.EcdsaSha256);
        }

        public override async Task<GetRecordResponse> GetRecord(GetRecordRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new();

            var record = await dataProvider.GetById(userToken.Id);

            return new() { Record = record };
        }

        public override async Task<ModifyNormalRecordResponse> ModifyNormalRecord(ModifyNormalRecordRequest request, ServerCallContext context)
        {
            try
            {
                var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
                if (userToken == null)
                    return new() { Error = "No user token specified" };

                var record = await dataProvider.GetById(userToken.Id);
                if (record == null)
                    return new() { Error = "User not found" };

                record.Normal = request.Record;
                record.ModifiedOnUTC = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow);

                await dataProvider.Save(record);

                return new();
            }
            catch
            {
                return new() { Error = "Unknown error" };
            }
        }
    }
}
