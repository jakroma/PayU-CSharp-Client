namespace PayU.Wrapper.Client
{
    /// <summary>
    /// Pay U Client Class
    /// </summary>
    /// <seealso cref="PayU.Wrapper.Client.IPayUClient" />
    public class PayUClient : IPayUClient
    {
        /// <summary>
        /// The base URL for API (TEST/PRODUCTION)
        /// </summary>
        private readonly string _baseUrl;

        public PayUClient(string baseUrl)
        {
           this. _baseUrl = baseUrl;
        }


    }
}