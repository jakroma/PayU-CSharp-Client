using System.Resources;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class OrderResponse : BaseOrderResponse
    {
        [JsonProperty(PayUContainer.PropsName.Status)]
        public StatusDescResponse Status { get; set; }
    }
}