using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CH.Data
{
    public class Convert
    {
        public static String AsciiToString(byte[] buffer, int count)
        {
            try
            {
                ASCIIEncoding ae = new ASCIIEncoding();
                return new String(ae.GetChars(buffer, 0, count));
            }
            catch
            {
                throw;
            }
        }

        public static byte[] StringToAscii(string str)
        {
            try
            {
                byte[] pStr = new byte[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    pStr[i] = System.Convert.ToByte(System.Convert.ToChar(str[i]));
                }
                return pStr;
            }
            catch
            {
                throw;
            }
        }
    }
}
