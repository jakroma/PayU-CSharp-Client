using System;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using Xunit;

namespace PayU.Wrapper.IntegrationTests
{
    /// <summary>
    /// PayU Client Integration Tests
    /// </summary>
    public class PayUClientITests
    {
        private readonly TokenContract _tokenContract = new TokenContract();

        [Fact(Skip= "Integration Test")]
        public void PostCreateNewOrder_WhenCall_ResultExpected()
        {
            //Arrange
            OrderContract orderContract = new OrderContract
            {
                //TODO
            };
            UserRequestData userRequestData = new UserRequestData
            {
                DataToRequest = new DataToRequest
                {
                    OrderContract = orderContract
                }
            };
            PayUClient payUClient = new PayUClient(userRequestData, _tokenContract);

            //Act
            var act = payUClient.Request<RefundContract>(PayURequestType.PostCreateNewOrder).Result;

            //Assert
            Console.WriteLine(act);
        }

        [Fact(Skip = "Integration Test")]
        public void GetOrderDetails_WhenCall_ResultExpected()
        {
            //Arrange
            int orderId = 0; 
            UserRequestData userRequestData = new UserRequestData();
            PayUClient payUClient = new PayUClient(userRequestData, _tokenContract);


            //Act
            var act = payUClient.Request<RefundContract>(PayURequestType.GetOrderDetails).Result;

            //Assert
            Console.WriteLine(act);
        }

        [Fact(Skip = "Integration Test")]
        public void GetRefundOrder_WhenCall_ResultExpected()
        {
            //Arrange
            int orderId = 0;
            UserRequestData userRequestData = new UserRequestData();
            PayUClient payUClient = new PayUClient(userRequestData, _tokenContract);


            //Act
            var act = payUClient.Request<RefundContract>(PayURequestType.PostRefundOrder).Result;

            //Assert
            Console.WriteLine(act);
        }
    }
}