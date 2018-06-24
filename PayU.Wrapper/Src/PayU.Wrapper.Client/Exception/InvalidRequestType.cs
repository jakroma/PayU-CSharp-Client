using System;

namespace PayU.Wrapper.Client.Exception
{
    public class InvalidRequestType : SystemException
    {
        public InvalidRequestType()
            : base($"This type of request dosen't exist")
        {
        }
    }
}