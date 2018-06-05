using System;
using System.Runtime.InteropServices;

namespace PayU.Shared
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