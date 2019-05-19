using Newtonsoft.Json;

namespace PayU.Client.Models.Transactions
{
    public class TransactionCard
    {
        [JsonProperty(PayUContainer.PropsName.CardData)]
        public TransactionCardData CardData { get; set; }
    }
}