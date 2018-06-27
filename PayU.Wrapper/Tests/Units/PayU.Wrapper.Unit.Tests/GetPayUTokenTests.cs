using System;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.Core;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Exception;
using Xunit;

namespace PayU.Wrapper.UnitTests
{
    public class GetPayUTokenTests
    {
        [Fact]
        public void GetPayUToken_WhenCreate_CreateProductionClient()
        {
            // Arrange
            UserRequestData fakeUserRequestData = new UserRequestData
            {
                ClientId = "412413251",
                ClientSecret = "4123412341",
                MD5Key = Arg.Any<string>()
            };
            IGetPayUToken fakeToken = null;

            // Act
            fakeToken = new GetPayUToken(true, fakeUserRequestData);

            // Assert
            Assert.Equal("https://secure.payu.com", fakeUserRequestData.BaseUrl);
        }

        [Fact]
        public void GetPayUToken_WhenCreate_CreateTestClient()
        {
            // Arrange
            UserRequestData fakeUserRequestData = new UserRequestData
            {
                ClientId = "412413251",
                ClientSecret = "4123412341",
                MD5Key = Arg.Any<string>()
            };
            IGetPayUToken fakeToken = null;

            // Act
            fakeToken = new GetPayUToken(false, fakeUserRequestData);

            // Assert
            Assert.Equal("https://secure.snd.payu.com", fakeUserRequestData.BaseUrl);
        }


        [Theory]
        [InlineData("", "")]
        [InlineData("", null)]
        [InlineData(null, null)]
        [InlineData(null, "f")]
        [InlineData("", "f")]
        [InlineData("f", "")]
        [InlineData("f", null)]
        public async void GetPayUToken_WhenCall_CantCreateTokenException(string clientSecret, string clientId)
        {
            // Arrange
            UserRequestData fakeUserRequestData = new UserRequestData
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                MD5Key = Arg.Any<string>(),
                DataToRequest = null
            };
            Console.WriteLine(clientSecret);

            // Act & Assert
            await Assert.ThrowsAsync<CreateTokenException>(() => new GetPayUToken(false, fakeUserRequestData).GetToken());
        }
    }
}