using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public abstract class BaseCard
    {
        [JsonProperty(PayUContainer.PropsName.CardExpirationYear)]
        public string CardExpirationYear { get; set; }

        [JsonProperty(PayUContainer.PropsName.CardExpirationMonth)]
        public string CardExpirationMonth { get; set; }
    }
}