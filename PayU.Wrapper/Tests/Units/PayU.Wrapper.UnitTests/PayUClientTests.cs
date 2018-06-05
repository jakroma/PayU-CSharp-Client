using AutoFixture;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PayU.Wrapper.Client;
using RestSharp;

namespace PayU.Wrapper.UnitTests
{
    /// <summary>
    /// Pay U Client Tests
    /// </summary>
    [TestFixture]
    public class PayUClientTests
    {
        /// <summary>
        /// The fixture
        /// </summary>
        private Fixture _fixture;

        /// <summary>
        /// The base URL
        /// </summary>
        private string _baseUrl;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
        }

        /// <summary>
        /// Posts the order when call HTTP200 expected.
        /// </summary>
        [Test]
        public void PostOrder_WhenCall_Http200Expected()
        {
            //Arrange
            //PayUClient payUClient = new PayUClient();

            //Act


            //Assert

        }
    }
}