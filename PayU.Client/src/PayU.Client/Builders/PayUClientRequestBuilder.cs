using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Runtime;
using PayU.Client.Models;
using System.Globalization;
using PayU.Client.Configurations;
using PayU.Client.Models.Content;
using System.Collections.Generic;

namespace PayU.Client.Builders
{
    public static class PayUClientRequestBuilder
    {
        public static HttpRequestMessage BuildRequestMessage(Uri url, HttpMethod method, string token)
        {
            var message = new HttpRequestMessage();
            message.Headers.Authorization = new AuthenticationHeaderValue(PayUContainer.BearerAuthentication, token);
            message.Headers.Accept.Add(PayUContainer.ContentJson);
            message.Method = method;
            message.RequestUri = url;
            return message;
        }

        public static HttpRequestMessage BuildRequestMessage(Uri url, HttpMethod method, string token, object content)
        {
            var message = new HttpRequestMessage();
            message.Headers.Authorization = new AuthenticationHeaderValue(PayUContainer.BearerAuthentication, token);
            message.Headers.Accept.Add(PayUContainer.ContentJson);
            message.Method = method;
            message.RequestUri = url;
            
            if (content != null)
            {
                message.Content = new JsonContent(content, PayUContainer.JsonSerializer);
            }
            
            return message;
        }

        public static HttpRequestMessage BuildTokenRequestMessage(PayUClientSettings settings, TrustedMerchant tm)
        {
            var message = new HttpRequestMessage();
            message.Headers.Accept.Add(PayUContainer.ContentJson);
            message.Method = HttpMethod.Post;
            message.RequestUri = PayUClientUrlBuilder.BuildOAuthTokenUrl(settings.Url);
            message.Content = tm != null ? GetTrustedTokenBody(settings, tm) : GetTokenBody(settings); 
            return message;
        }

        private static HttpContent GetTrustedTokenBody(PayUClientSettings settings, TrustedMerchant tm)
        {
            var content = new Dictionary<string, string>(5);
            AddBaseContent(settings, PayUContainer.GrantType.TrustedMerchant, content);
            if (!string.IsNullOrEmpty(tm.Email) && !string.IsNullOrEmpty(tm.ExtCustomerId))
            {
                content.Add(PayUContainer.PropsName.Email, tm.Email);
                content.Add(PayUContainer.PropsName.Ex_Customer_Id, tm.ExtCustomerId);
            }

            return new FormUrlEncodedContent(content);
        }

        private static HttpContent GetTokenBody(PayUClientSettings settings)
        {
            var content = new Dictionary<string, string>(3);
            AddBaseContent(settings, PayUContainer.GrantType.ClientCredentials, content);

            return new FormUrlEncodedContent(content);
        }

        private static void AddBaseContent(PayUClientSettings settings, string grantType, Dictionary<string, string> content)
        {
            content.Add(PayUContainer.PropsName.Grant_Type, grantType);
            content.Add(PayUContainer.PropsName.Client_Id, settings.ClientId);
            content.Add(PayUContainer.PropsName.Client_Secret, settings.ClientSecret);
        }
    }
}
