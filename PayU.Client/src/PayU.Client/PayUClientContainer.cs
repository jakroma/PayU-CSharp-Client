using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using Newtonsoft.Json;

namespace PayU.Client
{
    public static class PayUContainer
    {
        internal const string TokenCacheKey = "PayU_auth_token";
        internal const string TokenCacheTrustedFormat = "PayU_auth_token_{0}_{1}";
        internal const string BearerAuthentication = "bearer";
        internal static readonly JsonSerializer JsonSerializer = new JsonSerializer { NullValueHandling = NullValueHandling.Ignore };
        internal static MediaTypeWithQualityHeaderValue ContentJson = new MediaTypeWithQualityHeaderValue("application/json");

        public static class GrantType
        {
            public const string ClientCredentials = "client_credentials";
            public const string TrustedMerchant = "trusted_merchant";
        }

        public static class PayUApiUrl
        {
            public const string Mock = "https://private-anon-45d00fcdba-payu21.apiary-mock.com";
            public const string Sandbox = "https://secure.snd.payu.com";
            public const string Production = "https://secure.payu.com";
        }
        
        public static class PayMethodsTypes
        {
            public const string PBL = "PBL";
            public const string CARD_TOKEN = "CARD_TOKEN";
            public const string PAYMENT_WALL = "PAYMENT_WALL";
            public const string INSTALLMENTS = "INSTALLMENTS";
        }

        public class Currency
        {
            public const string BGN = "BGN"; 
            public const string CHF = "CHF"; 	
            public const string CZK = "CZK"; 	
            public const string DKK = "DKK"; 	
            public const string GBP = "GBP"; 	
            public const string HRK = "HRK"; 	
            public const string HUF = "HUF"; 	
            public const string NOK = "NOK"; 	
            public const string PLN = "PLN"; 
            public const string RON = "RON"; 
            public const string RUB = "RUB"; 	
            public const string SEK = "SEK"; 	
            public const string UAH = "UAH"; 
            public const string USD = "USD";   
        }

        internal class PropsName
        {
            internal const string City = "city";
            internal const string PostalCode = "postalCode";
            internal const string PostalBox = "postalBox";
            internal const string Street = "street";      
            internal const string RecipientName = "recipientName";
            internal const string State = "state";
            internal const string CountryCode = "countryCode";
            internal const string Name = "name";
            internal const string RecipientPhone = "recipientPhone";
            internal const string RecipientEmail = "recipientEmail";
            internal const string Email = "email";
            internal const string CustomerId = "customerId";
            internal const string extCustomerId = "extCustomerId";
            internal const string Phone = "phone";
            internal const string FistName = "firstName";
            internal const string LastName = "lastName";
            internal const string Language = "language";
            internal const string Nin = "nin";
            internal const string BuyerDelivery = "buyer.delivery";
            internal const string Type = "type";
            internal const string Value = "value";
            internal const string OrderStatus = "orderStatus";
            internal const string OrderId = "orderId";
            internal const string Grant_Type = "grant_type";
            internal const string Client_Id = "client_id";
            internal const string Client_Secret = "client_secret";
            internal const string Ex_Customer_Id = "ext_customer_id";
            internal const string Refresh_Token = "refresh_token";
            internal const string Expires_In = "expires_in";
            internal const string Token_Type = "token_type";
            internal const string Access_Token = "access_token";
            internal const string StatusDesc = "statusDesc";
            internal const string StatusCode = "statusCode";
            internal const string CardExpirationYear = "cardExpirationYear";
            internal const string CardExpirationMonth = "cardExpirationMonth";
            internal const string CardData = "cardData";
            internal const string CardNumberMasked = "cardNumberMasked";
            internal const string CardScheme = "cardScheme";
            internal const string CardProfile = "cardProfile";
            internal const string CardClassification = "cardClassification";
            internal const string CardResponseCode = "cardResponseCode";
            internal const string CardResponseCodeDesc = "cardResponseCodeDesc";
            internal const string CardEciCode = "cardEciCode";
            internal const string Card3DsStatus = "card3DsStatus";
            internal const string CardBinCountry = "cardBinCountry";
            internal const string Card = "card";
            internal const string PaymentFlow = "paymentFlow";
            internal const string PayMethod = "payMethod";
            internal const string Transactions = "transactions";
            internal const string Description = "description";
            internal const string Amount = "amount";
            internal const string Status = "status";
            internal const string Refund = "refund";
            internal const string RefundId = "refundId";
            internal const string ExtRefundId = "extRefundId";
            internal const string CurrencyCode = "currencyCode";
            internal const string CreationDateTime = "creationDateTime";
            internal const string StatusDateTime = "statusDateTime";
            internal const string PayoutId = "payoutId";
            internal const string BrandImageUrl = "brandImageUrl";
            internal const string Preferred = "preferred";
            internal const string UnitPrice = "unitPrice";
            internal const string Quantity = "quantity";
            internal const string AuthorizationCode = "authorizationCode";
            internal const string NotifyUrl = "notifyUrl";
            internal const string ContinueUrl = "continueUrl";
            internal const string ExtOrderId = "extOrderId";
            internal const string ValidityTime = "validityTime";
            internal const string CustomerIp = "customerIp";
            internal const string MerchantPosId = "merchantPosId";
            internal const string AdditionalDescription = "additionalDescription";
            internal const string TotalAmount = "totalAmount";
            internal const string Products = "products";
            internal const string PayMethods = "payMethods";
            internal const string DeviceFingerPrint = "deviceFingerprint";
            internal const string Buyer = "buyer";
            internal const string Reccuring = "recurring";
            internal const string Moto = "moto";
            internal const string OrderCreateDate = "orderCreateDate";
            internal const string Orders = "orders";
            internal const string Severity = "severity";
            internal const string Number = "number";
            internal const string RedirectUri = "redirectUri";
            internal const string Payout = "payout";
            internal const string ShopId = "shopId";
            internal const string PayByLinks = "payByLinks";
            internal const string PexTokens = "pexTokens";
            internal const string CardTokens = "cardTokens";
            internal const string AccountNumber = "accountNumber";
            internal const string PayType = "payType";
            internal const string BaseCurrency = "baseCurrency";
            internal const string ExchangeRate = "exchangeRate";
            internal const string TermCurrency = "termCurrency";
            internal const string Id = "id";
            internal const string ValidTo = "validTo";
            internal const string CurrencyPairs = "currencyPairs";
        }
    }
}