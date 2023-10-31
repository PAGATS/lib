using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tbSharedMemory
{
    public class SharedMemory : MarshalByRefObject
    {
        private static int count = 0;

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
