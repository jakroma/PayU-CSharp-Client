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
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IRestRequest> RequestPostOrders()
        {
            throw new System.NotImplementedException();
        }

        public Task<IRestRequest> PostOrders()
        {
            throw new System.NotImplementedException();
        }
    }
}