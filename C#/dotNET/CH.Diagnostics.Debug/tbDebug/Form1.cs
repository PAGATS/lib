using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CH.Diagnostics;

namespace tbDebug
{
    public partial class Form1 : Form
    {
        Debug dbg;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbg.Counting();
            dbg.Stamp();

            try
            {
                dbg.Log = "test1";
                dbg.Log = "test2";
                dbg.Log = "test3";
                dbg.Log = "test4";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dbg = new Debug("TEST");            
            dbg.StartStamp();
        }
    }
}
