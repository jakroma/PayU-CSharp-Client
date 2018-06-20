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
        private readonly bool isProduction = false;

        [Fact(Skip= "Integration Test")]
        public void PostCreateNewOrder_WhenCall_ResultExpected()
        {
            //Arrange
            OrderContract orderContract = new OrderContract
            {
                //TODO
            };
            UserRequest userRequest = new UserRequest
            {
                DataToRequest = new DataToRequest
                {
                    OrderContract = orderContract
                }
            };
            PayUClient payUClient = new PayUClient(isProduction, userRequest);

            //Act
            var act = payUClient.Request<RefundContract>(PayURequestType.PostCreateNewOrder, userRequest).Result;

            //Assert
            Console.WriteLine(act);
        }

        [Fact(Skip = "Integration Test")]
        public void GetOrderDetails_WhenCall_ResultExpected()
        {
            //Arrange
            int orderId = 0; 
            UserRequest userRequest = new UserRequest();
            PayUClient payUClient = new PayUClient(isProduction, userRequest);


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
            UserRequest userRequest = new UserRequest();
            PayUClient payUClient = new PayUClient(isProduction, userRequest);


            //Act
            var act = payUClient.Request<RefundContract>(PayURequestType.GetRefundOrder).Result;

            //Assert
            Console.WriteLine(act);
        }
    }
}