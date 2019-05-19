using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class CurrencyPair
    {
        [JsonProperty(PayUContainer.PropsName.BaseCurrency)]
        public string BaseCurrency { get; set; }

        [JsonProperty(PayUContainer.PropsName.ExchangeRate)]
        public double ExchangeRate { get; set; }

        [JsonProperty(PayUContainer.PropsName.TermCurrency)]
        public string TermCurrency { get; set; }
    }
}