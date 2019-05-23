using System;
using PayU.Client.Configurations;
using Xunit;

namespace PayU.Client.Tests.Settings
{
    public class PayUClientSettingsTests
    {
        [Theory]
        [InlineData("", "apiVersion", "clientId", "clientSecret")]
        [InlineData("url", "", "clientId", "clientSecret")]
        [InlineData("url", "apiVersion", "", "clientSecret")]
        [InlineData("url", "apiVersion", "clientId", "")]
        [InlineData(null, "apiVersion", "clientId", "clientSecret")]
        [InlineData("url", null, "clientId", "clientSecret")]
        [InlineData("url", "apiVersion", null, "clientSecret")]
        [InlineData("url", "apiVersion", "clientId", null)]
        public void Constructor_NullOrEmptyParameters_ThrowsArgumentException(string url, string apiVersion, string clientId, string clientSecret)
        {
            Assert.Throws(typeof(ArgumentException), () => new PayUClientSettings(url, apiVersion, clientId, clientSecret));
        }

        [Fact]
        public void Constructor_CorrectParameters_CreatePayUClientSettingsInstance()
        {
            var result = new PayUClientSettings(PayUContainer.PayUApiUrl.Production, PayUContainer.Version.v2_1, "clientId", "clientSecret");

            Assert.NotNull(result);
            Assert.Equal("https://secure.payu.com", result.Url);
            Assert.Equal("v2_1", result.ApiVersion);
            Assert.Equal("clientId", result.ClientId);
            Assert.Equal("clientSecret", result.ClientSecret);
        }
    }
}