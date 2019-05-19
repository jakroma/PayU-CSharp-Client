using System.Net.Http;
using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class StatusCodeResponse
    {
        [JsonProperty(PayUContainer.PropsName.StatusCode)]
        public string StatusCode { get; set; }
    }
}