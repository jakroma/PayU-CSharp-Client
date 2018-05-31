# PayU Wrapper
| Client wrapper (SDK) to implement request for your application
# Architecture
![alt text][logo]

[logo]: https://raw.githubusercontent.com/romabliski/.NET-core-PayU-Wrapper/master/Architecture/PayUArchitecture.png "Architecture Logo"

# Example usage
## Prepare parameter for constructor
   ```csharp
string baseUrl = //Implement string url from production or test server
UserRequest userRequest = new request {
    //TODO
}         
 var requestType = RequestType.\\Choose type of request type; 
 ```

 ## Example

   ```csharp
    PayUClient payUClient = new PayUClient(baseUrl, requestType, userRequest) 
 ```

