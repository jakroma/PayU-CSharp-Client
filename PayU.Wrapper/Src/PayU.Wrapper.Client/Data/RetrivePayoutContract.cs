using System.Collections.Generic;
using Newtonsoft.Json;

namespace PayU.Wrapper.Client.Data
{
    [JsonObject]
    public class RetrivePayoutContract
    {
        /// <summary>
        /// Gets or sets the card tokens.
        /// </summary>
        /// <value>
        /// The card tokens.
        /// </value>
        [JsonProperty(PropertyName = "cardTokens")]
        public List<CardTokens> cardTokens { get; set; }

        /// <summary>
        /// Gets or sets the pex tokens.
        /// </summary>
        /// <value>
        /// The pex tokens.
        /// </value>
        [JsonProperty(PropertyName = "pexTokens")]
        public List<PexTokens> pexTokens { get; set; }

        /// <summary>
        /// Gets or sets the pay by links.
        /// </summary>
        /// <value>
        /// The pay by links.
        /// </value>
        [JsonProperty(PropertyName = "payByLinks")]
        public List<PayByLinks> payByLinks { get; set; }
    }
}