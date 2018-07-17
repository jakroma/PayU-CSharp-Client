using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NSubstitute;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Exception;
using PayU.Wrapper.Client.Implementation;
using RestSharp;
using Shouldly;
using Xunit;

namespace PayU.Wrapper.Unit.Tests
{
    public class ResponseBuilderTests
    {
        /// <summary>
        /// The rest client
        /// </summary>
        private readonly IRestClient _restClient;

        /// <summary>
        /// The requeset builder
        /// </summary>
        private readonly IRequestBuilder _requesetBuilder;

        public ResponseBuilderTests()
        {
            _restClient = Substitute.For<IRestClient>();
            _requesetBuilder = Substitute.For<IRequestBuilder>();
        }

        [Fact]
        public async void PostAOuthToken_WhenCall_SuccessExpected()
        {
            // Arrange
            ResponseBuilder responseBuilder = new ResponseBuilder(_restClient, _requesetBuilder);
            _requesetBuilder.PreparePostOAuthToke(new UserRequestData()).Returns(new RestRequest(Method.POST));
            _restClient.Execute(Arg.Any<IRestRequest>()).Returns(new RestResponse() { StatusCode = HttpStatusCode.OK });

            // Act
            var result = responseBuilder.PostAOuthToken(new UserRequestData());

            // Assert
            await Assert.IsType<Task<TokenContract>>(result);
        }


        [Fact]
        public async void GetOrderDetails_WhenCall_HttpRequestException()
        {
            // Arrange
            ResponseBuilder responseBuilder = new ResponseBuilder(_restClient, _requesetBuilder);
            UserRequestData fakeUserRequestData = new UserRequestData { ClientId = "dsa", ClientSecret = "dsad" };
            TokenContract fakeContract = new TokenContract();
            _requesetBuilder.PreparePostOAuthToke(fakeUserRequestData).Returns(new RestRequest(Method.GET));
            _restClient.Execute(Arg.Any<IRestRequest>()).Returns(new RestResponse() { StatusCode = HttpStatusCode.BadRequest });

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => 
            responseBuilder.GetOrderDetails<OrderContract>("444", fakeContract));
        }

        [Fact]
        public async void PostAOuthToken_WhenCall_HttpRequestException()
        {
            // Arrange
            ResponseBuilder responseBuilder = new ResponseBuilder(_restClient, _requesetBuilder);
            _requesetBuilder.PreparePostOAuthToke(new UserRequestData()).Returns(new RestRequest(Method.POST));
            _restClient.Execute(Arg.Any<IRestRequest>()).Returns(new RestResponse() { StatusCode = HttpStatusCode.BadRequest });

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => 
            responseBuilder.PostAOuthToken(new UserRequestData()));
        }

        [Fact]
        public async void PostRefundOrder_WhenCall_HttpRequestException()
        {
            // Arrange
            ResponseBuilder responseBuilder = new ResponseBuilder(_restClient, _requesetBuilder);
            UserRequestData fakeUserRequestData = new UserRequestData { ClientId = "dsa", ClientSecret = "dsad" };
            _requesetBuilder.PreparePostOAuthToke(fakeUserRequestData).Returns(new RestRequest(Method.POST));
            _restClient.Execute(Arg.Any<IRestRequest>()).Returns(new RestResponse() { StatusCode = HttpStatusCode.BadRequest });

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() =>
            responseBuilder.PostRefundOrder<OrderContract>("444", new TokenContract()));
        }


        [Fact]
        public async void PutUpdateOrder_WhenCall_HttpRequestException()
        {
            // Arrange
            ResponseBuilder responseBuilder = new ResponseBuilder(_restClient, _requesetBuilder);
            UserRequestData fakeUserRequestData = new UserRequestData { ClientId = "dsa", ClientSecret = "dsad" };
            _requesetBuilder.PreparePostOAuthToke(fakeUserRequestData).Returns(new RestRequest(Method.PUT));
            _restClient.Execute(Arg.Any<IRestRequest>()).Returns(new RestResponse() { StatusCode = HttpStatusCode.BadRequest });

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() =>
            responseBuilder.PutUpdateOrder<OrderContract>("444", OrderStatus.Completed, new TokenContract()));
        }

        [Fact]
        public async void DeleteCancelOrderTask_WhenCall_HttpRequestException()
        {
            // Arrange
            ResponseBuilder responseBuilder = new ResponseBuilder(_restClient, _requesetBuilder);
            UserRequestData fakeUserRequestData = new UserRequestData { ClientId = "dsa", ClientSecret = "dsad" };
            _requesetBuilder.PreparePostOAuthToke(fakeUserRequestData).Returns(new RestRequest(Method.DELETE));
            _restClient.Execute(Arg.Any<IRestRequest>()).Returns(new RestResponse() { StatusCode = HttpStatusCode.BadRequest });

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() =>
            responseBuilder.DeleteCancelOrderTask<OrderContract>("444", new TokenContract()));
        }

        [Fact]
        public async void PostCreateNewOrder_WhenCall_HttpRequestException()
        {
            // Arrange
            ResponseBuilder responseBuilder = new ResponseBuilder(_restClient, _requesetBuilder);
            _requesetBuilder.PreparePostOAuthToke(Arg.Any<UserRequestData>()).Returns(new RestRequest(Method.POST));
            _restClient.Execute(Arg.Any<IRestRequest>()).Returns(new RestResponse() { StatusCode = HttpStatusCode.BadRequest });

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => responseBuilder.PostCreateNewOrder<PayUClient>(new TokenContract(), new OrderContract()));
        }

        [Fact]
        public async void GetRetrievePayout_WhenCall_HttpRequestException()
        {
            // Arrange
            ResponseBuilder responseBuilder = new ResponseBuilder(_restClient, _requesetBuilder);
            _requesetBuilder.PreparePostOAuthToke(Arg.Any<UserRequestData>()).Returns(new RestRequest(Method.POST));
            _restClient.Execute(Arg.Any<IRestRequest>()).Returns(new RestResponse() { StatusCode = HttpStatusCode.BadRequest });

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() =>
            responseBuilder.GetRetrievePayout(new TokenContract()));
        }

        [Fact]
        public async void GetOrderDetails_WhenCall_InvalidGenericTypeException()
        {
            // Arrange
            ResponseBuilder responseBuilder = new ResponseBuilder(_restClient, _requesetBuilder);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => responseBuilder
            .GetOrderDetails<ResponseBuilder>("444" , new TokenContract()));
        }

        [Fact]
        public async void PostRefundOrder_WhenCall_InvalidGenericTypeException()
        {
            // Arrange
            ResponseBuilder responseBuilder = new ResponseBuilder(_restClient, _requesetBuilder);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => responseBuilder
            .PostRefundOrder<ResponseBuilder>("444", new TokenContract()));
        }


        [Fact]
        public async void PutUpdateOrder_WhenCall_InvalidGenericTypeException()
        {
            // Arrange
            ResponseBuilder responseBuilder = new ResponseBuilder(_restClient, _requesetBuilder);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => responseBuilder
            .PutUpdateOrder<ResponseBuilder>("444" , OrderStatus.Completed, new TokenContract()));
        }

        [Fact]
        public async void DeleteCancelOrderTask_WhenCall_InvalidGenericTypeException()
        {
            // Arrange
            ResponseBuilder responseBuilder = new ResponseBuilder(_restClient, _requesetBuilder);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => responseBuilder
            .DeleteCancelOrderTask<ResponseBuilder>("444", new TokenContract()));
        }

        [Fact]
        public async void PostCreateNewOrder_WhenCall_InvalidGenericTypeException()
        {
            // Arrange
            ResponseBuilder responseBuilder = new ResponseBuilder(_restClient, _requesetBuilder);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => responseBuilder
            .PostCreateNewOrder<ResponseBuilder>(new TokenContract(), new OrderContract()));
        }

        [Fact]
        public async void FinishRequest_WhenCall_InvalidGenericTypeException()
        {
        }
    }
}