using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Caching;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using PayU.Client.Builders;
using PayU.Client.Configuartions;
using PayU.Client.Exceptions;
using PayU.Client.Extensions;
using PayU.Client.Models;
using PayU.Client.Models.Transactions;

namespace PayU.Client
{
    public class PayUClient : IPayUClient
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly PayUClientSettings settings;
        private readonly ObjectCache cache = MemoryCache.Default;

        public PayUClient(PayUClientSettings settings)
        {
            this.settings = settings;
        }

        public PayUClient(PayUClientSettings settings, IHttpClientFactory clientFactory)
        {
            this.settings = settings;
            this.clientFactory = clientFactory;
        }

        public async Task<OrderGetResponse> GetOrderAsync(string orderId, CancellationToken ct)
        {
            return await this.ProcessAsync<OrderGetResponse>(
                PayUClientUrlBuilder.BuilOrderIdUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Get,
                ct);
        }

        public async Task<OrderResponse> PostOrderAsync(OrderRequest order, CancellationToken ct)
        {
            return await this.ProcessAsync<OrderResponse>(
                PayUClientUrlBuilder.BuildPostOrderUrl(this.settings.Url, this.settings.ApiVersion),
                HttpMethod.Post,
                ct,
                order);
        }

        public async Task<OrderCardTokenResponse> PostTrustedOrderAsync(OrderRequest order, TrustedMerchant trustedMerchant, CancellationToken ct)
        {
            return await this.ProcessAsync<OrderCardTokenResponse>(
                PayUClientUrlBuilder.BuildPostOrderUrl(this.settings.Url, this.settings.ApiVersion),
                HttpMethod.Post,
                ct,
                order);
        }

        public async Task<OrderResponse> DeleteCancelOrderAsync(string orderId, CancellationToken ct)
        {
            return await this.ProcessAsync<OrderResponse>(
                PayUClientUrlBuilder.BuilOrderIdUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Delete,
                ct);
        }

        public async Task<OrderResponse> PutUpdateOrderAsync(string orderId, UpdateOrderRequest updateOrder, CancellationToken ct)
        {
            return await this.ProcessAsync<OrderResponse>(
                PayUClientUrlBuilder.BuildOrderStatusUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Put,
                ct,
                updateOrder);
        }

        public async Task<OrderTransactionResponse> GetOrderTransactionAsync(string orderId, CancellationToken ct)
        {
            return await this.ProcessAsync<OrderTransactionResponse>(
                PayUClientUrlBuilder.BuildOrderTransactionsUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Get,
                ct);
        }

        public async Task<RefundResponse> PostRefund(string orderId, RefundRequest refundRequest, CancellationToken ct)
        {
            return await this.ProcessAsync<RefundResponse>(
                PayUClientUrlBuilder.BuildOrderRefundsUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Post,
                ct,
                refundRequest);
        }

        public async Task<PayMethodsResponse> GetPayMethodsAsync(CancellationToken ct)
        {
            return await this.ProcessAsync<PayMethodsResponse>(
                PayUClientUrlBuilder.BuildPayMethodsUrl(this.settings.Url, this.settings.ApiVersion),
                HttpMethod.Get,
                ct);
        }

        public async Task<McpPartnersResponse> GetMcpPartnersAsync(string mcpPartnerId, CancellationToken ct)
        {
            return await this.ProcessAsync<McpPartnersResponse>(
                PayUClientUrlBuilder.BuildMcpPartnerIdUrl(this.settings.Url, this.settings.ApiVersion, mcpPartnerId),
                HttpMethod.Get,
                ct);
        }


        public async Task<PayoutResponse> PostPayoutAsync(PayoutRequest payoutRequest, CancellationToken ct)
        {
            return await this.ProcessAsync<PayoutResponse>(
                PayUClientUrlBuilder.BuildPayoutsUrl(this.settings.Url, this.settings.ApiVersion),
                HttpMethod.Post,
                ct,
                payoutRequest);
        }

        public async Task DeleteTokenAsync(string tokenId, CancellationToken ct)
        {
            await this.ProcessAsync<object>(
                PayUClientUrlBuilder.BuildDeleteTokenUrl(this.settings.Url, this.settings.ApiVersion, tokenId),
                HttpMethod.Delete,
                ct);
        }

        public async Task<RetrivePayoutResponse> GetRetrivePayoutAsync(string payoutId, CancellationToken ct)
        {
            return await this.ProcessAsync<RetrivePayoutResponse>(
                PayUClientUrlBuilder.BuildRetrievePayoutsUrl(this.settings.Url, this.settings.ApiVersion, payoutId),
                HttpMethod.Get,
                ct);
        }

        public async Task<Rs> CustomRequest<Rq, Rs>(Uri url, Rq rq, HttpMethod method, CancellationToken ct)
            where Rs : class
        {
            return await this.ProcessAsync<Rs>(url, method, ct, rq);
        }


        public async Task<Rs> TrustedCustomRequest<Rq, Rs>(Uri url, Rq rq, HttpMethod method, TrustedMerchant trustedMerchant, CancellationToken ct)
            where Rs : class
        {
            return await this.ProcessAsync<Rs>(url, method, ct, rq, trustedMerchant);
        }

        private async Task<T> ProcessAsync<T>(Uri requestUrl, HttpMethod httpMethod, CancellationToken ct, object content = default(HttpContent), TrustedMerchant trustedMerchant = null)
            where T : class
        {
            try
            {
                var token = await this.cache.GetTokenFromCacheAsync<PayUToken>(this.settings, this.clientFactory, trustedMerchant, ct);
                var request = PayUClientRequestBuilder.BuildRequestMessage(requestUrl, httpMethod, token.AccessToken, content);
                var communicator = new PayUApiHttpCommunicator<T>(this.clientFactory);
                return await communicator.SendAsync(request, ct);
            }
            catch (PayuClientException ex)
            {
                throw ex;
            } 
        }
    }
}