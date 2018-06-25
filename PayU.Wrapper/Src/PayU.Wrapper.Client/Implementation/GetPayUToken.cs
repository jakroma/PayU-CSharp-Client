using System;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Exception;

namespace PayU.Wrapper.Client
{
    public class GetPayUToken : IGetPayUToken
    {
        /// <summary>
        /// The PayU client
        /// </summary>
        private IPayUClient _payUClient;

        /// <summary>
        /// The user request
        /// </summary>
        private UserRequestData _userRequestData;

        /// <summary>
        /// The token contract
        /// </summary>
        private TokenContract _tokenContract;

        /// <summary>
        /// The rest builder
        /// </summary>
        private readonly ResponseBuilder _responseBuilder;

        /// <summary>
        /// Enum needed to money counter
        /// </summary>
        private readonly CountryCode _countryCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPayUToken"/> class.
        /// </summary>
        /// <param name="isProduction">if set to <c>true</c> [you want request production server].</param>
        /// <param name="userRequestData">The user request.</param>
        public GetPayUToken(bool isProduction, UserRequestData userRequestData)
        {
            if(userRequestData.ClientId == 0 || string.IsNullOrEmpty(userRequestData.ClientSecret))
            {
                throw new CreateTokenException();
            }
            userRequestData.BaseUrl = isProduction ? "https://secure.payu.com" : "https://secure.snd.payu.com";
            _userRequestData = userRequestData;
        }

        public TokenContract GetToken()
        {
            TokenContract tokenContract = new ResponseBuilder(_userRequestData.BaseUrl)
                .PostAOuthToken(_userRequestData)
                .Result;

            return tokenContract;
        }
    }
}