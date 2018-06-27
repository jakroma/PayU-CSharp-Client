using System;
using NSubstitute;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using Xunit;

namespace PayU.Wrapper.UnitTests
{
    public class RequestBuilderTests
    {
        private readonly IRequestBuilder _requestBuilder;

        public RequestBuilderTests()
        {
            _requestBuilder = new RequestBuilder();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void PrepareRequestGetOrderDetails_WhenCall_NullArgumentException(string orderId)
        {
            // Arrange
            TokenContract fakeToken = Substitute.For<TokenContract>();
            OrderContract fakeOrder = Substitute.For<OrderContract>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _requestBuilder
                .PrepareGetOrderDetails(orderId, fakeToken));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void PreparePostCreateNewOrder_WhenCall_NullArgumentException(string orderId)
        {
            // Arrange
            TokenContract fakeToken = Substitute.For<TokenContract>();
            OrderContract fakeOrder = Substitute.For<OrderContract>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _requestBuilder
                .PreparePostCreateNewOrder(orderId, fakeToken, fakeOrder));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void PreparePostRefundOrder_WhenCall_NullArgumentException(string orderId)
        {
            // Arrange
            TokenContract fakeToken = Substitute.For<TokenContract>();
            OrderContract fakeOrder = Substitute.For<OrderContract>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _requestBuilder
                .PreparePostCreateNewOrder(orderId, fakeToken, fakeOrder));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void PreparePutUpdateOrder_WhenCall_NullArgumentException(string orderId)
        {
            // Arrange
            TokenContract fakeToken = Substitute.For<TokenContract>();
            OrderContract fakeOrder = Substitute.For<OrderContract>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _requestBuilder
                .PreparePostCreateNewOrder(orderId, fakeToken, fakeOrder));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void PrepareDeleteCancelOrder_WhenCall_NullArgumentException(string orderId)
        {
            // TODO
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void PreparePostPayOutFromShop_WhenCall_NullArgumentException(string orderId)
        {
            // TODO
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void PrepareGetRetrevePayout_WhenCall_NullArgumentException(string orderId)
        {
            // TODO
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void PrepareDeleteToken_WhenCall_NullArgumentException(string orderId)
        {
            // TODO
        }
    }
}