using System;
using NSubstitute;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using RestSharp;
using Xunit;

namespace PayU.Wrapper.UnitTests
{
    public class RequestBuilderTests
    {
        [Fact]
        public void PrepareRequestPostOrders_WhenCall_RequestExpected()
        {
            //Arrange
            
            //Act

            //Assert
        }

        [Fact]
        public void PrepareRequestPostOrders_WhenCall_NullArgumentException()
        {
            //Arrange
            TokenContract token = Substitute.For<TokenContract>();
            int orderId = 0;
            RequestBuilder requestBuilder = Substitute.For<RequestBuilder>();

            //Act & Assert
            //Assert.Throws<ArgumentException>(() => new AggregateException().InnerExceptions.GetType() == requestBuilder.PreparePostCreateNewOrder(orderId, token, ));
        }
    }
}