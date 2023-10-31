using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoteObject_Prj
{
    public class RemoteObject : MarshalByRefObject
    {
        private static int callCount = 0;

        public int GetCount()
        {
            Console.WriteLine("GetCount has been called.");
            callCount++;
            return (callCount);
        }

        public void SetCount(int cnt )
        {
            callCount = cnt;
            Console.WriteLine("SetCount =" + cnt.ToString());
        }
    }
}
