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
        /// <param name="userRequest">The user request.</param>
        /// <returns>Rest Response</returns>
        Task<IRestRequest> PrepareOAuthToke(UserRequest userRequest);

        /// <summary>
        /// Prepares the get order details.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="tokenContract">The token contract.</param>
        /// <returns>Rest Response</returns>
        Task<IRestRequest> PrepareGetOrderDetails(int orderId, TokenContract tokenContract);

        /// <summary>
        /// Prepares the post create new order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="tokenContract">The token contract.</param>
        /// <param name="orderContract">The order contract.</param>
        /// <returns>Rest Response</returns></returns>
        Task<IRestRequest> PreparePostCreateNewOrder(int orderId, TokenContract tokenContract, OrderContract orderContract);
    }
}