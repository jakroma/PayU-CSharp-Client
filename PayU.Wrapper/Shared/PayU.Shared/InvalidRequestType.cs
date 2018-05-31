using System;
using System.Runtime.InteropServices;

namespace PayU.Shared
{
    public class InvalidRequestType : SystemException
    {
        public InvalidRequestType()
            : base($"This type of request dosen't exist")
        {

        }
    }
}