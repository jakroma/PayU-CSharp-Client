using System;
using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Exception;

namespace PayU.Wrapper.Client.Implementation
{
    /// <summary>
    /// Pay U Client Class
    /// </summary>
    /// <seealso cref="PayU.Wrapper.Client.IPayUClient" />
    public class PayUClient : IPayUClient
    {
        /// <summary>
        /// The user
        /// </summary>
        private TokenContract _tokenContract;

        /// <summary>
        /// The user request
        /// </summary>
        private UserRequestData _userRequestData;

        /// <summary>
        /// The rest builder
        /// </summary>
        private readonly IResponseBuilder _responseBuilder;

        /// <summary>
        /// The country code
        /// </summary>
        private readonly CountryCode _countryCode;

        /// <summary>
        /// FOR TEST ONLY!!!
        /// </summary>
        /// <param name="userRequestData">The user request data.</param>
        /// <param name="tokenContract">The token contract.</param>
        /// <param name="countryCode">The country code.</param>
        /// <param name="responseBuilder">The response builder.</param>
        public PayUClient(UserRequestData userRequestData, TokenContract tokenContract, CountryCode countryCode, ResponseBuilder responseBuilder)
        {
            this._userRequestData = userRequestData;
            this._responseBuilder = responseBuilder;
            this._tokenContract = tokenContract;
            this._countryCode = countryCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PayUClient"/> class.
        /// </summary>
        /// <param name="isProducition">if set to <c>true</c> [is producition].</param>
        /// <param name="baseUrl">base url to connect with API</param>
        public PayUClient(UserRequestData userRequestData, TokenContract tokenContract)
         {
             _userRequestData = userRequestData;
             _responseBuilder = new ResponseBuilder(userRequestData.BaseUrl);
             _tokenContract = tokenContract;
             _countryCode = userRequestData.CountryCode;
         }

        public async Task<T> Request<T>(PayURequestType payURequestType)
        {
            try
            {
            switch (payURequestType)
            {
                case PayURequestType.GetOrderDetails:
                    return (T)Convert.ChangeType(await _responseBuilder.GetOrderDetails<T>(_userRequestData.DataToRequest
                        .OrderId, _tokenContract),
                        typeof(T));

                case PayURequestType.PostRefundOrder:
                    return (T)Convert.ChangeType(await _responseBuilder.PostRefundOrder<T>(_userRequestData.DataToRequest
                        .OrderId, _tokenContract),
                        typeof(T));

                case PayURequestType.PutUpdateOrder:
                    return (T)Convert.ChangeType(await _responseBuilder
                        .PutUpdateOrder<T>(_userRequestData.DataToRequest.OrderId, _userRequestData.OrderStatus, _tokenContract),
                        typeof(T));

                    case PayURequestType.DeleteCancelOrder:
                        return (T)Convert.ChangeType(await _responseBuilder
                            .DeleteCancelOrderTask<T>(_userRequestData.DataToRequest.OrderId, _tokenContract),
                            typeof(T));

                    case PayURequestType.PostCreateNewOrder:
                    return (T)Convert.ChangeType(await _responseBuilder
                        .PostCreateNewOrder<T>(_tokenContract, _userRequestData.DataToRequest.OrderContract),
                        typeof(T));

                //case PayURequestType.PostPayOutFromShop:
                //    return this;

                //case PayURequestType.GetRetrevePayout:
                //    return this;

                //case PayURequestType.FinishRequests:
                //    return this;

                default:
                    throw new InvalidRequestType();
            }
        }
            catch (AggregateException innerException)
            {
                Console.WriteLine($"{innerException.Message}");
                throw innerException.InnerException.InnerException;
            }
        }
    }
}