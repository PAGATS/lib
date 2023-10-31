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
                IPC.CONFIG config = new IPC.CONFIG();

                config.ChannelName = "AS5216Server";
                config.IsServer = false;
                config.IsSecurityChannel = false;

                g.ipc = new IPC();
                g.ipc.Connect(null, config);
                g.ipc.Send(typeof(AS5216Data), null);
                g.sharedAS5216Data = new AS5216Data();
                g.ipc.Send(typeof(AS5216Command), null);
                g.sharedAS5216cmd = new AS5216Command();
                g.ipc.Send(typeof(AS5216Response), null);
                g.sharedAS5216Res = new AS5216Response();

                g.sharedAS5216Res.IsRun = false;
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
                g.ipc = new IPC();
            }
            catch (System.Exception ex)
            {
                error("DisconnectIPC", ex);
            }
        }
    }
}
