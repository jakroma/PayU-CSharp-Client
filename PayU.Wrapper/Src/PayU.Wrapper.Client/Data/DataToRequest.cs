namespace PayU.Wrapper.Client.Data
{
    public class DataToRequest
    {
        /// <summary>
        /// Property need to PostOrderContract
        /// </summary>
        /// <value>
        /// The order contract.
        /// </value>
        public OrderContract OrderContract { get; set; }

        /// <summary>
        /// Property need to PostRefundOrder & GetOrderDetails
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }
    }
}