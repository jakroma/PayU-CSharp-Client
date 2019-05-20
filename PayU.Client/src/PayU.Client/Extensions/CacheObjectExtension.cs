using System;
using System.Globalization;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading;
using System.Threading.Tasks;
using PayU.Client.Builders;
using PayU.Client.Configurations;
using PayU.Client.Models;

namespace PayU.Client.Extensions
{
    public static class CacheObjectExtension
    {
        public async static Task<T> GetTokenFromCacheAsync<T>(
            this ObjectCache cache,
            PayUClientSettings settings,
            IHttpClientFactory clientFactory,
            TrustedMerchant tm,
            CancellationToken ct)
            where T : PayUToken
        {
            var tokenKey = tm != null ? 
            string.Format(CultureInfo.InvariantCulture, PayUContainer.TokenCacheTrustedFormat, tm.Email, tm.ExtCustomerId) :
            PayUContainer.TokenCacheKey;

            var cachedObject = (T)cache[tokenKey];

            if (cachedObject == null)
            {
                var request = PayUClientRequestBuilder.BuildTokenRequestMessage(settings, tm);
                var communicator = new PayUApiHttpCommunicator<PayUToken>(clientFactory);
                cachedObject = (T)await communicator.SendAsync(request, ct);
                var policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cachedObject.ExpireIn - 30);
                cache.Set(tokenKey, cachedObject, policy);
            }

            return cachedObject;
        }

        public static T GetTokenFromCache<T>(
            this ObjectCache cache,
            PayUClientSettings settings,
            IHttpClientFactory clientFactory,
            TrustedMerchant tm)
            where T : PayUToken
        {
            var tokenKey = tm != null ? 
            string.Format(CultureInfo.InvariantCulture, PayUContainer.TokenCacheTrustedFormat, tm.Email, tm.ExtCustomerId) :
            PayUContainer.TokenCacheKey;

            var cachedObject = (T)cache[tokenKey];

            if (cachedObject == null)
            {
                var request = PayUClientRequestBuilder.BuildTokenRequestMessage(settings, tm);
                var communicator = new PayUApiHttpCommunicator<PayUToken>(clientFactory);
                cachedObject = (T)communicator.Send(request);
                var policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cachedObject.ExpireIn - 30);
                cache.Set(tokenKey, cachedObject, policy);
            }

            return cachedObject;
        }
    }
}