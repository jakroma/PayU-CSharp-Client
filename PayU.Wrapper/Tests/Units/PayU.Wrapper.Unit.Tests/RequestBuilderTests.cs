using System;
using NSubstitute;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Implementation;
using RestSharp;
using Shouldly;
using Xunit;

namespace PayU.Wrapper.Unit.Tests
{
    public class RequestBuilderTests
    {
        private readonly IRequestBuilder _requestBuilder;

        public RequestBuilderTests()
        {
            _requestBuilder = new RequestBuilder();
        }

        [Fact]
        public async void PreparePostOAuthToke_WhenCall_CorrectRestRequestExpected()
        {
            // Arrange
            RequestBuilder restRequest = new RequestBuilder();
            UserRequestData userRequestData = new UserRequestData();

            // Act
            var result = await restRequest.PreparePostOAuthToke(userRequestData);

            // Assert
            result.Method.ShouldBe(Method.POST);
            result.RequestFormat.ShouldBe(DataFormat.Json);
            result.Timeout.ShouldBe(3000);
        }

        [Fact]
        public async void PrepareRequestGetOrderDetails_WhenCall_CorrectRestRequestExpected()
        {
            // Arrange
            RequestBuilder restRequest = new RequestBuilder();
            TokenContract tokenContract = new TokenContract();

            // Act
            var result = await restRequest.PrepareGetOrderDetails("xxx", tokenContract);

            // Assert
            result.Method.ShouldBe(Method.GET);
            result.Timeout.ShouldBe(3000);
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
        public async void PreparePostRefundOrder_WhenCall_NullArgumentException(string orderId)
        {
            // Arrange
            TokenContract fakeToken = Substitute.For<TokenContract>();
            OrderContract fakeOrder = Substitute.For<OrderContract>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _requestBuilder
                .PreparePostRefundOrder<RefundContract>(orderId ,fakeToken));
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

        [Fact]
        public async void PrepareGetRetrevePayout_WhenCall_NullArgumentException()
        {
            // Arrange
            RequestBuilder restRequest = new RequestBuilder();
            TokenContract tokenContract = new TokenContract();

            // Act
            var result = await restRequest.PrepareGetRetrievePayout(tokenContract);

            // Assert
            result.Method.ShouldBe(Method.GET);
            result.RequestFormat.ShouldBe(DataFormat.Json);
            result.Timeout.ShouldBe(3000);
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