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
        public async Task<IRestRequest> PrepareRequestPostOrders(string baseUrl)
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