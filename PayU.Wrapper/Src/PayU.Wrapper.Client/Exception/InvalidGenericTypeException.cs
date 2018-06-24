using System;

namespace PayU.Wrapper.Client.Exception
{
    public class InvalidGenericTypeException : SystemException
    {
        public InvalidGenericTypeException(string type) : base($"Can generate request becouse this request don't return {type}")
        {
        }
    }
}