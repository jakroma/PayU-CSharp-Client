using Newtonsoft.Json;

namespace PayU.Wrapper.Client.Data
{
    [JsonObject]
    public class CardTokens
    {
        [JsonProperty(PropertyName = "cardExpirationYear")]
        public string cardExpirationYear { get; set; }
        [JsonProperty(PropertyName = "cardExpirationMonth")]
        public string cardExpirationMonth { get; set; }
        [JsonProperty(PropertyName = "cardNumberMasked")]
        public string cardNumberMasked { get; set; }
        [JsonProperty(PropertyName = "cardScheme")]
        public string cardScheme { get; set; }
        [JsonProperty(PropertyName = "value")]
        public string value { get; set; }
        [JsonProperty(PropertyName = "brandImageUrl")]
        public string brandImageUrl { get; set; }
        [JsonProperty(PropertyName = "preferred")]
        public bool preferred { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string status { get; set; }
    }
}