using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using CH.IO.Comm;

namespace AS5216Server
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
            try
            {
                g = new VARIABLES();
                g.DateTimeRun = DateTime.Now;
                g.strTitle = "[" + GetBuildInformation() + "], [Run: " + g.DateTimeRun.ToString() + "]";// "Version: 1.12.0917.1";

                d.Out = "===============================================";
                lbBoot.Text = g.strTitle;
                g.strTitle = "AS5216 Server " + g.strTitle;
                this.Text = g.strTitle;
                d.Out = "Name: " + this.Text;
                d.Out = "Designer: il-hyung Shin";
                d.Out = "Last update " + lbBoot.Text;
                d.Out = "===============================================";
               
                g.ui.nProgress = 0;
            }
            catch (System.Exception ex)
            {
                Error("UI", ex);
            }            
        }

        private string GetBuildInformation()
        {
            try
            {
                System.Version Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
                DateTime BuildDate = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).LastWriteTime;
                return string.Format("Build: {0}", BuildDate);
            }
            catch (System.Exception ex)
            {
                Error("GetBuildInformation", ex);
            }
            return "";
        }

        private void UI_Load(object sender, EventArgs e)
        {
            try
            {
                BOOT("<UI_Load>");
                Tray.ContextMenuStrip = contextMenuStrip;
                g.ui.nProgress = 1;
                Init();

            }
            catch (System.Exception ex)
            {
                Error("UI_Load", ex);
            }
        }

        private void btDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                if ("Display ON" == btDisplay.Text)
                {
                    btDisplay.Text = "Display OFF";
                    g.config.bChart = true;
                }
                else
                {
                    btDisplay.Text = "Display ON";
                    g.config.bChart = false;
                }
            }
            catch (System.Exception ex)
            {
                Error("btDisplay_Click", ex);
            }
        }

        private void btTopMost_Click(object sender, EventArgs e)
        {
            try
            {
                if ("TopMost ON" == btTopMost.Text)
                {
                    btTopMost.Text = "TopMost OFF";
                    this.TopMost = g.config.bTopMost = true;
                }
                else
                {
                    btTopMost.Text = "TopMost ON";
                    this.TopMost = g.config.bTopMost = false;
                }
            }
            catch (System.Exception ex)
            {
                Error("btTopMost_Click", ex);
            }
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            /*
            g.bWatchDogWakeup = false;
            g.avs_config.MeasurementType.IntegrationTime = 1000;
            g.avs_config.MeasurementType.NrAverages = 1;

            g.avs[0].StopMeasurement();
            g.avs[0].PrepareMeasure(g.avs_config.MeasurementType);
            g.avs[0].Measure(0);

            g.avs[1].StopMeasurement();
            g.avs[1].PrepareMeasure(g.avs_config.MeasurementType);
            g.avs[1].Measure(0);
            //g.bWatchDogWakeup = true;
             */
            this.WindowState = FormWindowState.Minimized;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Visible = true;
            }
            catch (System.Exception ex)
            {
                Error("showToolStripMenuItem_Click", ex);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (System.Exception ex)
            {
                Error("exitToolStripMenuItem_Click", ex);
            }
        }

        private void UI_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                //MessageBox.Show("보통상태");
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                //MessageBox.Show("최대창");
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.Hide();
                //MessageBox.Show("최소창");
            }
        }
    }
}
