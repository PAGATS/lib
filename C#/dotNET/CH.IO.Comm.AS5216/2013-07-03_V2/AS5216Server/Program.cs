using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AS5216Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System.Diagnostics.Process[] myProc = System.Diagnostics.Process.GetProcessesByName("AS5216Server");  // 여기서 Mulpumi는 프로젝트 속성의 프로젝트 이름
            if (myProc.Length < 2)
            {
                Application.Run(new UI());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
