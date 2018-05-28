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
        Task<IRestRequest> PostOrders();
    }
}