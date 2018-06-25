using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        private readonly RequestBuilder _requestBuilder;

        /// <summary>
        /// The rest client builder
        /// </summary>
        private readonly RestClientBuilder _restClientBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl"></param>
        public ResponseBuilder(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
            _requestBuilder = new RequestBuilder();
            _restClientBuilder = new RestClientBuilder(baseUrl);
        }

        public async Task<TokenContract> PostAOuthToken(UserRequestData userRequestData)
        {
            IRestRequest request = await _requestBuilder.PreparePostOAuthToke(userRequestData);

            var restResponse = _restClient.Execute<TokenContract>(request);

            if (restResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException($"Status:{restResponse.ResponseStatus} Message:{restResponse.ErrorMessage}");
            }

            return restResponse.Data;
        }

        public async Task<T> GetOrderDetails<T>(int orderId , TokenContract tokenContract)
        {
            if (typeof(T).FullName != typeof(PayUClient).FullName && typeof(T).FullName != typeof(OrderContract).FullName)
            {
                throw new InvalidGenericTypeException(typeof(T).FullName);
            }

            IRestRequest request = await _requestBuilder.PrepareGetOrderDetails(orderId, tokenContract);

            var restResponse = _restClientBuilder.Execute(request);

            if (restResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException($"Status:{restResponse.ResponseStatus} Message:{restResponse.ErrorMessage}");
            }

            return (T)Convert.ChangeType(restResponse, typeof(T));
        }

        public Task<T> PostRefundOrder<T>(int orderId, TokenContract tokenContract)
        {
            if (typeof(T) != typeof(PayUClient) && typeof(T) != typeof(IRestResponse))
            {
                throw new InvalidGenericTypeException(typeof(T).FullName);
            }
            throw new NotImplementedException();
        }

        public async Task<T> PutUpdateOrder<T>(int orderId, OrderStatus orderStatus, TokenContract tokenContract)
        {
            if (typeof(T) != typeof(PayUClient) && typeof(T) != typeof(IRestResponse))
            {
                throw new InvalidGenericTypeException(typeof(T).FullName);
            }

            IRestRequest request = await _requestBuilder.PrepareGetOrderDetails(orderId, tokenContract);

            var restResponse = _restClient.Execute<OrderContract>(request);

            if (restResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException($"Status:{restResponse.ResponseStatus} Message:{restResponse.ErrorMessage}");
            }

            return (T)Convert.ChangeType(restResponse, typeof(T));
        }

        public Task<T> DeleteCancelOrderTask<T>(int orderId, TokenContract token)
        {
            if (typeof(T) != typeof(PayUClient) && typeof(T) != typeof(IRestResponse))
            {
                throw new InvalidGenericTypeException(typeof(T).FullName);
            }
            throw new NotImplementedException();
        }

        public async Task<T> PostCreateNewOrder<T>(int orderId, TokenContract tokenContract, OrderContract orderContract)
         {
             try
             {
                 if (typeof(T) != typeof(PayUClient) && typeof(T) != typeof(IRestResponse))
                 {
                     throw new InvalidGenericTypeException(typeof(T).FullName);
                 }

                 IRestRequest request = await _requestBuilder.PreparePostCreateNewOrder(orderId, tokenContract, orderContract);

                 var restResponse = _restClient.Execute<OrderContract>(request);

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