using Newtonsoft.Json;

namespace PayU.Wrapper.Client.Data
{
    public class Status
    {
        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("statusDesc")]
        public string StatusDesc { get; set; }
    }
}