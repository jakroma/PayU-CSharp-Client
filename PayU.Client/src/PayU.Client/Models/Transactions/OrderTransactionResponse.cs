using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayU.Client.Models.Transactions
{
    public class OrderTransactionResponse
    {
        [JsonProperty(PayUContainer.PropsName.Transactions)]
        public IList<Transaction> Transactions { get; set; }
    }
}