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

namespace AS5216Server
{
    public partial class UI : Form
    {
        private void AvantesUSB_Mount()
        {
            try
            {
                BOOT("<AvantesUSB_Mount>");
                g.evMountWorker.Reset();
                
                g.ui.nProgress = 5;
                g.avst = AS5216.Mount(g.pUIHandle);
                g.nAvsCount = g.avst.Length;

                g.ui.nProgress = 6;
                g.pqSpectrum = new Queue<double[]>[g.nAvsCount];
                g.avs = new AS5216[g.nAvsCount];

                g.sharedAS5216Data.DeviceCount = g.nAvsCount;
                g.sharedAS5216Data.SerialNumber = new string[g.sharedAS5216Data.DeviceCount];
                g.sharedAS5216Data.NumPixels = new ushort[g.sharedAS5216Data.DeviceCount];
                g.sharedAS5216Data.Wavelength = new double[g.sharedAS5216Data.DeviceCount][];
                g.sharedAS5216Data.Spectrum = new double[g.sharedAS5216Data.DeviceCount][];
                                    
                g.ui.pfYSeries = new double[g.nAvsCount][];
                g.ui.series = new Series[g.nAvsCount];

                g.avs_config = new AS5216.CONFIG();                
                g.avs_config.MeasurementType = AS5216.GetDefaultMeasureConfigType;
                g.avs_config.MeasurementType.IntegrationTime = g.config.fIntegrationTime;
                g.avs_config.MeasurementType.NrAverages = g.config.nNrAverages;
                g.avs_config.MeasurementType.CorDynDark.Enable = g.config.CorDynDark;

                for (int i = 0; i < g.nAvsCount; i++)
                {                    
                    ConnectAS5216(i); // index is a avantes object number.             

                    g.pqSpectrum[i] = new Queue<double[]>();                    
                    g.sharedAS5216Data.NumPixels[i] = g.avs[i].GetNumPixels;
                    g.sharedAS5216Data.SerialNumber[i] = g.avst[i].SerialNumber;
                    g.sharedAS5216Data.Wavelength[i] = g.avs[i].GetLambda;

                    g.ui.series[i] = new Series();
                    g.ui.series[i].ChartArea = "ChartArea1";
                    g.ui.series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    g.ui.series[i].Legend = "Legend1";
                    g.ui.series[i].Name = "[" + i + "] " + g.avst[i].UserFriendlyName;

                }

                g.ui.nSeriesCount = g.nAvsCount;
                
                g.ui.nProgress = 8;
            }
            catch (System.Exception ex)
            {
                Error("AvantesUSB_Mount", ex);
            }
        }

        private void AvantesUSB_Unmount()
        {
            try
            {
                BOOT("<AvantesUSB_Unmount>");
                for (int i = 0; i < g.nAvsCount; i++)
                {
                    DisconnectAS5216(i);
                }
                AS5216.Unmount();
                 
                g.evMountWorker.Set();
            }
            catch (System.Exception ex)
            {
                Error("AvantesUSB_Unmount", ex);
            }
        }

        private void GetAvantesInfo()
        {
            try
            {
                BOOT("<GetAvantesInfo>");
                if(null != g.avs)
                {
                    for (int i = 0; i < g.nAvsCount; i++)
                    {
                        AS5216.VERSION_INFO info = g.avs[i].GetVersionInfo;
                        ushort pixelcnt = g.avs[i].GetNumPixels;
                        double[] lambda = g.avs[i].GetLambda;
                        AS5216.DeviceConfigType devType = g.avs[i].GetParameter;
                        string sensorType = g.avs[i].GetSensorType;
                    }
                }                
            }
            catch (System.Exception ex)
            {
                Error("GetAvantesInfo", ex);
            }
        }

        void WatchDog()
        {
            try
            {
                if (true == g.bWatchDogWakeup)
                {
                    if(null != g.sharedAS5216Data.Spectrum[0])
                    {
                        if(g.fWatchDogFood == g.sharedAS5216Data.Spectrum[0][0])
                        {
                            g.nWatchDogCount++;
                        }
                        else
                        {
                            g.fWatchDogFood = g.sharedAS5216Data.Spectrum[0][0];
                            g.nWatchDogCount = 0;
                        }

                        if ((g.config.fIntegrationTime * g.config.nNrAverages / g.config.nMountWorkerTime * 10) <= g.nWatchDogCount)
                        {
                            g.sharedAS5216Res.IsRun = false;
                            for (int i = 0; i < g.nAvsCount; i++)
                            {
                                if (g.bWatchDogWakeup)
                                {
                                    DisconnectAS5216(i);
                                    Thread.Sleep(g.config.nMountWorkerTime);
                                    ConnectAS5216(i);
                                    Thread.Sleep(g.config.nMountWorkerTime);
                                }
                            }
                            Error("WatchDog", new Exception("BowWow! " + DateTime.Now.ToString("yyyy-MM-dd, hh:mm:ss")));
                            g.nWatchDogCount = 0;
                        }
                    }                    
                }
                else
                {
                    g.nWatchDogCount = 0;
                }
            }
            catch (System.Exception ex)
            {
                Error("WatchDog", ex);
            }
        }

        private void MountWorker_DoWork(object sender, DoWorkEventArgs e)
        {            
            AvantesUSB_Mount();
            g.sharedAS5216Res.IsRun = true;
            g.bWatchDogWakeup = true;
            MountWorker.ReportProgress(1);
            while(true == g.bMountWorker)
            {
                try
                {
                    ParseCommand();
                    WatchDog();
                    Thread.Sleep(g.config.nMountWorkerTime);
                }
                catch (System.Exception ex)
                {
                    Error("MountWorker_DoWork", ex);
                }
            }
            g.bWatchDogWakeup = false;      
            AvantesUSB_Unmount();
            g.sharedAS5216Res.IsRun = false;
        }


        private void MountWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                switch (e.ProgressPercentage)
                {
                    case 1:
                        {
                            for (int i = 0; i < g.ui.series.Length ; i++)
                            {
                                ChartSpectrum.Series.Add(g.ui.series[i]);
                            }

                            ChartSpectrum.ChartAreas[0].AxisX.Interval = 100;
                            ChartSpectrum.ChartAreas[0].AxisX.Title = "Wavelength [nm]";
                            ChartSpectrum.ChartAreas[0].AxisY.Title = "AU";

                            int nCount = g.sharedAS5216Data.Wavelength[0].Length;
                            g.ui.strXAxis = new string[nCount];
                            for (int i = 0; i < nCount; i++)
                            {
                                g.ui.strXAxis[i] = g.sharedAS5216Data.Wavelength[0][i].ToString("0");
                            }

                            BootComplete();
                        }
                        break;
                }
            }
            catch (System.Exception ex)
            {
                Error("MountWorker_ProgressChanged", ex);
            }
        }
    }
}
