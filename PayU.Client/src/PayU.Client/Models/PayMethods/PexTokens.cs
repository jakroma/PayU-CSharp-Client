using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class PexToken
    {


        [JsonProperty(PayUContainer.PropsName.AccountNumber)]
        public string AccountNumber { get; set; }

        [JsonProperty(PayUContainer.PropsName.PayType)]
        public string PayType { get; set; }

        [JsonProperty(PayUContainer.PropsName.Value)]
        public string Value { get; set; }

        [JsonProperty(PayUContainer.PropsName.Name)]
        public string Name { get; set; }

        [JsonProperty(PayUContainer.PropsName.BrandImageUrl)]
        public string BrandImageUrl { get; set; }

        [JsonProperty(PayUContainer.PropsName.Preferred)]
        public bool Preferred { get; set; }

        [JsonProperty(PayUContainer.PropsName.Status)]
        public string Status { get; set; }
    }
}