using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using PayU.Client.Models;

namespace PayU.Client.Models
{
    public class OrderRequest : BaseOrder
    {
        public OrderRequest(string customerIp, string merchantPosId, string description, string currencyCode, string totalAmount, IList<Product> products)
            : base(customerIp, merchantPosId, description, currencyCode, totalAmount, products)
        {
        }
    }
}