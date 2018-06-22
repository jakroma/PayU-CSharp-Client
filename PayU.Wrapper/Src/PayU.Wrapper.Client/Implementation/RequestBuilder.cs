using System;
using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;
using RestSharp;

namespace PayU.Wrapper.Client
{
    /// <summary>
    /// RequestBuilderTemplate
    /// </summary>
    public sealed class RequestBuilder : IRequestBuilder
    {
        private readonly IRestRequest _restRequest;

        public RequestBuilder()
        {
            _restRequest = new RestRequest();
            _restRequest.Timeout = 3000;
        }

        public async Task<IRestRequest> PreparePostOAuthToke(UserRequest userRequest)
        {
            IRestRequest restRequest = new RestRequest("pl/standard/user/oauth/authorize");
            restRequest.Method = Method.POST;
            restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            restRequest.AddBody($"grant_type=client_credentials&client_id={userRequest.ClientId}&client_secret={userRequest.ClientSecret}");

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
            restRequest.Method = Method.GET;
            restRequest.AddHeader("Authorization", $"{tokenContract.TokenType} {tokenContract.AccessToken}");

            return restRequest;
        }

        public async Task<IRestRequest> PreparePostCreateNewOrder(int orderId, TokenContract tokenContract, OrderContract orderContract)
        {
            if (orderId == 0)
            {
                throw new ArgumentException();
            }

            IRestRequest restRequest = new RestRequest("api/v2_1/orders/{order_id}");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Method = Method.POST;
            restRequest.AddHeader("Authorization", $"{tokenContract.TokenType} {tokenContract.AccessToken}");
            restRequest.AddBody(orderContract);

            return restRequest;
        }

        public Task<IRestRequest> GetRefundOrder<T>(int orderId, TokenContract tokenContract)
        {
            throw new NotImplementedException();
        }

        public Task<IRestRequest> UpdateOrder()
        {
            throw new NotImplementedException();
        }

        public Task<IRestRequest> CancelOrder()
        {
            throw new NotImplementedException();
        }

        public Task<IRestRequest> PayOutFromShop()
        {
            throw new NotImplementedException();
        }

        public Task<IRestRequest> RetrevePayout()
        {
            throw new NotImplementedException();
        }
    }
}