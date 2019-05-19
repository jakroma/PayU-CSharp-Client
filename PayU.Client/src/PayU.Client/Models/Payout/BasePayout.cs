using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public abstract class BasePayout
    {
        [JsonProperty(PayUContainer.PropsName.PayoutId)]
        public string PayoutId { get; set; }

        [JsonProperty(PayUContainer.PropsName.Status)]
        public string Status { get; set; }
    }
}