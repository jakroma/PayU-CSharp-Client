using Newtonsoft.Json;

namespace PayU.Client.Models.Transactions
{
    public class TransactionCardData
    {
        [JsonProperty(PayUContainer.PropsName.CardNumberMasked)]
        public string CardNumberMasked { get; set; }

        [JsonProperty(PayUContainer.PropsName.CardScheme)]
        public string CardScheme { get; set; }
        
        [JsonProperty(PayUContainer.PropsName.CardProfile)]
        public string CardProfile { get; set; }

        [JsonProperty(PayUContainer.PropsName.CardClassification)]
        public string CardClassification { get; set; }

        [JsonProperty(PayUContainer.PropsName.CardResponseCode)]
        public string CardResponseCode { get; set; }

        [JsonProperty(PayUContainer.PropsName.CardResponseCodeDesc)]
        public string CardResponseCodeDesc { get; set; }
        
        [JsonProperty(PayUContainer.PropsName.CardEciCode)]
        public string CardEciCode { get; set; }

        [JsonProperty(PayUContainer.PropsName.Card3DsStatus)]
        public string Card3DsStatus { get; set; }

        [JsonProperty(PayUContainer.PropsName.CardBinCountry)]
        public string CardBinCountry { get; set; }
    }
}