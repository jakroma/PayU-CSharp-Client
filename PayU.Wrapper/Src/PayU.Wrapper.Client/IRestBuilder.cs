using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;

namespace PayU.Wrapper.Client
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IRestBuilder
    {
        /// <summary>
        /// Gets a outh token.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<T> GetAOuthToken<T>(UserRequest userRequest);

        /// <summary>
        /// Gets the order details.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="tokenContract">The token contract.</param>
        /// <returns>PayU Client (Fluent)</returns>
        Task<T> GetOrderDetails<T>(int orderId, TokenContract tokenContract);

        /// <summary>
        /// Refunds the order.
        /// </summary>
        /// <returns>PayU Client (Fluent)</returns>
        Task<PayUClient> RefundOrder();

        /// <summary>
        /// Updates the order.
        /// </summary>
        /// <returns>PayU Client (Fluent)</returns>
        Task<PayUClient> UpdateOrder();

        /// <summary>
        /// Cancels the order.
        /// </summary>
        /// <returns>PayU Client (Fluent)</returns>
        Task<PayUClient> CancelOrder();

        /// <summary>
        /// Creates the new order.
        /// </summary>
        /// <returns>PayU Client (Fluent)</returns>
        Task<PayUClient> CreateNewOrder();

        /// <summary>
        /// Pays the out from shop.
        /// </summary>
        /// <returns>PayU Client (Fluent)</returns>
        Task<PayUClient> PayOutFromShop();

        /// <summary>
        /// Retreves the payout.
        /// </summary>
        /// <returns>PayU Client (Fluent)</returns>
        Task<PayUClient> RetrevePayout();

        /// <summary>
        /// Finishes the request.
        /// </summary>
        /// <typeparam name="T">Generic</typeparam>
        /// <returns>Response</returns>
        Task<Response<T>> FinishRequest<T>();
    }
}