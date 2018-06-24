using System;
using PayU.Wrapper.Client.Enum;

namespace PayU.Wrapper.Client.Exception
{
    public class OrderStatusException : SystemException
    {
        public OrderStatusException(OrderStatus orderStatus) : base($"Can't change status for {orderStatus}" +
                                                                    $" becouse this status dosen't exist")
        {
        }
    }
}