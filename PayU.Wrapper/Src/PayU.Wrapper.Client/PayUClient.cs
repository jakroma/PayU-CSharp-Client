using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using PayU.Shared;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
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

        public async Task<T> Request<T>(RequestType requestType, UserRequest userRequest, int orderId = 0)
        {
            TokenContract tokenContract = await _restBuilder.GetAOuthToken<TokenContract>(userRequest);
            switch (requestType)
            {
                case RequestType.GetOrderDetails:
                    return (T)Convert.ChangeType(_restBuilder.GetOrderDetails<T>(orderId, tokenContract) , typeof(T));

                //case RequestType.RefundOrder:
                //    return this;

                //case RequestType.UpdateOrder:
                //    return this;

                //case RequestType.CancelOrder:
                //    return this;

                //case RequestType.CreateNewOrder:
                //    return this;

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