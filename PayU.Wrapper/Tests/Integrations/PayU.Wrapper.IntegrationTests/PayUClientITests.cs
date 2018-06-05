using System;
using NUnit.Framework;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using RestSharp;

namespace PayU.Wrapper.IntegrationTests
{
    /// <summary>
    /// PayU Client Integration Tests
    /// </summary>
    [TestFixture]
    public class PayUClientITests
    {
        /// <summary>
        /// The base URL
        /// </summary>
        private readonly bool isProduction = false;

        /// <summary>
        /// Posts the payment when call result expected.
        /// </summary>
        [Test]
        public void PostPayment_WhenCall_ResultExpected()
        {
            //Arrange
            UserRequest userRequest = new UserRequest();
            PayUClient payUClient = new PayUClient(isProduction);
            OrderContract orderContract = new OrderContract
            {
                //TODO
            };

            //Act
            //var act = payUClient.Request(baseUrl, RequestType.Payment, userRequest).Result;

            //Assert
            //Console.WriteLine(act);
        }
    }
}