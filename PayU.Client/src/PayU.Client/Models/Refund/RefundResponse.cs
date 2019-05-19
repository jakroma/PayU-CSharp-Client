using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class RefundResponse
    {
        [JsonProperty(PayUContainer.PropsName.OrderId)]
        public string OrderId { get; set; }

        [JsonProperty(PayUContainer.PropsName.Refund)]
        public Refund Refund { get; set; }

        [JsonProperty(PayUContainer.PropsName.Status)]
        public StatusDescResponse Status { get; set; }
    }
}