using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CH.Data.Parsing
{
    public class Parser
    {
        class VARIABLES
        {
            public bool bSTX;
            public byte STX;
            public byte ETX;
            public Queue<byte> qBuf;
            public Queue<byte> qBuf0; // double buffer
            public Queue<byte> qBuf1;
            public byte[] pByte;

            public VARIABLES(byte nSTX, byte nETX)
            {
                bSTX = false;
                STX = nSTX;
                ETX = nETX;
                qBuf0 = new Queue<byte>();
                qBuf1 = new Queue<byte>();
                qBuf = qBuf0;
                pByte = null;
            }
        }

        VARIABLES g_vb = null;
        
        public delegate void PARSEREventHandler(object sender, string msg);

        public event PARSEREventHandler OnParsed = null;

        public Parser()
        {
            g_vb = null;
            g_vb = new VARIABLES((byte)'<', (byte)'>');
        }

        public Parser(char STX, char ETX)
        {
            g_vb = null;
            g_vb = new VARIABLES((byte)STX, (byte)ETX);
        }

        int i, j;
        int nCount;
        ASCIIEncoding ae = new ASCIIEncoding();
        public void Parsing(byte[] pData, int nDataCount)
        {
            try
            {
                for (int i = 0; i < nDataCount; i++)
                {
                    if (true == g_vb.bSTX)
                    {
                        if (g_vb.ETX != pData[i])
                        {
                            g_vb.qBuf.Enqueue(pData[i]);
                        }
                        else
                        {
                            g_vb.bSTX = false;
                            //g_vb.qBuf.Enqueue(0);

                            if (null != OnParsed)
                            {
                                nCount = g_vb.qBuf.Count;
                                g_vb.pByte = new byte[nCount];
                                for (j = 0; j < nCount; j++)
                                {
                                    g_vb.pByte[j] = g_vb.qBuf.Dequeue();
                                }

                                OnParsed(this, new String(ae.GetChars(g_vb.pByte, 0, nCount)));
                            }

                            if (g_vb.qBuf == g_vb.qBuf0)
                            {
                                g_vb.qBuf = g_vb.qBuf1;
                            }
                            else
                            {
                                g_vb.qBuf = g_vb.qBuf0;
                            }
                        }
                    }

                    if (g_vb.STX == pData[i])
                    {
                        // STX is arrived and parser is reseted.
                        g_vb.bSTX = true;
                        g_vb.qBuf.Clear();
                    }
                }  
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
