using System.Collections;
using System.Reflection.Metadata.Ecma335;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Exception;

namespace PayU.Wrapper.Client.Helpers
{
    public static class EnumToStringHelper
    {
        public static string OrderStatusToString(OrderStatus orderStatus)
        {
            switch (orderStatus)
            {
                case OrderStatus.Pending:
                    return "PENDING";
                case OrderStatus.Completed:
                    return "COMPLETED";
                case OrderStatus.Canceled:
                    return "CANCELED";
                case OrderStatus.Reject:
                    return "REJECT";
                case OrderStatus.WaitingForConfirmation:
                    return "WAITING_FOR_CONFIRMATION";
                default:
                    throw new OrderStatusException(orderStatus);
            }
        }
    }
}