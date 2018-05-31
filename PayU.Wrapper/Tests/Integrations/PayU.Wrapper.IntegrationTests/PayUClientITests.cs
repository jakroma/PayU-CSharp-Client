using System;
using NUnit.Framework;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
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
        private readonly string baseUrl = "https://secure.snd.payu.com";

        /// <summary>
        /// Posts the payment when call result expected.
        /// </summary>
        [Test]
        public void PostPayment_WhenCall_ResultExpected()
        {
            //Arrange
            UserRequest userRequest = new UserRequest();
            PayUClient payUClient = new PayUClient(baseUrl, userRequest);
            OrderContract orderContract = new OrderContract
            {
                //TODO
            };

            //Act
           // IRestResponse act = payUClient.Request<>().Result;

            //Assert
            Console.WriteLine();
        }
    }
}