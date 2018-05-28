using System;
using NUnit.Framework;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using RestSharp;

namespace PayU.Wrapper.IntegrationTests
{
    [TestFixture]
    public class PayUClientITests
    {
        /// <summary>
        /// The base URL
        /// </summary>
        private readonly string baseUrl = "";

        public void PostPayment_WhenCall_ResultExpected()
        {
            //Arrange
            PayUClient payUClient = new PayUClient(baseUrl);
            PaymentContract payment = new PaymentContract
            {
                //TODO
            };

            //Act
            IRestResponse act = payUClient.PostOrder().Result;

            //Assert
            Console.WriteLine(act);
        }
    }
}