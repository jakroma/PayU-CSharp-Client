using System;
using NSubstitute;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Exception;
using Xunit;

namespace PayU.Wrapper.UnitTests
{
    public class GetPayUTokenTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData(null, 0)]
        [InlineData("x", 0)]
        [InlineData("", 100)]
        [InlineData(null, 100)]
        public void GetPayUToken_WhenCall_CantCreateTokenException(string clientSecret, int clientId)
        {
            //Arrange
            UserRequestData userRequestData = new UserRequestData
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                MD5Key = Arg.Any<string>(),
                DataToRequest = null
            };
            Console.WriteLine(clientSecret);

            //Act & Assert
            Assert.Throws<CreateTokenException>(() => new GetPayUToken(false, userRequestData).GetToken());
        }
    }
}