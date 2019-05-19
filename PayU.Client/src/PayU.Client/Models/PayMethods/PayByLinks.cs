using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class PayByLink
    {
        [JsonProperty(PayUContainer.PropsName.Value)]
        public string Value { get; set; }

        [JsonProperty(PayUContainer.PropsName.Name)]
        public string Name { get; set; }

        [JsonProperty(PayUContainer.PropsName.BrandImageUrl)]
        public string BrandImageUrl { get; set; }

        [JsonProperty(PayUContainer.PropsName.Status)]
        public string Status { get; set; }
    }
}