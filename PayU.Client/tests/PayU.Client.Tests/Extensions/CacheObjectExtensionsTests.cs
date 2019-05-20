using System;
using System.Runtime.Caching;
using System.Threading;
using PayU.Client.Configurations;
using PayU.Client.Extensions;
using PayU.Client.Models;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace PayU.Client.Tests.Extensions
{
    public class CacheObjectExtensionsTests
    {
        [Fact]
        public async void GetTokenFromCacheAsync_TokenExistInCache_GetTokenFromCache()
        {
            ObjectCache cache = MemoryCache.Default;
            var fakeToken = new PayUToken { 
                TokenType = "type",
                GrantType = PayUContainer.GrantType.ClientCredentials,
                AccessToken = "fakeToken",
                ExpireIn = 999999 };
            cache.Add("PayU_auth_token", fakeToken, DateTime.MaxValue);

            var result = await
                cache.GetTokenFromCacheAsync<PayUToken>(new PayUClientSettings("localhost", "1", "1", "2"), null, null, default(CancellationToken));

            Assert.Equal("fakeToken", result.AccessToken);
            Assert.Equal(999999, result.ExpireIn);
            Assert.Equal("type", result.TokenType);
            Assert.Equal("client_credentials", result.GrantType);
        }

        [Fact]
        public async void GetTokenFromCacheAsync_TokenNotExistInCache_GetTokenFromCache()
        {
            using (var server = FluentMockServer.Start())
            {
                server
                  .Given(Request.Create().WithPath("/pl/standard/user/oauth/authorize").UsingPost())
                  .RespondWith(
                    Response.Create()
                      .WithStatusCode(200)
                      .WithBody(Json.ReadFromTestFiles("token.json"))
                  );
                ObjectCache cache = MemoryCache.Default;

                var result = await
                    cache.GetTokenFromCacheAsync<PayUToken>(new PayUClientSettings(string.Concat("http://localhost:", server.Ports[0]), "1", "1", "2"), null, null, default(CancellationToken));

                Assert.Equal("fakeToken", result.AccessToken);
                Assert.Equal(999999, result.ExpireIn);
                Assert.Equal("type", result.TokenType);
                Assert.Equal("client_credentials", result.GrantType);
            }
        }

        [Fact]
        public async void GetTrustedTokenFromCacheAsync_TokenExistInCache_GetTokenFromCache()
        {
            ObjectCache cache = MemoryCache.Default;
            var fakeToken = new PayUToken { 
                TokenType = "type",
                GrantType = PayUContainer.GrantType.ClientCredentials,
                AccessToken = "fakeToken",
                ExpireIn = 999999 };
            cache.Add("PayU_auth_token_test@test.com_extCustomerId", fakeToken, DateTime.MaxValue);

            var result = await
                cache.GetTokenFromCacheAsync<PayUToken>(new PayUClientSettings("localhost", "1", "1", "2"), null, new TrustedMerchant("test@test.com", "extCustomerId"), default(CancellationToken));

            Assert.Equal("fakeToken", result.AccessToken);
            Assert.Equal(999999, result.ExpireIn);
            Assert.Equal("type", result.TokenType);
            Assert.Equal("client_credentials", result.GrantType);
        }

        [Fact]
        public async void GetTrustedFromCacheAsync_TokenNotExistInCache_GetTokenFromCache()
        {
            using (var server = FluentMockServer.Start())
            {
                server
                  .Given(Request.Create().WithPath("/pl/standard/user/oauth/authorize").UsingPost())
                  .RespondWith(
                    Response.Create()
                      .WithStatusCode(200)
                      .WithBody(Json.ReadFromTestFiles("token.json"))
                  );
                ObjectCache cache = MemoryCache.Default;

                var result = await
                    cache.GetTokenFromCacheAsync<PayUToken>(new PayUClientSettings(string.Concat("http://localhost:", server.Ports[0]), "1", "1", "2"), null, new TrustedMerchant("test@test.com", "extCustomerId"), default(CancellationToken));

                Assert.Equal("fakeToken", result.AccessToken);
                Assert.Equal(999999, result.ExpireIn);
                Assert.Equal("type", result.TokenType);
                Assert.Equal("client_credentials", result.GrantType);
            }
        }
    }
}