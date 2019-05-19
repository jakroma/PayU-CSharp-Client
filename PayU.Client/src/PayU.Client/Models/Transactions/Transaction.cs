using Newtonsoft.Json;

namespace PayU.Client.Models.Transactions
{
    public class Transaction
    {
        [JsonProperty(PayUContainer.PropsName.PayMethod)]
        public TransactionPayMethod PayMethod { get; set; }

        [JsonProperty(PayUContainer.PropsName.PaymentFlow)]
        public string PaymentFlow { get; set; }

        [JsonProperty(PayUContainer.PropsName.Card)]
        public TransactionCard Card { get; set; }
    }
}