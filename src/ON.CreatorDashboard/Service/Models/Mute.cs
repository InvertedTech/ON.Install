namespace ON.CreatorDashboard.Service.Models
{
    public class Mute 
    {
        private string id { get; set; }
        private bool isValid { get; set; } = false;
        private string userId { get; set; }
        private string message { get; set; }
        private string reason { get; set; }
        private string mutedBy { get; set; }
        private string unmutedBy { get; set; }
        private Google.Protobuf.WellKnownTypes.Timestamp dateMuted { get; set; } = new Google.Protobuf.WellKnownTypes.Timestamp();
        private Google.Protobuf.WellKnownTypes.Duration durationMuted { get; set; }
        private Google.Protobuf.WellKnownTypes.Timestamp DateUnmuted { get; set; }
    }
}
