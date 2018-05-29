using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;
using RestSharp;

namespace PayU.Wrapper.Client
{
    /// <summary>
    /// Request Builder Interface
    /// </summary>
    public interface IRequestBuilder
    {
        /// <summary>
        /// Posts the orders.
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        Task<IRestRequest> PrepareRequestPostOrders(string baseUrl);
    }
}