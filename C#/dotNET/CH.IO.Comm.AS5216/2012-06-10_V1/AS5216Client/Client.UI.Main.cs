using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CH.IO.Comm;
using CH.IO.Service;
using CH.Diagnostics;

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
        }

        private void UIClient_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void UIClient_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
