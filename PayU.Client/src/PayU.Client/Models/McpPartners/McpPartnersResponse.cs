using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class McpPartnersResponse
    {
        [JsonProperty(PayUContainer.PropsName.Id)]
        public string Id { get; set; }

        [JsonProperty(PayUContainer.PropsName.ValidTo)]
        public string validTo { get; set; }

        [JsonProperty(PayUContainer.PropsName.CurrencyPairs)]
        public IList<CurrencyPair> CurrencyPairs { get; set; }
    }
}