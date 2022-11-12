using System.Text.Json;

namespace ON.Authentication.SimpleAuth.Service.Helpers
{
    public class NeutralNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name;
    }
}
