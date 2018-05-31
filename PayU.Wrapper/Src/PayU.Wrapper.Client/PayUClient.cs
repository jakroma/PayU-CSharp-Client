using System;
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
    public sealed class PayUClient : IPayUClient
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
        /// The request type
        /// </summary>
        public RequestType _requestType;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayUClient"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="userRequest">The user request.</param>
        public PayUClient(string baseUrl, RequestType requestType, UserRequest userRequest)
         {
            this._baseUrl = baseUrl;
            this._userRequest = userRequest;
             this._requestType = requestType;
            this._requestBuilder = new RequestBuilder();
        }

        public async Task<Response<T>> Request<T>(string baseUrl, UserRequest userRequest)
        {
            await AOuthToken(_userRequest.Token);
            switch (_requestType)
            {
                case RequestType.Order:
                    throw new NotImplementedException();

                case RequestType.Payment:
                    throw new NotImplementedException();

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
        private async Task AOuthToken(string Token)
        {
            IRestRequest request = await _requestBuilder.PrepareOAuthToke(Token, _baseUrl);
        }
    }
}