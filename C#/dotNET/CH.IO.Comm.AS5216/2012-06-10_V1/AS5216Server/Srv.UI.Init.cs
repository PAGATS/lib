using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AS5216Server
{
    public partial class UI : Form
    {
        private void UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                MSG("<UI_FormClosing>");
                Final();
            }
            catch (System.Exception ex)
            {
                Error("UI_FormClosing", ex);
            }
        }

        private void UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                MSG("<UI_FormClosed>");
                MSG("===============================================");
            }
            catch (System.Exception ex)
            {
                Error("UI_FormClosed", ex);
            }
        }

        void InitVariable()
        {
            try
            {                
                MSG("<InitVariable>");
                g.ui.nProgress = 3;
                g.config = new CONFIG();
                
            }
            catch (System.Exception ex)
            {
                Error("InitVariable", ex);
            }
        }

        void FinalVariable()
        {
            try
            {
                MSG("<FinalVariable>");
            }
            catch (System.Exception ex)
            {
                Error("FinalVariable", ex);
            }
        }

        void InitSystem()
        {
            try
            {
                MSG("<InitSystem>");
                g.ui.nProgress = 4;
                ReadXML();

                ConnectIPC();

                this.TopMost = g.config.bTopMost;
                this.Opacity = g.config.fTransparency;

                g.bUIWorker = true;
                UIWorker.RunWorkerAsync();
                g.bMountWorker = true;
                MountWorker.RunWorkerAsync();
            }
            catch (System.Exception ex)
            {
                Error("InitSystem", ex);
            }
        }

        void FinalSystem()
        {
            try
            {
                MSG("<FinalSystem>");

                g.bMountWorker = false;
                g.evMountWorker.WaitOne(300);

                g.bUIWorker = false;
                g.evUIWorker.WaitOne(300);

                DisconnectIPC();

                WriteXML();
            }
            catch (System.Exception ex)
            {
                Error("FinalSystem", ex);
            }
        }        

        void Init()
        {
            try
            {
                MSG("<Init>");
                g.ui.nProgress = 2;
                InitVariable();
                InitSystem();
            }
            catch (System.Exception ex)
            {
                Error("Init", ex);
            }
        }

        void Final()
        {
            try
            {
                MSG("<Final>");
                FinalSystem();
                FinalVariable();
            }
            catch (System.Exception ex)
            {
                Error("Final", ex);
            }
        }
    }
}
