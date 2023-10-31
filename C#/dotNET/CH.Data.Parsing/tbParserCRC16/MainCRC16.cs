using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CH.Data.Parsing;

namespace tbParserCRC16
{
    public partial class MainCRC16 : Form
    {
        ParserCRC16 ps = null;

        public MainCRC16()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ps = new ParserCRC16('<', '>');
            ps.OnParsed += new ParserCRC16.PARSEREventHandler(ps_OnParsed);
            ps.OnCRC16Error += new ParserCRC16.CRC16ErrorEventHandler(ps_OnCRC16Error);

            tbMsg.Focus();
        }

        void ps_OnCRC16Error(object sender)
        {
            tbParsed.Text += "CRC16 Error \r\n";
        }

        void ps_OnParsed(object sender, string msg)
        {
            tbParsed.Text += msg + "\r\n";
        }

        private void MainCRC16_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = tbMsg.Text;
            byte[] pTemp = new byte[1];
            byte[] pStr = new byte[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                pStr[i] = System.Convert.ToByte(System.Convert.ToChar(str[i]));
            }

            pTemp[0] = (byte)'<';
            ps.Parsing(pTemp, 1);

            ps.Parsing(pStr, pStr.Length);

            pTemp[0] = (byte)'>';
            ps.Parsing(pTemp, 1);

            UInt16 crc16 = ps.CRC16(pStr, pStr.Length);
            string str2 = string.Format("{0:x4}", crc16);
            tbCRC16.Text = str2;
            byte[] pData = new byte[4];
            for(int i = 0 ; i < 4 ; i++)
            {
                pData[i] = System.Convert.ToByte(System.Convert.ToChar(str2[i]));
            }           

            ps.Parsing(pData, 4);
        }
    }
}
