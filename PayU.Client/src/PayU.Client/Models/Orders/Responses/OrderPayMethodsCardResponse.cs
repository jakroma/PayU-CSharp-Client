using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class OrderPayMethodsCardResponse
    {
        [JsonProperty(PayUContainer.PropsName.PayMethod)]
        public OrderPayMethodResponse PayMethod { get; set; }
    }
}