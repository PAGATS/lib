using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CH.Windows32
{
    public class Power
    {
        static public void Shutdown(int seconds)
        {
            try
            {
                Process.Start("shutdown.exe", "-s -t " + seconds.ToString());
            }
            catch
            {
                throw;
            }

        }

        static public void Shutdown()
        {
            try
            {
                Process.Start("shutdown.exe", "-s -t 0");
            }
            catch
            {
                throw;
            }
            
        }

        static public void Restart(int seconds)
        {
            try
            {
                Process.Start("shutdown.exe", "-r -t " + seconds.ToString());
            }
            catch
            {
                throw;
            }
        }

        static public void Restart()
        {
            try
            {
                Process.Start("shutdown.exe", "-r -t 0");
            }
            catch
            {
                throw;
            }
        }
    }
}
