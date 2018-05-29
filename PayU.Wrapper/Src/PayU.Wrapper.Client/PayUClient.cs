using System;
using System.Threading.Tasks;
using RestSharp;

namespace PayU.Wrapper.Client
{
    /// <summary>
    /// Pay U Client Class
    /// </summary>
    /// <seealso cref="PayU.Wrapper.Client.IPayUClient" />
    public class PayUClient : IPayUClient
    {
        /// <summary>
        /// The base URL for API (TEST/PRODUCTION)
        /// </summary>
        private readonly string _baseUrl;

        /// <summary>
        /// The request builder
        /// </summary>
        private readonly IRequestBuilder _requestBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayUClient"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="requestBuilder">The request builder.</param>
        public PayUClient(string baseUrl, IRequestBuilder requestBuilder)
        {
            this._baseUrl = baseUrl;
            this._requestBuilder = requestBuilder;
        }

        /// <summary>
        /// Gets the connection to API.
        /// </summary>
        /// <returns>
        /// Response
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IRestResponse> PostOrder()
        {
            IRestRequest request = await _requestBuilder.PrepareRequestPostOrders(_baseUrl);
            if (request == null)
            {
                throw new NullReferenceException();
            }

            throw new NotImplementedException();
        }
    }
}