using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

using CH.IO.Comm;
using CH.IO.Service;
using CH.Diagnostics;

namespace AS5216Server
{
    public partial class UI : Form
    {
        public class CONFIG
        {
            public bool bChart;

            public bool bDebugOut;
            public bool bDebugLog;

            public bool bTopMost;
            public double fTransparency;

            public bool bContinuousMode;
            public bool bSimulationMode;
            public int nSpectrumLength;

            public bool bServerMode;
            public string strIPC_IP;
            public int nIPC_Port;

            public float fIntegrationTime;
            public uint nNrAverages;

            public int nMountWorkerTime;
            public int nUIWorkerTime;

            public CONFIG()
            {
                bChart = false;

                bDebugOut = true;
                bDebugLog = true;

                bTopMost = false;
                fTransparency = 0;

                bContinuousMode = true;
                bSimulationMode = false;
                nSpectrumLength = 2048;

                bServerMode = false;
                strIPC_IP = "127.0.0.1";
                nIPC_Port = 50000;

                fIntegrationTime = 3.0F;
                nNrAverages = 25;

                nUIWorkerTime = 100;
                nMountWorkerTime = 50;
            }
        }

        public class UserInterface
        {
            public string strMsg = "";
            public int nProgress = 0;

            public int nSeriesCount = 0;
            public Series[] series = null;
            public double[][] pfYSeries = null;
            public string[] strXAxis = null;

            public UserInterface()
            {
                strMsg = "";
                nSeriesCount = 0;
                nProgress = 0;
            }
        }

        class VARIABLES
        {
            public CONFIG config;
            public UserInterface ui;

            public Queue<double[]>[] pqSpectrum = null;

            public bool bUIWorker;
            public ManualResetEvent evUIWorker = null;

            public bool bMountWorker;
            public ManualResetEvent evMountWorker = null;

            public IPC ipc = null;
            public CHSock sock = null;

            public int nAvsCount = 0;
            public AS5216.AvsIdentityType[] avst = null;
            public AS5216[] avs = null;

            public AS5216ServerMemory[] SharedMemory = null;

            public int nWatchDogCount = 0;
            public double fWatchDogFood = 0;

            public VARIABLES()
            {
                config = new CONFIG();
                ui = new UserInterface();

                nAvsCount = 0;

                bUIWorker = true;
                evUIWorker = new ManualResetEvent(false);

                bMountWorker = true;
                evMountWorker = new ManualResetEvent(false);

                nWatchDogCount = 0;
            }
        }
        VARIABLES g;
        Debug d = new Debug("AS5216Server");
    }
}
