using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CH.IO.Comm
{
    public class AS5216ServerMemory : MarshalByRefObject
    {
        // Addrsss
        public string Address;
        public int Offset;
        public static ulong Index;
        static ulong static_Index = 0;

        // Data
        public string SerialNumber;
        public double[] Spectrum;
        public ushort NumPixels;

        public AS5216ServerMemory()
        {
            Address = "";
            Offset = 0;
            Spectrum = new double[2048];
            NumPixels = 2048;
        }

        public void Tick()
        {
            Index = (static_Index < ulong.MaxValue) ? static_Index++ : 0;
        }

        public void Tick(ulong i)
        {
            Index = static_Index = i;
        }
    }
}
