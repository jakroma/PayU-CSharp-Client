using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PayU.Wrapper.Client.Data
{
    /// <summary>
    /// Settings Contract
    /// </summary>
    [JsonObject]
    public class Settings
    {
        /// <summary>
        /// Gets or sets a value indicating whether [invoice disabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [invoice disabled]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty(PropertyName = "invoiceDisabled")]
        public bool invoiceDisabled { get; set; }
    }
}