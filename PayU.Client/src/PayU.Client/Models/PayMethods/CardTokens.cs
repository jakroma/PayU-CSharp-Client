using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class CardToken : BaseCard
    {
        [JsonProperty(PayUContainer.PropsName.CardNumberMasked)]
        public string CardNumberMasked { get; set; }

        [JsonProperty(PayUContainer.PropsName.CardScheme)]
        public string CardScheme { get; set; }

        [JsonProperty(PayUContainer.PropsName.Value)]
        public string Value { get; set; }

        [JsonProperty(PayUContainer.PropsName.BrandImageUrl)]
        public string BrandImageUrl { get; set; }

        [JsonProperty(PayUContainer.PropsName.Preferred)]
        public bool Preferred { get; set; }

        [JsonProperty(PayUContainer.PropsName.Status)]
        public string Status { get; set; }
    }
}