using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PayU.Client.Models;
using Xunit;

namespace PayU.Client.Tests.Models
{
    public class OrderRequestTests
    {
        [Theory]
        [InlineData(null, "merchantPosId", "description", "currencyCode", "totalAmount")]
        [InlineData("customerIp", null, "description", "currencyCode", "totalAmount")]
        [InlineData("customerIp", "merchantPosId", null, "currencyCode", "totalAmount")]
        [InlineData("customerIp", "merchantPosId", "description", null,"totalAmount")]
        [InlineData("customerIp", "merchantPosId", "description", "currencyCode", null)]
        [InlineData("", "merchantPosId", "description", "currencyCode", "totalAmount")]
        [InlineData("customerIp", "", "description", "currencyCode", "totalAmount")]
        [InlineData("customerIp", "merchantPosId", "", "currencyCode", "totalAmount")]
        [InlineData("customerIp", "merchantPosId", "description", "","totalAmount")]
        [InlineData("customerIp", "merchantPosId", "description", "currencyCode", "")]
        public void Constructor_NullOrEmptyParameters_ThrowsArgumentException(string customerIp, string merchantPosId, string description, string currencyCode, string totalAmount)
        {
            Assert.Throws<ArgumentException>(() => new OrderRequest(customerIp, merchantPosId, description, currencyCode, totalAmount, null));
        }

        [Fact]
        public void Constructor_NullOrEmptyProductList_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new OrderRequest("customerIp", "merchantPosId", "description", "currencyCode", "totalAmount", null));
            Assert.Throws<ArgumentException>(() => new OrderRequest("customerIp", "merchantPosId", "description", "currencyCode", "totalAmount", new List<Product>(0)));
        }

        [Fact]
        public void Constructor_CorrectParameter_CreateOrderRequestInstance()
        {
            var result = new OrderRequest("127.0.0.1", "111", "XXX", "PLN", "2", new List<Product>{ new Product("XXX", "1", "2") });

            Assert.NotNull(result);
            Assert.Equal("127.0.0.1", result.CustomerIp);
            Assert.Equal("111", result.MerchantPosId);
            Assert.Equal("XXX", result.Description);
            Assert.Equal("PLN", result.CurrencyCode);
            Assert.Equal("2", result.TotalAmount);
            Assert.Equal("XXX", result.Products[0].Name);
            Assert.Equal("1", result.Products[0].UnitPrice);
            Assert.Equal("2", result.Products[0].Quantity);
            Assert.Equal(JsonConvert.SerializeObject(result, Formatting.Indented), Json.ReadFromTestFiles("fakeProduct.json"), true, true, true);
        }
    }
}