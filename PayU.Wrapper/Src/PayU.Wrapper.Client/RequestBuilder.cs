using System;
using System.Threading.Tasks;
using RestSharp;

namespace PayU.Wrapper.Client
{
    /// <summary>
    /// RequestBuilderTemplate
    /// </summary>
    /// <seealso cref="PayU.Wrapper.Client.IRequestBuilder" />
    public class RequestBuilder : IRequestBuilder
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

            throw new System.NotImplementedException();
        }
    }
}