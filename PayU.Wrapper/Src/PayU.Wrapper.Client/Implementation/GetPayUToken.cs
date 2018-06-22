using System;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Exception;

namespace PayU.Wrapper.Client
{
    public class GetPayUToken : IGetPayUToken
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
        /// FOR TEST ONLY!!!
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="userRequest">The user request.</param>
        /// <exception cref="PayU.Wrapper.Client.Exception.CantCreateTokenException"></exception>
        public GetPayUToken(UserRequest userRequest)
        {
            if (userRequest.ClientId == 0 || string.IsNullOrEmpty(userRequest.ClientSecret))
            {
                throw new CantCreateTokenException();
            }
            _userRequest = userRequest;
            _baseUrl = "https://private-anon-ed86bcf860-payu21.apiary-mock.com/";
            _payUClient = new PayUClient(userRequest, _baseUrl);
            _tokenContract = _payUClient.Request<TokenContract>(Enum.PayURequestType.PostAOuthToken).Result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPayUToken"/> class.
        /// </summary>
        /// <param name="isProduction">if set to <c>true</c> [you want request production server].</param>
        /// <param name="userRequest">The user request.</param>
        public GetPayUToken(bool isProduction, UserRequest userRequest)
        {
            if(userRequest.ClientId == 0 || string.IsNullOrEmpty(userRequest.ClientSecret))
            {
                throw new CantCreateTokenException();
            }
            _userRequest = userRequest;
            _baseUrl = isProduction ? "https://secure.payu.com" : "https://secure.snd.payu.com";
            _payUClient = new PayUClient(userRequest, _baseUrl);
            _tokenContract = _payUClient.Request<TokenContract>(Enum.PayURequestType.PostAOuthToken).Result;
        }

        public IPayUClient GetPayUClient()
        {
            return _payUClient;
        }
    }
}