using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public abstract class BaseOrderResponse
    {
        [JsonProperty(PayUContainer.PropsName.OrderId)]
        public string OrderId { get; set; }

        [JsonProperty(PayUContainer.PropsName.RedirectUri)]
        public string RedirectUri { get; set; }

        [JsonProperty(PayUContainer.PropsName.ExtOrderId)]
        public string ExtOrderId { get; set; }
    }
}