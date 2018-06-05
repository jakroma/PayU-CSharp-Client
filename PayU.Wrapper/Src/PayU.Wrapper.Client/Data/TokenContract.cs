using System;
using System.Runtime.Serialization;

namespace PayU.Wrapper.Client.Data
{
    /// <summary>
    /// Token Contract Class
    /// </summary>
    [DataContract]
    public class TokenContract
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        [DataMember(Name = "access_token")]
        public string Access_Token { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        /// <value>
        /// The type of the token.
        /// </value>
        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the expires in.
        /// </summary>
        /// <value>
        /// The expires in.
        /// </value>
        [DataMember(Name = "expires_in")]
        public int Expires_In { get; set; }

        /// <summary>
        /// Gets or sets the type of the grant.
        /// </summary>
        /// <value>
        /// The type of the grant.
        /// </value>
        [DataMember(Name = "grant_type")]
        public string Grant_Type { get; set; }
    }
}