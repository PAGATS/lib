using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CH.System;
using CH.Diagnostics;

namespace tbZygote
{
    public partial class tbZygote : Form
    {
        Zygote zygote1 = new Zygote();
        Zygote zygote2 = new Zygote();
        Debug dbg = new Debug("Zygote");

        public tbZygote()
        {
            InitializeComponent();
        }

        private void Zygote_Load(object sender, EventArgs e)
        {
            dbg.Out = "Zygote_Load";
        }

        private void Zygote_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbg.Out = "Zygote_FormClosing";
        }

        private void tbZygote_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbg.Out = "tbZygote_FormClosed";
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.OK == openFileDialog1.ShowDialog())
                {
                    Zygote.CONFIG config = new Zygote.CONFIG();
                    config.ExePath = openFileDialog1.FileName;
                    zygote1.Open(config);
                    zygote2.Open(config);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            try
            {
                zygote1.Close();
                zygote2.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btWrite_Click(object sender, EventArgs e)
        {
            try
            {
                //zygote.Write(textBox1.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}

