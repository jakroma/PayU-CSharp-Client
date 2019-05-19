using System;
using Xunit;
using PayU.Client.Builders;
using PayU.Client.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using PayU.Client.Configuartions;

namespace PayU.Client.Tests.Builders
{
    public class PayUClientRequestBuilderTests
    {

        [Fact]
        public async void BuildTokenRequestMessage_CorrectSettings_CorrectBuildedTokenRequest()
        {
            var expectedAcceptContent = new MediaTypeWithQualityHeaderValue("application/json");
            var settings = new PayUClientSettings("http://www.localhost.com", "v1", "1", "2");

            var result = PayUClientRequestBuilder.BuildTokenRequestMessage(settings, null);

            var content = await result.Content.ReadAsStringAsync();
            Assert.Equal(HttpMethod.Post, result.Method);
            Assert.Equal(new Uri("http://www.localhost.com/pl/standard/user/oauth/authorize"), result.RequestUri);
            Assert.Contains(expectedAcceptContent, result.Headers.Accept);
            Assert.Equal("grant_type=client_credentials&client_id=1&client_secret=2", content);
        }

        [Fact]
        public async void BuildTokenRequestMessage_CorrectSettings_CorrectBuildedTrustedTokenRequest()
        {
            var expectedAcceptContent = new MediaTypeWithQualityHeaderValue("application/json");
            var settings = new PayUClientSettings("http://www.localhost.com", "v1", "1", "2");

            var result = PayUClientRequestBuilder.BuildTokenRequestMessage(settings, new TrustedMerchant("test@test.com", "extCustomerId"));
            
            var content = await result.Content.ReadAsStringAsync();
            Assert.Equal(HttpMethod.Post, result.Method);
            Assert.Equal(new Uri("http://www.localhost.com/pl/standard/user/oauth/authorize"), result.RequestUri);
            Assert.Contains(expectedAcceptContent, result.Headers.Accept);
            Assert.Equal("grant_type=trusted_merchant&client_id=1&client_secret=2&email=test%40test.com&ext_customer_id=extCustomerId", content, true);
        }
        
        [Fact]
        public void BuildOAuthTokenUrl_GetMethod_CorrectBuildedRequest()
        {
            var result = PayUClientRequestBuilder.BuildRequestMessage(new Uri("http://localhost"), HttpMethod.Get, "fakeToken");

            this.AssertBuildRequestMessage(result, HttpMethod.Get, false);
        }

        [Fact]
        public void BuildOAuthTokenUrl_PostMethod_CorrectBuildedRequest()
        {
            var result = PayUClientRequestBuilder.BuildRequestMessage(new Uri("http://localhost"), HttpMethod.Post, "fakeToken", new object());

            this.AssertBuildRequestMessage(result, HttpMethod.Post, true);
        }

        [Fact]
        public void BuildOAuthTokenUrl_PutMethod_CorrectBuildedRequest()
        {
            var result = PayUClientRequestBuilder.BuildRequestMessage(new Uri("http://localhost"), HttpMethod.Put, "fakeToken", new object());

            this.AssertBuildRequestMessage(result, HttpMethod.Put, true);
        }

        [Fact]
        public void BuildOAuthTokenUrl_DeleteMethod_CorrectBuildedRequest()
        {
            var result = PayUClientRequestBuilder.BuildRequestMessage(new Uri("http://localhost"), HttpMethod.Delete, "fakeToken");

            this.AssertBuildRequestMessage(result, HttpMethod.Delete, false);
        }

        private void AssertBuildRequestMessage(HttpRequestMessage result, HttpMethod expectedHttpMethod, bool shouldContainsContent)
        {
            Assert.Equal(expectedHttpMethod, result.Method);
            Assert.Equal("bearer", result.Headers.Authorization.Scheme);
            Assert.Equal("fakeToken", result.Headers.Authorization.Parameter);
            Assert.Equal(new Uri("http://localhost"), result.RequestUri);
            Assert.Contains(new MediaTypeWithQualityHeaderValue("application/json"), result.Headers.Accept);
            Assert.True(shouldContainsContent ? result.Content != null : result.Content == null);
        }

    }
}