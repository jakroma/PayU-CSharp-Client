using System;

namespace PayU.Client.Builders
{
    public static class PayUClientUrlBuilder
    {
        public static Uri BuildOAuthTokenUrl(string baseUrl)
        {
            return new Uri(string.Concat(baseUrl, "/pl/standard/user/oauth/authorize"));
        }

        public static Uri BuildPayMethodsUrl(string baseUrl, string apiVersion)
        {
            ValidApiVersion(apiVersion);

            return new Uri(string.Concat(baseUrl, "/api/", apiVersion, "/paymethods/"));
        }

        public static Uri BuilOrderIdUrl(string baseUrl, string apiVersion, string orderId)
        {
            return BuildBaseOrderUrl(baseUrl, apiVersion, orderId);
        }

        public static Uri BuildPostOrderUrl(string baseUrl, string apiVersion)
        {
            ValidApiVersion(apiVersion);

            return new Uri(string.Concat(baseUrl, "/api/", apiVersion, "/orders/"));
        }

        public static Uri BuildOrderTransactionsUrl(string baseUrl, string apiVersion, string orderId)
        {
            return BuildBaseOrderUrl(baseUrl, apiVersion, orderId, "/transactions");
        }

        public static Uri BuildOrderStatusUrl(string baseUrl, string apiVersion, string orderId)
        {
            return BuildBaseOrderUrl(baseUrl, apiVersion, orderId, "/status");
        }

        public static Uri BuildOrderRefundsUrl(string baseUrl, string apiVersion, string orderId)
        {
            return BuildBaseOrderUrl(baseUrl, apiVersion, orderId, "/refunds");
        }

        public static Uri BuildPayoutsUrl(string baseUrl, string apiVersion)
        {
            ValidApiVersion(apiVersion);

            return new Uri(string.Concat(baseUrl, "/api/", apiVersion, "/payouts"));
        }

        public static Uri BuildRetrievePayoutsUrl(string baseUrl, string apiVersion, string payoutId)
        {
            ValidApiVersion(apiVersion);

            if (string.IsNullOrEmpty(payoutId))
            {
                throw new ArgumentException(payoutId);
            }

            return new Uri(string.Concat(baseUrl, "/api/", apiVersion, "/payouts/", payoutId));
        }

        public static Uri BuildMcpPartnerIdUrl(string baseUrl, string apiVersion, string mcpPartnerId)
        {
            ValidApiVersion(apiVersion);

            if (string.IsNullOrEmpty(mcpPartnerId))
            {
                throw new ArgumentException(mcpPartnerId);
            }

            return new Uri(string.Concat(baseUrl, "/api/", apiVersion, "/mcp-partners/", mcpPartnerId, "/fx-table/"));
        }

        public static Uri BuildDeleteTokenUrl(string baseUrl, string apiVersion, string tokenId)
        {
            ValidApiVersion(apiVersion);

            if (string.IsNullOrEmpty(tokenId))
            {
                throw new ArgumentException(tokenId);
            }

            return new Uri(string.Concat(baseUrl, "/api/", apiVersion, "/tokens/", tokenId));
        }

        private static Uri BuildBaseOrderUrl(string baseUrl, string apiVersion, string orderId, string orderEndpoint = null)
        {
            ValidApiVersion(apiVersion);

            if (string.IsNullOrEmpty(orderId))
            {
                throw new ArgumentException(orderId);
            }

            return new Uri(string.Concat(baseUrl, "/api/", apiVersion, "/orders/", orderId, orderEndpoint));
        }

        private static void ValidApiVersion(string apiVersion)
        {
            if (string.IsNullOrEmpty(apiVersion))
            {
                throw new ArgumentException(apiVersion);
            }
        }
    }
}