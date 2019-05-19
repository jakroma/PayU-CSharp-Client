using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class OrderCardTokenResponse : BaseOrderResponse
    {
        [JsonProperty(PayUContainer.PropsName.Status)]
        public StatusSeverity Status { get; set; }

        [JsonProperty(PayUContainer.PropsName.PayMethods)]
        public OrderPayMethodsCardResponse PayMethods { get; set; }
    }
}