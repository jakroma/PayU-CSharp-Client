namespace PayU.Wrapper.Client.Enum
{
    /// <summary>
    /// Request Type Enum
    /// </summary>
    public enum PayURequestType
    {
        GetOrderDetails,
        PostCreateNewOrder,
        PostRefundOrder,
        DeleteCancelOrder,
        PutUpdateOrder,
        PostPayOutFromShop,
        GetRetrevePayout,
        FinishRequests
    }
}