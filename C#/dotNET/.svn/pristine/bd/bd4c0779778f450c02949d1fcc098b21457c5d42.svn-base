using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CH.IO.Comm;
using System.Net.Sockets;
using System.Threading;

namespace TB_CHSOCK
{
    public partial class Form1 : Form
    {
        /*
        **************************************************************
        * Variables
        **************************************************************
        */
        private CHSock sock = null;
        private bool mSending = true;
        private int mSendingSize = 0;

        public Form1()
        {
            InitializeComponent();
        }

        /*
        **************************************************************
        * CHSock Related
        **************************************************************
        */

        public void MsgEventHandler(object sender, string type, object msg)
        {
            switch (type)
            {
                case "CONNECTED":
                    richTextBox1.AppendText("Connected\n");
                    button3.Enabled = true;
                    button4.Enabled = true;
                    break;

                case "CONNECTING":
                    richTextBox1.AppendText("Disconnected\n");
                    
                    button3.Enabled = false;
                    button4.Enabled = false;
                    break;

                case "CLOSE":
                    richTextBox1.AppendText("Close!\n");
                    break;

                case "READ":
                    richTextBox1.AppendText("DataReceived: " +
                        sock.ByteToRead.ToString() + "\n");
                    byte[] data = new byte[sock.ByteToRead];
                    if (sock.Read(data, 0, data.Length) < 0)
                    {
                        richTextBox1.AppendText("Fail to Read!\n");
                    }
                    break;
            }
        }

        public void ErrorEventHandler(object sender, string src, Exception err)
        {
            try
            {
                richTextBox1.AppendText("@" + src + ": " + err.Message + "\n");
            }
            catch
            {
            }
        }

        /*
        **************************************************************
        * Events
        **************************************************************
        */
        //
        // Form Loaded
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            sock = new CHSock();
            sock.OnMsg += new DEVICE.MsgEventHandler(MsgEventHandler);
            sock.OnError += new DEVICE.ErrorEventHandler(ErrorEventHandler);
        }
        //
        // Form Closing
        //
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sock != null && sock.IsOpen)
            {
                sock.Close();
                sock = null;
            }
        }
        //
        // Listening
        //
        private void button1_Click(object sender, EventArgs e)
        {
            int port;
            if (!int.TryParse(textBox3.Text, out port))
            {
                MessageBox.Show("Check Port Number!");
                return;
            }

            CHSock.CONFIG config = new CHSock.CONFIG();
            config.isServer = true;
            config.port = port;

            if (sock.Open(config) != 0)
            {
                MessageBox.Show("Fail to CHSock Open!");
            }
            else
            {
                richTextBox1.AppendText("Start Listening...\n");
            }
        }
        //
        // Connect
        //
        private void button2_Click(object sender, EventArgs e)
        {
            CHSock.CONFIG config = new CHSock.CONFIG();
            config.isServer = false;
            config.ip = textBox1.Text;
            if (!int.TryParse(textBox2.Text, out config.port))
            {
                MessageBox.Show("Check Port Number!");
            }

            if (sock.Open(config) != 0)
            {
                MessageBox.Show("Fail to CHSock Open!");
            }
        }
        //
        // Disconnect
        //
        private void button3_Click(object sender, EventArgs e)
        {
            sock.Close();
        }
        //
        // Messages
        //
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Focus();
        }
        //
        // Server?
        //
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = !button1.Enabled;
            button2.Enabled = !button2.Enabled;
            button3.Enabled = false;
        }
        //
        // Send
        //
        private void button4_Click(object sender, EventArgs e)
        {
            int size = 0;

            if (button4.Text == "Send")
            {
                if (sock != null)
                {
                    if (int.TryParse(textBox4.Text, out size) && size > 0)
                    {
                        
                        byte[] data = new byte[size];
                        if (sock.Write(data, 0, data.Length) < 0)
                        {
                            richTextBox1.AppendText("Fail to send!\n");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Check Send Size!");
                    }
                }
            }
            else
            {
                mSending = false;
                button4.Text = "Send";
            }
        }
        //
        //
        //
    }
}
