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

        public PayUClient(string baseUrl, IRequestBuilder requestBuilder)
        {
            this._baseUrl = baseUrl;
            this._requestBuilder = requestBuilder;
        }

        public Task<IRestResponse> PostOrder()
        {
            throw new System.NotImplementedException();
        }
    }
}