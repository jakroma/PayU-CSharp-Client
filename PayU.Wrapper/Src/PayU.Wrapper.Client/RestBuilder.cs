using System;
using System.Net.Http;
using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;
using RestSharp;
using PayU.Wrapper.Client;

namespace PayU.Wrapper.Client
{
    internal sealed class RestBuilder : IRestBuilder
    {
        /// <summary>
        /// The rest client
        /// </summary>
        private readonly RestClient _restClient;

        /// <summary>
        /// The request builder
        /// </summary>
        private readonly RequestBuilder _requestBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl"></param>
        public RestBuilder(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
            _requestBuilder = new RequestBuilder();
        }

        public async Task<T> GetAOuthToken<T>(UserRequest userRequest)
        {
            IRestRequest request = await _requestBuilder.PrepareOAuthToke(userRequest);

            var restResponse = _restClient.Execute<TokenContract>(request);

            if (restResponse.ResponseStatus != ResponseStatus.Completed)
            {
                throw new HttpRequestException("Request Fail");
            }

            return (T)Convert.ChangeType(restResponse, typeof(T));
        }

        public async Task<T> GetOrderDetails<T>(int orderId , TokenContract tokenContract)
        {
            IRestRequest request = await _requestBuilder.PrepareGetOrderDetails(orderId, tokenContract);

            var restResponse = _restClient.Execute<OrderContract>(request);

            if (restResponse.ResponseStatus != ResponseStatus.Completed)
            {
                throw new HttpRequestException("Request Fail");
            }

            return (T)Convert.ChangeType(restResponse, typeof(T));
        }

        public Task<PayUClient> RefundOrder()
        {
            throw new NotImplementedException();
        }

        public Task<PayUClient> UpdateOrder()
        {
            throw new NotImplementedException();
        }

        public Task<PayUClient> CancelOrder()
        {
            throw new NotImplementedException();
        }

        public Task<PayUClient> CreateNewOrder()
        {
            throw new NotImplementedException();
        }

        public Task<PayUClient> PayOutFromShop()
        {
            throw new NotImplementedException();
        }

        public Task<PayUClient> RetrevePayout()
        {
            throw new NotImplementedException();
        }

        public Task<Response<T>> FinishRequest<T>()
        {
            throw new NotImplementedException();
        }
    }
}