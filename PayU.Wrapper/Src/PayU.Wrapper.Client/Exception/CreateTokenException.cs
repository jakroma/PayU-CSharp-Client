using System;

namespace PayU.Wrapper.Client.Exception
{
    public class CreateTokenException : SystemException
    {
        public CreateTokenException() : base($"Cant create token becouse ClientId or ClientSecret is null or empty")
        {   
        }
    }
}