namespace ON.CreatorDashboard.Service.Models
{
    public class Ban
    {
        private string id { get; set; }
        private bool isValid { get; set; } = false;
        private string userId { get; set; }
        private string message { get; set; }
        private string reason { get; set; }
        private string bannedBy { get; set; }
        private string unbannedBy { get; set; }
        private Google.Protobuf.WellKnownTypes.Timestamp dateBanned { get; set; } = new Google.Protobuf.WellKnownTypes.Timestamp();
        private Google.Protobuf.WellKnownTypes.Duration durationBanned { get; set; }
        private Google.Protobuf.WellKnownTypes.Timestamp dateUnbanned { get; set; }
    }
}
