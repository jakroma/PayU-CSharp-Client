using System;
using AutoFixture;
using NSubstitute;
using NUnit.Framework;
using PayU.Wrapper.Client;
using RestSharp;

namespace PayU.Wrapper.UnitTests
{
    [TestFixture]
    public class RequestBuilderTests
    {
        private Fixture _fixture;

        /// <summary>
        /// The request builder
        /// </summary>
        private IRequestBuilder _requestBuilder;

        [SetUp]
        public void Set_Up()
        {
            _fixture = new Fixture();
            _requestBuilder = _fixture.Build<RequestBuilder>().Create();
        }

        [Test]
        public void PrepareRequestPostOrders_WhenCall_RequestExpected()
        {
            //Arrange
            IRestRequest requestmoq = _fixture.Build<IRestRequest>().Create();

            //Act

            //Assert
           
        }

        [TestCase("",null)]
        public void PrepareRequestPostOrders_WhenCall_NullArgumentException(string baseUrl)
        {
            //Arrange in TestCase
            //Act
            _requestBuilder.PrepareRequestPostOrders(baseUrl);

            //Assert
            Assert.Throws<ArgumentException>(() => new ArgumentException());
        }
    }
}