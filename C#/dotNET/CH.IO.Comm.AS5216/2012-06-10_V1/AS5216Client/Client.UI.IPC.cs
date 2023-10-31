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

namespace AS5216Client
{
    public partial class UIClient : Form
    {
        void ConnectIPC()
        {
            try
            {
                CHSock.CONFIG s_config = new CHSock.CONFIG();
                s_config.isServer = false; // client
                s_config.ip = g.config.strIPC_IP;
                s_config.port = g.config.nIPC_Port;
                g.sock.Open(s_config);

                IPC.CONFIG i_config = new IPC.CONFIG();
                i_config.type = typeof(AS5216ServerMemory);

                g.ipc.OnMsg += new INTERFACE.MsgEventHandler(ipc_OnMsg);
                g.ipc.OnError += new INTERFACE.ErrorEventHandler(ipc_Onerror);
                g.ipc.Connect(g.sock, i_config);
            }
            catch (System.Exception ex)
            {
                error("ConnectIPC", ex);
            }
        }

        void ipc_Onerror(object sender, string source, Exception err)
        {
            try
            {
                error(source, err);
            }
            catch (System.Exception ex)
            {
                error("ipc_Onerror", ex);
            }
        }

        void ipc_OnMsg(object sender, string type, object msg)
        {
            try
            {
                d.Out = type;
                if (type == typeof(AS5216ServerMemory).FullName)
                {
                    AS5216ServerMemory sm = (AS5216ServerMemory)msg;
                    switch (sm.Address)
                    {
                        case "Lamda":
                            {
                                g.ui.strXAxis = new string[sm.Spectrum.Length];
                                for (int i = 0; i < sm.Spectrum.Length; i++)
                                {
                                    g.ui.strXAxis[i] = sm.Spectrum[i].ToString("0");
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
                            d.Out = "Connected";
                        }
                        return;
                    case "DISCONNECTED":
                        {
                            d.Out = "Disconnected";
                            ConnectIPC();
                        }
                        return;
                }
            }
            catch (System.Exception ex)
            {
                error("ipc_OnMsg", ex);
            }
        }

        void DisconnectIPC()
        {
            try
            {
                g.ipc.Disconnect();
                g.sock.Close();
                g.sock = new CHSock();
                g.ipc = new IPC();
            }
            catch (System.Exception ex)
            {
                error("DisconnectIPC", ex);
            }
        }
    }
}
