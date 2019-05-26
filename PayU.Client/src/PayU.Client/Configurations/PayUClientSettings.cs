using System;
using System.Net.Http;
using PayU.Client.Models;

namespace PayU.Client.Configurations
{
    public class PayUClientSettings
    {
        public PayUClientSettings(string url, string apiVersion, string clientId, string clientSecret)
        {
            this.AssignMandatoryProperties(url, apiVersion, clientId, clientSecret);
        }

        public PayUClientSettings(string url, string apiVersion, string clientId, string clientSecret, string factoryClientName)
        {
            this.AssignMandatoryProperties(url, apiVersion, clientId, clientSecret);
            this.FactoryClientName = factoryClientName;
        }

        public string Url { get; private set; }
        public string ApiVersion { get; private set; }
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }
        public string FactoryClientName { get; set; }

        private void AssignMandatoryProperties(string url, string apiVersion, string clientId, string clientSecret)
        {
            this.Valid(url, apiVersion, clientId, clientSecret);
            this.Url = url;
            this.ApiVersion = apiVersion;
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
        }

        private void Valid(string url, string apiVersion, string clientId, string clientSecret)
        {
            if (string.IsNullOrEmpty(url) ||
                    string.IsNullOrEmpty(apiVersion) ||
                    string.IsNullOrEmpty(clientId) ||
                    string.IsNullOrEmpty(clientSecret))
                 {
                     throw new ArgumentException("Some of settings properties are null or empty");
                 }
        }
    }
}