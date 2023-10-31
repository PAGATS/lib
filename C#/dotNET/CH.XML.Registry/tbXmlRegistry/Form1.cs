using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using CH.XML;

namespace tbXmlRegistry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class TEST
        {
            //public Queue<string> q = new Queue<string>();
            public ArrayList a = new ArrayList();
            public string strTemp = " iii ";
        }
        TEST g = new TEST();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //g.q.Enqueue("I Love you 1");
                g.a.Add("TEST");
                Registry.TryToRead<TEST>(@".\Config.txt", ref g);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
