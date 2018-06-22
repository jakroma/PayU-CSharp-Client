namespace PayU.Wrapper.Client
{
    public interface IGetPayUToken
    {
        /// <summary>
        /// Gets the pay u client.
        /// </summary>
        /// <returns>Interface of IPayUToken</returns>
        IPayUClient GetPayUClient();
    }
}