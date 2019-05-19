using System;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class Refund
    {
        [JsonProperty(PayUContainer.PropsName.RefundId)]
        public string RefundId { get; set; }
        
        [JsonProperty(PayUContainer.PropsName.ExtRefundId)]
        public string ExtRefundId { get; set; }

        [JsonProperty(PayUContainer.PropsName.Amount)]
        public string Amount { get; set; }

        [JsonProperty(PayUContainer.PropsName.CurrencyCode)]
        public string CurrencyCode { get; set; }

        [JsonProperty(PayUContainer.PropsName.Description)]
        public string Description { get; set; }

        [JsonProperty(PayUContainer.PropsName.CreationDateTime)]
        public string CreationDateTime { get; set; }

        [JsonProperty(PayUContainer.PropsName.Status)]
        public string Status { get; set; }

        [JsonProperty(PayUContainer.PropsName.StatusDateTime)]
        public string StatusDateTime { get; set; }
    }
}