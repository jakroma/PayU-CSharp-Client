using System;

namespace PayU.Wrapper.Client.Exception
{
    public class CantCreateTokenException : SystemException
    {
        public CantCreateTokenException() : base($"Cant create token becouse ClientId or ClientSecret is null or empty")
        {   
        }
    }
}