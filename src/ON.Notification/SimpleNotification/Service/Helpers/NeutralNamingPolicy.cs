using System.Text.Json;

namespace ON.Notification.SimpleNotification.Service.Helpers
{
    public class NeutralNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name;
    }
}
