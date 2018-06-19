using System;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace PayU.Wrapper.Client.Data
{
    /// <summary>
    /// Refund class to RefundContractClass
    /// </summary>
    public class Refund
    {
        [JsonProperty("refundId")]
        public int RefundId { get; set; }
        
        [JsonProperty("extRefundId")]
        public string ExtRefundId { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("creationDateTime")]
        public DateTime CreationDateTime { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusDateTIme")]
        public DateTime StatusDateTime { get; set; }
    }
}