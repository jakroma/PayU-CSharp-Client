using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
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
        /// <param name="userRequestData">The user request.</param>
        /// <returns>Rest Response</returns>
        Task<IRestRequest> PreparePostOAuthToke(UserRequestData userRequestData);

        /// <summary>
        /// Prepares the get order details.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="tokenContract">The user contract.</param>
        /// <returns>Rest Response</returns>
        Task<IRestRequest> PrepareGetOrderDetails(int orderId, TokenContract tokenContract);

        /// <summary>
        /// Prepares the post create new order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="tokenContract">The user contract.</param>
        /// <param name="orderContract">The order contract.</param>
        /// <returns>Rest Response</returns></returns>
        Task<IRestRequest> PreparePostCreateNewOrder(int orderId, TokenContract tokenContract, OrderContract orderContract);

        /// <summary>
        /// Gets the refund order.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="tokenContract">The user contract.</param>
        /// <returns></returns>
        Task<IRestRequest> PreparePostRefundOrder<T>(int orderId, TokenContract tokenContract);

        /// <summary>
        /// Updates the order.
        /// </summary>
        /// <returns></returns>
        Task<IRestRequest> PreparePutUpdateOrder(int orderId, OrderStatus orderStatus, TokenContract tokenContract);

        /// <summary>
        /// Cancels the order.
        /// </summary>
        /// <returns></returns>
        Task<IRestRequest> PrepareDeleteCancelOrder();

        /// <summary>
        /// Pays the out from shop.
        /// </summary>
        /// <returns></returns>
        Task<IRestRequest> PreparePostPayOutFromShop();

        /// <summary>
        /// Retreves the payout.
        /// </summary>
        /// <returns></returns>
        Task<IRestRequest> PrepareGetRetrevePayout();

        /// <summary>
        /// Prepares the delete token.
        /// </summary>
        /// <returns></returns>
        Task<IRestRequest> PrepareDeleteToken();
    }
}