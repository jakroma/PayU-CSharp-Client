using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class RefundRequest
    {
        public RefundRequest(string orderId, RefundRq refund)
        {
            this.OrderId = orderId;
            this.Refund = refund;
        }

        [JsonProperty(PayUContainer.PropsName.OrderId)]
        public string OrderId { get; private set; }

        [JsonProperty(PayUContainer.PropsName.Refund)]
        public RefundRq Refund { get; private set; }

    }
}