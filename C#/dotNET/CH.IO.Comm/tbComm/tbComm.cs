﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CH.IO;

namespace CH.IO.Comm
{
    public class tbComm : DEVICE
    {

        public class CONFIG : DEVICE_CONFIG
        {

        }

        #region Mount methods as static
        #region Handle Class for initial setup of Mount
        public class HANDLE
        {
        }
        #endregion

        public static int Mount(HANDLE handle)
        {
            try
            {
            }
            catch
            {
                throw;
            }
            return 0;
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
        #endregion

        #region Configration Class for initial setup
        #endregion

        #region Delegates
        public override event MsgEventHandler OnMsg = null;
        public override event ErrorEventHandler OnError = null;
        #endregion

        public override int Open(DEVICE_CONFIG config)
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

        public override int Close()
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

        public override bool IsOpen
        {
            get
            {
                return false;
            }
        }

        public override int ByteToRead
        {
            get 
            {
                return 0;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
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

        public override int Read(out byte datum)
        {
            try
            {
                datum = 3;
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public class testData
        {
            public int Data1 = 1;
            public int Data2 = 2;
        }

        public override int Write(byte datum)
        {
            try
            {
                OnMsg(this, "string", "Test String");
                byte[] ar = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                OnMsg(this, "byte[]", ar);
                testData td = new testData();
            }
            catch
            {
                throw;
            }
            return 0;
        }

        public override int Write(byte[] buffer, int offset, int count)
        {
            try
            {
            }
            catch
            {
                throw;
            }
            return 0;
        }

        public void UniqueMethodForTest()
        {
            try
            {
            }
            catch
            {
                throw;
            }
        }
    }
}
