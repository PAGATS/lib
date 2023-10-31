using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using RemoteObject_Prj;

namespace dotNet_IPC_Client
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

            IpcClientChannel clientChannel = new IpcClientChannel();
            ChannelServices.RegisterChannel(clientChannel, false);
            RemotingConfiguration.RegisterWellKnownClientType(typeof(RemoteObject), "ipc://remote/Cnt");
            RemoteObject rt = new RemoteObject();
            Console.WriteLine("This is call number =" + rt.GetCount());
            Console.ReadLine();
        }

      
    }
}
