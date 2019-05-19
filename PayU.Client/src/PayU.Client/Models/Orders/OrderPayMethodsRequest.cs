using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class OrderPayMethodsRequest
    {
        public OrderPayMethodsRequest(OrderPayMethodRequest payMethod) => this.PayMethod = payMethod;

        public OrderPayMethodsRequest(string value)
        {
            this.PayMethod = new OrderPayMethodRequest(value);
        }

        public OrderPayMethodsRequest(string type, string value)
        {
            this.PayMethod = new OrderPayMethodRequest(type, value);
        }

        [JsonProperty(PayUContainer.PropsName.PayMethod)]
        public OrderPayMethodRequest PayMethod { get; set; }
    }
}