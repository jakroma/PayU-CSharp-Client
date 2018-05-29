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
        

        private IRequestBuilder _requestBuilder;

        [SetUp]
        public void Set_Up()
        {
            _requestBuilder = new RequestBuilder();
        }
        [Test]
        public void PostPayment_WhenCall_ResultExpected()
        {
            //Arrange
            PayUClient payUClient = new PayUClient(baseUrl, _requestBuilder);
            OrderContract orderContract = new OrderContract
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