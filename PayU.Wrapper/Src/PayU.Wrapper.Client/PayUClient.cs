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
        /// The rest builder
        /// </summary>
        private readonly IRestBuilder _restBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayUClient"/> class.
        /// </summary>
        /// <param name="isProducition">if set to <c>true</c> [is producition].</param>
        public PayUClient(bool isProducition)
         {
            this._baseUrl = isProducition ? "https://secure.payu.com" : "https://secure.snd.payu.com";
             _restBuilder = new RestBuilder(_baseUrl);
         }

        public async Task<T> Request<T>(RequestType requestType, UserRequest userRequest, OrderContract orderContract = null, int orderId = 0)
        {
            if (_tokenContract == null)
            {
                _tokenContract = await _restBuilder.GetAOuthToken<TokenContract>(userRequest);
            }
            switch (requestType)
            {
                case RequestType.GetOrderDetails:
                    return (T)Convert.ChangeType(_restBuilder.GetOrderDetails<T>(orderId, _tokenContract) , typeof(T));

                case RequestType.RefundOrder:
                    return (T)Convert.ChangeType(_restBuilder.GetRefundOrder<T>(orderId, _tokenContract) , typeof(T));

                //case RequestType.UpdateOrder:
                //    return this;

                //case RequestType.CancelOrder:
                //    return this;

                case RequestType.CreateNewOrder:
                    return (T)Convert.ChangeType(_restBuilder.PostCreateNewOrder<T>(orderId, _tokenContract, orderContract), typeof(T)); ;

                //case RequestType.PayOutFromShop:
                //    return this;

                //case RequestType.RetrevePayout:
                //    return this;

                //case RequestType.FinishRequest:
                //    return this;

                default:
                    throw new InvalidRequestType();
            }
        }
    }
}