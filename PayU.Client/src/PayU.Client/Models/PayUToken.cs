using Newtonsoft.Json;

namespace PayU.Client.Models
{
    public class PayUToken
    {
        [JsonProperty(PayUContainer.PropsName.Access_Token)]
        public string AccessToken { get; set; }

        [JsonProperty(PayUContainer.PropsName.Token_Type)]
        public string TokenType { get; set; }

        [JsonProperty(PayUContainer.PropsName.Expires_In)]
        public int ExpireIn { get; set; }

        [JsonProperty(PayUContainer.PropsName.Refresh_Token)]
        public string RefreshToken { get; set; }

        [JsonProperty(PayUContainer.PropsName.Grant_Type)]
        public string GrantType { get; set; }
    }
}