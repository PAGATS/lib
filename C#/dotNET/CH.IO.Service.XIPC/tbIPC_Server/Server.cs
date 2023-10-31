using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CH.IO.Comm;
using CH.IO.Service;
using CH.Diagnostics;
using tbSharedMemory;

namespace tbIPC_Server
{
    public partial class Server : Form
    {
        CHSock sock = null;
        USART serial = null;
        IPC ipc = null;        
        Debug dbg = new Debug("IPC");

        AS5216ServerMemory sm = new AS5216ServerMemory();

        public class SharedMemory
        {
            public string memo = "";
            public double[] data = new double[2048];
        }

        public Server()
        {
            InitializeComponent();
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

        private void Server_Load(object sender, EventArgs e)
        {
            /*
            USART.CONFIG config_usart = new USART.CONFIG();
            config_usart.PortName = "COM4";
            config_usart.BaudRate = "921600";
            serial = new USART();
            serial.Open(config_usart);
            */

            byte[] pTest = StringToAscii("<?xml version");

            CHSock.CONFIG config_sock = new CHSock.CONFIG();
            config_sock.isServer = true;
            config_sock.port = 50000;
            config_sock.rxBufSize = 1024 * 1024;
            config_sock.txBufSize = 1024 * 1024;
            sock = new CHSock();
            sock.Open(config_sock);

            IPC.CONFIG config_ipc = new IPC.CONFIG();
            config_ipc.type = typeof(AS5216ServerMemory);

            ipc = new IPC();
            ipc.OnMsg += new INTERFACE.MsgEventHandler(ipc_OnMsg);
            ipc.OnError += new INTERFACE.ErrorEventHandler(ipc_OnError);

            //ipc.Connect(serial, config_ipc);
            ipc.Connect(sock, config_ipc);

            UIWorker.RunWorkerAsync();
        }

        void ipc_OnError(object sender, string source, Exception err)
        {
            dbg.Out = "[Server:" + source + "] " + err.Message;
        }

        void ipc_OnMsg(object sender, string type, object msg)
        {
            dbg.Out = "IPC type:" + type;
            if (type == typeof(AS5216ServerMemory).FullName)
            {
                sm = (AS5216ServerMemory)msg;
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            ipc.Disconnect();
            sock.Close();
            bUIWorker = false;
        }

        bool bUIWorker = true;
        private void UIWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (bUIWorker)
            {
                UIWorker.ReportProgress(0);
                System.Threading.Thread.Sleep(50);
            }
        }

        private void UIWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (null != sm)
            {
                tbMsg.Text = sm.Address;
            }
        }
    }
}
