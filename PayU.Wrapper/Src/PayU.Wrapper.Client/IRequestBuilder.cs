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
        /// Prepares the o authentication toke.
        /// </summary>
        /// <param name="Token">The token.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <returns></returns>
        Task<IRestRequest> PrepareOAuthToke(string Token, string baseUrl);
    }
}