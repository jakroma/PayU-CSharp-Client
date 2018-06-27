using PayU.Wrapper.Client.Enum;

namespace PayU.Wrapper.Client.Data
{
    /// <summary>
    /// User Request
    /// </summary>
    public class UserRequestData
    {
        /// <summary>
        /// Gets or sets the client secret.
        /// </summary>
        /// <value>
        /// The client secret.
        /// </value>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the m d5 key.
        /// </summary>
        /// <value>
        /// The m d5 key.
        /// </value>
        public string MD5Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// The data to request.
        /// </value>
        public DataToRequest DataToRequest { get; set; }

        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <value>
        /// The country code.
        /// </value>
        public CountryCode CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the order status.
        /// </summary>
        /// <value>
        /// The order status.
        /// </value>
        public OrderStatus OrderStatus { get; set; }
    }
}