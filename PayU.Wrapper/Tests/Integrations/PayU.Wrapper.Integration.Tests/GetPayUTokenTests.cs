using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Implementation;
using Xunit;

namespace PayU.Wrapper.Integration.Tests
{
    public class GetPayUTokenTests
    {
        [Fact]
        public void TokenGet_WhenCall_ResultExpected()
        {
            // Arragne
            UserRequestData userRequestData = new UserRequestData
            {
            };
            GetPayUToken getPayUToken = new GetPayUToken(false, userRequestData);

            // Act
            getPayUToken.GetToken();

            // Assert
        }
    }
}