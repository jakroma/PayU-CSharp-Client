using PayU.Wrapper.Client.Data;
using RestSharp;

namespace PayU.Wrapper.Client
{
    public class RestClientBuilder
    {
        private readonly RestClient _restClientBuilder;

        public RestClientBuilder(string baseUrl)
        {
            _restClientBuilder = new RestClient(baseUrl);
        }

        public IRestResponse Execute(IRestRequest request)
        {
            return _restClientBuilder.Execute<OrderContract>(request);
        }
    }
}