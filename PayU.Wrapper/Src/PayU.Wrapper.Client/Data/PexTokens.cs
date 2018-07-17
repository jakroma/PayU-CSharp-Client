using Newtonsoft.Json;

namespace PayU.Wrapper.Client.Data
{
    [JsonObject]
    public class PexTokens
    {
        [JsonProperty(PropertyName = "accountNumber")]
        public string accountNumber { get; set; }
        [JsonProperty(PropertyName = "payType")]
        public string payType { get; set; }
        [JsonProperty(PropertyName = "value")]
        public string value { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "brandImageUrl")]
        public string brandImageUrl { get; set; }
        [JsonProperty(PropertyName = "preferred")]
        public bool preferred { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string status { get; set; }
    }
}