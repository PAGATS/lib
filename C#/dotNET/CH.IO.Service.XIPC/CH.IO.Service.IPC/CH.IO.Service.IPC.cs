using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;

using CH.Data;
using CH.IO.Comm;
using CH.IO.Service;
using CH.Diagnostics;

namespace CH.IO.Service
{
    public class IPC : INTERFACE
    {
        private class VARIABLE
        {
            public CONFIG config = null;
            public DEVICE OpenDevice = null;
            public MemoryStream MemStream = null;
            public bool bClientOpenCMD;
            public int nXMLLength;
            public byte[] pBuf = null;
            public int nBufCount = 0;
            public int nBufCountRemainder = 0;
            public XmlSerializer xs = null;
            public Queue<byte[]> qBytes = new Queue<byte[]>();
            public bool bThRxData = true;
            public ManualResetEvent evThRxData = new ManualResetEvent(false);
            public Thread thRxData = null;

            public VARIABLE()
            {
                bClientOpenCMD = false;
            }
        }
        private VARIABLE g;
        private Debug d = new Debug("CH.IO.Service.IPC");

        public class CONFIG
        {
            public Type type = null;
        }
        
        public IPC()
        {
            try
            {
                g = new VARIABLE();
            }
            catch
            {
                throw;
            }
        }

        // Standard Method for POSIX
        public override int Connect(DEVICE openDevice, object config)
        {
            try
            {
                g.bClientOpenCMD = true;
                g.config = (CONFIG)config;
                g.OpenDevice = (DEVICE)openDevice;
                g.xs = new XmlSerializer(g.config.type);
                g.OpenDevice.OnMsg += new DEVICE.MsgEventHandler(OpenDevice_OnMsg);
                g.OpenDevice.OnError += new DEVICE.ErrorEventHandler(OpenDevice_OnError);
                
                g.thRxData = new Thread(new ThreadStart(ThRxData));
                g.thRxData.Start();

                return 0;
            }
            catch
            {
                throw;
            }
        }

        public override int Disconnect()
        {
            try
            {
                g.evThRxData.Set();
                g.bThRxData = false;
                g.bClientOpenCMD = false;
                return 0;
            }
            catch
            {
                throw;
            }
        }

        private String AsciiToString(byte[] buffer, int count)
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

        private byte[] StringToAscii(string str)
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

        public override int Send(Type type, object RegisteredClass)
        {
            try
            {
                int rst = -1;
                if (null != g.OpenDevice)
                {
                    if (true == IsConnection)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            g.xs.Serialize(ms, RegisteredClass);
                            ms.Flush();

                            if (true == IsConnection)
                            {
                                rst = g.OpenDevice.Write(StringToAscii(string.Format("<?xml size={0:0000000000}>", ms.Length) ), 0, 22);
                                rst = g.OpenDevice.Write(ms.GetBuffer(), 0, (int)ms.Length);
                            }
                            ms.Close();
                        }
                        return rst;
                    }
                }
                return rst;
            }
            catch
            {
                throw;
            }
        }


       

        // Standard Method for Semi-POSIX
        public override object IOCtrl(string type, object cmd)
        {
            try
            {
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public override bool IsConnection
        {
            get
            {
                try
                {
                    if (null != g.OpenDevice)
                    {
                        return (g.OpenDevice.IsOpen && g.bClientOpenCMD);
                    }
                    return false;
                }
                catch
                {
                    throw;
                }
            }
        }

        // Extension for CH
        public override event MsgEventHandler OnMsg;

        public override event ErrorEventHandler OnError;

        void OpenDevice_OnError(object sender, string source, Exception err)
        {

        }

        void ThRxData()
        {
            while (g.bThRxData)
            {                
                try
                {
                    g.evThRxData.WaitOne();
                    while (0 < g.qBytes.Count)
                    {
                        byte[] pData = (byte[])g.qBytes.Dequeue();                        
                        int nXMLStartIndex = Encoding.Default.GetString(pData).IndexOf("<?xml size=");

                        switch (nXMLStartIndex)
                        {
                            case 0:
                                {
                                    // <?xml size=가 0번에 있는 경우
                                    int nCount = 0;
                                    byte[] pTemp = new byte[10];
                                    Array.Copy(pData, nXMLStartIndex + 11, pTemp, 0, 10);
                                    g.nXMLLength = int.Parse(AsciiToString(pTemp, pTemp.Length));

                                    g.nBufCount = 0;
                                    g.nBufCountRemainder = 0;
                                    g.pBuf = new byte[g.nXMLLength];

                                    int nDataLength = pData.Length - (nXMLStartIndex + 22);
                                    nCount = (g.nXMLLength > nDataLength) ? nDataLength : g.nXMLLength; // 작은 것을 입력

                                    Array.Copy(pData, nXMLStartIndex + 22, g.pBuf, 0, nCount);

                                    g.nBufCount = nCount;
                                    g.nBufCountRemainder = g.nXMLLength - g.nBufCount;

                                    if (0 >= g.nBufCountRemainder)
                                    {
                                        g.MemStream = new MemoryStream(g.pBuf, 0, g.pBuf.Length);

                                        try
                                        {
                                            if (null != OnMsg)
                                            {
                                                OnMsg(this, g.config.type.FullName, System.Convert.ChangeType(g.xs.Deserialize(g.MemStream), g.config.type));
                                            }
                                        }
                                        catch { }

                                        g.MemStream.Close();
                                        g.MemStream = null;
                                        g.pBuf = null;
                                        g.nBufCount = 0;
                                        g.nBufCountRemainder = 0;
                                    }
                                }
                                break;
                            case -1:
                                {
                                    // <?xml size=가 없는 경우 : XML 데이터의 중간(혹은 딱 마지막에 맞게) 부분이 들어 온 경우
                                    if (null != g.pBuf)
                                    {
                                        int nCount = (pData.Length > g.nBufCountRemainder) ? g.nBufCountRemainder : pData.Length;

                                        Array.Copy(pData, 0, g.pBuf, g.nBufCount, nCount);

                                        g.nBufCount += nCount;
                                        g.nBufCountRemainder = g.nXMLLength - g.nBufCount;

                                        if (0 >= g.nBufCountRemainder) // 딱 마지막에 맞게 들어 온 경우
                                        {
                                            // 데이터가 모두 온 상태
                                            g.MemStream = new MemoryStream(g.pBuf, 0, g.pBuf.Length);

                                            try
                                            {
                                                if (null != OnMsg)
                                                {
                                                    OnMsg(this, g.config.type.FullName, System.Convert.ChangeType(g.xs.Deserialize(g.MemStream), g.config.type));
                                                }
                                            }
                                            catch{}

                                            g.MemStream.Close();
                                            g.MemStream = null;
                                            g.pBuf = null;
                                            g.nBufCount = 0;
                                            g.nBufCountRemainder = 0;
                                        }
                                    }
                                }
                                break;
                            default:
                                {
                                    // <?xml size=가 중간에 있는 경우 : 앞의 것을 먼저 보내고, 뒤의 것을 다시 시작해야 함
                                    int nCount;
                                    if (null != g.pBuf)
                                    {
                                        nCount = (pData.Length > g.nBufCountRemainder) ? g.nBufCountRemainder : pData.Length;
                                        Array.Copy(pData, 0, g.pBuf, g.nBufCount, nCount);

                                        g.nBufCount += nCount;
                                        g.nBufCountRemainder = g.nXMLLength - g.nBufCount;

                                        if (0 >= g.nBufCountRemainder)
                                        {
                                            g.MemStream = new MemoryStream(g.pBuf, 0, g.pBuf.Length);

                                            try
                                            {
                                                if (null != OnMsg)
                                                {
                                                    OnMsg(this, g.config.type.FullName, System.Convert.ChangeType(g.xs.Deserialize(g.MemStream), g.config.type));
                                                }
                                            }
                                            catch { }

                                            g.MemStream.Close();
                                            g.MemStream = null;
                                            g.pBuf = null;
                                            g.nBufCount = 0;
                                            g.nBufCountRemainder = 0;
                                        }
                                    }

                                    // 다시 처음부터 다시 보내기
                                    byte[] pTemp = new byte[10];
                                    Array.Copy(pData, nXMLStartIndex + 11, pTemp, 0, 10);
                                    g.nXMLLength = int.Parse(AsciiToString(pTemp, pTemp.Length));

                                    g.nBufCount = 0;
                                    g.nBufCountRemainder = 0;
                                    g.pBuf = new byte[g.nXMLLength];

                                    int nDataLength = pData.Length - (nXMLStartIndex + 22);
                                    nCount = (g.nXMLLength > nDataLength) ? nDataLength : g.nXMLLength; // 작은 것을 입력

                                    Array.Copy(pData, nXMLStartIndex + 22, g.pBuf, 0, nCount);

                                    g.nBufCount = nCount;
                                    g.nBufCountRemainder = g.nXMLLength - g.nBufCount;

                                    if (0 >= g.nBufCountRemainder)
                                    {
                                        g.MemStream = new MemoryStream(g.pBuf, 0, g.pBuf.Length);

                                        try
                                        {
                                            if (null != OnMsg)
                                            {
                                                OnMsg(this, g.config.type.FullName, System.Convert.ChangeType(g.xs.Deserialize(g.MemStream), g.config.type));
                                            }
                                        }
                                        catch { }

                                        g.MemStream.Close();
                                        g.MemStream = null;
                                        g.pBuf = null;
                                        g.nBufCount = 0;
                                        g.nBufCountRemainder = 0;
                                    }
                                }
                                break;
                        }
                        g.evThRxData.Reset();

                        if (!g.bThRxData)
                        {
                            break;
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    OnError(this, "ThRxData", ex);
                }
            }
        }

        void OpenDevice_OnMsg(object sender, string type, object msg)
        {
            try
            {
                switch (type)
                {
                    case "CONNECTED":
                        {  
                            if (null != OnMsg)
                            {
                                OnMsg(this, "CONNECTED", null);
                            }
                        }
                        break;
                    case "DISCONNECTED":
                        {
                            if(null != OnMsg)
                            {
                                OnMsg(this, "DISCONNECTED", null);
                            }
                        }
                        break;
                    case "READ":
                        {
                            try
                            {
                                byte[] pData = new byte[g.OpenDevice.ByteToRead];
                                g.OpenDevice.Read(pData, 0, pData.Length);
                                byte[] pDataClone = (byte[])pData.Clone();
                                g.qBytes.Enqueue(pDataClone);
                                g.evThRxData.Set();
                            }
                            catch (System.Exception ex)
                            {
                                OnError(this, "OpenDevice_OnMsg", ex);
                            }
                            finally
                            {
                                
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                OnError(this, "OpenDevice_OnMsg", ex);
            }
        }
    }
}
