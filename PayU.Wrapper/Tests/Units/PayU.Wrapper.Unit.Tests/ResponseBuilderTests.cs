using System;
using System.Net;
using System.Net.Http;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.Extensions;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Exception;
using RestSharp;
using Xunit;

namespace PayU.Wrapper.UnitTests
{
    public class RestBuilderTests
    {
        private readonly IRestClient _restClient;

        private readonly IResponseBuilder _responseBuilder;
        /// <summary>
        /// The requeset builder
        /// </summary>
        private readonly IRequestBuilder _requesetBuilder;

        public RestBuilderTests()
        {
            _restClient = Substitute.For<RestClient>("https://secure.snd.payu.com");
            _responseBuilder = new ResponseBuilder("https://secure.snd.payu.com");
            _requesetBuilder = Substitute.For<IRequestBuilder>();
        }

        [Fact]
        public async void GetOrderDetails_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _responseBuilder
            .GetOrderDetails<ResponseBuilder>(orderId ,tokenContract));
        }

        [Fact]
        public async void PostRefundOrder_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _responseBuilder
            .PostRefundOrder<ResponseBuilder>(orderId, tokenContract));
        }


        [Fact]
        public async void PutUpdateOrder_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            OrderStatus order = Arg.Any<OrderStatus>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _responseBuilder
            .PutUpdateOrder<ResponseBuilder>(orderId , order, tokenContract));
        }

        [Fact]
        public async void DeleteCancelOrderTask_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _responseBuilder
            .DeleteCancelOrderTask<ResponseBuilder>(orderId, tokenContract));
        }

        [Fact]
        public async void PostCreateNewOrder_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            OrderContract order = Arg.Any<OrderContract>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _responseBuilder
            .PostCreateNewOrder<ResponseBuilder>(orderId, tokenContract, order));
        }

        [Fact]
        public async void GetRetrevePayout_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _responseBuilder
            .GetRetrevePayout<ResponseBuilder>(tokenContract));
        }

        [Fact]
        public async void FinishRequest_WhenCall_InvalidGenericTypeException()
        {
        }

        [Fact]
        public async void GetOrderDetails_WhenCall_HttpRequestException()
        {
            //Arrange
            int orderId = 444;
            TokenContract tokenContract = new TokenContract();

            //Act
            _restClient.Execute(Arg.Any<IRestRequest>())
                .Returns(new RestResponse() { StatusCode = HttpStatusCode.Unauthorized });

            //Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => _responseBuilder
                .GetOrderDetails<PayUClient>(orderId, tokenContract));
        }

        [Fact]
        public async void PostRefundOrder_WhenCall_HttpRequestException()
        {
            //Arrange
            int orderId = 444;
            TokenContract tokenContract = new TokenContract();

            //Act
            _restClient.Execute(Arg.Any<IRestRequest>())
                .Returns(new RestResponse() { StatusCode = HttpStatusCode.Unauthorized });

            //Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => _responseBuilder
                .PostRefundOrder<PayUClient>(orderId, tokenContract));
        }


        [Fact]
        public async void PutUpdateOrder_WhenCall_HttpRequestException()
        {
            //Arrange
            int orderId = 444;
            TokenContract tokenContract = new TokenContract();

            //Act
            _restClient.Execute(Arg.Any<IRestRequest>())
                .Returns(new RestResponse(){StatusCode = HttpStatusCode.Unauthorized });

            //Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => _responseBuilder
                .PutUpdateOrder<PayUClient>(orderId ,OrderStatus.Completed, tokenContract));
        }

        [Fact]
        public async void DeleteCancelOrderTask_WhenCall_HttpRequestException()
        {
            //Arrange
            int orderId = 444;
            TokenContract tokenContract = new TokenContract();

            //Act
            _restClient.Execute(Arg.Any<IRestRequest>())
                .Returns(new RestResponse() { StatusCode = HttpStatusCode.Unauthorized });

            //Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => _responseBuilder
                .DeleteCancelOrderTask<PayUClient>(orderId, tokenContract));
        }

        [Fact]
        public async void PostCreateNewOrder_WhenCall_HttpRequestException()
        {
            //Arrange
            int orderId = 444;
            OrderContract orderContract = new OrderContract();
            TokenContract tokenContract = new TokenContract();

            //Act
            _restClient.Execute(Arg.Any<IRestRequest>())
                .Returns(new RestResponse() { StatusCode = HttpStatusCode.Unauthorized });

            //Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => _responseBuilder
                .PostCreateNewOrder<PayUClient>(orderId, tokenContract, orderContract));
        }

        [Fact]
        public async void GetRetrevePayout_WhenCall_HttpRequestException()
        {
            //Arrange
            TokenContract tokenContract = new TokenContract();

            //Act
            _restClient.Execute(Arg.Any<IRestRequest>())
                .Returns(new RestResponse() { StatusCode = HttpStatusCode.Unauthorized });

            //Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => _responseBuilder
                .GetRetrevePayout<PayUClient>(tokenContract));
        }
    }
}