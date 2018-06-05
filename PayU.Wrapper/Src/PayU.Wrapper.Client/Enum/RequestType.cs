namespace PayU.Wrapper.Client.Enum
{
    /// <summary>
    /// Request Type Enum
    /// </summary>
    public enum RequestType
    {
        /// <summary>
        /// The get a outh token
        /// </summary>
        GetAOuthToken,
        /// <summary>
        /// The order
        /// </summary>
        GetOrderDetails,
        /// <summary>
        /// The payment
        /// </summary>
        CreateNewOrder,
        /// <summary>
        /// The refund order
        /// </summary>
        RefundOrder,
        /// <summary>
        /// The cancel order
        /// </summary>
        CancelOrder,
        /// <summary>
        /// The update order
        /// </summary>
        UpdateOrder,
        /// <summary>
        /// The pay out from shop
        /// </summary>
        PayOutFromShop,
        /// <summary>
        /// The retreve payout
        /// </summary>
        RetrevePayout,
        /// <summary>
        /// The finish request
        /// </summary>
        FinishRequest
    }
}