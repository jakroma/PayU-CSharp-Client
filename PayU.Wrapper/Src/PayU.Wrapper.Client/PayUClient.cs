using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Exception;
using RestSharp;

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

        /// <summary>
        /// The token
        /// </summary>
        private TokenContract _tokenContract;

        /// <summary>
        /// The user request
        /// </summary>
        private UserRequest _userRequest;

        /// <summary>
        /// The rest builder
        /// </summary>
        private readonly IRestBuilder _restBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayUClient"/> class.
        /// </summary>
        /// <param name="isProducition">if set to <c>true</c> [is producition].</param>
        public PayUClient(bool isProducition, UserRequest userRequest)
         {
             this._baseUrl = isProducition ? "https://secure.payu.com" : "https://secure.snd.payu.com";
             _userRequest = userRequest;
             _restBuilder = new RestBuilder(_baseUrl);
             _tokenContract = _restBuilder.GetAOuthToken<TokenContract>(_userRequest).Result;
        }

        public async Task<T> Request<T>(PayURequestType payURequestType)
        {
            if (_tokenContract == null)
            {
                _tokenContract = await _restBuilder.GetAOuthToken<TokenContract>(_userRequest);
            }
            switch (payURequestType)
            {
                case PayURequestType.GetOrderDetails:
                    return (T)Convert.ChangeType(_restBuilder.GetOrderDetails<T>(_userRequest.DataToRequest.OrderId, _tokenContract) , typeof(T));

                case PayURequestType.GetRefundOrder:
                    return (T)Convert.ChangeType(_restBuilder.GetRefundOrder<T>(_userRequest.DataToRequest.OrderId, _tokenContract) , typeof(T));

                //case PayURequestType.UpdateOrder:
                //    return this;

                //case PayURequestType.CancelOrder:
                //    return this;

                case PayURequestType.PostCreateNewOrder:
                    return (T)Convert.ChangeType(_restBuilder.PostCreateNewOrder<T>(_userRequest.DataToRequest.OrderId, _tokenContract, _userRequest.DataToRequest.OrderContract), typeof(T)); ;

                //case PayURequestType.PayOutFromShop:
                //    return this;

                //case PayURequestType.RetrevePayout:
                //    return this;

                //case PayURequestType.FinishRequest:
                //    return this;

                default:
                    throw new InvalidRequestType();
            }
        }
    }
}