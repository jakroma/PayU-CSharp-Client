namespace PayU.Wrapper.Client.Enum
{
    /// <summary>
    /// Enum for Order Status
    /// </summary>
    public enum OrderStatus
    {
        Pending,
        Canceled,
        /// <summary>
        /// Only For without auto pickup option
        /// </summary>
        WaitingForConfirmation,
        Completed,
        Reject

    }
}