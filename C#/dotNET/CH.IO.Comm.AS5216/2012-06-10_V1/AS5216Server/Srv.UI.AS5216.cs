﻿using System;
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
        void ConnectAS5216(int nIndex)
        {
            try
            {
                MSG("<ConnectAS5216>");
                if(false == g.config.bSimulationMode)
                {
                    // Not simulation mode

                    AS5216.CONFIG config = new AS5216.CONFIG();
                    config.IDType = g.avst[nIndex];
                    g.avs[nIndex] = new AS5216();
                    config.MeasurementType = AS5216.GetDefaultMeasureConfigType;
                    config.MeasurementType.IntegrationTime = g.config.fIntegrationTime;
                    config.MeasurementType.NrAverages = g.config.nNrAverages;
                    config.MeasurementType.CorDynDark.Enable = 100;
                    g.avs[nIndex].Open(config);
                }
                else
                {
                    // simulation mode
                }
            }
            catch (System.Exception ex)
            {
                Error("", ex);
            }
        }

        void DisconnectAS5216(int nIndex)
        {
            try
            {
                if(false == g.config.bSimulationMode)
                {
                    // Not simulation mode

                    MSG("<DisconnectAS5216>");
                    g.avs[nIndex].Close();
                    g.avs[nIndex] = null;
                }
                else
                {
                    // simulation mode

                }                
            }
            catch (System.Exception ex)
            {
                Error("", ex);
            }
        }

        protected override void WndProc(ref Message a_WinMess)
        {
            try
            {
                if (a_WinMess.Msg == AS5216.WM_DEVICE_RESET ||
                    a_WinMess.Msg == AS5216.WM_DBG_INFOAs ||
                    a_WinMess.Msg == AS5216.WM_USER
                    )
                {
                    MessageBox.Show(a_WinMess.Msg.ToString());
                }

                if (a_WinMess.Msg == AS5216.WM_MEAS_READY)
                {
                    if ((int)a_WinMess.WParam >= AS5216.ERR_SUCCESS)
                    {
                        if (AS5216.ERR_SUCCESS == (int)a_WinMess.WParam) // normal measurements
                        {
                            // "Meas.Status: success";                            
                            for (int i = 0 ; i < g.nAvsCount ; i++)
                            {
                                if (g.avs[i].GetNumPixels > 0)
                                {                                    
                                    AS5216.SCOPE_DATA pSpectrum = g.avs[i].GetScopeData;                                 
                                    g.pqSpectrum[i].Enqueue(pSpectrum.pSpectrum);
                                }
                            }
                        }
                        else    // a WParam > 0 indicates a response to StoreToRam
                        // using StoreToRAM requires firmware version 0.20.0.0 or later
                        // a_WinMess.WParam holds the number of scans stored in RAM
                        // import into application by call to g.avs_GetScopeData for each scan
                        {
                            // "Meas.Status: Reading RAM";
                            /*
                            for (int j = 1; j <= a_WinMess.WParam.ToInt32(); j++)
                            {
                                AS5216.SCOPE_DATA pSpectrum = g.avs.GetScopeData;
                            }*/
                        }
                    }
                    else // message.WParam < 0 indicates error 
                    {
                        //"Meas.Status: failed. Error " + a_WinMess.WParam.ToString();
                    }
                }
                else
                {

                }
            }
            catch { }
            finally
            {
                base.WndProc(ref a_WinMess);
            }
        }
    }
}
