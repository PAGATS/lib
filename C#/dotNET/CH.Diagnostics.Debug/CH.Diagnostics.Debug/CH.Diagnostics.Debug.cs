using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CH.Diagnostics
{
    public class Debug
    {
        private class VARIABLE
        {
            public bool IsDebug = true;
            public bool IsLog = true;
            public string Filter = "";
            public string strTemp = "";
            public string strMethodName = "";
            public int nStartMethodName = 0;
            public int nEndMethodName = 0;
            public uint nCount = 0;
            public DateTime timeStamp = DateTime.Now;
            public string strLogFilePath = "";
            public string strMsg = "";
        }

        private VARIABLE g;

        public Debug(string Filter)
        {
            try
            {
                g = new VARIABLE();
                g.Filter = Filter;
                DateTime timeNow = DateTime.Now;
                g.strLogFilePath = @".\Log\" + timeNow.ToString("yyyy-MM-dd") + "_" + Filter + ".txt";
                Directory.CreateDirectory(@".\Log");
            }
            catch
            {
                throw;
            }
        }

        public bool IsDebug
        {
            set
            {
                g.IsDebug = value;
            }

            get
            {
                return g.IsDebug;
            }
        }

        public bool IsLog
        {
            set
            {
                g.IsLog = value;
            }

            get
            {
                return g.IsLog;
            }
        }

        public string Filter
        {
            set
            {
                if (g.IsDebug)
                {
                    g.Filter = value;
                }
            }

            get
            {
                return g.Filter;
            }
        }

        public void Indent()
        {
            try
            {
                System.Diagnostics.Debug.Indent();
            }
            catch
            {
                throw;
            }
        }

        public void Unindent()
        {
            try
            {
                System.Diagnostics.Debug.Unindent();
            }
            catch
            {
                throw;
            }
        }

        public void StartStamp()
        {
            try
            {
                if (g.IsDebug)
                {
                    g.timeStamp = DateTime.Now;
                }
            }
            catch
            {
                throw;
            }
        }

        public void Stamp()
        {
            try
            {
                if (g.IsDebug)
                {
                    StackTrace st = new StackTrace(true);
                    StackFrame sf = st.GetFrame(1);
                    DateTime timeNow = DateTime.Now;

                    g.strTemp = string.Format("{0}", sf.GetMethod());

                    g.nStartMethodName = g.strTemp.IndexOf(' ');
                    g.nEndMethodName = g.strTemp.IndexOf('(');

                    g.strMethodName = g.strTemp.Substring(g.nStartMethodName + 1, g.nEndMethodName - g.nStartMethodName - 1);

                    System.Diagnostics.Debug.Write("(" +
                        timeNow.ToString("hh:mm:ss.ffffff") + ")[ " +
                        g.Filter + " . " +
                        g.strMethodName + "] ⓢ " + (timeNow - g.timeStamp));
                }
            }
            catch
            {
                throw;
            }
        }

        public void Counting()
        {
            try
            {
                if (g.IsDebug)
                {
                    StackTrace st = new StackTrace(true);
                    StackFrame sf = st.GetFrame(1);

                    g.strTemp = string.Format("{0}", sf.GetMethod());

                    g.nStartMethodName = g.strTemp.IndexOf(' ');
                    g.nEndMethodName = g.strTemp.IndexOf('(');

                    g.strMethodName = g.strTemp.Substring(g.nStartMethodName + 1, g.nEndMethodName - g.nStartMethodName - 1);

                    System.Diagnostics.Debug.Write("(" +
                        DateTime.Now.ToString("hh:mm:ss.ffffff") + ")[ " +
                        g.Filter + " . " +
                        g.strMethodName + "] △ " + (++g.nCount).ToString());
                }
            }
            catch
            {
                throw;
            }
        }

        public void Counting(uint SetCount)
        {
            try
            {
                if (g.IsDebug)
                {
                    g.nCount = SetCount;

                    StackTrace st = new StackTrace(true);
                    StackFrame sf = st.GetFrame(1);

                    g.strTemp = string.Format("{0}", sf.GetMethod());

                    g.nStartMethodName = g.strTemp.IndexOf(' ');
                    g.nEndMethodName = g.strTemp.IndexOf('(');

                    g.strMethodName = g.strTemp.Substring(g.nStartMethodName + 1, g.nEndMethodName - g.nStartMethodName - 1);

                    System.Diagnostics.Debug.Write("(" +
                        DateTime.Now.ToString("hh:mm:ss.ffffff") + ")[ " +
                        g.Filter + " . " +
                        g.strMethodName + "] △ " + g.nCount.ToString());
                }
            }
            catch
            {
                throw;
            }
        }

        public string Out
        {
            set
            {
                try
                {
                    if (g.IsDebug)
                    {
                        StackTrace st = new StackTrace(true);
                        StackFrame sf = st.GetFrame(1);

                        g.strTemp = string.Format("{0}", sf.GetMethod());

                        g.nStartMethodName = g.strTemp.IndexOf(' ');
                        g.nEndMethodName = g.strTemp.IndexOf('(');

                        g.strMethodName = g.strTemp.Substring(g.nStartMethodName + 1, g.nEndMethodName - g.nStartMethodName - 1);                        
                        System.Diagnostics.Debug.Write("(" +
                            DateTime.Now.ToString("hh:mm:ss.ffffff") + ")[ " +
                            g.Filter + " . " +
                            g.strMethodName + "] ▶ " +
                            value);
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        public string Log
        {
            set
            {
                try
                {
                    if(g.IsDebug || g.IsLog)
                    {
                        StackTrace st = new StackTrace(true);
                        StackFrame sf = st.GetFrame(1);

                        g.strTemp = string.Format("{0}", sf.GetMethod());

                        g.nStartMethodName = g.strTemp.IndexOf(' ');
                        g.nEndMethodName = g.strTemp.IndexOf('(');

                        g.strMethodName = g.strTemp.Substring(g.nStartMethodName + 1, g.nEndMethodName - g.nStartMethodName - 1);

                        g.strMsg = "(" +
                            DateTime.Now.ToString("hh:mm:ss.ffffff") + ")[ " +
                            g.Filter + " . " +
                            g.strMethodName + "] ▶ ";
                    }

                    if (g.IsDebug)
                    {
                        System.Diagnostics.Debug.Write(g.strMsg + value);
                    }

                    if(g.IsLog)
                    {
                        try
                        {
                            StreamWriter sw = new StreamWriter(g.strLogFilePath, true);
                            sw.WriteLine(g.strMsg + value);
                            sw.Close();
                        }
                        catch{}
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
