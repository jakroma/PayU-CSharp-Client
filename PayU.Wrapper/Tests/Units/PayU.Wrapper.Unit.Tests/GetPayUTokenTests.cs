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
        /// <summary>
        /// The response builder
        /// </summary>
        private readonly IResponseBuilder _responseBuilder;

        public GetPayUTokenTests()
        {
            _responseBuilder = Substitute.For<IResponseBuilder>();
        }

        [Fact]
        public void GetPayUToken_WhenCall_TokenCreated()
        {
            // Arrange
            GetPayUToken fakePayUToken = new GetPayUToken(_responseBuilder, new UserRequestData());
            TokenContract fakeTokenContractExpected = new TokenContract{ access_token = "444", token_type = "444", expires_in = 444, grant_type = "444"};
            _responseBuilder.PostAOuthToken(Arg.Any<UserRequestData>()).Returns(new TokenContract{ access_token = "444", token_type = "444", expires_in = 444, grant_type = "444" });

            // Act & Assert
            Assert.True(fakeTokenContractExpected.access_token == fakePayUToken.GetToken().Result.access_token);
        }

        [Fact]
        public void GetPayUToken_WhenCreate_CreateProductionClient()
        {
            // Arrange
            UserRequestData fakeUserRequestData = new UserRequestData
            {
                ClientId = "412413251",
                ClientSecret = "4123412341",
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
                ClientSecret = clientSecret
            };

            // Act & Assert
            await Assert.ThrowsAsync<CreateTokenException>(() => new GetPayUToken(false, fakeUserRequestData).GetToken());
        }
    }
}