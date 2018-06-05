using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using PayU.Shared;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using RestSharp;

namespace PayU.Wrapper.Client
{
    /// <summary>
    /// Pay U Client Class
    /// </summary>
    /// <seealso cref="PayU.Wrapper.Client.IPayUClient" />
    public sealed class PayUClient
    {
        /// <summary>
        /// The base URL for API (TEST/PRODUCTION)
        /// </summary>
        private readonly string _baseUrl;

        /// <summary>
        /// The request builder
        /// </summary>
        private readonly RequestBuilder _requestBuilder;

        /// <summary>
        /// The user request
        /// </summary>
        private readonly UserRequest _userRequest;

        /// <summary>
        /// The rest client
        /// </summary>
        private readonly RestClient _restClient;

        /// <summary>
        /// The request type
        /// </summary>
        public RequestType _requestType;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayUClient"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="userRequest">The user request.</param>
        public PayUClient(bool isProducition, RequestType requestType, UserRequest userRequest)
         {
            this._baseUrl = isProducition ? "https://secure.payu.com/api/v2_1" : "https://secure.snd.payu.com/api/v2_1"; 
            this._userRequest = userRequest;
            this._requestType = requestType;
            this._restClient = new RestClient(_baseUrl);
         }

        /// <summary>
        /// Requests the specified base URL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="userRequest">The user request.</param>
        /// <returns>
        /// Generic Response
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        /// <exception cref="InvalidRequestType"></exception>
        public async Task<PayUClient> Request(string baseUrl, UserRequest userRequest)
        {
            await AOuthToken();
            switch (_requestType)
            {
                case RequestType.Order:
                    return this;

                case RequestType.Payment:
                    return this;

                default:
                    throw new InvalidRequestType();
            }
        }

        /// <summary>
        /// Gets the connection to API.
        /// </summary>
        /// <returns>
        /// Response
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IRestResponse> Request()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// as the outh token.
        /// </summary>
        /// <param name="Token">The token.</param>
        /// <returns></returns>
        public async Task<Task<PayUClient>> AOuthToken()
        {
            IRestRequest request = await _requestBuilder.PrepareOAuthToke(_userRequest);

            var restResponse = _restClient.Execute<TokenContract>(request);

            return Request(_baseUrl, _userRequest);
        }
    }
}