using System.Resources;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class Buyer
    {
        public Buyer(string email)
        {
            this.Email = email;
        }

        /// <summary>
        /// Mandatory Field
        /// </summary>
        [JsonProperty(PayUContainer.PropsName.Email)]
        public string Email { get; private set; }

        [JsonProperty(PayUContainer.PropsName.CustomerId, NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; set; }

        [JsonProperty(PayUContainer.PropsName.extCustomerId, NullValueHandling = NullValueHandling.Ignore)]
        public string ExtCumstomerId { get; set; }

        [JsonProperty(PayUContainer.PropsName.Phone, NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonProperty(PayUContainer.PropsName.FistName, NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty(PayUContainer.PropsName.LastName, NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty(PayUContainer.PropsName.Language, NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty(PayUContainer.PropsName.Nin, NullValueHandling = NullValueHandling.Ignore)]
        public string Nin { get; set; }

        [JsonProperty(PayUContainer.PropsName.BuyerDelivery, NullValueHandling = NullValueHandling.Ignore)]
        public BuyerDeliver BuyerDeliver { get; set; }
    }
}