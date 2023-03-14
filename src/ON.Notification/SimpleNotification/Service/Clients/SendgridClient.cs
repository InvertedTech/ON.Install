using ON.Fragments.Notification;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Threading.Tasks;
using ON.Settings;

namespace ON.Notification.SimpleNotification.Service.Clients
{
    public class SendgridClient
    {
        private readonly SettingsClient settingsClient;

        public SendgridClient(SettingsClient settingsClient)
        {
            this.settingsClient = settingsClient;
        }

        public async Task<string> SendEmail(SendEmailRequest request)
        {
            if (settingsClient.OwnerData?.Notification?.Sendgrid == null)
                return "Email Service Disabled";

            if (!settingsClient.OwnerData.Notification.Sendgrid.Enabled)
                return "Email Service Disabled";

            var apiKey = settingsClient.OwnerData.Notification.Sendgrid.ApiKeySecret;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(settingsClient.OwnerData.Notification.Sendgrid.SendFromAddress);
            var subject = request.Subject;
            var to = new EmailAddress(request.SendToAddress);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, request.BodyPlain, request.BodyHtml);
            var response = await client.SendEmailAsync(msg);

            return null;
        }
    }
}
