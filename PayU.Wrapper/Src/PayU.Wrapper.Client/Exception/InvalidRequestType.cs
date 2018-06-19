using System;

namespace PayU.Wrapper.Client.Exception
{
    /// <summary>
    /// Invalid Request Type Exception
    /// </summary>
    /// <seealso cref="System.SystemException" />
    public class InvalidRequestType : SystemException
    {
        public InvalidRequestType()
            : base($"This type of request dosen't exist")
        {
        }
    }
}