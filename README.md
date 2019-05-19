# PayU Client
|Branch|Master|
|------|------|
|Build | [![Build status](https://ci.appveyor.com/api/projects/status/g0di4mjvy5wl7nl9?svg=true)](https://ci.appveyor.com/project/romabliski/net-core-payu-wrapper) |
|NuGet| WIP |



# Table of Contents 
1. [Docs PayU](#docs)
2. [Create Settings for clients](#settings)
   - [Client credentials](##Client-credentials)
   - [Trusted Merchant](##Trusted-Merchant)
3. [Get Started](#get-started)
4. [Convetions](#Convetions)
    - [Request/Response](##Request/Response)
      - [Order](###Order)
5. [Example Requests](#Example-Request)
    - [Get Order](##Get-Order)
    - [Create Order](##Create-Order)
    - [Refund Order](##Refund-Order)
    - [Cancel Order](##Cancel-Order)
    - [Update Order](##Update-Order)
    - [PayMethods](##PayMethods)
    - [Payout](##Payout)
    - [Retrieve Payout](##Retrieve-Payout)
    - [Delete Token](##Delete-Token)
6. [Own Request](#Own-Request)
    

# Docs
http://developers.payu.com/en/restapi.html#references_api_signature
http://developers.payu.com/en/payu_express.html
https://payu21.docs.apiary.io

# Settings

```csharp
      PayUClientSettings settings = new PayUClientSettings(
                PayUClientContainer.Sandbox, // Url You could use string example from configuration or use const
                "v2_1", // api version
                "clientId", // clientId from shop configuration
                "clientSecret" // clientId from shop configuration
            );
```

## Token
`PayUClient get&care about token in every request.`

`Cache expire time = (Api token expire time - 30 seconds)`

## Client Credentials
`Cache key` - `PayU_auth_token`

Thats mean, client credentials token is per client instance.

## Trusted Merchant

`Cache key` - `PayU_auth_token_{email}_{extCustomerId}`

```csharp
var trustedClient = new TrustedMerchant("test@test.com", "2312")
```

`PayU_auth_token_test@test.com_2312`

Thats mean, every trusted customer have own cache.

Every request what need this token have info in method name, and contains parameter for TrustedMerchant class instance (example - [Convetions](#Convetions))

---

# Get Started
If you create PayUSettings now we could create PayUClient instance

You could use IoC container (example Autofac)
```csharp
  var builder = new ContainerBuilder();
  ...
  builder.RegisterType<PayUClient>().As<IPayUClient>();
  ...
  var container = builder.Build();
```

Constructors:

More recommended (Only if you use IHttpClientFactory):

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-2.2
```csharp
  PayUClient client = new PayUClient(settings, IHttpClientFactory);
```
Remeber to create `HttpClientHandler` for factory, client couldn't work properly:
```csharp
var handler = new HttpClientHandler
        {
            AllowAutoRedirect = false,
            SslProtocols = SslProtocols.Tls12
        };
```

---
# Convetions

## Methods Names
PostTrustedOrderAsync()

`Post` - HttpMetod type for method

`Trusted` - only if you need trusted token (contains TrustedMerchant parameter)

`Order` - Name of PayU action

`Async` - .Net convetion for asynchronous methods

## Request/Response

Every request where json object have mandatory properties, have constructor with validator.

`Mandatory properties have private setters!!!`

Optional json properties have null value handling so, if you don't fill it, they won't send by http.

---

### Order
`Look on PayU Api documentation what respons properties will return for diffrent kind of request.`



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
  var fullRefund = new RefundRequest("GPNG88VBW6151031GUEST000P01", new RefundRq("Refund"));
  var refund = new RefundRequest("GPNG88VBW6151031GUEST000P01", new RefundRq("Refund", "Amount"));

  var result = await this.client.PostRefund("orderId", refund, default(CancellationToken));
  var fullRefundResult = await this.client.PostRefund("orderId", fullRefund, default(CancellationToken));
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
                                                                            //422 - payout amount
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
  this.client.CustomRequest<NewRequestType, OrderResponse>(new Uri("enpointUrl"), `NewRequestType instance`, HttpMethod, default(CancellationToken))
```

if you need trusted_merchant 

```csharp
  this.client.TrustedCustomRequest<NewRequestType, OrderResponse>(new Uri("enpointUrl"), `NewRequestType instance`, HttpMethod,new TrustedMerchant("email", "extCustomerId"), default(CancellationToken))
```

---

## For new changes

1. Fork it
2. Create branch for issue (`git checkout -b issue_id`)
3. implementation
4. Push changes (`git push origin issue_id`)
5. Create new Pull Request