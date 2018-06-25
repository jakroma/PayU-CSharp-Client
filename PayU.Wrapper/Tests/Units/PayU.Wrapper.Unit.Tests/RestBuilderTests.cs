using System.Net.Http;
using NSubstitute;
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
        private ResponseBuilder _responseClient;

        public RestBuilderTests()
        {
            _responseClient = new ResponseBuilder("https://secure.snd.payu.com");
        }

        [Fact]
        public async void GetOrderDetails_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _responseClient
            .GetOrderDetails<ResponseBuilder>(orderId ,tokenContract));
        }

        [Fact]
        public async void PostRefundOrder_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _responseClient
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
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _responseClient
            .PutUpdateOrder<ResponseBuilder>(orderId , order, tokenContract));
        }

        [Fact]
        public async void DeleteCancelOrderTask_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _responseClient
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
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _responseClient
            .PostCreateNewOrder<ResponseBuilder>(orderId, tokenContract, order));
        }

        [Fact]
        public async void GetRetrevePayout_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _responseClient
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
            int orderId = Arg.Any<int>();
            IRestResponse res = Substitute.For<IRestResponse>();
            TokenContract tokenContract = Substitute.For<TokenContract>();
            ResponseBuilder responseBuilder = Substitute.For<ResponseBuilder>("https://secure.snd.payu.com");
            IRestRequest restRequest = Substitute.For<RestRequest>();
            RestClientBuilder restClient = Substitute.For<RestClientBuilder>("https://secure.snd.payu.com");
            restClient.Execute(restRequest).Returns(res);

            //Act
            var result =  responseBuilder
                .GetOrderDetails<PayUClient>(orderId, tokenContract);

            //Act & Assert
             Assert.ThrowsAsync<HttpRequestException>(async () => await result);
        }

        [Fact]
        public async void PostRefundOrder_WhenCall_HttpRequestException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => _responseClient
            .PostRefundOrder<ResponseBuilder>(orderId, tokenContract));
        }


        [Fact]
        public async void PutUpdateOrder_WhenCall_HttpRequestException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            OrderStatus order = Arg.Any<OrderStatus>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => _responseClient
            .PutUpdateOrder<ResponseBuilder>(orderId, order, tokenContract));
        }

        [Fact]
        public async void DeleteCancelOrderTask_WhenCall_HttpRequestException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => _responseClient
            .DeleteCancelOrderTask<ResponseBuilder>(orderId, tokenContract));
        }

        [Fact]
        public async void PostCreateNewOrder_WhenCall_HttpRequestException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            OrderContract order = Arg.Any<OrderContract>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => _responseClient
            .PostCreateNewOrder<ResponseBuilder>(orderId, tokenContract, order));
        }

        [Fact]
        public async void GetRetrevePayout_WhenCall_HttpRequestException()
        {
            //Arrange
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => _responseClient
            .GetRetrevePayout<ResponseBuilder>(tokenContract));
        }
    }
}