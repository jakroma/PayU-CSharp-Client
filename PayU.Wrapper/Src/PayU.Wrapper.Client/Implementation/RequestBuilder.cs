using System;
using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Helpers;
using RestSharp;

namespace PayU.Wrapper.Client
{
    /// <summary>
    /// RequestBuilderTemplate
    /// </summary>
    public sealed class RequestBuilder : IRequestBuilder
    {
        public async Task<IRestRequest> PreparePostOAuthToke(UserRequestData userRequestData)
        {
            if (string.IsNullOrEmpty(userRequestData.ClientId) || string.IsNullOrEmpty(userRequestData.ClientSecret))
            {
                throw new ArgumentException();
            }

            IRestRequest restRequest = new RestRequest("pl/standard/user/oauth/authorize");
            restRequest.Method = Method.POST;
            restRequest.Timeout = 3000;
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            restRequest.AddParameter("application/json",
                $"grant_type=client_credentials&client_id={userRequestData.ClientId}&client_secret={userRequestData.ClientSecret}",
                ParameterType.RequestBody);

            return restRequest;
        }

        public async Task<IRestRequest> PrepareGetOrderDetails(string orderId, TokenContract tokenContract)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                throw new ArgumentException();
            }

            IRestRequest restRequest = new RestRequest("api/v2_1/orders/{order_id}");
            restRequest.Method = Method.GET;
            restRequest.Timeout = 3000;
            restRequest.AddHeader("Authorization", $"{tokenContract.token_type} {tokenContract.access_token}");

            return restRequest;
        }

        public async Task<IRestRequest> PreparePostCreateNewOrder(string orderId, TokenContract tokenContract, OrderContract orderContract)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                throw new ArgumentException();
            }

            IRestRequest restRequest = new RestRequest("api/v2_1/orders/{order_id}");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Method = Method.POST;
            restRequest.AddHeader("Authorization", $"{tokenContract.token_type} {tokenContract.access_token}");
            restRequest.AddBody(orderContract);

            return restRequest;
        }

        public async Task<IRestRequest> PreparePostRefundOrder<T>(string orderId, TokenContract tokenContract)
        {
            throw new NotImplementedException();
        }

        public async Task<IRestRequest> PreparePutUpdateOrder(string orderId, OrderStatus orderStatus, TokenContract tokenContract)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                throw new ArgumentException();
            }

            IRestRequest restRequest = new RestRequest("api/v2_1/orders/{order_id}");
            restRequest.Method = Method.PUT;
            restRequest.AddUrlSegment("order_id", orderId.ToString());
            restRequest.AddBody($"\\ 'orderId': {orderId}," +
                                $" \\'orderStatus': {EnumToStringHelper.OrderStatusToString(orderStatus)}" +
                                $" \\");
            restRequest.AddParameter("application/json",
                $"\\ 'orderId': {orderId}," +
                $" \\'orderStatus': {EnumToStringHelper.OrderStatusToString(orderStatus)}" +
                $" \\",
                ParameterType.RequestBody);
            restRequest.AddHeader("Authorization", $"{tokenContract.token_type} {tokenContract.access_token}");

            return restRequest;
        }

        public Task<IRestRequest> PrepareDeleteCancelOrder()
        {
            throw new NotImplementedException();
        }

        public Task<IRestRequest> PreparePostPayOutFromShop()
        {
            throw new NotImplementedException();
        }

        public Task<IRestRequest> PrepareGetRetrevePayout()
        {
            throw new NotImplementedException();
        }

        public Task<IRestRequest> PrepareDeleteToken()
        {
            throw new NotImplementedException();
        }
    }
}