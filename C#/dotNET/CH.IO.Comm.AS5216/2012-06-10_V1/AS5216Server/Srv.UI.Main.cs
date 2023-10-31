using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CH.IO.Comm;

namespace AS5216Server
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
            d.Out = "===============================================";
            lbBoot.Text = GetBuildInformation() + "], [Run: " + DateTime.Now.ToString() + "]";// "Version: 1.12.0917.1";
            this.Text = "AS5216 Server [" + lbBoot.Text + "]";
            d.Out = "Name: " + this.Text;
            d.Out = "Designer: il-hyung Shin";
            d.Out = "Last update " + lbBoot.Text;
            d.Out = "===============================================";
            
            g = new VARIABLES();            
            g.ui.nProgress = 0;
        }

        private string GetBuildInformation()
        {
            System.Version Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            DateTime BuildDate = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).LastWriteTime;
            return string.Format("Build: {0}", BuildDate);
        }

        private void UI_Load(object sender, EventArgs e)
        {
            try
            {
                MSG("<UI_Load>");
                g.ui.nProgress = 1;
                Init();

            }
            catch (System.Exception ex)
            {
                Error("UI_Load", ex);
            }
        }       
    }
}
