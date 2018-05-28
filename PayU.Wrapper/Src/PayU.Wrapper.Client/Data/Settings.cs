using System.Runtime.Serialization;

namespace PayU.Wrapper.Client.Data
{
    /// <summary>
    /// Settings Contract
    /// </summary>
    [DataContract]
    public class Settings
    {
        /// <summary>
        /// Gets or sets a value indicating whether [invoice disabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [invoice disabled]; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "invoiceDisabled")]
        public bool InvoiceDisabled { get; set; }
    }
}