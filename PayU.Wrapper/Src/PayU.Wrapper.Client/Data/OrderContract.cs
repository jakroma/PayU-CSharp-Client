using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PayU.Wrapper.Client.Data
{
    /// <summary>
    /// Payment Contract
    /// </summary>
    [DataContract]
    public class OrderContract
    {
        /// <summary>
        /// Gets or sets the notify URL.
        /// </summary>
        /// <value>
        /// The notify URL.
        /// </value>
        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Gets or sets the customer ip address.
        /// </summary>
        /// <value>
        /// The customer ip address.
        /// </value>
        [JsonProperty("customerIp")]
        public string CustomerIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the merchant position identifier.
        /// </summary>
        /// <value>
        /// The merchant position identifier.
        /// </value>
        [JsonProperty("merchantPosId")]
        public int MerchantPosId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        [JsonProperty("totalAmount")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the buyer.
        /// </summary>
        /// <value>
        /// The buyer.
        /// </value>
        [JsonProperty("buyer")]
        public Buyer Buyer { get; set; }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        [JsonProperty("products")]
        public Products[] Products { get; set; }
    }
}