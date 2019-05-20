using System;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading;
using System.Threading.Tasks;
using PayU.Client.Builders;
using PayU.Client.Configurations;
using PayU.Client.Exceptions;
using PayU.Client.Extensions;
using PayU.Client.Models;

namespace PayU.Client
{
    public abstract class BaseClient
    {
        protected readonly ObjectCache cache = MemoryCache.Default;
        protected readonly IHttpClientFactory clientFactory;
        protected readonly PayUClientSettings settings;

        public BaseClient(PayUClientSettings settings)
        {
            this.settings = settings;
        }

        public BaseClient(PayUClientSettings settings, IHttpClientFactory clientFactory)
        {
            this.settings = settings;
            this.clientFactory = clientFactory;
        }

        public async Task<Rs> CustomRequestAsync<Rq, Rs>(Uri url, Rq rq, HttpMethod method, CancellationToken ct)
            where Rs : class
        {
            return await this.ProcessAsync<Rs>(url, method, ct, rq);
        }


        public async Task<Rs> TrustedCustomRequestAsync<Rq, Rs>(Uri url, Rq rq, HttpMethod method, TrustedMerchant trustedMerchant, CancellationToken ct)
            where Rs : class
        {
            return await this.ProcessAsync<Rs>(url, method, ct, rq, trustedMerchant);
        }

        public Rs CustomRequest<Rq, Rs>(Uri url, Rq rq, HttpMethod method, CancellationToken ct)
            where Rs : class
        {
            return this.Process<Rs>(url, method, rq);
        }


        public Rs TrustedCustomRequest<Rq, Rs>(Uri url, Rq rq, HttpMethod method, TrustedMerchant trustedMerchant, CancellationToken ct)
            where Rs : class
        {
            return this.Process<Rs>(url, method, rq, trustedMerchant);
        }

        protected async Task<T> ProcessAsync<T>(Uri requestUrl, HttpMethod httpMethod, CancellationToken ct, object content = default(HttpContent), TrustedMerchant trustedMerchant = null)
            where T : class
        {
            try
            {
                var token = await this.cache.GetTokenFromCacheAsync<PayUToken>(this.settings, this.clientFactory, trustedMerchant, ct);
                var request = PayUClientRequestBuilder.BuildRequestMessage(requestUrl, httpMethod, token.AccessToken, content);
                var communicator = new PayUApiHttpCommunicator<T>(this.clientFactory);
                return await communicator.SendAsync(request, ct);
            }
            catch (PayUClientException ex)
            {
                throw ex;
            } 
        }

        protected T Process<T>(Uri requestUrl, HttpMethod httpMethod, object content = default(HttpContent), TrustedMerchant trustedMerchant = null)
            where T : class
        {
            try
            {
                var token = this.cache.GetTokenFromCache<PayUToken>(this.settings, this.clientFactory, trustedMerchant);
                var request = PayUClientRequestBuilder.BuildRequestMessage(requestUrl, httpMethod, token.AccessToken, content);
                var communicator = new PayUApiHttpCommunicator<T>(this.clientFactory);
                return communicator.Send(request);
            }
            catch (PayUClientException ex)
            {
                throw ex;
            } 
        }
    }
}