using System;
using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;
using RestSharp;

namespace PayU.Wrapper.Client
{
    /// <summary>
    /// RequestBuilderTemplate
    /// </summary>
    internal sealed class RequestBuilder
    {
        /// <summary>
        /// Posts the orders.
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IRestRequest> PrepareRequestPostOrders(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException();
            }

            IRestClient restClient = new RestClient(baseUrl);
            IRestRequest restRequest = new RestRequest();

            return restRequest;
        }

        /// <summary>
        /// Prepares the o authentication toke.
        /// </summary>
        /// <param name="Token">The token.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <returns>Response with Token</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IRestRequest> PrepareOAuthToke(UserRequest userRequest)
        {
            IRestRequest restRequest = new RestRequest();
            restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            restRequest.AddBody($"grant_type=client_credentials&client_id={userRequest.ClientId}&client_secret={userRequest.MD5Key}");

            return restRequest;
        }
    }
}