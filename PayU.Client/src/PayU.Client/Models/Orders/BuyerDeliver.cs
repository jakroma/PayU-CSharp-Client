using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class BuyerDeliver
    {
        public BuyerDeliver(string street,
            string postalCode,
            string city,
            string countryCode,
            string recipientName)
        {
            this.Street = street;
            this.PostalCode = postalCode;
            this.City = city;
            this.CountryCode = countryCode;
            this.RecipientName = recipientName;
        }

        /// <summary>
        /// Mandatory Field
        /// </summary>
        [JsonProperty(PayUContainer.PropsName.Street)]
        public string Street { get; private set; }

        [JsonProperty(PayUContainer.PropsName.PostalBox, NullValueHandling = NullValueHandling.Ignore)]
        public string PostalBox { get; set; }

        /// <summary>
        /// Mandatory Field
        /// </summary>
        [JsonProperty(PayUContainer.PropsName.PostalCode)]
        public string PostalCode { get; private set; }
        
        /// <summary>
        /// Mandatory Field
        /// </summary>
        [JsonProperty(PayUContainer.PropsName.City)]
        public string City { get; private set; }

        [JsonProperty(PayUContainer.PropsName.State, NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }

        [JsonProperty(PayUContainer.PropsName.CountryCode, NullValueHandling = NullValueHandling.Ignore)]
        public string CountryCode { get; private set; }

        [JsonProperty(PayUContainer.PropsName.Name, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Mandatory Field
        /// </summary>
        [JsonProperty(PayUContainer.PropsName.RecipientName)]
        public string RecipientName { get; private set; }

        [JsonProperty(PayUContainer.PropsName.RecipientPhone, NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientPhone { get; set; }

        [JsonProperty(PayUContainer.PropsName.RecipientEmail, NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientEmail { get; set; }
    }
}