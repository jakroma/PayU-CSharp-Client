using Newtonsoft.Json;

namespace PayU.Client.Models.Transactions
{
    public class TransactionPayMethod
    {
        [JsonProperty(PayUContainer.PropsName.Value)]
        public string Value { get; set; }
    }
}