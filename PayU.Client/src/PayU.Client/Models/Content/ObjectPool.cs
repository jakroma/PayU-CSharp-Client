using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PayU.Client.Models.Content
{
    public class ObjectPool<T> : IDisposable
    {
        private readonly Func<T> factory;
        private readonly Action<T> onRelease;
        private readonly T[] pool;
        private readonly int maxSize;

        private volatile int currentTicket;

        private int ticketCounter = -1;
        private int index = -1;
        private bool isDisposed;

        public ObjectPool(int maxSize, Func<T> factory, Action<T> onRelease = null)
        {
            if (maxSize == 0)
                throw new ArgumentException("Max size is required", nameof(maxSize));

            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            this.factory = factory;
            this.onRelease = onRelease;
            this.pool = new T[maxSize];
            this.maxSize = maxSize - 1;
        }

        public T Acquire()
        {
            var nextTicket = EnterLock();

            if (this.isDisposed)
            {
                currentTicket = nextTicket;
                throw new ObjectDisposedException(nameof(ObjectPool<T>));
            }

            if (this.index == -1)
            {
                currentTicket = nextTicket;
                return factory();
            }

            var value = this.pool[index--];
            this.currentTicket = nextTicket;
            return value;
        }
        
        public bool TryAcquire(out T value)
        {
            var nextTicket = EnterLock();

            if (this.isDisposed)
            {
                currentTicket = nextTicket;
                throw new ObjectDisposedException(nameof(ObjectPool<T>));
            }

            if (index == -1)
            {
                currentTicket = nextTicket;
                value = default(T);
                return false;
            }

            value = pool[index--];
            this.currentTicket = nextTicket;
            return true;
        }

        public bool Release(T value)
        {
            onRelease?.Invoke(value);

            var nextTicket = EnterLock();
            var result = !isDisposed && index != maxSize;

            if (result)
                this.pool[++index] = value;

            this.currentTicket = nextTicket;
            return result;
        }

        public UsableValue Use()
        {
            var value = Acquire();
            return new UsableValue(this, value);
        }

        public void Dispose()
        {
            var nextTicket = EnterLock();

            try
            {
                if (isDisposed)
                    return;

                foreach (var value in pool)
                {
                    var disposable = value as IDisposable;
                    if (disposable == null) break;
                    disposable.Dispose();
                }

                Array.Clear(pool, 0, pool.Length);
            }
            finally
            {
                this.isDisposed = true;
                this.currentTicket = nextTicket;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int EnterLock()
        {
            var myTicket = Interlocked.Increment(ref ticketCounter);

            if (myTicket != currentTicket)
                while (myTicket != currentTicket)
                {
                }

            return myTicket + 1;
        }

        public struct UsableValue : IDisposable
        {
            private readonly ObjectPool<T> pool;

            public readonly T Value;

            public UsableValue(ObjectPool<T> pool, T value)
            {
                this.pool = pool;
                this.Value = value;
            }

            public void Dispose()
            {
                this.pool.Release(Value);
            }

            public static implicit operator T(UsableValue usableValue)
            {
                return usableValue.Value;
            }
        }
    }
}