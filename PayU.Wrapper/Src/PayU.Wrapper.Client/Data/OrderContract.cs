using System;
using System.Runtime.Serialization;
using RestSharp.Serializers;
using SimpleJson;

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
        [DataMember(Name = "notifyUrl")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Gets or sets the customer ip address.
        /// </summary>
        /// <value>
        /// The customer ip address.
        /// </value>
        [DataMember(Name = "customerIp")]
        public string CustomerIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the merchant position identifier.
        /// </summary>
        /// <value>
        /// The merchant position identifier.
        /// </value>
        [DataMember(Name = "merchantPosId")]
        public int MerchantPosId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        [DataMember(Name = "currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        [DataMember(Name = "totalAmount")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the buyer.
        /// </summary>
        /// <value>
        /// The buyer.
        /// </value>
        [DataMember(Name = "buyer")]
        public Buyer Buyer { get; set; }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        [DataMember(Name = "settings")]
        public Settings Settings { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        [DataMember(Name = "products")]
        public Products[] Products { get; set; }
    }
}