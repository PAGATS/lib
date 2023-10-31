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
using CH.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace AS5216Client
{
    public partial class UIClient : Form
    {
        public UIClient()
        {
            InitializeComponent();
        }

        private void UIClient_Load(object sender, EventArgs e)
        {
            d.Out = "UIClient_Load";
            g = new VARIABLES();
            ConnectIPC();

            g.chartSeries = new Series[g.sharedAS5216Data.DeviceCount];
            for (int i = 0; i < g.chartSeries.Length; i++)
            {
                g.chartSeries[i] = new Series();

                g.chartSeries[i].ChartArea = "ChartArea1";
                g.chartSeries[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                g.chartSeries[i].Legend = "Legend1";
                g.chartSeries[i].Name = g.sharedAS5216Data.SerialNumber[i];
                chartSpectrum.Series.Add(g.chartSeries[i]);
            }
            UIWorker.RunWorkerAsync();
        }

        private void UIClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            g.bUIWorker = false;
        }

        private void UIClient_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void UIWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (g.bUIWorker)
            {
                UIWorker.ReportProgress(0);
                Thread.Sleep(200);
            }
        }

        private void UIWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            d.Out = "g.sharedAS5216Res.IsRun =" + g.sharedAS5216Res.IsRun;

            for (int i = 0; i < g.sharedAS5216Data.DeviceCount; i++)
            {
                chartSpectrum.Series[i].Points.DataBindXY(g.ui.strXAxis, g.sharedAS5216Data.Spectrum[i]);
            }            
        }

        private void btSendCmd_Click(object sender, EventArgs e)
        {
            try
            {
                g.sharedAS5216cmd.Command = tbCmd.Text;
            }
            catch (System.Exception ex)
            {
            	
            }
        }

        private string SendCmd(string cmd)
        {
            string result = "Not response";
            g.sharedAS5216cmd.Command = cmd;

            for (int i = 0; i < 20; i++)
            {
                if (cmd + " OK" == g.sharedAS5216Res.Response)
                {
                    result = DateTime.Now.ToString("yyyy-MM-dd, hh:mm:ss.ffffff") + " / " + cmd + " OK";
                    break;
                }
                Thread.Sleep(100);
            }
            return result;            
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = "";
                string rst = "";
                string msg = DateTime.Now.ToString("yyyy-MM-dd, hh:mm:ss.ffffff") + " / Start Test\r\n";

                for (int itg = 3; itg < 10; itg++)
                {
                    for (int noa = 1; noa < 2; noa++)
                    {
                        cmd = "IntegrationTime " + itg;
                        rst = SendCmd(cmd);
                        if (rst.Contains("Not response"))
                        {
                            tbMsg.Text = msg;
                            return;
                        }                            
                        msg += rst + "\r\n";

                        cmd = "NumberOfAverage " + noa;
                        rst = SendCmd(cmd);
                        if (rst.Contains("Not response"))
                        {
                            tbMsg.Text = msg;
                            return;
                        }
                        msg += rst + "\r\n";

                        cmd = "IOCTRL";
                        rst = SendCmd(cmd);
                        if (rst.Contains("Not response"))
                        {
                            tbMsg.Text = msg;
                            return;
                        }
                        msg += rst + "\r\n";

                        tbMsg.Text = msg;

                        Thread.Sleep(itg * noa + 2000);
                    }
                }

                tbMsg.Text = msg;
            }
            catch (System.Exception ex)
            {
            	
            }
        }
    }
}
