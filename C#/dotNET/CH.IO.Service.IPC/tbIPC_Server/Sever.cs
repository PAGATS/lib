using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using tbSharedMemory;

using CH.IO.Comm;
using CH.IO.Service;

namespace tbIPC_Server
{
    public partial class Sever : Form
    {
        SharedMemory sm = null;
        IPC ipc = new IPC();

        public Sever()
        {
            InitializeComponent();
        }

        private void Sever_Load(object sender, EventArgs e)
        {
            try
            {
                this.TopMost = true;

                IPC.CONFIG config = new IPC.CONFIG();
                config.IsServer = true;

                ipc.Connect(null, config);
                ipc.Send(typeof(SharedMemory), sm);
                sm = new SharedMemory();
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Sever_FormClosing(object sender, FormClosingEventArgs e)
        {
            ipc.Disconnect();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            sm.Count++;
            tbMsg.Text = sm.Count.ToString();
        }

        private void btChange_Click(object sender, EventArgs e)
        {
        }
    }
}
