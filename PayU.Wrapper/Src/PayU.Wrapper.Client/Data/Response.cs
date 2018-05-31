using System;
using System.Collections.Generic;

namespace PayU.Wrapper.Client.Data
{
    /// <summary>
    /// Generic Response Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        /// <summary>
        /// Gets or sets the response list.
        /// </summary>
        /// <value>
        /// The response list.
        /// </value>
        public List<T> ResponseList { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}