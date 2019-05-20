using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Caching;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using PayU.Client.Builders;
using PayU.Client.Configurations;
using PayU.Client.Exceptions;
using PayU.Client.Extensions;
using PayU.Client.Models;
using PayU.Client.Models.Transactions;

namespace PayU.Client
{
    public class PayUClient : BaseClient, IPayUClient
    {
        public PayUClient(PayUClientSettings settings)
            : base(settings) {}

        public PayUClient(PayUClientSettings settings, IHttpClientFactory clientFactory)
            : base(settings, clientFactory) {}

        public async Task<OrderGetResponse> GetOrderAsync(string orderId, CancellationToken ct = default(CancellationToken))
        {
            return await this.ProcessAsync<OrderGetResponse>(
                PayUClientUrlBuilder.BuilOrderIdUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Get,
                ct);
        }

        public OrderGetResponse GetOrder(string orderId)
        {
            return this.Process<OrderGetResponse>(
                PayUClientUrlBuilder.BuilOrderIdUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Get);
        }

        public async Task<OrderResponse> PostOrderAsync(OrderRequest order, CancellationToken ct = default(CancellationToken))
        {
            return await this.ProcessAsync<OrderResponse>(
                PayUClientUrlBuilder.BuildPostOrderUrl(this.settings.Url, this.settings.ApiVersion),
                HttpMethod.Post,
                ct,
                order);
        }

        public OrderResponse PostOrder(OrderRequest order)
        {
            return this.Process<OrderResponse>(
                PayUClientUrlBuilder.BuildPostOrderUrl(this.settings.Url, this.settings.ApiVersion),
                HttpMethod.Post,
                order);
        }

        public async Task<OrderCardTokenResponse> PostTrustedOrderAsync(OrderRequest order, TrustedMerchant trustedMerchant, CancellationToken ct = default(CancellationToken))
        {
            return await this.ProcessAsync<OrderCardTokenResponse>(
                PayUClientUrlBuilder.BuildPostOrderUrl(this.settings.Url, this.settings.ApiVersion),
                HttpMethod.Post,
                ct,
                order,
                trustedMerchant);
        }

        public OrderCardTokenResponse PostTrustedOrder(OrderRequest order, TrustedMerchant trustedMerchant)
        {
            return this.Process<OrderCardTokenResponse>(
                PayUClientUrlBuilder.BuildPostOrderUrl(this.settings.Url, this.settings.ApiVersion),
                HttpMethod.Post,
                order,
                trustedMerchant);
        }

        public async Task<OrderResponse> DeleteCancelOrderAsync(string orderId, CancellationToken ct = default(CancellationToken))
        {
            return await this.ProcessAsync<OrderResponse>(
                PayUClientUrlBuilder.BuilOrderIdUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Delete,
                ct);
        }

        public OrderResponse DeleteCancelOrder(string orderId)
        {
            return this.Process<OrderResponse>(
                PayUClientUrlBuilder.BuilOrderIdUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Delete);
        }

        public async Task<OrderResponse> PutUpdateOrderAsync(string orderId, UpdateOrderRequest updateOrder, CancellationToken ct = default(CancellationToken))
        {
            return await this.ProcessAsync<OrderResponse>(
                PayUClientUrlBuilder.BuildOrderStatusUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Put,
                ct,
                updateOrder);
        }

        public OrderResponse PutUpdateOrder(string orderId, UpdateOrderRequest updateOrder)
        {
            return this.Process<OrderResponse>(
                PayUClientUrlBuilder.BuildOrderStatusUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Put,
                updateOrder);
        }

        public async Task<OrderTransactionResponse> GetOrderTransactionAsync(string orderId, CancellationToken ct = default(CancellationToken))
        {
            return await this.ProcessAsync<OrderTransactionResponse>(
                PayUClientUrlBuilder.BuildOrderTransactionsUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Get,
                ct);
        }

        public OrderTransactionResponse GetOrderTransaction(string orderId)
        {
            return this.Process<OrderTransactionResponse>(
                PayUClientUrlBuilder.BuildOrderTransactionsUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Get);
        }

        public async Task<RefundResponse> PostRefundAsync(string orderId, RefundRequest refundRequest, CancellationToken ct = default(CancellationToken))
        {
            return await this.ProcessAsync<RefundResponse>(
                PayUClientUrlBuilder.BuildOrderRefundsUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Post,
                ct,
                refundRequest);
        }

        public RefundResponse PostRefund(string orderId, RefundRequest refundRequest)
        {
            return this.Process<RefundResponse>(
                PayUClientUrlBuilder.BuildOrderRefundsUrl(this.settings.Url, this.settings.ApiVersion, orderId),
                HttpMethod.Post,
                refundRequest);
        }

        public async Task<PayMethodsResponse> GetPayMethodsAsync(CancellationToken ct = default(CancellationToken))
        {
            return await this.ProcessAsync<PayMethodsResponse>(
                PayUClientUrlBuilder.BuildPayMethodsUrl(this.settings.Url, this.settings.ApiVersion),
                HttpMethod.Get,
                ct);
        }

        public PayMethodsResponse GetPayMethods()
        {
            return this.Process<PayMethodsResponse>(
                PayUClientUrlBuilder.BuildPayMethodsUrl(this.settings.Url, this.settings.ApiVersion),
                HttpMethod.Get);
        }

        public async Task<McpPartnersResponse> GetMcpPartnersAsync(string mcpPartnerId, CancellationToken ct = default(CancellationToken))
        {
            return await this.ProcessAsync<McpPartnersResponse>(
                PayUClientUrlBuilder.BuildMcpPartnerIdUrl(this.settings.Url, this.settings.ApiVersion, mcpPartnerId),
                HttpMethod.Get,
                ct);
        }

        public McpPartnersResponse GetMcpPartners(string mcpPartnerId)
        {
            return this.Process<McpPartnersResponse>(
                PayUClientUrlBuilder.BuildMcpPartnerIdUrl(this.settings.Url, this.settings.ApiVersion, mcpPartnerId),
                HttpMethod.Get);
        }

        public async Task<PayoutResponse> PostPayoutAsync(PayoutRequest payoutRequest, CancellationToken ct = default(CancellationToken))
        {
            return await this.ProcessAsync<PayoutResponse>(
                PayUClientUrlBuilder.BuildPayoutsUrl(this.settings.Url, this.settings.ApiVersion),
                HttpMethod.Post,
                ct,
                payoutRequest);
        }

        public PayoutResponse PostPayout(PayoutRequest payoutRequest)
        {
            return this.Process<PayoutResponse>(
                PayUClientUrlBuilder.BuildPayoutsUrl(this.settings.Url, this.settings.ApiVersion),
                HttpMethod.Post,
                payoutRequest);
        }

        public async Task DeleteTokenAsync(string tokenId, CancellationToken ct = default(CancellationToken))
        {
            await this.ProcessAsync<object>(
                PayUClientUrlBuilder.BuildDeleteTokenUrl(this.settings.Url, this.settings.ApiVersion, tokenId),
                HttpMethod.Delete,
                ct);
        }

        public void DeleteTokenAsync(string tokenId)
        {
            this.Process<object>(
                PayUClientUrlBuilder.BuildDeleteTokenUrl(this.settings.Url, this.settings.ApiVersion, tokenId),
                HttpMethod.Delete);
        }

        public async Task<RetrivePayoutResponse> GetRetrivePayoutAsync(string payoutId, CancellationToken ct = default(CancellationToken))
        {
            return await this.ProcessAsync<RetrivePayoutResponse>(
                PayUClientUrlBuilder.BuildRetrievePayoutsUrl(this.settings.Url, this.settings.ApiVersion, payoutId),
                HttpMethod.Get,
                ct);
        }

        public RetrivePayoutResponse GetRetrivePayout(string payoutId)
        {
            return this.Process<RetrivePayoutResponse>(
                PayUClientUrlBuilder.BuildRetrievePayoutsUrl(this.settings.Url, this.settings.ApiVersion, payoutId),
                HttpMethod.Get);
        }
    }
}