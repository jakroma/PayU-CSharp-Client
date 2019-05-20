using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using PayU.Client.Configurations;
using PayU.Client.Models;
using Xunit;

namespace PayU.Client.Tests
{
    public class PayUClientMockIntegrationTests
    {
        private const string expectedStatus = "SUCCESS";
        private readonly PayUClient client;

        public PayUClientMockIntegrationTests()
        {
            var settings = new PayUClientSettings(
                "https://private-anon-45d00fcdba-payu21.apiary-mock.com",
                "v2_1",
                "145227",
                "12f071174cb7eb79d4aac5bc2f0756"
            );
            this.client = new PayUClient(settings);
        }

        [Fact(Skip = "External service dependency")]
        public async void GetRetrivePayout_WhenCall_CorrectDeserializedResponse()
        {
            var result = await this.client.GetRetrivePayoutAsync("2231", default(CancellationToken));

            Assert.NotNull(result);
            Assert.NotNull(result.Status);
            Assert.NotNull(result.RetrievePayout);
            Assert.False(string.IsNullOrEmpty(result.RetrievePayout.Status));
            Assert.False(string.IsNullOrEmpty(result.RetrievePayout.PayoutId));
            Assert.False(string.IsNullOrEmpty(result.RetrievePayout.Amount));
            Assert.Equal(expectedStatus, result.Status.StatusCode);
        }

        [Fact(Skip = "External service dependency")]
        public async void PostPayoutAsync_WhenCall_CorrectDeserializedResponse()
        {
            PayoutRequest rq = new PayoutRequest("125533", 4124);

            var result = await this.client.PostPayoutAsync(rq, default(CancellationToken));

            Assert.NotNull(result);
            Assert.NotNull(result.Status);
            Assert.NotNull(result.Payout);
            Assert.False(string.IsNullOrEmpty(result.Payout.Status));
            Assert.False(string.IsNullOrEmpty(result.Payout.PayoutId));
            Assert.NotNull(result.Status);
            Assert.Equal(expectedStatus, result.Status.StatusCode);
        }

        [Fact(Skip = "External service dependency")]
        public async void GetPayMethodsAsync_WhenCall_CorrectDeserializedResponse()
        {
            var result = await this.client.GetPayMethodsAsync(default(CancellationToken));

            System.Console.WriteLine(result);
            Assert.NotNull(result);
            Assert.NotEmpty(result.CardTokens);
            Assert.NotEmpty(result.PayByLinks);
            Assert.NotEmpty(result.PexTokens);
        }

        [Fact(Skip = "External service dependency")]
        public async void GetOrderAsync_WhenCall_CorrectDeserializedResponse()
        {
            var result = await this.client.GetOrderAsync("123133", default(CancellationToken));

            Assert.NotNull(result);
            Assert.NotEmpty(result.Orders);
            Assert.NotNull(result.Status);
            Assert.Equal(expectedStatus, result.Status.StatusCode);
            Assert.NotNull(result.Status.StatusDesc);
            Assert.NotEmpty(result.Orders);
        }

        [Fact(Skip = "External service dependency")]
        public async void PostOrderAsync_WhenCall_CorrectDeserializedResponse()
        {
            var result = await this.client.PostOrderAsync(GetFakeOrderData(), default(CancellationToken));

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.OrderId));
            Assert.False(string.IsNullOrEmpty(result.RedirectUri));
            Assert.NotNull(result.Status);
            Assert.Equal(expectedStatus, result.Status.StatusCode);
        }

        [Fact(Skip = "External service dependency")]
        public async void DeleteCancelOrderAsync_WhenCall_CorrectDeserializedResponse()
        {
            var result = await this.client.DeleteCancelOrderAsync("111", default(CancellationToken));

            Assert.NotNull(result);
            Assert.False(string.IsNullOrEmpty(result.OrderId));
            Assert.NotNull(result.Status);
            Assert.Equal(expectedStatus, result.Status.StatusCode);
            Assert.NotNull(result.Status.StatusDesc);
        }

        [Fact(Skip = "External service dependency")]
        public async void PutUpdateOrderAsync_WhenCall_CorrectDeserializedResponse()
        {
            var order = new UpdateOrderRequest("216VVQ3TMW151031GUEST000P01", "COMPLETED");
            var result = await this.client.PutUpdateOrderAsync("111", order, default(CancellationToken));

            Assert.NotNull(result);
            Assert.NotNull(result.Status);
            Assert.Equal(expectedStatus, result.Status.StatusCode);
            Assert.NotNull(result.Status.StatusDesc);
        }

        [Fact(Skip = "External service dependency")]
        public async void PostRefund_WhenCall_CorrectDeserializedResponse()
        {
            var order = new RefundRequest("GPNG88VBW6151031GUEST000P01", new RefundRq("Refund", "100"));
            var result = await this.client.CustomRequestAsync<RefundRequest, RefundResponse>(
            // refund Mock url != refund Production url
            new Uri("https://private-anon-70e85fe603-payu21.apiary-mock.com/api/v2_1/orders/orders/44/refund"),
             order, HttpMethod.Post, default(CancellationToken));

            Assert.NotNull(result);
            Assert.NotNull(result.Status);
            Assert.Equal(expectedStatus, result.Status.StatusCode);
            Assert.NotNull(result.Status.StatusDesc);
            Assert.NotNull(result.OrderId);
            Assert.NotNull(result.Refund);
            Assert.NotNull(result.Refund.Amount);
            Assert.NotNull(result.Refund.CreationDateTime);
            Assert.NotNull(result.Refund.CurrencyCode);
            Assert.NotNull(result.Refund.Description);
            Assert.NotNull(result.Refund.ExtRefundId);
            Assert.NotNull(result.Refund.RefundId);
            Assert.NotNull(result.Refund.Status);
            Assert.NotNull(result.Refund.StatusDateTime);
        }

        [Fact(Skip = "External service dependency")]
        public async void DeleteToken_WhenCall_CorrectDeserializedResponse()
        {
            await this.client.DeleteTokenAsync("4442", default(CancellationToken));
        }

        private static OrderRequest GetFakeOrderData()
        {
            var products = new List<Product>(2);
            products.Add(new Product("Wireless mouse", "15000", "1"));
            products.Add(new Product("HDMI cable", "6000", "1"));
            var request = new OrderRequest("127.0.0.1", "145227", "RTV market", "PLN", "21000", products);
            request.PayMethods = new OrderPayMethodsRequest("CARD_TOKEN", "TOK_XATB7DF8ACXYTVQIPLWTVPFRKQE");
            return request;
        }
    }
}