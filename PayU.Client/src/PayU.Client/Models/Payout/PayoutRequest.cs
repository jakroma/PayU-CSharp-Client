using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class PayoutRequest
    {
        public PayoutRequest(string shopId, long payoutAmount)
        {
            this.ShopId = shopId;
            this.Payout = new PayoutAmount(payoutAmount);
        }

        [JsonProperty(PayUContainer.PropsName.ShopId)]
        public string ShopId { get; set; }

        [JsonProperty(PayUContainer.PropsName.Payout)]
        public PayoutAmount Payout { get; set; }
    }
}