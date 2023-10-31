using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CH.IO.Comm
{
    abstract public class DEVICE
    {
        // 아래의 주석처리된 부분은 DEVICE 클래스를 상속받는 클래스 내에서 static으로 정의하도록 한다.
        // STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC
        /*
        public class HANDLE
        {
        }
        // 외부 장비의 디바이스 드라이버에 연결할 때 필요한 설정 요소들을 정의하는 클래스 (예를 들어 윈도우 핸들 hwnd)

        public static int Mount(HANDLE handle)
        {
            try
            {
            }
            catch
            {
                throw;
            }
            return 0;
        }
        // 대기 여부: Blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 인자 handle: 외부 장비의 디바이스 드라이버에 연결하기 위한 설정값
        // 특징: 정상 동작 후에는 정상 동작에 필요한 모든 것이 자동으로 이루어져야 한다. 예를 들어 외부 장비와 분리가 되었다면 다시 재 연결을 시도해야 한다.

        public static int GetDeviceID(out int[] ID)
        {
            try
            {
            }
            catch
            {
            	throw;
            }
        }
        // 대기 여부: Non-blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 인자 ID: 외부 장비의 디바이스 드라이버를 통해서 연결된 장비의 ID 번호들
        // 예외 처리 필요성: 필요
        // 특징: 현재 사용할 수 있는 장비의 ID만 out을 이용하여 반환한다.

        public static int Unmount()
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
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 인자 handle: 외부 장비의 디바이스 드라이버에 연결하기 위한 설정값
        // 특징: 정상 동작 후에는 연결된 모든 외부 장비의 연결 해제가 되어야 하며, 외부 장비의 디바이스 드라이버와도 분리되어야 한다.
        */
        // STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC STATIC

        public class DEVICE_CONFIG { };
        // 특징: DEVICE 클래스를 상속받는 클래스 내에서 DEVICE_CONFIG 클래스를 상속하는 설정 클래스를 작성하여 사용한다. (예를 들어 public class CONFIG : DEVICE_CONFIG와 같이 작성한다. 그리고 Open함수 내에서 CONFIG 클래스로 다시 재캐스팅을 한다.)
        
        abstract public int Open(DEVICE_CONFIG config);
        // 대기 여부: Blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 인자 config: 외부 장비를 연결하는데 필요한 설정값 클래스, DEVICE_CONFIG를 상속하여 작성한 클래스로 포인트하여 활용하되 함수 내부에서는 다시 본 클래스로 복원하여 사용한다.
        // 예외 처리 필요성: 필요
        // 특징: 외부 장비의 디바이스 드라이버에서 하나의 장비만을 여는 함수이다. 정상 동작 후에는 정상 동작에 필요한 모든 것이 자동으로 이루어져야 한다. 예를 들어 DEVICE가 끊겼을 때 자동으로 재연결 시도를 해야 한다.

        abstract public int Read(out byte datum);
        // 대기 여부: Non-blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 인자 datum: 읽기 버퍼에서 1 byte를 읽은 값
        // 예외 처리 필요성: 필요
        // 특징: 이 함수는 읽기 버퍼에서만 값을 읽어 오면, 그 이외의 모든 읽기와 관련된 에러는 ErrorEventHandler를 통해서 처리한다.

        abstract public int Read(byte[] buffer, int offset, int count);
        // 대기 여부: Non-blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 인자 buffer: 읽은 버퍼를 저장할 메모리 공간
        // 인자 offset: buffer 인자의 시작 포인트
        // 인자 int: 읽기 버퍼에서 buffer 인자에 읽어 올 데이터 크기
        // 예외 처리 필요성: 필요
        // 특징: offset 인자와 count 인자가 읽기 버퍼 및 buffer 인자의 사이즈 규칙에 어긋나지 않는지 미리 계산하여야 하며, 계산에 문제가 있을 시 바로 에러 코드를 반환한다. 그 이외의 모든 읽기와 관련된 에러는 ErrorEventHandler를 통해서 처리한다.

        abstract public int Write(byte datum);
        // 대기 여부: Non-blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 인자 datum: 쓰기 버퍼에 쓸 1 byte 값
        // 예외 처리 필요성: 필요
        // 특징: 이 함수는 쓰기 버퍼에서만 값을 읽어 오면, 그 이외의 모든 쓰기와 관련된 에러는 ErrorEventHandler를 통해서 처리한다.

        abstract public int Write(byte[] buffer, int offset, int count);
        // 대기 여부: Non-blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 인자 buffer: 쓰기 버퍼에 쓸 메모리 데이터
        // 인자 offset: buffer 인자의 시작 포인트
        // 인자 int: buffer 인자에서 쓰기 버퍼로 쓸 데이터 크기
        // 예외 처리 필요성: 필요
        // 특징: offset 인자와 count 인자가 쓰기 버퍼 및 buffer 인자의 사이즈 규칙에 어긋나지 않는지 미리 계산하여야 하며, 계산에 문제가 있을 시 바로 에러 코드를 반환한다. 그 이외의 모든 쓰기와 관련된 에러는 ErrorEventHandler를 통해서 처리한다.

        abstract public int Close();
        // 대기 여부: Blocking call
        // 반환값: 정상 동작 0, 에러 발생시 코드 값
        // 예외 처리 필요성: 필요
        // 특징: 외부 장비의 디바이스 드라이버에서 하나의 장비만을 닫는 함수이다.

        abstract public object IOCtrl(string type, object cmd);
        // 대기 여부: Blocking call
        // 반환값: cmd에 따른 클래스
        // 인자 type: 인자 cmd의 타입
        // 인자 cmd: IOCtrl에 설정을 하거나 설정값을 읽어 오는 등의 모든 동작과 관련된 클래스
        // 예외 처리 필요성: 필요
        // 특징: DEVICE를 상속한 클래스의 내부 설정값을 쓰거나 읽는 등에 사용된다. 각각의 cmd에 대한 정의는 각각의 INTERFACE를 상속한 클래스에 따라서 정의되며 이와 같은 파편성으로 인해서 꼭 필요한 경우에만 정의해서 사용하고, 정의한 내용을 상세히 리포트해야 한다.
                     
        abstract public bool IsOpen { get; }
        // 대기 여부: Non-blocking call
        // 반환값: DEVICE를 상속한 클래스의 모든 동작이 정상이면 true, 아니면 false
        // 특징: 재연결 중일 때도 false를 반환해야 한다.

        abstract public int ByteToRead { get; }
        // 대기 여부: Non-blocking call
        // 반환값: 읽기 버퍼에서 읽을 수 있는 데이터의 크기D

        // delegate of Event handler
        public delegate void MsgEventHandler(object sender, string type, object msg); // Reserved type: "CONNECTED", "DISCONNECTED", "READ"
        // 인자 sender: 외부 장비 하나의 내부에도 구별해야 할 필요가 있을 때 사용. DEVICE를 상속한 클래스 각각에 대해서 정의하여 사용하고 그 내용을 상세히 리포트해야 한다.
        // 인자 type: 인자 msg가 어떠한 의미인지를 알려주는 string값으로 다음의 세가지 값은 반드시 정의되어 있어야 한다. {"CONNECTED", "DISCONNECTED", "READ"}. 나머지 string값에 대해서는 각각 정의하여 사용하고 그 내용을 상세히 리포트해야 한다.
        // 인자 msg: 전송된 데이터 클래스
        // 특징: 이 delegate함수 내에서 처리하는 시간이 길어지더라도 문제가 발생하지 않도록 처리되어야 한다. 즉 이 핸들러를 호출하기 전에 들어오는 데이터들에 대한 Buffering 문제를 잘 해결해야 한다.

        public delegate void ErrorEventHandler(object sender, string source, Exception err);
        // 인자 sender: 외부 장비 하나의 내부에도 구별해야 할 필요가 있을 때 사용. MsgEventHandler와 같은 것으로 정의해야 한다.
        // 인자 source: 에러 메시지에 대한 문자열 설명으로 "[발생한 함수] 에러 내용"의 형식으로 구성되어 있다.
        // 인자 err: 함수에서 발생한 예외

        // 앞선 delegate 함수들의 Event handler
        abstract public event MsgEventHandler OnMsg;
        abstract public event ErrorEventHandler OnError;
    }
}

/*
using System;
using CH.IO.Comm;

namespace CH.IO.Comm
{
    public partial class USB : DEVICE
    {
        public USB()
        {

        }

        public class HANDLE
        {
        }

        public static int Mount(HANDLE handle)
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

        public static int GetDeviceID(out int[] ID)
        {
            try
            {
                ID = null;
                return 0;
            }
            catch
            {
            	throw;
            }
        }

        public static int Unmount()
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

        public class CONFIG : DEVICE.DEVICE_CONFIG
        {

        }

        override public int Open(DEVICE.DEVICE_CONFIG config)
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
       

        override public int Read(out byte datum)
        {
            try
            {
                datum = 0;
                return 0;
            }
            catch
            {
                throw;
            }
        }

        override public int Read(byte[] buffer, int offset, int count)
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

        override public int Write(byte datum)
        {
            try
            {
                datum = 0;
                return 0;
            }
            catch
            {
                throw;
            }
        }

        override public int Write(byte[] buffer, int offset, int count)
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

        override public int Close()
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

        override public object IOCtrl(string type, object cmd)
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

        override public bool IsOpen
        {
            get
            {
                try
                {
                    return true;
                }
                catch
                {
                    throw;
                }
            }
        }

        override public int ByteToRead
        {
            get
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
        }

        override public event MsgEventHandler OnMsg = null;
        override public event ErrorEventHandler OnError = null;
    }
}
*/