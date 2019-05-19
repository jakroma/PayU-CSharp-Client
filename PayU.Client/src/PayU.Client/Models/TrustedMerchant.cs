using System;

namespace PayU.Client
{
    public class TrustedMerchant
    {
        public TrustedMerchant(string email, string extCustomerId)
        {
            this.Valid(email, extCustomerId);
            this.Email = email;
            this.ExtCustomerId = extCustomerId;            
        }

        public string Email { get; private set; }
        public string ExtCustomerId { get; private set; }


        private void Valid(string email, string extCustomerId)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(extCustomerId))
            {
                throw new ArgumentException("Email or extCustomerId are null or empty");
            }
        }
    }
}