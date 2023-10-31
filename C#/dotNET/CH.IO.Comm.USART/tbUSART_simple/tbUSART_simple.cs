using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.Threading;

namespace tbUSART_simple
{
    public partial class tbUSART_simple : Form
    {
        bool bPulseToggle = true;
        Thread thPulse = null;
        bool bThPulse = true;
        ManualResetEvent evThPulse = new ManualResetEvent(false);

        public tbUSART_simple()
        {
            InitializeComponent();
        }

        private void tbUSART_simple_Load(object sender, EventArgs e)
        {
            try
            {
                thPulse = new Thread(new ThreadStart(ThreadPulse));
                bThPulse = true;
                evThPulse.Reset();
                thPulse.Start();

                bt370LedON.Enabled = false;
                bt370LedOFF.Enabled = false;
                bt370LedPulseON.Enabled = false;
                bt370LedPulseOFF.Enabled = false;
                serial.Open();
                bt370LedON.Enabled = true;
                bt370LedOFF.Enabled = true;
                bt370LedPulseON.Enabled = true;
                bt370LedPulseOFF.Enabled = true;                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void tbUSART_simple_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                serial.Close();

                bThPulse = false;
                evThPulse.Set();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt370LedON_Click(object sender, EventArgs e)
        {
            try
            {
                if (serial.IsOpen)
                {
                    serial.Write("P16");
                    byte[] pData = { 0x0D };
                    serial.Write(pData, 0, pData.Length);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt370LedOFF_Click(object sender, EventArgs e)
        {
            try
            {
                if (serial.IsOpen)
                {
                    serial.Write("P06");
                    byte[] pData = { 0x0D };
                    serial.Write(pData, 0, pData.Length);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void ThreadPulse()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            while (bThPulse)
            {
                try
                {
                    evThPulse.WaitOne();

                    if (bPulseToggle)
                    {
                        bPulseToggle = false;

                        if (serial.IsOpen)
                        {
                            serial.Write("P16");
                            byte[] pData = { 0x0D };
                            serial.Write(pData, 0, pData.Length);
                        }
                    }
                    else
                    {
                        bPulseToggle = true;

                        if (serial.IsOpen)
                        {
                            serial.Write("P06");
                            byte[] pData = { 0x0D };
                            serial.Write(pData, 0, pData.Length);
                        }
                    }
                    Thread.Sleep(100);

                }
                catch (System.Exception ex)
                {
                	
                }
            }
            stopwatch.Stop();
        }

        private void bt370LedPulseON_Click(object sender, EventArgs e)
        {
            evThPulse.Set();
        }

        private void bt370LedPulseOFF_Click(object sender, EventArgs e)
        {
            evThPulse.Reset();
        }
    }
}
