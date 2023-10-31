using System;

namespace CH.IO.Comm
{
    abstract public class DEVICE
    {
        public class DEVICE_CONFIG { };

        //Blocking Call
        abstract public int Open(DEVICE_CONFIG config);

        abstract public int Read(out byte datum);

        abstract public int Read(byte[] buffer, int offset, int count);

        abstract public int Write(byte datum);

        abstract public int Write(byte[] buffer, int offset, int count);

        abstract public int Close();

        abstract public object IOCtrl(string type, object cmd);

        // Non-Blocking call
        abstract public bool IsOpen { get; }

        abstract public int ByteToRead { get; }

        // Delegate of Event Handler
        public delegate void MsgEventHandler(object sender, string type, object msg);

        public delegate void ErrorEventHandler(object sender, string src, Exception err);

        // Event Handler
        abstract public event MsgEventHandler OnMsg;

        abstract public event ErrorEventHandler OnError;
    }
}
