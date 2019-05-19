using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class StatusSeverity : StatusCodeResponse
    {
        [JsonProperty(PayUContainer.PropsName.Severity)]
        public string Severity { get; set; }
    }
}