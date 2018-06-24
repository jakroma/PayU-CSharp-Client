using System;
using Moq;
using NSubstitute;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Exception;
using Xunit;

namespace PayU.Wrapper.UnitTests
{
    public class GetPayUTokenTests
    {
        //[Fact]
        //public void GetPayUToken_Call_PayUClient_Success()
        //{
        //    UserRequestData userRequestData = new UserRequestData();
        //    RestBuilder restBuilder = new RestBuilder("https://secure.snd.payu.com");
        //    var data = Arg.Any<TokenContract>();
        //    var mock = new Mock<IGetPayUToken>();

        //    //Arrange
        //    IGetPayUToken payUToken = Substitute.For<IGetPayUToken>();         

        //    //Act
        //    var result = mock.SetupGet(m => m.GetToken()).Returns(data);

        //    //Assert
        //    Assert.IsType<PayUClient>(result);
        //}

        [Theory]
        [InlineData("", 0)]
        [InlineData(null, 0)]
        [InlineData("x", 0)]
        [InlineData("", 100)]
        [InlineData(null, 100)]
        public void GetPayUToken_Call_CantCreateTokenException_Success(string clientSecret, int clientId)
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