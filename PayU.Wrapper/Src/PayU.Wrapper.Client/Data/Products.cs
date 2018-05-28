using System.Runtime.Serialization;

namespace PayU.Wrapper.Client.Data
{
    /// <summary>
    /// Products Contract
    /// </summary>
    [DataContract]
    public class Products
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        [DataMember(Name = "unitPrice")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }
    }
}