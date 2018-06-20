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
        /// <param name="payURequestType">Type of the request.</param>
        /// <returns>Generic Response</returns>
        Task<T> Request<T>(PayURequestType payURequestType);
    }
}