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

namespace AS5216Server
{
    public partial class UI : Form
    {
        private void UIWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            g.evUIWorker.Reset();
            while(true == g.bUIWorker)
            {
                UIWorker.ReportProgress(0);
                Thread.Sleep(g.config.nUIWorkerTime);
            }
            g.evUIWorker.Set();
        }

        private void UIWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                lbBoot.Text = g.ui.strBoot;
                lbMsg.Text = g.ui.strMsg;
                lbError.Text = g.ui.strError;
                pbBoot.Value = g.ui.nProgress;

                for (int i = 0; i < g.ui.nSeriesCount; i++)
                {
                    int nCount = g.pqSpectrum[i].Count;
                    if (0 < nCount)
                    {
                        nCount--;
                        for (int j = 0; j < nCount; j++)
                        {
                            g.pqSpectrum[i].Dequeue();
                        }

                        if (true == g.config.bChart)
                        {
                            ChartSpectrum.Series[i].Points.DataBindXY(g.ui.strXAxis, g.pqSpectrum[i].Dequeue());
                        }

                        UpdateAvantesInfo();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Error("UIWorker_ProgressChanged", ex);
            }
        }
    }
}
