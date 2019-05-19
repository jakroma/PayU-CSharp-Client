using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using PayU.Client.Models;
using PayU.Client.Models.Transactions;

namespace PayU.Client
{
    public interface IPayUClient
    {
        Task<OrderGetResponse> GetOrderAsync(string orderId, CancellationToken ct);
        Task<OrderResponse> PostOrderAsync(OrderRequest order, CancellationToken ct);
        Task<OrderCardTokenResponse> PostTrustedOrderAsync(OrderRequest order, TrustedMerchant trustedMerchant, CancellationToken ct);
        Task<OrderResponse> DeleteCancelOrderAsync(string orderId, CancellationToken ct);
        Task<OrderResponse> PutUpdateOrderAsync(string orderId, UpdateOrderRequest updateOrder, CancellationToken ct);
        Task<OrderTransactionResponse> GetOrderTransactionAsync(string orderId, CancellationToken ct);
        Task<RefundResponse> PostRefund(string orderId, RefundRequest refundRequest, CancellationToken ct);
        Task<PayMethodsResponse> GetPayMethodsAsync(CancellationToken ct);
        Task<McpPartnersResponse> GetMcpPartnersAsync(string mcpPartnerId, CancellationToken ct);
        Task<PayoutResponse> PostPayoutAsync(PayoutRequest payoutRequest, CancellationToken ct);
        Task DeleteTokenAsync(string tokenId, CancellationToken ct);
        Task<RetrivePayoutResponse> GetRetrivePayoutAsync(string payoutId, CancellationToken ct);
        Task<Rs> CustomRequest<Rq, Rs>(Uri url, Rq rq, HttpMethod method, CancellationToken ct)
            where Rs : class;
        Task<Rs> TrustedCustomRequest<Rq, Rs>(Uri url, Rq rq, HttpMethod method, TrustedMerchant trustedMerchant, CancellationToken ct)
            where Rs : class;
    }
}