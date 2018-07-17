using System.Threading.Tasks;
using NSubstitute;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Implementation;
using RestSharp;
using Xunit;

namespace PayU.Wrapper.Unit.Tests
{
    /// <summary>
    /// Pay U Client Tests
    /// </summary>
    public class PayUClientTests
    {
        /// <summary>
        /// The rest builder
        /// </summary>
        private readonly IResponseBuilder _responseBuilder;

        /// <summary>
        /// The request builders
        /// </summary>
        private readonly IRequestBuilder _requestBuilder;

        /// <summary>
        /// The base URL
        /// </summary>
        private UserRequestData userRequestData;

        public PayUClientTests()
        {
            this._responseBuilder = Substitute.For<IResponseBuilder>();
            this._requestBuilder = Substitute.For<IRequestBuilder>();
            userRequestData = new UserRequestData() {BaseUrl = "https://secure.snd.payu.com"};
        }

        [Fact]
        public void GetOrderDetails_WhenCall_FluentExpected()
        {
            // Arrange
            PayUClient fakePayUClient = new PayUClient(userRequestData, new TokenContract());
            _requestBuilder.PrepareGetOrderDetails(Arg.Any<string>(), Arg.Any<TokenContract>()).Returns(new RestRequest());
            _responseBuilder.GetOrderDetails<PayUClient>(Arg.Any<string>(), Arg.Any<TokenContract>())
                .Returns(Task.FromResult(new PayUClient(new UserRequestData() { BaseUrl = "https://secure.snd.payu.com" }, new TokenContract())));

            // Act

            // Act & Assert
            Assert.Equal(fakePayUClient.Request<PayUClient>(PayURequestType.GetOrderDetails).Result, fakePayUClient);
        }

        [Fact]
        public void PostCreateNewOrder_WhenCall_FluentExpected()
        {
            //Arrange
            //PayUClient payUClient = new PayUClient();

            //Act


            //Assert

        }

        [Fact]
        public void PostRefundOrder_WhenCall_FluentExpected()
        {
            //Arrange
            //PayUClient payUClient = new PayUClient();

            //Act


            //Assert

        }

        [Fact]
        public async void DeleteCancelOrder_WhenCall_ExceptionExpected()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async void PutUpdateOrder_WhenCall_ExceptionExpected()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async void PostPayOutFromShop_WhenCall_ExceptionExpected()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async void GetRetrevePayout_WhenCall_ExceptionExpected()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public async void FinishRequests_WhenCall_ExceptionExpected()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}