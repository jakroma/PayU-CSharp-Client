# PayU Wrapper
[![Build status](https://ci.appveyor.com/api/projects/status/g0di4mjvy5wl7nl9?svg=true)](https://ci.appveyor.com/project/romabliski/net-core-payu-wrapper)

| Client wrapper (SDK) to implement request for your application
# Table of Contents 
1. [Architecture](#architecture)
2. [Example of usage](#Example-of-usage) 
    - [Tip UserRequestData](#tip-userrequestdata) 
    - [Example of multiple usage](#example-of-multiple-usage) 
    - [Example of single usage](#example-of-single-usage)
3. [Exception](#exception)
# Architecture
![alt text][logo]

[logo]: https://image.ibb.co/b4ai5T/Pay_UArchitecture.png "Architecture Logo"

# Example of usage
## Tip UserRequestData
   ```csharp
//TODO
 ```

 ## Example of multiple usage

   ```csharp
   UserRequestData userRequestData = new UserRequestData();

    PayUClient payUClient = new PayUToken(false,userRequestData).GetPayUToken();

    var result = payUClient.Request<PayUClient>(PayURequestType.PostCreateNewOrder)
    .Request<PayUClient>(PayURequestType.GetOrderDetails)
    .Request<Response>(PayURequestType.FinishRequests);
 ```

  ## Example of single usage

   ```csharp
   UserRequestData userRequestData = new UserRequestData();

    PayUClient payUClient = new PayUToken(false,userRequestData).GetPayUToken();

    OrderContract result = payUClient
    .Request<GetOrderDetails>(PayURequestType.PostCreateNewOrder);
 ```

 # Exception

 ```csharp
    throw new InvalidRequestType();

    throw new CreateTokenException();

    throw new InvalidGenericTypeException();

    throw new OrderStatusException();
 ```

