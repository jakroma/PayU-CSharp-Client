using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PayU.Client.Models.Content
{
    public class JsonContent : HttpContent
    {
        private PooledStream pooledStream;

        public JsonContent(object obj, JsonSerializer jsonSerializer)
        {
            pooledStream = PooledStream.Acquire();

            jsonSerializer.Serialize(pooledStream.StreamWriter, obj);

            pooledStream.StreamWriter.Flush();

            Headers.ContentType = PayUContainer.ContentJson;
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            ArraySegment<byte> buffer;
            if (!pooledStream.MemoryStream.TryGetBuffer(out buffer))
                throw new InvalidOperationException("No Buffer Found");

            return stream.WriteAsync(buffer.Array, 0, buffer.Count);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = pooledStream.MemoryStream.Length;
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && pooledStream != null)
            {
                PooledStream.Return(pooledStream);
                pooledStream = null;
            }

            base.Dispose(disposing);
        }

        private class PooledStream
        {
            private static readonly ObjectPool<PooledStream> Pool
                = new ObjectPool<PooledStream>(100, () => new PooledStream());

            public readonly StreamWriter StreamWriter;
            public readonly MemoryStream MemoryStream;

            private PooledStream()
            {
                MemoryStream = new MemoryStream();
                StreamWriter = new StreamWriter(MemoryStream);
            }

            public static PooledStream Acquire()
            {
                return Pool.Acquire();
            }

            public static void Return(PooledStream pooledStream)
            {
                pooledStream.MemoryStream.SetLength(0);
                Pool.Release(pooledStream);
            }
        }
    }
}