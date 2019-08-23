using Newtonsoft.Json;

namespace SkiDataAPI.models
{
    /// <summary>
    /// Simple object for receiving angular site data
    /// </summary>
    [JsonObject]
    public class RegisterModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
