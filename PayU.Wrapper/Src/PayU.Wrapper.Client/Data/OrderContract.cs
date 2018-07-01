using System.Collections.Generic;
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
        public string notifyUrl { get; set; }

        /// <summary>
        /// Gets or sets the customer ip address.
        /// </summary>
        /// <value>
        /// The customer ip address.
        /// </value>
        public string customerIp { get; set; }

        /// <summary>
        /// Gets or sets the merchant position identifier.
        /// </summary>
        /// <value>
        /// The merchant position identifier.
        /// </value>
        public int merchantPosId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string description { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public string currencyCode { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal totalAmount { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public List<Product> products { get; set; }
    }
}