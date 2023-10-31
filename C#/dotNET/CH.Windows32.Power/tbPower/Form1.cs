using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CH.Windows32;

namespace tbPower
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btShutdown_Click(object sender, EventArgs e)
        {
            Power.Shutdown();
        }

        private void btRestart_Click(object sender, EventArgs e)
        {
            Power.Restart();
        }
    }
}
