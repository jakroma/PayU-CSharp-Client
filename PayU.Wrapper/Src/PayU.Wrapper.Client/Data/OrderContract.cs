using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PayU.Wrapper.Client.Data
{
    /// <summary>
    /// Payment Contract
    /// </summary>
    [JsonObject]
    public class OrderContract
    {
        /// <summary>
        /// Gets or sets the notify URL.
        /// </summary>
        /// <value>
        /// The notify URL.
        /// </value>
        [JsonProperty(PropertyName = "notifyUrl")]
        public string notifyUrl { get; set; }

        /// <summary>
        /// Gets or sets the customer ip address.
        /// </summary>
        /// <value>
        /// The customer ip address.
        /// </value>
        [JsonProperty(PropertyName = "customerIp")]
        public string customerIp { get; set; }

        /// <summary>
        /// Gets or sets the merchant position identifier.
        /// </summary>
        /// <value>
        /// The merchant position identifier.
        /// </value>
        [JsonProperty(PropertyName = "merchantPosId")]
        public int merchantPosId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        [JsonProperty(PropertyName = "currencyCode")]
        public string currencyCode { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        [JsonProperty(PropertyName = "totalAmount")]
        public decimal totalAmount { get; set; }

        /// <summary>
        /// Gets or sets the buyer.
        /// </summary>
        /// <value>
        /// The buyer.
        /// </value>
        [JsonProperty(PropertyName = "buyer")]
        public Buyer buyer { get; set; }


        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        [JsonProperty(PropertyName = "settings")]
        public Settings settings { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        [JsonProperty(PropertyName = "products")]
        public List<Product> products { get; set; }
    }
}