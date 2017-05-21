using Newtonsoft.Json;

namespace ZSPA.ClientModels
{
    public class EnterpriseEntry
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}