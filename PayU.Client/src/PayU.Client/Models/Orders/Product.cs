using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class Product
    {
        public Product(string name, string unitPrice, string quantity)
        {
            this.Name = name;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
        }

        [JsonProperty(PayUContainer.PropsName.Name)]
        public string Name { get; set; }

        [JsonProperty(PayUContainer.PropsName.UnitPrice)]
        public string UnitPrice { get; set; }

        [JsonProperty(PayUContainer.PropsName.Quantity)]
        public string Quantity { get; set; }
    }
}