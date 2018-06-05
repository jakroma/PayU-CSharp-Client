namespace PayU.Wrapper.Client.Data
{
    /// <summary>
    /// User Request
    /// </summary>
    public class UserRequest
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
    }
}