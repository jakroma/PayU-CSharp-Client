# PayU Wrapper
[![Build status](https://ci.appveyor.com/api/projects/status/g0di4mjvy5wl7nl9?svg=true)](https://ci.appveyor.com/project/romabliski/net-core-payu-wrapper)

| Client wrapper (SDK) to implement request for your application
# Table of Contents 
1. [Architecture](#Architecture)
2. [Example of usage](#Example-of-usage) 
    - [Tip UserRequestData](##Tip-UserRequestData) 
    - [Example of multiple usage](##Example-of-multiple-usage) 
    - [Example of single usage](##Example-of-single-usage)
3. [Exception](#Exception)
# Architecture
![alt text][logo]

[logo]: https://raw.githubusercontent.com/romabliski/.NET-core-PayU-Wrapper/master/Architecture/PayUArchitecture.png "Architecture Logo"

# Example of usage
## Prepare parameter for constructor
   ```csharp
bool isProduction;
UserRequest userRequest = new request {
    //TODO
}         
 var requestType = RequestType.\\Choose type from enum
 ```

## Tip UserRequestData

   ```csharp
//TODO
 ```

 ## Example of multiple usage

   ```csharp
   UserRequestData userRequestData = new UserRequestData();

    PayUClient payUClient = new PayUToken(false,userRequestData).GetPayUToken();

    var result = payUClient.Request<PayUClient>(PayURequestType.PostCreateNewOrder)
    .Request<PayUClient>(PostCreateNewOrder.PostCreateNewOrder)
    .Request<Response>(PostCreateNewOrder.FinishRequests);
 ```

  ## Example of single usage

   ```csharp
   UserRequestData userRequestData = new UserRequestData();

    PayUClient payUClient = new PayUToken(false,userRequestData).GetPayUToken();

    OrderContract result = payUClient
    .Request<GetOrderDetails>(PostCreateNewOrder.PostCreateNewOrder);
 ```

 # Exception

 ```csharp
    throw new InvalidRequestType();

    throw new CreateTokenException();

    throw new InvalidGenericTypeException();

    throw new OrderStatusException();
 ```

