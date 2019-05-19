using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public abstract class BasePayMethod
    {
        [JsonProperty(PayUContainer.PropsName.Type)]
        public string Type { get; set; }

        [JsonProperty(PayUContainer.PropsName.Value)]
        public string Value { get; set; }
    }
}