using System;
using Xunit;
using PayU.Client.Builders;

namespace PayU.Client.Tests.Units.Builders
{
    public class PayUClientUrlBuilderTests
    {
        [Fact]
        public void BuildOAuthTokenUrl_CorrectUrl_CorrectBuildedUrl()
        {
            Assert.Equal(new Uri("http://localhost:3000/pl/standard/user/oauth/authorize"),
            PayUClientUrlBuilder.BuildOAuthTokenUrl("http://localhost:3000"));
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public static void BuildPaymethodsUrl_NullEmptyApiVersion_ThrowsArgumentException(string apiVersion)
        {
            Assert.Throws<ArgumentException>(() => PayUClientUrlBuilder.BuildPayMethodsUrl("http://localhost:3000", apiVersion));
        }

        [Fact]
        public static void BuildPaymethodsUrl_CorrectApiVersion_CorrectBuildedUrl()
        {
            Assert.Equal(new Uri("http://localhost:3000/api/v2.1/paymethods/"), 
            PayUClientUrlBuilder.BuildPayMethodsUrl("http://localhost:3000", "v2.1"));
        }

        [Theory]
        [InlineData("", "orderId")]
        [InlineData(null, "orderId")]
        [InlineData("v2.1", "")]
        [InlineData("v2.1", null)]
        public static void BuilOrderIdUrl_NullEmptyApiVersion_ThrowsArgumentException(string apiVersion, string orderId)
        {
            Assert.Throws<ArgumentException>(() => PayUClientUrlBuilder.BuilOrderIdUrl("http://localhost:3000", apiVersion, orderId));
        }

        [Fact]
        public static void BuilOrderIdUrl_CorrectParameters_CorrectBuildedUrl()
        {
            Assert.Equal(new Uri("http://localhost:3000/api/v2.1/orders/orderId"), 
            PayUClientUrlBuilder.BuilOrderIdUrl("http://localhost:3000", "v2.1", "orderId"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public static void BuildPostOrderUrl_NullEmptyApiVersion_ThrowsArgumentException(string apiVersion)
        {
            Assert.Throws<ArgumentException>(() => PayUClientUrlBuilder.BuildPostOrderUrl("http://localhost:3000", apiVersion));
        }

        [Fact]
        public static void BuildPostOrderUrl_CorrectApiVersion_CorrectBuildedUrl()
        {
            Assert.Equal(new Uri("http://localhost:3000/api/v2.1/orders/"), 
            PayUClientUrlBuilder.BuildPostOrderUrl("http://localhost:3000", "v2.1"));
        }

        [Theory]
        [InlineData("", "orderId")]
        [InlineData(null, "orderId")]
        [InlineData("v2.1", "")]
        [InlineData("v2.1", null)]
        public static void BuildOrderRefundsUrl_NullEmptyApiVersion_ThrowsArgumentException(string apiVersion, string orderId)
        {
            Assert.Throws<ArgumentException>(() => PayUClientUrlBuilder.BuildOrderRefundsUrl("http://localhost:3000", apiVersion, orderId));
        }

        [Fact]
        public static void BuildOrderRefundsUrl_CorrectParameters_CorrectBuildedUrl()
        {
            Assert.Equal(new Uri("http://localhost:3000/api/v2.1/orders/orderId/refunds"), 
            PayUClientUrlBuilder.BuildOrderRefundsUrl("http://localhost:3000", "v2.1", "orderId"));
        }

        [Theory]
        [InlineData("", "orderId")]
        [InlineData(null, "orderId")]
        [InlineData("v2.1", "")]
        [InlineData("v2.1", null)]
        public static void BuildOrderStatusUrl_NullEmptyApiVersion_ThrowsArgumentException(string apiVersion, string orderId)
        {
            Assert.Throws<ArgumentException>(() => PayUClientUrlBuilder.BuildOrderStatusUrl("http://localhost:3000", apiVersion, orderId));
        }

        [Fact]
        public static void BuildOrderStatusUrl_CorrectParameters_CorrectBuildedUrl()
        {
            Assert.Equal(new Uri("http://localhost:3000/api/v2.1/orders/orderId/status"), 
            PayUClientUrlBuilder.BuildOrderStatusUrl("http://localhost:3000", "v2.1", "orderId"));
        }

        [Theory]
        [InlineData("", "orderId")]
        [InlineData(null, "orderId")]
        [InlineData("v2.1", "")]
        [InlineData("v2.1", null)]
        public static void BuildOrderTransactionsUrl_NullEmptyApiVersion_ThrowsArgumentException(string apiVersion, string orderId)
        {
            Assert.Throws<ArgumentException>(() => PayUClientUrlBuilder.BuildOrderTransactionsUrl("http://localhost:3000", apiVersion, orderId));
        }

        [Fact]
        public static void BuildOrderTransactionsUrl_CorrectParameters_CorrectBuildedUrl()
        {
            Assert.Equal(new Uri("http://localhost:3000/api/v2.1/orders/orderId/transactions"), 
            PayUClientUrlBuilder.BuildOrderTransactionsUrl("http://localhost:3000", "v2.1", "orderId"));
        }

        [Theory]
        [InlineData("", "payoutId")]
        [InlineData(null, "payoutId")]
        [InlineData("v2.1", "")]
        [InlineData("v2.1", null)]
        public static void BuildRetrievePayoutsUrl_NullEmptyApiVersion_ThrowsArgumentException(string apiVersion, string payoutId)
        {
            Assert.Throws<ArgumentException>(() => PayUClientUrlBuilder.BuildRetrievePayoutsUrl("http://localhost:3000", apiVersion, payoutId));
        }

        [Fact]
        public static void BuildRetrievePayoutsUrl_CorrectParameters_CorrectBuildedUrl()
        {
            Assert.Equal(new Uri("http://localhost:3000/api/v2.1/payouts/payoutId"), 
            PayUClientUrlBuilder.BuildRetrievePayoutsUrl("http://localhost:3000", "v2.1", "payoutId"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public static void BuildPayoutsUrl_NullEmptyApiVersion_ThrowsArgumentException(string apiVersion)
        {
            Assert.Throws<ArgumentException>(() => PayUClientUrlBuilder.BuildPayoutsUrl("http://localhost:3000", apiVersion));
        }

        [Fact]
        public static void BuildMcpPartnerIdUrl_CorrectParameters_CorrectBuildedUrl()
        {
            Assert.Equal(new Uri("http://localhost:3000/api/v2_1/mcp-partners/mcpPartnerId/fx-table/"), 
            PayUClientUrlBuilder.BuildMcpPartnerIdUrl("http://localhost:3000", "v2_1", "mcpPartnerId"));
        }

        [Theory]
        [InlineData("", "mcpPartnerId")]
        [InlineData(null, "mcpPartnerId")]
        [InlineData("apiVersion", "")]
        [InlineData("apiVersion", null)]
        public static void BuildMcpPartnerIdUrl_NullEmptyApiVersion_ThrowsArgumentException(string apiVersion, string mcpPartnerId)
        {
            Assert.Throws<ArgumentException>(() => PayUClientUrlBuilder.BuildMcpPartnerIdUrl("http://localhost:3000", apiVersion, mcpPartnerId));
        }

        [Fact]
        public static void BuildDeleteTokenUrl_CorrectParameters_CorrectBuildedUrl()
        {
            Assert.Equal(new Uri("http://localhost:3000/api/v2_1/tokens/tokenId"), 
            PayUClientUrlBuilder.BuildDeleteTokenUrl("http://localhost:3000", "v2_1", "tokenId"));
        }

        [Theory]
        [InlineData("", "tokenId")]
        [InlineData(null, "tokenId")]
        [InlineData("apiVersion", "")]
        [InlineData("apiVersion", null)]
        public static void BuildDeleteTokenUrl_NullEmptyApiVersion_ThrowsArgumentException(string apiVersion, string tokenId)
        {
            Assert.Throws<ArgumentException>(() => PayUClientUrlBuilder.BuildDeleteTokenUrl("http://localhost:3000", apiVersion, tokenId));
        }

        [Fact]
        public static void BuildPayoutsUrl_CorrectApiVersion_CorrectBuildedUrl()
        {
            Assert.Equal(new Uri("http://localhost:3000/api/v2.1/payouts"), 
            PayUClientUrlBuilder.BuildPayoutsUrl("http://localhost:3000", "v2.1"));
        }
    }
}