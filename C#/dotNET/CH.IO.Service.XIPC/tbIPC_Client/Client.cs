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
using System.Threading;

using tbSharedMemory;

namespace tbIPC_Client
{
    public partial class Client : Form
    {
        USART serial = null;
        CHSock sock = null;
        IPC ipc = null;
        Debug dbg = new Debug("IPC");

        AS5216ServerMemory sm = new AS5216ServerMemory();

        public class SharedMemory
        {
            public string memo = "";
            public double[] data = new double[2048];
        }
        public Client()
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

        private void Client_Load(object sender, EventArgs e)
        {
            /*
            USART.CONFIG config_usart = new USART.CONFIG();
            config_usart.PortName = "COM3";
            config_usart.BaudRate = "921600";
            serial = new USART();
            serial.Open(config_usart);
            */
            byte[] pTest = StringToAscii("<?xml version");

            int ia = int.MaxValue;

            ulong i = ulong.Parse("9876543210987654321");

            //string str = string.Format("{0:00000000000}", 123);
            //str = "<?xml size=0000000000000000000";
            //ulong ia = int.MaxValue;

            CHSock.CONFIG config_sock = new CHSock.CONFIG();
            config_sock.isServer = true;
            config_sock.ip = "127.0.0.1";
            config_sock.port = 50000;
            config_sock.rxBufSize = 30000;
            config_sock.txBufSize = 30000;
            sock = new CHSock();
            sock.Open(config_sock);


            IPC.CONFIG config_ipc = new IPC.CONFIG();
            sm.Address = "Spectrum";
            sm.SerialNumber = "120765E1";

            config_ipc.type = typeof(AS5216ServerMemory);
            ipc = new IPC();
            ipc.OnMsg += new INTERFACE.MsgEventHandler(ipc_OnMsg);
            ipc.OnError += new INTERFACE.ErrorEventHandler(ipc_OnError);

            //ipc.Connect(serial, config_ipc);
            ipc.Connect(sock, config_ipc);

            ComWorker.RunWorkerAsync();

        }

        void ipc_OnError(object sender, string source, Exception err)
        {
            dbg.Out = "[Client:" + source + "] " + err.Message;
        }

        void ipc_OnMsg(object sender, string type, object msg)
        {
            if (type == typeof(AS5216ServerMemory).FullName)
            {
                sm = (AS5216ServerMemory)msg;
                tbMsg.Text = sm.SerialNumber;
                dbg.Out = "[ThRx] " + sm.SerialNumber;
                dbg.Out = "[ThRx] " + sm.Index;
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            bComWorker = false;
            ipc.Disconnect();
            sock.Close();
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            //sm.Address = tbMsg.Text;
            //ipc.Send(typeof(AS5216ServerMemory), sm);
            Thread.Sleep(5000);
        }

        int nTemp = 0;
        bool bComWorker = true;
        ManualResetEvent evComWorker = new ManualResetEvent(false);
        private void ComWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while(bComWorker)
            {
                nTemp++;
                sm.Address = nTemp.ToString();
                ComWorker.ReportProgress(0);
                Thread.Sleep(500);
            }
            evComWorker.Set();
        }

        private void ComWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                //ipc.Send(typeof(AS5216ServerMemory), sm);

            }
            catch (System.Exception ex)
            {
                dbg.Out = ex.Message;
            }
            
        }
    }
}
