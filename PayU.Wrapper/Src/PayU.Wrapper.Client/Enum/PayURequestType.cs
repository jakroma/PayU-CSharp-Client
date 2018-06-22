namespace PayU.Wrapper.Client.Enum
{
    /// <summary>
    /// Request Type Enum
    /// </summary>
    public enum PayURequestType
    {
        /// <summary>
        /// The post a outh token
        /// </summary>
        PostAOuthToken,
        /// <summary>
        /// The order
        /// </summary>
        GetOrderDetails,
        /// <summary>
        /// The payment
        /// </summary>
        PostCreateNewOrder,
        /// <summary>
        /// The refund order
        /// </summary>
        GetRefundOrder,
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