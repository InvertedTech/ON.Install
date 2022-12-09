namespace ON.Settings
{
    public class SettingsClientSettings
    {
        public string EventDBConnStr { get; set; } = "esdb://eventdb:2113?tls=false&keepAliveTimeout=10000&keepAliveInterval=10000";
    }
}
