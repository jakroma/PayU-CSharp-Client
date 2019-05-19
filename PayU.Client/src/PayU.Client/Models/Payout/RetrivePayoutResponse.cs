using Newtonsoft.Json;
using PayU.Client.Models;

namespace PayU.Client.Models
{
    public class RetrivePayoutResponse
    {
        [JsonProperty(PayUContainer.PropsName.Payout)]
        public RetrivePayout RetrievePayout { get; set; }

        [JsonProperty(PayUContainer.PropsName.Status)]
        public StatusCodeResponse Status { get; set; }
    }
}