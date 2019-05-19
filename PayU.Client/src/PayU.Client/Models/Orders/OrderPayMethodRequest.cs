using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class OrderPayMethodRequest : BasePayMethod
    {
        public OrderPayMethodRequest() {}

        public OrderPayMethodRequest(string value) => this.Value = value;

        public OrderPayMethodRequest(string type, string value)
        { 
            this.Type = type;
            this.Value = value;
        }

        [JsonProperty(PayUContainer.PropsName.AuthorizationCode, NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorizationCode { get; set; }
    }
}