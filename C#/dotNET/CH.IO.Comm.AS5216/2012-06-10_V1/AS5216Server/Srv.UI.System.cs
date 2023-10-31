using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CH.XML;

namespace AS5216Server
{
    public partial class UI : Form
    {
        void BootComplete()
        {
            try
            {
                
            }
            catch (System.Exception ex)
            {
                Error("BootComplete", ex);
            }
        }

        void ReadXML()
        {
            try
            {
                Registry.TryToRead<CONFIG>(@".\[AS5216ServerConfig].xml", ref g.config);
            }
            catch (System.Exception ex)
            {
                Error("InitXMLConfig", ex);
            }
        }

        void WriteXML()
        {
            try
            {
                Registry.Write<CONFIG>(@".\[AS5216ServerConfig].xml", g.config);
            }
            catch (System.Exception ex)
            {
                Error("InitXMLConfig", ex);
            }
        }

    }
}
