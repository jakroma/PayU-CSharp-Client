using System;
using System.Collections.Generic;
using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using Xunit;

namespace PayU.Wrapper.Integration.Tests
{
    /// <summary>
    /// PayU Client Integration Tests
    /// </summary>
    public class PayUClientITests
    {
        private readonly TokenContract _tokenContract = new TokenContract();

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

        [Fact(Skip= "Integration Test")]
        public void PostCreateNewOrder_WhenCall_ResultExpected()
        {
            //Arrange
            Product product = new Product
            {
                name = "Wireless mouse",
                quantity = 1,
                unitPrice = 15000
            };
            List<Product> products = new List<Product>();
            products.Add(product);
            
            OrderContract orderContract = new OrderContract
            {
                notifyUrl = "https://your.eshop.com/notify",
                customerIp = "127.0.0.1",
                merchantPosId = 145227,
                description = "RTV market",
                currencyCode = "PLN",
                products = products,
                totalAmount = 15000,
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
        public void PostRefundOrder_WhenCall_ResultExpected()
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

        [Fact(Skip = "Integration Test")]
        public void DeleteCancelOrder_WhenCall_ResultExpected()
        {
            //Arrange
            int orderId = 0;
            UserRequestData userRequestData = new UserRequestData();
            PayUClient payUClient = new PayUClient(userRequestData, _tokenContract);


            //Act
            var act = payUClient.Request<RefundContract>(PayURequestType.DeleteCancelOrder).Result;

            //Assert
            Console.WriteLine(act);
        }

        [Fact(Skip = "Integration Test")]
        public void PutUpdateOrder_WhenCall_ResultExpected()
        {
            //Arrange
            int orderId = 0;
            UserRequestData userRequestData = new UserRequestData();
            PayUClient payUClient = new PayUClient(userRequestData, _tokenContract);


            //Act
            var act = payUClient.Request<RefundContract>(PayURequestType.PutUpdateOrder).Result;

            //Assert
            Console.WriteLine(act);
        }

        [Fact(Skip = "Integration Test")]
        public void PostPayOutFromShop_WhenCall_ResultExpected()
        {
            //Arrange
            int orderId = 0;
            UserRequestData userRequestData = new UserRequestData();
            PayUClient payUClient = new PayUClient(userRequestData, _tokenContract);


            //Act
            var act = payUClient.Request<RefundContract>(PayURequestType.PostPayOutFromShop).Result;

            //Assert
            Console.WriteLine(act);
        }

        [Fact(Skip = "Integration Test")]
        public void GetRetrevePayout_WhenCall_ResultExpected()
        {
            //Arrange
            int orderId = 0;
            UserRequestData userRequestData = new UserRequestData();
            PayUClient payUClient = new PayUClient(userRequestData, _tokenContract);


            //Act
            var act = payUClient.Request<RefundContract>(PayURequestType.GetRetrevePayout).Result;

            //Assert
            Console.WriteLine(act);
        }

        [Fact(Skip = "Integration Test")]
        public void FinishRequest_WhenCall_ResultExpected()
        {
            //Arrange
            int orderId = 0;
            UserRequestData userRequestData = new UserRequestData();
            PayUClient payUClient = new PayUClient(userRequestData, _tokenContract);

            //Act
            var act = payUClient.Request<RefundContract>(PayURequestType.FinishRequests).Result;

            //Assert
            Console.WriteLine(act);
        }
    }
}