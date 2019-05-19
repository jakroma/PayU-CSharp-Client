using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class RetrivePayout : BasePayout
    {
        [JsonProperty(PayUContainer.PropsName.Amount)]
        public string Amount { get; set; }
    }
}