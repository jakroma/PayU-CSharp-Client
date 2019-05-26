# PayU Client
|Branch|Master|
|------|------|
|Build | [![Build Status](https://travis-ci.org/romabliski/PayU-CSharp-Client.svg?branch=master)](https://travis-ci.org/romabliski/PayU-CSharp-Client) |
|NuGet| [![NuGet version](https://badge.fury.io/nu/PayU.Client.svg)](https://badge.fury.io/nu/PayU.Client) |


# Table of Contents 
1. [Docs PayU](#docs)
2. [Get Started](#get-started)
   - [Create Settings for clients](#settings)
   - [Client credentials](#Client-credentials)
   - [Trusted Merchant](#Trusted-Merchant)
   - [IHttpClientFactory example](#IHttpClientFactory)
   - [Standard HttpClient example](#Standard-HttpClient)
3. [Convention](#Conventions)
    - [Request/Response](#Request-Response)
      - [Order](#Order)
4. [Example Requests](#Requests-Examples)
    - [Get Order](#Get-Order)
    - [Create Order](#Create-Order)
    - [Refund Order](#Refund-Order)
    - [Cancel Order](#Cancel-Order)
    - [Update Order](#Update-Order)
    - [PayMethods](#PayMethods)
    - [Payout](#Payout)
    - [Retrieve Payout](#Retrieve-Payout)
    - [Delete Token](#Delete-Token)
5. [Own Request](#Own-Request)
    

# Docs
http://developers.payu.com/en/restapi.html#references_api_signature
http://developers.payu.com/en/payu_express.html
https://payu21.docs.apiary.io

# Get Started

## Settings

### For Standard HttpClient

```csharp
      PayUClientSettings settings = new PayUClientSettings(
                PayUClientContainer.Sandbox, // Url You could use string example from configuration or use const
                "v2_1", // api version
                "clientId", // clientId from shop configuration
                "clientSecret" // clientId from shop configuration
            );
```
### For IHttpClientFactory

[Look on](#Factory-Settings)

```csharp
      PayUClientSettings settings = new PayUClientSettings(
                PayUClientContainer.Sandbox,
                "v2_1",
                "clientId",
                "clientSecret"
                "PayUHttpClient" // look on IHttpClientFactory example
            );
```

## Token
`PayUClient get or set token into/from cache.`

`Cache expire time = (Api token expire time - 30 seconds)`

### Client Credentials
`Cache key` - `PayU_auth_token`

Thats mean, client credentials token is per client instance.

### Trusted Merchant

`Cache key` - `PayU_auth_token_{email}_{extCustomerId}`

```csharp
var trusted = new TrustedMerchant("test@test.com", "2312")
```

`PayU_auth_token_test@test.com_2312`

Thats mean, every trusted customer have own cache.

Every request what need this token have info in method name, and contains parameter for TrustedMerchant class instance ([example](#Create-Order))

---

## IHttpClientFactory

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-2.2

Now we could create PayUClient

### Autofac
```csharp
  var builder = new ContainerBuilder();
  ...
  builder.RegisterInstance(settings).As<PayUClientSettings>();
  builder.RegisterType<PayUClient>().As<IPayUClient>().SingleInstance();
  ...
  var container = builder.Build();
```

### Create instance
```csharp
  IPayUClient client = new PayUClient(settings, IHttpClientFactory);
```

### Factory Settings
Remember to create `HttpClientHandler` for factory, client couldn't work properly:
```csharp
services.AddHttpClient("PayUHttpClient", c =>
{
    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
}).
ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    AllowAutoRedirect = false,
    SslProtocols = SslProtocols.Tls12
});
```

## Standard HttpClient

If you don't use `IHttpClientFactory` PayUClient will create communication with own HttpClient
Look on `PayUApiHttpCommunicator.cs`

Now we could create PayUClient

### Autofac
```csharp
  var builder = new ContainerBuilder();
  ...
  builder.RegisterInstance(settings).As<PayUClientSettings>();
  builder.RegisterType<PayUClient>().As<IPayUClient>().SingleInstance();
  ...
  var container = builder.Build();
```


### Create instance

```csharp
  PayUClient client = new PayUClient(settings);
```


---
# Conventions

## Request Response

Request type are same as api json property type,
For example sometimes amount could be number value or text value.

Every request where json object have mandatory properties, have constructor with validator.

`Mandatory properties have private setters!!!`

Optional json properties have null value handling so, if you don't fill it, they won't send by http.

---

### Order
`Look on PayU Api documentation what response properties will return for different request kind.`

---

# Requests Examples
https://payu21.docs.apiary.io/#introduction

## Get Order
```csharp
  var result = await this.client.GetOrderAsync("123133", default(CancellationToken));
```

---

## Create Order
```csharp
  var products = new List<Product>(2);
            products.Add(new Product("Wireless mouse", "15000", "1"));
            products.Add(new Product("HDMI cable", "6000", "1"));
            var request = new OrderRequest("127.0.0.1", "145227", "RTV market", "PLN", "21000", products);
  var result = await this.client.PostOrderAsync(request, default(CancellationToken));
```

Or you can use Express request `trusted_merchant grant type`

http://developers.payu.com/en/payu_express.html
```csharp
  var products = new List<Product>(2);
  products.Add(new Product("Wireless mouse", "15000", "1"));
  products.Add(new Product("HDMI cable", "6000", "1"));

  var request = new OrderRequest("127.0.0.1", "merchantPosId", "RTV market", "PLN", "21000", products);

  request.PayMethods = new OrderPayMethodsRequest("CARD_TOKEN", "TOK_XATB7DF8ACXYTVQIPLWTVPFRKQE");

  var result = await this.client.PostTrustedOrderAsync(request, new TrustedMerchant("email", "extCustomerId"), default(CancellationToken));
```

---

## Refund Order
```csharp
  var refund = new RefundRequest("GPNG88VBW6151031GUEST000P01", new RefundRq("Refund", "Amount"));

  var result = await this.client.PostRefund("orderId", refund, default(CancellationToken));
```

Full Refund
```csharp
  var refund = new RefundRequest("GPNG88VBW6151031GUEST000P01", new RefundRq("Refund"));

  var fullRefundResult = await this.client.PostRefund("orderId", refund, default(CancellationToken));
```
---

## Cancel Order
```csharp
  var result = await this.client.DeleteCancelOrderAsync("orderId", default(CancellationToken));
```

---

## Update Order
```csharp
  var result = await this.client.PutUpdateOrderAsync("orderId", new UpdateOrderRequest("orderId", "orderStatus"),  default(CancellationToken));
```

---

## PayMethods
```csharp
  var result = await this.client.GetPayMethodsAsync(default(CancellationToken));
```

---

## Payout
```csharp                                                   
  var result = await this.client.PostPayoutAsync(new PayoutRequest("shopId", 422), default(CancellationToken));
```

---

## Retrieve Payout
```csharp
  var result = await this.client.GetRetrivePayoutAsync("PayoutId", default(CancellationToken));
```

---

## Delete Token
```csharp
  await this.client.DeleteTokenAsync("TokenId", default(CancellationToken));
```

---

# Own Request

If some of new type payment will release and you'll need implement it ASAP. You could create you own class definition (you may inheritance `BaseOrder`)

Example:
New Request Definition
```csharp
    public class NewRequestType : BaseOrder
    {
        public OrderRequest(string customerIp, string merchantPosId, string description, string currencyCode, string totalAmount, IList<Product> products, string newJsonField)
            : base(customerIp, merchantPosId, description, currencyCode, totalAmount, products) {}

        [JsonProperty("NewFieldJsonPropertyName",  NullValueHandling = NullValueHandling.Ignore)]
        public string NewField { get; set; }
    }
```

now you can make request
```csharp
  this.client.CustomRequest<NewRequestType, OrderResponse>(new Uri("endpointUrl"), `NewRequestType instance`, HttpMethod, default(CancellationToken))
```

if you need trusted_merchant 

```csharp
  this.client.TrustedCustomRequest<NewRequestType, OrderResponse>(new Uri("endpointUrl"), `NewRequestType instance`, HttpMethod,new TrustedMerchant("email", "extCustomerId"), default(CancellationToken))
```
