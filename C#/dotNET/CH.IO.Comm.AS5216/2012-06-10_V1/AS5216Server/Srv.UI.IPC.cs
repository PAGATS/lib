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

namespace AS5216Server
{
    public partial class UI : Form
    {
        void ConnectIPC()
        {
            try
            {
                CHSock.CONFIG s_config = new CHSock.CONFIG();
                s_config.isServer = g.config.bServerMode;
                s_config.ip = g.config.strIPC_IP;
                s_config.port = g.config.nIPC_Port;
                s_config.rxBufSize = 2 * 1024 * 2024;
                s_config.txBufSize = 2 * 1024 * 2024;

                if(null != g.sock)
                {
                    g.sock.Close();
                }
                g.sock = new CHSock();
                g.sock.Open(s_config);

                IPC.CONFIG i_config = new IPC.CONFIG();
                i_config.type = typeof(AS5216ServerMemory);
                if(null != g.ipc)
                {
                    g.ipc.Disconnect();
                }

                g.ipc = new IPC();
                g.ipc.OnMsg += new INTERFACE.MsgEventHandler(ipc_OnMsg);
                g.ipc.OnError += new INTERFACE.ErrorEventHandler(ipc_OnError);
                g.ipc.Connect(g.sock, i_config);
            }
            catch (System.Exception ex)
            {
                Error("ConnectIPC", ex);
            }
        }

        void ipc_OnError(object sender, string source, Exception err)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                Error("ipc_OnError", ex);
            }
        }

        void ipc_OnMsg(object sender, string type, object msg)
        {
            try
            {
                if (type == typeof(AS5216ServerMemory).FullName)
                {                    
                    AS5216ServerMemory sm = (AS5216ServerMemory)msg;
                    switch (sm.Address)
                    {
                        case "Lamda":
                            {
                                for (int i = 0; i < g.nAvsCount; i++)
                                {
                                    g.SharedMemory[i].Tick(0);
                                    g.SharedMemory[i].Address = "Lamda";
                                    g.SharedMemory[i].Offset = i;
                                    g.SharedMemory[i].Spectrum = g.avs[i].GetLambda;
                                    g.ipc.Send(typeof(AS5216ServerMemory), g.SharedMemory[i]);
                                    lbMsg.Text = "Sent Lamda[" + i + "]";
                                }
                            }
                            return;
                        case "Spectrum":
                            {
                                for (int i = 0; i < g.ui.nSeriesCount; i++)
                                {
                                    if (false == g.config.bContinuousMode)
                                    {
                                        if (g.avst[i].SerialNumber == sm.SerialNumber)
                                        {
                                            g.ipc.Send(typeof(AS5216ServerMemory), g.SharedMemory[i]);
                                            lbMsg.Text = "Sent Spectrum[" + i + "]";
                                        }
                                    }
                                }
                            }
                            return;
                    }
                    return;
                }

                switch (type)
                {
                    case "CONNECTED":
                        {
                            lbMsg.Text = "IPC Connected.";
                        }
                        return;
                    case "DISCONNECTED":
                        {
                            lbMsg.Text = "IPC Disconnected.";
                            ConnectIPC();
                        }
                        return;
                }
            }
            catch (System.Exception ex)
            {
                Error("ipc_OnMsg", ex);
            }
        }

        void DisconnectIPC()
        {
            try
            {
                g.ipc.Disconnect();
                g.sock.Close();
                g.sock = null;
                g.ipc = null;
            }
            catch (System.Exception ex)
            {
                Error("DisconnectIPC", ex);
            }
        }
    }
}
