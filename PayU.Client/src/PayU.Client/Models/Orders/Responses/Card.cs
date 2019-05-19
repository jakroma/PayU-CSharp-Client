using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class Card : BaseCard
    {
        [JsonProperty(PayUContainer.PropsName.Number)]
        public string Number { get; set; }
    }
}