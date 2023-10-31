using System;
using System.Threading;

namespace CH.IO.Comm
{
    class CQBuf<T>
    {
        /*
        ****************************************************************
        * Definition of Global Variable(Member Variable)
        ****************************************************************
        */
        private class Variable
        {
            public int maxSize = 0;
            public int capacity = 0;
            public int count = 0;
            public int rxIdx = 0;
            public int txIdx = 0;
            public int rSize = 0;
            public int tSize = 0;
            public T[] buf = null;
            public Mutex sync = null;
        }

        /*
        ****************************************************************
        * Member Variable
        ****************************************************************
        */
        Variable g;

        /*
        ****************************************************************
        * Interfaces
        ****************************************************************
        */
        public CQBuf(int bufferSize)
        {
            Init(bufferSize);
        }

        public void Init(int bufferSize)
        {
            g = new Variable();
            g.maxSize = bufferSize;
            g.capacity = 1;

            if (g.sync != null)
                g.sync.Close();

            g.sync = new Mutex();
        }

        public int Enqueue(T input)
        {
            if (g.capacity - g.count > 0)
            {
                g.sync.WaitOne();

                g.buf[g.rxIdx++] = input;
                if (g.rxIdx == g.capacity)
                    g.rxIdx = 0;
                g.count++;

                g.sync.ReleaseMutex();
            }
            else
            {
                if (Expand(g.capacity + 1)) 
                    return this.Enqueue(input);
                else
                    return 0;
            }
            
            return 1;
        }

        public int Enqueue(T[] input, int offset, int size)
        {
            if (offset + size > input.Length) 
                return 0;
            if (g.capacity - g.count >= size)
            {
                g.sync.WaitOne();

                g.rSize = g.capacity - g.rxIdx;
                if (g.rSize >= size)
                {
                    Array.Copy(
                        input, offset, 
                        g.buf, g.rxIdx, size);
                    if ((g.rxIdx += size) == g.capacity)
                        g.rxIdx = 0;
                }
                else
                {
                    Array.Copy(
                        input, offset, 
                        g.buf, g.rxIdx, g.rSize);
                    Array.Copy(
                        input, offset + g.rSize, 
                        g.buf, 0, size - g.rSize);
                    g.rxIdx = size - g.rSize;
                }
                g.count += size;

                g.sync.ReleaseMutex();
            }
            else
            {
                if (Expand(g.count + size))
                    return Enqueue(input, offset, size);
                else
                    return 0;
            }
            return size;
        }

        public int Dequeue(out T output)
        {
            output = default(T);
            if (g.count > 0)
            {
                g.sync.WaitOne();

                output = g.buf[g.txIdx++];
                if (g.txIdx == g.capacity)
                    g.txIdx = 0;
                g.count--;

                g.sync.ReleaseMutex();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Dequeue(T[] output, int offset, int size)
        {
            if (offset + size > output.Length)
                return 0;
            if (g.count == 0) return 0;
            else
            {
                g.sync.WaitOne();

                if (g.count < size)
                    size = g.count;
                g.tSize = g.capacity - g.txIdx;
                if (size <= g.tSize)
                {
                    Array.Copy(
                        g.buf, g.txIdx, 
                        output, offset, size);
                    if ((g.txIdx += size) == g.capacity)
                        g.txIdx = 0;
                }
                else
                {
                    Array.Copy(
                        g.buf, g.txIdx, 
                        output, offset, g.tSize);
                    Array.Copy(
                        g.buf, 0, 
                        output, offset + g.tSize, 
                        size - g.tSize);
                    g.txIdx = size - g.tSize;
                }
                g.count -= size;

                g.sync.ReleaseMutex();
                return size;
            }            
        }

        /*
        ****************************************************************
        * Properties
        ****************************************************************
        */
        public int MaxSize { get { return g.maxSize; } }

        public int Capacity { get { return g.capacity; } }

        public int Count { get { return g.count; } }

        public int Available { get { return g.capacity - g.count; } }

        /*
        ****************************************************************
        * Utilities
        ****************************************************************
        */
        private bool Expand(int size)
        {
            if (size > g.maxSize)
                return false;
            else
            {
                g.sync.WaitOne();

                T[] buf = new T[size];
                if (g.count != this.Dequeue(buf, 0, g.count))
                    return false;
                g.buf = buf;
                g.capacity = buf.Length;
                g.txIdx = 0;
                g.rxIdx = g.count;

                g.sync.ReleaseMutex();
                return true;
            }
        }
    }
}
