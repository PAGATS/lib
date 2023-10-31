using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CH.IO.Comm;

namespace CH.IO.Service
{
    abstract public class INTERFACE
    {
        abstract public int Connect(DEVICE openDevice, object config);  
        // 대기 여부: Blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 인자 openDevice: DEVICE 클래스를 상속한 클래스의 인스턴스로 인자로 할당되기 전에 Open되어 있어야 한다.
        // 인자 config: INTERFACE 클래스를 상속한 클래스의 인스턴스에 필요한 설정 구조체(혹은 클래스)
        // 예외 처리 필요성: 필요
        // 특징: 정상 동작 후에는 정상 동작에 필요한 모든 것이 자동으로 이루어져야 한다. 예를 들어 DEVICE가 끊겼을 때 자동으로 재연결 시도를 해야 한다.

        abstract public int Send(Type type, object msg);
        // 대기 여부: Non-blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 인자 type: 인자 msg의 타입
        // 인자 msg: 전송할 데이터 클래스
        // 예외 처리 필요성: 필요
        // 특징: 데이터를 전송 Buffer에 넣는 것까지만 정상 동작 확인을 진행한다. 이후 전송이 되지 않는 등 비정상적인 동작에 관한 리포트는 ErrorEventHandler를 통해서 한다.
        
        abstract public int Disconnect();
        // 대기 여부: Blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 예외 처리 필요성: 필요
        // 특징: 정상 동작 후에는 INTERFACE를 상속한 클래스와 관련된 모든 기능을 중지하고 리소스를 반환한다. 단, 인자로 활용한 DEVICE를 닫지는 않는다. 

        abstract public object IOCtrl(string type, object cmd);
        // 대기 여부: Blocking call
        // 반환값: cmd에 따른 클래스
        // 인자 type: 인자 cmd의 타입
        // 인자 cmd: IOCtrl에 설정을 하거나 설정값을 읽어 오는 등의 모든 동작과 관련된 클래스
        // 예외 처리 필요성: 필요
        // 특징: INTERFACE를 상속한 클래스의 내부 설정값을 쓰거나 읽는 등에 사용된다. 각각의 cmd에 대한 정의는 각각의 INTERFACE를 상속한 클래스에 따라서 정의되며 이와 같은 파편성으로 인해서 꼭 필요한 경우에만 정의해서 사용하고, 정의한 내용을 상세히 리포트해야 한다.

        abstract public bool IsConnection { get; }
        // 대기 여부: Non-blocking call
        // 반환값: INTERFACE를 상속한 클래스의 모든 동작이 정상이면 true, 아니면 false
        // 특징: 재연결 중일 때도 false를 반환해야 한다.

        public delegate void MsgEventHandler(object sender, string type, object msg);
        // 인자 sender: 여러개의 DEVICE 사용시 이를 구분할 수 있게 해주는 클래스. INTERFACE를 상속한 클래스 각각에 대해서 정의하여 사용하고 그 내용을 상세히 리포트해야 한다.
        // 인자 type: 인자 msg가 어떠한 의미인지를 알려주는 string값으로 다음의 세가지 값은 반드시 정의되어 있어야 한다. {"CONNECTED", "DISCONNECTED", "READ"}. 나머지 string값에 대해서는 각각 정의하여 사용하고 그 내용을 상세히 리포트해야 한다.
        // 인자 msg: 전송된 데이터 클래스
        // 특징: 이 delegate함수 내에서 처리하는 시간이 길어지더라도 문제가 발생하지 않도록 처리되어야 한다. 즉 이 핸들러를 호출하기 전에 들어오는 데이터들에 대한 Buffering 문제를 잘 해결해야 한다.

        public delegate void ErrorEventHandler(object sender, string source, Exception err);
        // 인자 sender: 여러개의 DEVICE 사용시 이를 구분할 수 있게 해주는 클래스. MsgEventHandler와 같은 것으로 정의해야 한다.
        // 인자 source: 에러 메시지에 대한 문자열 설명으로 "[발생한 함수] 에러 내용"의 형식으로 구성되어 있다.
        // 인자 err: 함수에서 발생한 예외

        // 앞선 delegate 함수들의 event 핸들러
        abstract public event MsgEventHandler OnMsg;
        abstract public event ErrorEventHandler OnError;
    }
}
