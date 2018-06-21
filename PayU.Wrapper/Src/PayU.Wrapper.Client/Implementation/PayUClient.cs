using System;
using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;
using PayU.Wrapper.Client.Enum;
using PayU.Wrapper.Client.Exception;

namespace PayU.Wrapper.Client
{
    /// <summary>
    /// Pay U Client Class
    /// </summary>
    /// <seealso cref="PayU.Wrapper.Client.IPayUClient" />
    public class PayUClient : IPayUClient
    {
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
        /// <param name="baseUrl">base url to connect with API</param>
        public PayUClient(UserRequest userRequest, string baseUrl)
         {
             _userRequest = userRequest;
             _restBuilder = new RestBuilder(baseUrl);
        }

        public async Task<T> Request<T>(PayURequestType payURequestType)
        {
            try
            {
            if (_tokenContract == null)
            {
                _tokenContract = await _restBuilder.PostAOuthToken<TokenContract>(_userRequest);
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
            catch (AggregateException innerException)
            {
                Console.WriteLine($"{innerException.Message}");
                throw innerException.InnerException.InnerException;
            }
        }
    }
}