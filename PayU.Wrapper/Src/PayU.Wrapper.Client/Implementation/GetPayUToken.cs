using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Exception;

namespace PayU.Wrapper.Client.Implementation
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
        private readonly IResponseBuilder _responseBuilder;

        /// <summary>
        /// Enum needed to money counter
        /// </summary>
        private readonly CountryCode _countryCode;

        /// <summary>
        /// ONLY FOR TEST!!!
        /// </summary>
        /// <param name="responseBuilder"></param>
        public GetPayUToken(IResponseBuilder responseBuilder, UserRequestData userRequestData)
        {
            _responseBuilder = responseBuilder;
            _userRequestData = userRequestData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPayUToken"/> class.
        /// </summary>
        /// <param name="isProduction">if set to <c>true</c> [you want request production server].</param>
        /// <param name="userRequestData">The user request.</param>
        public GetPayUToken(bool isProduction, UserRequestData userRequestData)
        {
            if (string.IsNullOrEmpty(userRequestData.ClientId) || string.IsNullOrEmpty(userRequestData.ClientSecret))
            {
                throw new CreateTokenException();
            }
            userRequestData.BaseUrl = isProduction ? "https://secure.payu.com" : "https://secure.snd.payu.com";
            _userRequestData = userRequestData;
            _responseBuilder = new ResponseBuilder(userRequestData.BaseUrl);
        }

        public async Task<TokenContract> GetToken()
        {
            return await _responseBuilder
                .PostAOuthToken(_userRequestData);
        }
    }
}