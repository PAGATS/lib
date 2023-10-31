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
            public bool bChart = false;

            public bool bDebugOut = true;
            public bool bDebugLog = true;

            public bool bTopMost = false;
            public double fTransparency = 100;

            public int nSpectrumLength = 2048;

            public string strIpcChannelName = "AS5216Server";

            public float fIntegrationTime = 10.0F;
            public uint nNrAverages = 3;
            public byte CorDynDark = 100;

            public int nUIWorkerTime = 100;
            public int nMountWorkerTime = 250;
        }

        public class UserInterface
        {
            public string strMsg = "";
            public string strBoot = "";
            public string strError = "";
            public int nProgress = 0;

            public int nSeriesCount = 0;
            public Series[] series = null;
            public double[][] pfYSeries = null;
            public string[] strXAxis = null;
        }

        class VARIABLES
        {
            public string strTitle = "";
            public DateTime DateTimeRun = DateTime.Now;
            public CONFIG config = new CONFIG();                
            public UserInterface ui = new UserInterface();

            public Queue<double[]>[] pqSpectrum = null;

            public bool bUIWorker = true;
            public ManualResetEvent evUIWorker = new ManualResetEvent(false);

            public bool bMountWorker = true;
            public ManualResetEvent evMountWorker = new ManualResetEvent(false);

            public IntPtr pUIHandle = new IntPtr();

            public IPC ipc = new IPC();

            public int nAvsCount = 0;
            public AS5216.AvsIdentityType[] avst = null;
            public AS5216[] avs = null;
            public AS5216.CONFIG avs_config = null;

            public bool bWatchDogWakeup = false;
            public int nWatchDogCount = 0;
            public double fWatchDogFood = 0;

            public AS5216Data sharedAS5216Data = null;
            public AS5216Command sharedAS5216Cmd = null;
            public AS5216Response sharedAS5216Res = null;
        }

        VARIABLES g;
        Debug d = new Debug("AS5216Server");
    }
}
