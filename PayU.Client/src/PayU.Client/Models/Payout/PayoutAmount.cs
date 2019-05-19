using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class PayoutAmount
    {
        public PayoutAmount(long Amount)
        {
            this.Amount = Amount;
        }
        
        [JsonProperty(PayUContainer.PropsName.Amount)]
        public long Amount { get; private set; }
    }
}