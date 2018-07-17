using Newtonsoft.Json;

namespace PayU.Wrapper.Client.Data
{
    [JsonObject]
    public class PayByLinks
    {
        [JsonProperty(PropertyName = "value")]
        public string value { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "brandImageUrl")]
        public string brandImageUrl { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string status { get; set; }
    }
}