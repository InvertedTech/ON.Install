using System.Text.Json;

namespace ON.Settings.SimpleSettings.Service.Helpers
{
    public class NeutralNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name;
    }
}
