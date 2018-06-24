using PayU.Wrapper.Client.Data;

namespace PayU.Wrapper.Client
{
    public interface IGetPayUToken
    {
        /// <summary>
        /// Gets the pay u client.
        /// </summary>
        /// <returns>PayUClient Class.</returns>
        TokenContract GetToken();
    }
}