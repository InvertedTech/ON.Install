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
using ON.Notification.SimpleNotification.Service.Clients;

namespace ON.Notification.SimpleNotification.Service.Services
{
    [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER_OR_SERVICE_OR_BOT)]
    public class NotificationService : NotificationInterface.NotificationInterfaceBase
    {
        private readonly ILogger logger;
        private readonly SendgridClient sendgridClient;

        public NotificationService(ILogger<NotificationService> logger, SendgridClient sendgridClient)
        {
            this.logger = logger;
            this.sendgridClient = sendgridClient;
        }

        public override async Task<SendEmailResponse> SendEmail(SendEmailRequest request, ServerCallContext context)
        {
            try
            {
                var error = await sendgridClient.SendEmail(request);
                if (error != null)
                    return new() { Error = error };

                return new();
            }
            catch
            {
                return new() { Error = "Unknown Error" };
            }
        }
    }
}
