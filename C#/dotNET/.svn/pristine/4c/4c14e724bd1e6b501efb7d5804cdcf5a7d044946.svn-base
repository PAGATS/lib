using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CH.Data.Parsing;

namespace tbParser
{
    public partial class Form1 : Form
    {
        Parser ps = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ps = new Parser('<', '>');
            ps.OnParsed += new Parser.PARSEREventHandler(ps_OnParsed);

            tbMsg.Focus();
        }

        void ps_OnParsed(object sender, Parser.PARSEREventArgs e)
        {
            tbParsed.Text += e.RxMsg + "\r\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = tbMsg.Text;

            byte[] pStr = new byte[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                pStr[i] = System.Convert.ToByte(System.Convert.ToChar(str[i]));
            }

            ps.Parsing(pStr, pStr.Length);
        }
    }
}
