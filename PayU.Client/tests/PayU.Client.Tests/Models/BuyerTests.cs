using System;
using System;
using Newtonsoft.Json;
using PayU.Client.Models;
using Xunit;

namespace PayU.Client.Tests.Models
{
    public class BuyerTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_NullOrEmptyParameters_ThrowsArgumentException(string email)
        {
            Assert.Throws(typeof(ArgumentException), () => new Buyer(email));
        }

        [Fact]
        public void Constructor_CorrectParameter_CreateBuyerInstance()
        {
            var result = new Buyer("test@test.test");

            Assert.NotNull(result);
            Assert.Equal("test@test.test", result.Email);
            Assert.Equal(JsonConvert.SerializeObject(result, Formatting.Indented), Json.ReadFromTestFiles("fakeBuyer.json"), true, true, true);
        }
    }
}