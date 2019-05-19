using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PayU.Client.Models;

namespace PayU.Client.Models
{
    public abstract class BaseOrder
    {
        public BaseOrder(string customerIp, string merchantPosId, string description, string currencyCode, string totalAmount, IList<Product> products)
        {
            this.isValid(customerIp, description, currencyCode, totalAmount, products);
            this.CustomerIp = customerIp;
            this.MerchantPosId = merchantPosId;
            this.Description = description;
            this.CurrencyCode = currencyCode;
            this.TotalAmount = totalAmount;
            this.Products = products;
        }

        protected BaseOrder(){}

        [JsonProperty(PayUContainer.PropsName.NotifyUrl,  NullValueHandling = NullValueHandling.Ignore)]
        public string NotifyUrl { get; set; }

        [JsonProperty(PayUContainer.PropsName.ContinueUrl, NullValueHandling = NullValueHandling.Ignore)]
        public string ContinueUrl { get; set; }

        [JsonProperty(PayUContainer.PropsName.ExtOrderId,  NullValueHandling = NullValueHandling.Ignore)]
        public string ExtOrderId { get; set; }

        [JsonProperty(PayUContainer.PropsName.ValidityTime,  NullValueHandling = NullValueHandling.Ignore)]
        public string ValidityTime { get; set; }

        /// <summary>
        /// Mandatory Field
        /// </summary>
        [JsonProperty(PayUContainer.PropsName.CustomerIp)]
        public string CustomerIp { get; private set; }

        /// <summary>
        /// Mandatory Field
        /// </summary>
        [JsonProperty(PayUContainer.PropsName.MerchantPosId)]
        public string MerchantPosId { get; private set; }

        /// <summary>
        /// Mandatory Field
        /// </summary>
        [JsonProperty(PayUContainer.PropsName.Description)]
        public string Description { get; private set; }

        [JsonProperty(PayUContainer.PropsName.AdditionalDescription,  NullValueHandling = NullValueHandling.Ignore)]
        public string AdditionalDescription { get; set; }

        /// <summary>
        /// Mandatory Field
        /// </summary>
        [JsonProperty(PayUContainer.PropsName.CurrencyCode)]
        public string CurrencyCode { get; private set; }

        /// <summary>
        /// Mandatory Field
        /// </summary>
        [JsonProperty(PayUContainer.PropsName.TotalAmount)]
        public string TotalAmount { get;  private set; }

        /// <summary>
        /// Mandatory Field
        /// </summary>
        [JsonProperty(PayUContainer.PropsName.Products)]
        public IList<Product> Products { get; private set; }

        [JsonProperty(PayUContainer.PropsName.PayMethods, NullValueHandling = NullValueHandling.Ignore)]
        public OrderPayMethodsRequest PayMethods { get; set; }

        [JsonProperty(PayUContainer.PropsName.DeviceFingerPrint, NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceFingerPrint { get; set; }

        [JsonProperty(PayUContainer.PropsName.Buyer, NullValueHandling = NullValueHandling.Ignore)]
        public Buyer Buyer { get; set; }

        [JsonProperty(PayUContainer.PropsName.Reccuring, NullValueHandling = NullValueHandling.Ignore)]
        public string Reccuring { get; set; }

        [JsonProperty(PayUContainer.PropsName.Moto, NullValueHandling = NullValueHandling.Ignore)]
        public string Moto { get; set; }

        private void isValid(string customerIp, string description, string currencyCode, string totalAmount, IList<Product> products)
        {
            bool mandatoryFieldsAreEmpty = string.IsNullOrEmpty(customerIp) ||
                string.IsNullOrEmpty(description) ||
                string.IsNullOrEmpty(currencyCode) ||
                string.IsNullOrEmpty(totalAmount) ||
                products == null ||
                products.Count == 0;

            if (mandatoryFieldsAreEmpty)
            {
                throw new ArgumentException("Some of mandatory fields in order doesn't contains values");
            }
        }
    }
}