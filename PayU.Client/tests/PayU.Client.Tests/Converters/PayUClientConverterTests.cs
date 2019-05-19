using PayU.Client.Converters;
using PayU.Client.Models;
using Xunit;

namespace PayU.Client.Tests.Converters
{
    public class PayUClientConverterTests
    {
        [Fact]
        public void DeserializeResponse_BadJsonStringResponseRetrivePayout_CorrectDeserialize()
        {
            var badJsonValue = 
            @"{
              ""payout"": {
                ""payoutId"": ""2DVZMPMFPN140219GUEEE000P01AFAFA"",
                ""amount"": ""1100"";
                ""status"": ""WAITING""
              },
              ""status"": {
                ""statusCode"": ""SUCCESS""
              }
            }";

            var result = PayUClientConverter.DeserializeResponse<RetrivePayoutResponse>(badJsonValue);

            Assert.Equal("SUCCESS", result.Status.StatusCode);
            Assert.Equal("2DVZMPMFPN140219GUEEE000P01AFAFA", result.RetrievePayout.PayoutId);
            Assert.Equal("1100", result.RetrievePayout.Amount);
            Assert.Equal("WAITING", result.RetrievePayout.Status);
        }

        [Fact]
        public void DeserializeResponse_CorrectStringResponse_CorrectDeserialize()
        {
            var result = PayUClientConverter.DeserializeResponse<PayUToken>(Json.ReadFromTestFiles("token.json"));

            Assert.Equal("fakeToken", result.AccessToken);
            Assert.Equal(999999, result.ExpireIn);
            Assert.Equal("type", result.TokenType);
            Assert.Equal("client_credentials", result.GrantType);
        }
    }
}