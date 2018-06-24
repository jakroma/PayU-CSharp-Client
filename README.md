# PayU Wrapper
[![Build status](https://ci.appveyor.com/api/projects/status/g0di4mjvy5wl7nl9?svg=true)](https://ci.appveyor.com/project/romabliski/net-core-payu-wrapper)

| Client wrapper (SDK) to implement request for your application
# Architecture
![alt text][logo]

[logo]: https://raw.githubusercontent.com/romabliski/.NET-core-PayU-Wrapper/master/Architecture/PayUArchitecture.png "Architecture Logo"

# Example usage
## Prepare parameter for constructor
   ```csharp
bool isProduction;
UserRequest userRequest = new request {
    //TODO
}         
 var requestType = RequestType.\\Choose type from enum
 ```

 ## Example

   ```csharp
    PayUClient payUClient = new PayUToken().GetPayUToken();
    var result = payUClient.Request<T>().Request<T>
 ```

 ## Exception

 ```csharp



 ```

