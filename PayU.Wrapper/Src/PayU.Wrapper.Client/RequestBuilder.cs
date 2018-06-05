using System;
using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;
using RestSharp;

namespace PayU.Wrapper.Client
{
    /// <summary>
    /// RequestBuilderTemplate
    /// </summary>
    internal sealed class RequestBuilder : IRequestBuilder
    {
        public async Task<IRestRequest> PrepareRequestPostOrders(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException();
            }

            IRestClient restClient = new RestClient(baseUrl);
            IRestRequest restRequest = new RestRequest();

            return restRequest;
        }

        public async Task<IRestRequest> PrepareOAuthToke(UserRequest userRequest)
        {
            if (string.IsNullOrEmpty(userRequest.MD5Key) || string.IsNullOrEmpty(userRequest.ClientId))
            {
                throw new ArgumentNullException();
            }

            IRestRequest restRequest = new RestRequest("pl/standard/user/oauth/authorize");
            restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            restRequest.AddBody($"grant_type=client_credentials&client_id={userRequest.ClientId}&client_secret={userRequest.MD5Key}");

            return restRequest;
        }

        public async Task<IRestRequest> PrepareGetOrderDetails(int orderId, TokenContract tokenContract)
        {
            if (orderId == 0)
            {
                throw new ArgumentException();
            }

            IRestRequest restRequest = new RestRequest("api/v2_1/orders/{order_id}");
            restRequest.AddUrlSegment("order_id", orderId.ToString());
            restRequest.AddHeader("Authorization", $"{tokenContract.TokenType} {tokenContract.Access_Token}");

            return restRequest;
        }
    }
}