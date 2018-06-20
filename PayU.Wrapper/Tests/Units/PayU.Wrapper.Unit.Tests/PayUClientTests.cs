using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Exception;
using Ploeh.AutoFixture;
using RestSharp;
using Xunit;

namespace PayU.Wrapper.UnitTests
{
    /// <summary>
    /// Pay U Client Tests
    /// </summary>
    public class PayUClientTests
    {
        /// <summary>
        /// The fixture
        /// </summary>
        private Fixture _fixture;

        /// <summary>
        /// The PayU client
        /// </summary>
        private IPayUClient _payUClient;

        /// <summary>
        /// The base URL
        /// </summary>
        private string _baseUrl;

        public PayUClientTests()
        {
            _fixture = new Fixture();
            _payUClient = _fixture.Build<PayUClient>().Create();
        }

        [Fact]
        public void Request_GetOrderRefund_WhenCall_GetDataExpected()
        {
            //Arrange
            //PayUClient payUClient = new PayUClient();

            //Act


            //Assert

        }

        [Fact]
        public void Request_GetOrderDetails_WhenCall_GetDataExpected()
        {
            //Arrange
            //PayUClient payUClient = new PayUClient();

            //Act


            //Assert

        }

        [Fact]
        public void Request_NoRequestType_WhenCall_ExceptionExpected()
        {
            //Arrange
            PayURequestType badRequest = (PayURequestType)40;
            UserRequest userRequest = _fixture.Build<UserRequest>().Create();

            //Act & Assert
            Assert.Throws<InvalidRequestType>(() => _payUClient.Request<OrderContract>(badRequest).Result);
        }
    }
}