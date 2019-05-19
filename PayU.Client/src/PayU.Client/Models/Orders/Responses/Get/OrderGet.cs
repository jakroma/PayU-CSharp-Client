using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class OrderGet : BaseOrder
    {
    
        [JsonProperty(PayUContainer.PropsName.OrderId)]
        public string OrderId { get; set; }

        [JsonProperty(PayUContainer.PropsName.OrderCreateDate)]
        public string OrderCreationDate { get; set; } 
    }
}