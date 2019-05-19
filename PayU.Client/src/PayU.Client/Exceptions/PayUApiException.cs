using System;
using System.Net;

namespace PayU.Client.Exception
{
    public class PayUApiException : SystemException
    {
        public PayUApiException(HttpStatusCode statusCode, string reasonPhase, string apiMessage) : base(string.Concat("PayU Api Exception Reason: ", statusCode, reasonPhase, " Message: ", apiMessage))
        {   
        }
    }
}