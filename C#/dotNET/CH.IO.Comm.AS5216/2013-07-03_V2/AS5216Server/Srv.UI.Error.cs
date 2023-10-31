using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CH.Diagnostics;

namespace AS5216Server
{
    public partial class UI : Form
    {
        void BOOT(string msg)
        {
            try
            {
                d.Out = g.ui.strBoot = msg;
            }
            catch (System.Exception ex)
            {
                Error("BOOT", ex);
            }
        }

        void MSG(string msg)
        {
            try
            {
                d.Out = g.ui.strMsg = msg;
            }
            catch (System.Exception ex)
            {
                Error("MSG", ex);
            }
        }

        void Error(string source, string err)
        {
            d.Log = g.ui.strError = "[" + source + "] " + err;
        }

        void Error(string source, Exception ex)
        {
            d.Log = g.ui.strError = "[" + source + "] " + ex.Message;            
        }
    }
}
