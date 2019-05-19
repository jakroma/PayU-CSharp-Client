using System;
using Newtonsoft.Json;
using PayU.Client.Models;

namespace PayU.Client.Converters
{
    public static class PayUClientConverter
    {
        private const string OldValue = "\";\n";
        private const string NewValue = "\",\n";

        public static T DeserializeResponse<T>(string value)
            where T : class
        {
            if (typeof(T) == typeof(RetrivePayoutResponse))
            {
                return JsonConvert.DeserializeObject<T>(FixBadJsonResponse(value));
            }

            return JsonConvert.DeserializeObject<T>(value);
        }


        private static string FixBadJsonResponse(string value)
        {
            return value.Replace(OldValue, NewValue);
        }
    }
}