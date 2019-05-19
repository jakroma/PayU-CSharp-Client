using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class OrderGetResponse
    {
        [JsonProperty(PayUContainer.PropsName.Orders)]
        public IList<OrderGet> Orders { get; set; }

        [JsonProperty(PayUContainer.PropsName.Status)]
        public StatusDescResponse Status { get; set; }
    }
}