using System;
using System.Threading.Tasks;
using RestSharp;

namespace PayU.Wrapper.Client
{
    /// <summary>
    /// RequestBuilderTemplate
    /// </summary>
    /// <seealso cref="PayU.Wrapper.Client.IRequestBuilder" />
    internal sealed class RequestBuilder : IRequestBuilder
    {
        /// <summary>
        /// Posts the orders.
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<IRestRequest> PrepareRequestPostOrders(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException();
            }

            IRestClient restClient = new RestClient(baseUrl);
            IRestRequest restRequest = new RestRequest();

            throw new NotImplementedException();
        }

        /// <summary>
        /// Prepares the o authentication toke.
        /// </summary>
        /// <param name="Token">The token.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <returns>Response with Token</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IRestRequest> PrepareOAuthToke(string Token, string baseUrl)
        {
            IRestRequest restRequest = new RestRequest(baseUrl);
            restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            throw new NotImplementedException();
        }
    }
}