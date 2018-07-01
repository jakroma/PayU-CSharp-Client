using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayU.Wrapper.Client.Data;
using RestSharp;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Exception;

namespace PayU.Wrapper.Client
{
    public class ResponseBuilder : IResponseBuilder
    {
        /// <summary>
        /// The rest client
        /// </summary>
        private readonly IRestClient _restClient;

        /// <summary>
        /// The request builder
        /// </summary>
        private readonly IRequestBuilder _requestBuilder;

        /// <summary>
        /// ONLY FOR TEST!!!
        /// </summary>
        /// <param name="restClient"></param>
        /// <param name="requestBuilder"></param>
        public ResponseBuilder(IRestClient restClient, IRequestBuilder requestBuilder)
        {
            this._restClient = restClient;
            this._requestBuilder = requestBuilder;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl"></param>
        public ResponseBuilder(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
            _requestBuilder = new RequestBuilder();
        }

        public async Task<TokenContract> PostAOuthToken(UserRequestData userRequestData)
        {
            IRestRequest request = await _requestBuilder.PreparePostOAuthToke(userRequestData);

            var restResponse = _restClient.Execute(request);

            if (restResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException($"Status:{restResponse.ResponseStatus} Message:{restResponse.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<TokenContract>(restResponse.Content);
        }

        public async Task<T> GetOrderDetails<T>(string orderId , TokenContract tokenContract)
        {
            if (typeof(T).FullName != typeof(PayUClient).FullName && typeof(T).FullName != typeof(OrderContract).FullName)
            {
                throw new InvalidGenericTypeException(typeof(T).FullName);
            }

            IRestRequest request = await _requestBuilder.PrepareGetOrderDetails(orderId, tokenContract);

            var restResponse = _restClient.Execute(request);

            if (restResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException($"Status:{restResponse.ResponseStatus} Message:{restResponse.ErrorMessage}");
            }

            return (T)Convert.ChangeType(restResponse, typeof(T));
        }

        public Task<T> PostRefundOrder<T>(string orderId, TokenContract tokenContract)
        {
            if (typeof(T) != typeof(PayUClient) && typeof(T) != typeof(IRestResponse))
            {
                throw new InvalidGenericTypeException(typeof(T).FullName);
            }
            throw new NotImplementedException();
        }

        public async Task<T> PutUpdateOrder<T>(string orderId, OrderStatus orderStatus, TokenContract tokenContract)
        {
            if (typeof(T) != typeof(PayUClient) && typeof(T) != typeof(IRestResponse))
            {
                throw new InvalidGenericTypeException(typeof(T).FullName);
            }

            IRestRequest request = await _requestBuilder.PrepareGetOrderDetails(orderId, tokenContract);

            var restResponse = _restClient.Execute(request);

            if (restResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException($"Status:{restResponse.ResponseStatus} Message:{restResponse.ErrorMessage}");
            }

            return (T)Convert.ChangeType(restResponse, typeof(T));
        }

        public Task<T> DeleteCancelOrderTask<T>(string orderId, TokenContract tokenContract)
        {
            if (typeof(T) != typeof(PayUClient) && typeof(T) != typeof(IRestResponse))
            {
                throw new InvalidGenericTypeException(typeof(T).FullName);
            }

            IRestRequest request = await _requestBuilder.PrepareDeleteCancelOrder();

            if (restResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException($"Status:{restResponse.ResponseStatus} Message:{restResponse.ErrorMessage}");
            }
            throw new NotImplementedException();
        }

        public async Task<T> PostCreateNewOrder<T>(string orderId, TokenContract tokenContract, OrderContract orderContract)
         {
             try
             {
                 if (typeof(T) != typeof(PayUClient) && typeof(T) != typeof(IRestResponse))
                 {
                     throw new InvalidGenericTypeException(typeof(T).FullName);
                 }

                 IRestRequest request = await _requestBuilder.PreparePostCreateNewOrder(orderId, tokenContract, orderContract);

                 var restResponse = _restClient.Execute(request);

                 if (restResponse.StatusCode != HttpStatusCode.Found && restResponse.StatusCode != HttpStatusCode.Created)
                 {
                     throw new HttpRequestException($"Status:{restResponse.ResponseStatus} Message:{restResponse.ErrorMessage}");
                 }

                 return (T)Convert.ChangeType(restResponse, typeof(T));
            }
             catch (AggregateException exception)
             {
                 Console.WriteLine(exception.InnerExceptions.First());
                 throw new AggregateException().InnerException;
             }
        }

        public Task<T> PostPayOutFromShop<T>(TokenContract token)
        {
            if (typeof(T) != typeof(PayUClient) && typeof(T) != typeof(IRestResponse))
            {
                throw new InvalidGenericTypeException(typeof(T).FullName);
            }
            throw new NotImplementedException();
        }

        public Task<T> GetRetrevePayout<T>(TokenContract token)
        {
            if (typeof(T) != typeof(PayUClient) && typeof(T) != typeof(IRestResponse))
            {
                throw new InvalidGenericTypeException(typeof(T).FullName);
            }
            throw new NotImplementedException();
        }

        public Task<Response<T>> FinishRequest<T>()
        {
            throw new NotImplementedException();
        }
    }
}