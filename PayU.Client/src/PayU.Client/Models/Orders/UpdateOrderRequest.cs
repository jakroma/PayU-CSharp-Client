using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class UpdateOrderRequest
    {
        public UpdateOrderRequest(string orderId, string orderStatus)
        {
            this.OrderId = orderId;
            this.OrderStatus = orderStatus;
        }

        [JsonProperty(PayUContainer.PropsName.OrderId)]
        public string OrderId { get; private set; }
        
        [JsonProperty(PayUContainer.PropsName.OrderStatus)]
        public string OrderStatus { get; private set; }
    }
}