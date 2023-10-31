using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CH.IO.Comm;

namespace CH.IO.Comm
{
    public partial class USB : DEVICE
    {
        public USB()
        {

        }

        public class HANDLE
        {
        }

        public static int Mount(HANDLE handle)
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

        public static int GetDeviceID(out int[] ID)
        {
            try
            {
                ID = null;
                return 0;
            }
            catch
            {
            	throw;
            }
        }

        public static int Unmount()
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

        public class CONFIG : DEVICE.DEVICE_CONFIG
        {

        }

        override public int Open(DEVICE.DEVICE_CONFIG config)
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
       

        override public int Read(out byte datum)
        {
            try
            {
                datum = 0;
                return 0;
            }
            catch
            {
                throw;
            }
        }

        override public int Read(byte[] buffer, int offset, int count)
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

        override public int Write(byte datum)
        {
            try
            {
                datum = 0;
                return 0;
            }
            catch
            {
                throw;
            }
        }

        override public int Write(byte[] buffer, int offset, int count)
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

        override public int Close()
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

        override public object IOCtrl(string type, object cmd)
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

        override public bool IsOpen
        {
            get
            {
                try
                {
                    return true;
                }
                catch
                {
                    throw;
                }
            }
        }

        override public int ByteToRead
        {
            get
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
        }

        override public event MsgEventHandler OnMsg = null;
        override public event ErrorEventHandler OnError = null;
    }
}
