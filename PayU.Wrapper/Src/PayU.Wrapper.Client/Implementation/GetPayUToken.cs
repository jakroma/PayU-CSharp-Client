using PayU.Wrapper.Client.Data;

namespace PayU.Wrapper.Client
{
    public class GetPayUToken
    {
        /// <summary>
        /// base url to connect with API (Production or Test Server)
        /// </summary>
        private string _baseUrl;

        /// <summary>
        /// The PayU client
        /// </summary>
        private IPayUClient _payUClient;

        /// <summary>
        /// The user request
        /// </summary>
        private UserRequest _userRequest;

        /// <summary>
        /// The token contract
        /// </summary>
        private TokenContract _tokenContract;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPayUToken"/> class.
        /// </summary>
        /// <param name="isProduction">if set to <c>true</c> [you want request production server].</param>
        /// <param name="userRequest">The user request.</param>
        public GetPayUToken(bool isProduction, UserRequest userRequest)
        {
            _userRequest = userRequest;
            _baseUrl = isProduction ? "https://secure.payu.com" : "https://secure.snd.payu.com";
            _payUClient = new PayUClient(userRequest, _baseUrl);
            _tokenContract = _payUClient.Request<TokenContract>(Enum.PayURequestType.PostAOuthToken).Result;
        }

        /// <summary>
        /// Tokens the return.
        /// </summary>
        /// <returns>PayU Token Class</returns>
        public IPayUClient TokenReturn()
        {
            return _payUClient;
        }
    }
}