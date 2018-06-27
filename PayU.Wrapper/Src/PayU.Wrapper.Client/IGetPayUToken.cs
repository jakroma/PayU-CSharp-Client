using System.Threading.Tasks;
using PayU.Wrapper.Client.Data;

namespace PayU.Wrapper.Client
{
    public interface IGetPayUToken
    {
        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <returns>PayUClient Object.</returns>
        Task<TokenContract> GetToken();
    }
}