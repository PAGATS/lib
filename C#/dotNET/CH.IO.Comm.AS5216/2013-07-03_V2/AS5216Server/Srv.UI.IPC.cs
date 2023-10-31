using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using CH.IO.Comm;
using CH.IO.Service;

namespace AS5216Server
{
    public partial class UI : Form
    {
        // WorkerMount에서 호출함.
        void ParseCommand()
        {
            try
            {
                int nCmdCnt = 0;
                if (0 < (nCmdCnt = g.sharedAS5216Cmd.Count))
                {
                    for (int i = 0; i < nCmdCnt; i++)
                    {
                        string strMsg = g.ui.strMsg = g.sharedAS5216Cmd.Command;
                        ProcessCommand(strMsg.Split(' '));
                    }
                }
            }
            catch (System.Exception ex)
            {
                Error("ParseCommand", ex);
            }
        }

        void ProcessCommand(string[] arg)
        {
            try
            {
                g.nWatchDogCount = 0;
                switch (arg[0])
                {
                    case AS5216Enum.IOCTRL:
                        {
                            foreach (AS5216 avs in g.avs)
                            {
                                avs.IOCtrl("config", g.avs_config.MeasurementType);
                            }
                            Thread.Sleep(1000);
                            g.sharedAS5216Res.Response = arg[0] + " " + "OK";
                        }
                        break;
                    case AS5216Enum.IntegrationTime:
                        {
                            foreach (AS5216 avs in g.avs)
                            {                                
                                g.avs_config.MeasurementType.IntegrationTime = g.config.fIntegrationTime = float.Parse(arg[1]);
                            }
                            g.sharedAS5216Res.Response = arg[0] + " " + arg[1] + " " + "OK";
                        }
                        break;
                    case AS5216Enum.IntegrationDelay:
                        {

                        }
                        break;
                    case AS5216Enum.NumberOfAverage:
                        {
                            foreach (AS5216 avs in g.avs)
                            {
                                g.avs_config.MeasurementType.NrAverages = g.config.nNrAverages = uint.Parse(arg[1]);
                            }
                            g.sharedAS5216Res.Response = arg[0] + " " + arg[1] + " " + "OK";
                        }
                        break;
                    case AS5216Enum.DynamicDarkCorrection:
                        {

                        }
                        break;
                    case AS5216Enum.Smoothing:
                        {

                        }
                        break;
                    case AS5216Enum.SaturationDetection:
                        {

                        }
                        break;
                    case AS5216Enum.TriggerType:
                        {

                        }
                        break;
                    case AS5216Enum.DisplayChart:
                        {
                            switch (arg[1])
                            {
                                case "1":
                                    {
                                        g.config.bChart = true;
                                    }
                                    break;

                                case "0":
                                    {
                                        g.config.bChart = false;
                                    }
                                    break;
                            }
                        }
                        break;
                    case AS5216Enum.TopMost:
                        {
                            switch (arg[1])
                            {
                                case "1":
                                    {
                                        this.TopMost = g.config.bTopMost = true;
                                    }
                                    break;

                                case "0":
                                    {
                                        this.TopMost = g.config.bTopMost = false;
                                    }
                                    break;
                            }
                        }
                        break;
                    case AS5216Enum.Close:
                        {
                            this.Close();
                        }
                        break;
                }
            }
            catch (System.Exception ex)
            {
                g.sharedAS5216Res.Response = arg[0] + " " + arg[1] + " " + "ERROR";
                Error("ProcessCommand", ex);
            }
            finally
            {
                g.nWatchDogCount = 0;
                UpdateAvantesInfo();
            }
        }

        void ConnectIPC()
        {
            try
            {
                IPC.CONFIG config = new IPC.CONFIG();

                config.ChannelName = g.config.strIpcChannelName;
                config.IsServer = true;
                config.IsSecurityChannel = false;
                
                g.ipc.Connect(null, config);

                g.ipc.Send(typeof(AS5216Data), null);
                g.sharedAS5216Data = new AS5216Data();

                g.ipc.Send(typeof(AS5216Command), null);
                g.sharedAS5216Cmd = new AS5216Command();

                g.ipc.Send(typeof(AS5216Response), null);
                g.sharedAS5216Res = new AS5216Response();                

                g.ui.strMsg = "IPC Connected.";
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

        void ipc_OnBOOT(object sender, string type, object msg)
        {
            try
            {
                switch (type)
                {
                    case "CONNECTED":
                        {
                            g.ui.strMsg = "IPC Connected.";
                        }
                        return;
                    case "DISCONNECTED":
                        {
                            g.ui.strMsg = "IPC Disconnected.";
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
                g.ipc = null;
            }
            catch (System.Exception ex)
            {
                Error("DisconnectIPC", ex);
            }
        }
    }
}
