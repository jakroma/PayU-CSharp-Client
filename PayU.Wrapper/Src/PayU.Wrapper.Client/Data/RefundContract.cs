using Newtonsoft.Json;

namespace PayU.Wrapper.Client.Data
{
    public class RefundContract
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the refund.
        /// </summary>
        /// <value>
        /// The refund.
        /// </value>
        [JsonProperty("refund")]
        public Refund Refund { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}