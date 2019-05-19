using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using PayU.Client.Models;

namespace PayU.Client.Models
{
    public class PayMethodsResponse
    {
        [JsonProperty(PayUContainer.PropsName.CardTokens)]
        public IList<CardToken> CardTokens { get; set; }

        [JsonProperty(PayUContainer.PropsName.PexTokens)]
        public IList<PexToken> PexTokens { get; set; }
        
        [JsonProperty(PayUContainer.PropsName.PayByLinks)]
        public IList<PayByLink> PayByLinks { get; set; }
        
    }
}