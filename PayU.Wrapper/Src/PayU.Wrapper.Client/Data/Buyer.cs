using System.Resources;
using System.Runtime.Serialization;

namespace PayU.Wrapper.Client.Data
{
    /// <summary>
    /// Buyer Contract
    /// </summary>
    [DataContract]
    public class Buyer
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [DataMember(Name = "email")]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        [DataMember(Name = "phone")]
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [DataMember(Name = "language")]
        public string Language { get; set; }
    }
}