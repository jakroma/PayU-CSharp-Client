using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayU.Client.Builders;
using PayU.Client.Converters;
using PayU.Client.Exception;
using PayU.Client.Models;

namespace PayU.Client
{
    public class PayUApiHttpCommunicator<T>
        where T : class
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly HttpClientHandler handler = new HttpClientHandler
        {
            AllowAutoRedirect = false,
            SslProtocols = SslProtocols.Tls12
        };

        public PayUApiHttpCommunicator(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public PayUApiHttpCommunicator() {}

        public async Task<T> SendAsync(HttpRequestMessage rq, CancellationToken ct)
        {
            return clientFactory == null ? await this.SendRequestByClientAsync(rq, ct) : await this.SendRequestByFactoryAsync(rq, ct);
        }

        public T Send(HttpRequestMessage rq)
        {
            return clientFactory == null ? this.SendRequestByClient(rq) : this.SendRequestByFactory(rq);
        }

        private T SendRequestByFactory(HttpRequestMessage rq)
        {
            using (var client = clientFactory.CreateClient())
            {
                return this.SendReceive(rq, client);
            }
        }

        private T SendRequestByClient(HttpRequestMessage rq)
        {
            using (var client = new HttpClient(this.handler))
            {
                return this.SendReceive(rq, client);
            }
        }

        private async Task<T> SendRequestByFactoryAsync(HttpRequestMessage rq, CancellationToken ct)
        {
            using (var client = clientFactory.CreateClient())
            {
                return await this.SendReceiveAsync(rq, client, ct);
            }
        }

        private async Task<T> SendRequestByClientAsync(HttpRequestMessage rq, CancellationToken ct)
        {
            using (var client = new HttpClient(this.handler))
            {
                return await this.SendReceiveAsync(rq, client, ct);
            }
        }

        private async Task<T> SendReceiveAsync(HttpRequestMessage rq, HttpClient client, CancellationToken ct)
        {
            var response = await client.SendAsync(rq, ct);

            if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.Found)
            {
                return await this.DeserializeResponseAsync(response);
            }

            throw new PayUApiException(response.StatusCode, response.ReasonPhrase, await response.Content.ReadAsStringAsync());
        }

        private T SendReceive(HttpRequestMessage rq, HttpClient client)
        {
            var response = client.SendAsync(rq).Result;

            if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.Found)
            {
                return this.DeserializeResponse(response);
            }

            throw new PayUApiException(response.StatusCode, response.ReasonPhrase, response.Content.ReadAsStringAsync().Result);
        }

        private async Task<T> DeserializeResponseAsync(HttpResponseMessage response)
        {
            using (var contentStream = await response.Content.ReadAsStreamAsync())
            using (var streamReader = new StreamReader(contentStream))
            {
                return PayUClientConverter.DeserializeResponse<T>(await streamReader.ReadToEndAsync());
            }
        }

        private T DeserializeResponse(HttpResponseMessage response)
        {
            using (var contentStream = response.Content.ReadAsStreamAsync().Result)
            using (var streamReader = new StreamReader(contentStream))
            {
                return PayUClientConverter.DeserializeResponse<T>(streamReader.ReadToEnd());
            }
        }
    }
}