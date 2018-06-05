using System;
using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using RestSharp;

namespace PayU.Wrapper.Client
{
    /// <summary>
    /// PayU Client Interface
    /// </summary>
    public interface IPayUClient
    {
        /// <summary>
        /// Requests the specified request type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="userRequest">The user request.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>Generic Response</returns>
        Task<T> Request<T>(RequestType requestType, UserRequest userRequest, int orderId = 0);
    }
}