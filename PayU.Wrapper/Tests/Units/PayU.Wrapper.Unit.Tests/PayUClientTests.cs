using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.ExceptionExtensions;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Exception;
using Xunit;

namespace PayU.Wrapper.UnitTests
{
    /// <summary>
    /// Pay U Client Tests
    /// </summary>
    public class PayUClientTests
    {
        /// <summary>
        /// The PayU client
        /// </summary>
        private IPayUClient _payUClient;

        /// <summary>
        /// The user request
        /// </summary>
        private UserRequestData _userRequestData;

        /// <summary>
        /// The base URL
        /// </summary>
        private string _baseUrl;

        public PayUClientTests()
        {
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
        public async void Request_NoRequestType_WhenCall_ExceptionExpected()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}