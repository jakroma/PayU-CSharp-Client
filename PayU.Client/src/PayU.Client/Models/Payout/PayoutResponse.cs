using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class PayoutResponse
    {
        [JsonProperty(PayUContainer.PropsName.Payout)]
        public Payout Payout { get; set; }

        [JsonProperty(PayUContainer.PropsName.Status)]
        public StatusCodeResponse Status { get; set; }
    }
}
