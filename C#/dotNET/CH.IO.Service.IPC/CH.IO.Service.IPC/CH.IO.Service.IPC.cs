using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

using CH.IO.Comm;

namespace CH.IO.Service
{
    public class IPC : INTERFACE
    {
        private class VARIABLE
        {
            public bool IsOpen = false;
            public CONFIG config = null;            
            public IpcServerChannel server = null;
            public IpcClientChannel client = null;            
        }
        VARIABLE g = new VARIABLE();

        public class CONFIG
        {
            public bool IsServer = false;
            public string ChannelName = "ch.ipc";
            public string PortName = "remote";
            public bool IsSecurityChannel = false;
        }

        public override int Connect(DEVICE openDevice, object config)
        {
            try
            {
                if (g.IsOpen)
                    return 1;

                g.config = (CONFIG)config;
                
                if (g.config.IsServer)
                {
                    g.server = new IpcServerChannel(g.config.ChannelName, g.config.PortName);     
                    //g.server = new IpcServerChannel(g.config.PortName);     
                    ChannelServices.RegisterChannel(g.server, g.config.IsSecurityChannel);
                    
                }
                else
                {
                    g.client = new IpcClientChannel();
                    ChannelServices.RegisterChannel(g.client, g.config.IsSecurityChannel);
                }
                g.IsOpen = true;
                return 0;
            }
            catch(Exception ex)
            {
                if (null != OnError)
                {
                    OnError(this, "Connect", ex);
                }
                return -1;
            }
        }
        // 대기 여부: Blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 인자 openDevice: DEVICE 클래스를 상속한 클래스의 인스턴스로 인자로 할당되기 전에 Open되어 있어야 한다.
        // 인자 config: INTERFACE 클래스를 상속한 클래스의 인스턴스에 필요한 설정 구조체(혹은 클래스)
        // 예외 처리 필요성: 필요
        // 특징: 정상 동작 후에는 정상 동작에 필요한 모든 것이 자동으로 이루어져야 한다. 예를 들어 DEVICE가 끊겼을 때 자동으로 재연결 시도를 해야 한다.

        public override int Send(Type type, object msg)
        {
            try
            {
                if (!g.IsOpen)
                    return 1;

                if (g.config.IsServer)
                {
                    RemotingConfiguration.RegisterWellKnownServiceType(type, type.ToString(), WellKnownObjectMode.Singleton);
                    return 0;
                }
                else
                {
                    RemotingConfiguration.RegisterWellKnownClientType(type, "ipc://" + g.config.PortName + "/" + type.ToString());
                    return 0;
                }                
            }
            catch (Exception ex)
            {
                if (null != OnError)
                {
                    OnError(this, "Send", ex);
                }
                return -1;
            }
        }
        // 대기 여부: Non-blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 인자 type: 인자 msg의 타입
        // 인자 msg: 전송할 데이터 클래스
        // 예외 처리 필요성: 필요
        // 특징: 데이터를 전송 Buffer에 넣는 것까지만 정상 동작 확인을 진행한다. 이후 전송이 되지 않는 등 비정상적인 동작에 관한 리포트는 ErrorEventHandler를 통해서 한다.

        public override int Disconnect()
        {
            try
            {
                if (g.config.IsServer)
                {
                    if (null != g.server)
                    {
                        ChannelServices.UnregisterChannel(g.server);
                    }
                    g.server = null;
                }
                else
                {
                    if (null != g.client)
                    {
                        ChannelServices.UnregisterChannel(g.client);
                    }
                    g.client = null;
                    
                }
                g.IsOpen = false;
                return 0;
            }
            catch
            {
                throw;
            }
        }
        // 대기 여부: Blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 예외 처리 필요성: 필요
        // 특징: 정상 동작 후에는 INTERFACE를 상속한 클래스와 관련된 모든 기능을 중지하고 리소스를 반환한다. 단, 인자로 활용한 DEVICE를 닫지는 않는다. 

        public override object IOCtrl(string type, object cmd)
        {
            try
            {
                return 0;
            }
            catch
            {
                throw;
            }
        }
        // 대기 여부: Blocking call
        // 반환값: cmd에 따른 클래스
        // 인자 type: 인자 cmd의 타입
        // 인자 cmd: IOCtrl에 설정을 하거나 설정값을 읽어 오는 등의 모든 동작과 관련된 클래스
        // 예외 처리 필요성: 필요
        // 특징: INTERFACE를 상속한 클래스의 내부 설정값을 쓰거나 읽는 등에 사용된다. 각각의 cmd에 대한 정의는 각각의 INTERFACE를 상속한 클래스에 따라서 정의되며 이와 같은 파편성으로 인해서 꼭 필요한 경우에만 정의해서 사용하고, 정의한 내용을 상세히 리포트해야 한다.

        public override bool IsConnection 
        {
            get
            {
                return false;
            }
        }
        // 대기 여부: Non-blocking call
        // 반환값: INTERFACE를 상속한 클래스의 모든 동작이 정상이면 true, 아니면 false
        // 특징: 재연결 중일 때도 false를 반환해야 한다.

        // 앞선 delegate 함수들의 event 핸들러
        public override event MsgEventHandler OnMsg;
        public override event ErrorEventHandler OnError;
    }
}
