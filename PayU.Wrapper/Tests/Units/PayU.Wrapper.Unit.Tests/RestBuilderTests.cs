using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using NSubstitute;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Exception;
using RestSharp;
using Xunit;

namespace PayU.Wrapper.UnitTests
{
    public class RestBuilderTests
    {
        private RestBuilder _restClient;

        public RestBuilderTests()
        {
            _restClient = new RestBuilder("https://secure.snd.payu.com");
        }

        [Fact]
        public async void GetOrderDetails_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _restClient
            .GetOrderDetails<RestBuilder>(orderId ,tokenContract));
        }

        [Fact]
        public async void PostRefundOrder_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _restClient
            .PostRefundOrder<RestBuilder>(orderId, tokenContract));
        }


        [Fact]
        public async void PutUpdateOrder_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            OrderStatus order = Arg.Any<OrderStatus>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _restClient
            .PutUpdateOrder<RestBuilder>(orderId , order, tokenContract));
        }

        [Fact]
        public async void DeleteCancelOrderTask_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _restClient
            .DeleteCancelOrderTask<RestBuilder>(orderId, tokenContract));
        }

        [Fact]
        public async void PostCreateNewOrder_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            int orderId = Arg.Any<int>();
            OrderContract order = Arg.Any<OrderContract>();
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _restClient
            .PostCreateNewOrder<RestBuilder>(orderId, tokenContract, order));
        }

        [Fact]
        public async void GetRetrevePayout_WhenCall_InvalidGenericTypeException()
        {
            //Arrange
            TokenContract tokenContract = Substitute.For<TokenContract>();

            //Act & Assert
            await Assert.ThrowsAsync<InvalidGenericTypeException>(() => _restClient
            .GetRetrevePayout<RestBuilder>(tokenContract));
        }

        [Fact]
        public async void FinishRequest_WhenCall_InvalidGenericTypeException()
        {
        }
    }
}