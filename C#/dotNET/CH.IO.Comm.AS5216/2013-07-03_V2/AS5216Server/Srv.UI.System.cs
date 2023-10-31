using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CH.XML;

namespace AS5216Server
{
    public partial class UI : Form
    {
        void BootComplete()
        {
            try
            {
                lbServerStatusIndicator.BackColor = Color.Lime;
                lbServerStatusIndicator.Text = "Server is OK";
                g.sharedAS5216Res.IsRun = true;
            }
            catch (System.Exception ex)
            {
                Error("BootComplete", ex);
            }
        }

        void InitUI(CONFIG config)
        {
            try
            {
                if (true == config.bChart)
                {
                    btDisplay.Text = "Display OFF";
                }
                else
                {
                    btDisplay.Text = "Display ON";
                }

                if (true == config.bTopMost)
                {
                    btTopMost.Text = "TopMost OFF";
                }
                else
                {
                    btTopMost.Text = "ToMost ON";
                }

                UpdateAvantesInfo();
            }
            catch (System.Exception ex)
            {
                Error("InitUI", ex);
            }
        }

        void UpdateAvantesInfo()
        {
            try
            {
                if (null != g.avs_config)
                {
                    tbAvantesInfo.Text = "Integration Time: " + g.avs_config.MeasurementType.IntegrationTime + " msec" + "\r\n" +
                                     "Integration Delay: " + g.avs_config.MeasurementType.IntegrationDelay + " msec" + "\r\n" +
                                     "Number of Average: " + g.avs_config.MeasurementType.NrAverages + "\r\n" +
                                     "Correction of DynDarkCur: " + g.avs_config.MeasurementType.CorDynDark.ForgetPercentage + "%\r\n" +
                                     "Watchdog Time: " + g.avs_config.MeasurementType.IntegrationTime * g.avs_config.MeasurementType.NrAverages * 10 + " msec" + "\r\n";
                    TimeSpan diff = DateTime.Now - g.DateTimeRun;
                    this.Text = g.strTitle + ", [ELPAS: " + diff.ToString(@"dd\.hh\:mm\:ss");
                }
            }
            catch (System.Exception ex)
            {
                Error("UpdateAvantesInfo", ex);
            }
        }

        void ReadXML()
        {
            try
            {
                Registry.TryToRead<CONFIG>(@".\AS5216Server.cfg", ref g.config);
                InitUI(g.config);

            }
            catch (System.Exception ex)
            {
                Error("ReadXML", ex);
            }
        }

        void WriteXML()
        {
            try
            {
                Registry.Write<CONFIG>(@".\AS5216Server.cfg", g.config);
            }
            catch (System.Exception ex)
            {
                Error("WriteXML", ex);
            }
        }

        void UpdateInfo()
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                Error("UpdateInfo", ex);
            }
        }
    }
}
