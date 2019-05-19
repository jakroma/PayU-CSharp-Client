using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class StatusDescResponse : StatusCodeResponse
    {
        [JsonProperty(PayUContainer.PropsName.StatusDesc)]
        public string StatusDesc { get; set; }
    }
}