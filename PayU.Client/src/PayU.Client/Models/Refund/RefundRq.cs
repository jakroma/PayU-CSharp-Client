using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class RefundRq
    {
        public RefundRq(string description, string amount)
        {
            this.Description = description;
            this.Amount = amount;
        }

        public RefundRq(string description)
        {
            this.Description = description;
        }

        /// <summary>
        /// Mandatory Field
        /// </summary>
        [JsonProperty(PayUContainer.PropsName.Description)]
        public string Description { get; private set; }

        [JsonProperty(PayUContainer.PropsName.Amount, NullValueHandling = NullValueHandling.Ignore)]
        public string Amount { get; set; }
    }
}