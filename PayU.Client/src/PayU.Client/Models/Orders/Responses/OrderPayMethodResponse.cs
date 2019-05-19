using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class OrderPayMethodResponse : BasePayMethod
    {
        [JsonProperty(PayUContainer.PropsName.Card)]
        public Card Card { get; set; }
    }
}