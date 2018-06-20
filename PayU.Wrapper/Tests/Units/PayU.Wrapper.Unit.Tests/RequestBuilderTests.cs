using System;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using Ploeh.AutoFixture;
using RestSharp;
using Xunit;

namespace PayU.Wrapper.UnitTests
{
    public class RequestBuilderTests
    {
        private Fixture _fixture;

        /// <summary>
        /// The request builder
        /// </summary>
        private IRequestBuilder _requestBuilder;

        public RequestBuilderTests()
        {
            _fixture = new Fixture();
            _requestBuilder = _fixture.Build<IRequestBuilder>().Create();
        }

        [Fact]
        public void PrepareRequestPostOrders_WhenCall_RequestExpected()
        {
            //Arrange
            IRestRequest requestmoq = _fixture.Build<IRestRequest>().Create();

            //Act

            //Assert

        }

        [Theory]
        [InlineData("", null)]
        public void PrepareRequestPostOrders_WhenCall_NullArgumentException(int orderId)
        {
            //Arrange
            TokenContract token = _fixture.Build<TokenContract>().Create();

            //Act
             _requestBuilder.PrepareGetOrderDetails(orderId, token);

            //Assert
            Assert.Throws<ArgumentException>(() => new ArgumentException());
        }
    }
}