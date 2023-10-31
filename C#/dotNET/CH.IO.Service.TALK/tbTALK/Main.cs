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

namespace tbTALK
{
    public partial class tbTALK : Form
    {
        USART usart;
        Talk talk;
        public tbTALK()
        {
            InitializeComponent();
        }

        private void tbTALK_Load(object sender, EventArgs e)
        {
            try
            {
                USART.CONFIG config = new USART.CONFIG();
                config.BaudRate = "115200";
                config.PortName = "COM4";
                usart = new USART();
                usart.Open(config);

                Talk.CONFIG t_config = new Talk.CONFIG();
                t_config.EnableACK = false;
                talk = new Talk('<', '>', 20);
                talk.Connect(usart, t_config);

                talk.OnMsg += new INTERFACE.MsgEventHandler(talk_OnMsg);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        void talk_OnMsg(object sender, string type, object msg)
        {
            if(type == "STRING")
            {
                label1.Text = (string)msg;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            talk.Send(typeof(string), "FTN PDT 0 10 0");
        }

        private void tbTALK_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                talk.Disconnect();
                usart.Close();
            }
            catch (System.Exception ex)
            {
            	
            }
            
        }
    }
}
