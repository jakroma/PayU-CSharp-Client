using PayU.Wrapper.Client;
using PayU.Wrapper.Client.Data;
using Xunit;

namespace PayU.Wrapper.IntegrationTests
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