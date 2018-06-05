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
    interface IPayUClient
    {
        /// <summary>
        /// Requests the specified base URL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="userRequest">The user request.</param>
        /// <returns>Generic Response</returns>
        Task<PayUClient> Request<T>(string baseUrl, UserRequest userRequest);
    }
}