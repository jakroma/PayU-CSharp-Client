using System;
using System.Reflection.Emit;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.Extensions;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Exception;
using Xunit;

namespace PayU.Wrapper.UnitTests
{
    public class GetPayUTokenTests
    {
        [Fact]
        public void GetPayUToken_Call_PayUClient_Success()
        {
            //Arrange
            var payUToken = Substitute.For<GetPayUToken>(new UserRequest{ClientId = 1, ClientSecret = "22", MD5Key = "as"});

            //Act
            var result = payUToken.Received().GetPayUClient();

            //Assert
            Assert.Same(result, typeof(IPayUClient));
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData(null, 0)]
        [InlineData("x", 0)]
        [InlineData("", 100)]
        [InlineData(null, 100)]
        public void GetPayUToken_Call_CantCreateTokenException_Success(string clientSecret, int clientId)
        {
            //Arrange
            UserRequest userRequest = new UserRequest
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                MD5Key = Arg.Any<string>(),
                DataToRequest = null
            };
            Console.WriteLine(clientSecret);

            //Act & Assert
            Assert.Throws<CantCreateTokenException>(() => new GetPayUToken(false, userRequest).GetPayUClient());
        }
    }
}