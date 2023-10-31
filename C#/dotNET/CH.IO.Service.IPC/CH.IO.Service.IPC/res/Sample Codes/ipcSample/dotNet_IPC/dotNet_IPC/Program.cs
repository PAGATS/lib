using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using RemoteObject_Prj;

namespace dotNet_IPC
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        [SecurityPermission(SecurityAction.Demand)]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            IpcServerChannel svr = new IpcServerChannel("remote");
            ChannelServices.RegisterChannel(svr, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject), "Cnt", WellKnownObjectMode.Singleton);
            Console.WriteLine("Listening on " + svr.GetChannelUri());
            RemoteObject ro = new RemoteObject();
            ro.SetCount(100);
            Console.ReadLine();
            ro.SetCount(200);
            Console.ReadLine();
            ro.SetCount(300);
            Console.ReadLine();
            ro.SetCount(400);
            Console.ReadLine();
            ro.SetCount(500);
            Console.ReadLine();
        }
      
    }
}
