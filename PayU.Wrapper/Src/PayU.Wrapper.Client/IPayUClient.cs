using System;
using System.Threading.Tasks;
using RestSharp;

namespace PayU.Wrapper.Client
{
    public interface IPayUClient
    {
        /// <summary>
        /// Gets the connection to API.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>Response</returns>
        Task<IRestResponse> PostOrder();
    }
}