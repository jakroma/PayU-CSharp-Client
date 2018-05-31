using AutoFixture;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RestSharp;

namespace PayU.Wrapper.UnitTests
{
    /// <summary>
    /// Pay U Client Tests
    /// </summary>
    [TestFixture]
    public class PayUClientTests
    {
        private Fixture _fixture;

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


            //Act


            //Assert

        }
    }
}