using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.ComponentModel;

using CH.IO.Comm;

namespace CH.IO.Comm
{
    public partial class USART : DEVICE
    {
        #region The struct of version information
        public class CONFIG : DEVICE_CONFIG
        {
            
            public string PortName;
            public string BaudRate;
            public string DataBits;
            public string Parity;
            public string StopBits;
            public string Handshake;
            public UInt32 ReadTimeout;
            public UInt32 WriteTimeout;
            public UInt32 ReadThreashold;
            public UInt32 WriteThreshold;

            public CONFIG()
            {                
                PortName = "COM1";
                BaudRate = "115200";
                DataBits = "8";
                Parity = "None";
                StopBits = "1";
                Handshake = "None";
            }
        }

        class VARIABLES
        {
            public SerialPort serial = null;
            public byte[] pReadBuf = null;
            public byte[] pReadDatum = null;
            public byte[] pWriteDatum = null;

            public VARIABLES()
            {
                serial = new SerialPort();
                pReadDatum = new byte[1];
                pWriteDatum = new byte[1];
            }
        }

        VARIABLES g = null;
        override public event MsgEventHandler OnMsg = null;
        override public event ErrorEventHandler OnError = null;
        #endregion

        public static string[] GetPortNames()
        {
            try
            {
                return SerialPort.GetPortNames();
            }
            catch
            {
                throw;
            }
        }

        public static string[] GetBaudRates()
        {
            try
            {
                return new string[] { "75", "150", "200", "300", "600", "1200", "1800", "2400", "4800", "9600", "19200", "28800", "38400", "57600", "115200", "128000", "230400", "460800", "921600" };
            }
            catch
            {
                throw;
            }
        }

        public static string[] GetDataBits()
        {
            try
            {
                return new string[] { "5", "6", "7", "8" };
            }
            catch
            {
                throw;
            }
        }

        public static string[] GetStopBits()
        {
            try
            {
                return new string[] { "1", "1.5", "2" };
            }
            catch
            {
                throw;
            }
        }

        public static string[] GetParities()
        {
            try
            {
                return new string[] { "Even", "Mark", "None", "Odd", "Space" };
            }
            catch
            {
                throw;
            }
        }

        public static string[] GetHandShakes()
        {
            try
            {
                return new string[] { "None", "RequestToSend", "RequestToSendXOnXOff", "XOnXOff" };
            }
            catch
            {
                throw;
            }
        }

        public USART()
        {
            try
            {
                g = new VARIABLES();

                g.serial.PortName = "COM1";
                g.serial.BaudRate = 115200;
                g.serial.DataBits = 8;
                g.serial.Parity = Parity.None;
                g.serial.StopBits = StopBits.One;
                g.serial.Handshake = Handshake.None;
                g.serial.DataReceived += new SerialDataReceivedEventHandler(USART_DataReceived);
            }
            catch
            {
                throw;
            }
        }

        override public int Open(DEVICE_CONFIG config)
        {
            try
            {
                Close();

                #region CONFIGURATION
                CONFIG cfg = (CONFIG)config;
                g.serial.PortName = cfg.PortName;
                switch (cfg.BaudRate)
                {
                    case "75":
                        {
                            g.serial.BaudRate = 75;
                        } break;
                    case "150":
                        {
                            g.serial.BaudRate = 150;
                        } break;
                    case "200":
                        {
                            g.serial.BaudRate = 200;
                        } break;
                    case "300":
                        {
                            g.serial.BaudRate = 300;
                        } break;
                    case "600":
                        {
                            g.serial.BaudRate = 600;
                        } break;
                    case "1200":
                        {
                            g.serial.BaudRate = 1200;
                        } break;
                    case "1800":
                        {
                            g.serial.BaudRate = 1800;
                        } break;
                    case "2400":
                        {
                            g.serial.BaudRate = 2400;
                        } break;
                    case "4800":
                        {
                            g.serial.BaudRate = 4800;
                        } break;
                    case "9600":
                        {
                            g.serial.BaudRate = 9600;
                        } break;
                    case "19200":
                        {
                            g.serial.BaudRate = 19200;
                        } break;
                    case "28800":
                        {
                            g.serial.BaudRate = 28800;
                        } break;
                    case "38400":
                        {
                            g.serial.BaudRate = 38400;
                        } break;
                    case "57600":
                        {
                            g.serial.BaudRate = 57600;
                        } break;
                    case "115200":
                        {
                            g.serial.BaudRate = 115200;
                        } break;
                    case "128000":
                        {
                            g.serial.BaudRate = 128000;
                        } break;
                    case "230400":
                        {
                            g.serial.BaudRate = 230400;
                        } break;
                    case "460800":
                        {
                            g.serial.BaudRate = 460800;
                        } break;
                    case "921600":
                        {
                            g.serial.BaudRate = 921600;
                        } break;
                    default:
                        {
                            throw new Exception("This Baud Rate is not supported.");
                        }
                }

                switch (cfg.DataBits)
                {
                    case "5":
                        {
                            g.serial.DataBits = 5;
                        } break;
                    case "6":
                        {
                            g.serial.DataBits = 6;
                        } break;
                    case "7":
                        {
                            g.serial.DataBits = 7;
                        } break;
                    case "8":
                        {
                            g.serial.DataBits = 8;
                        } break;
                    default:
                        {
                            throw new Exception("This Data Bits is not supported.");
                        }
                }

                switch (cfg.Parity)
                {
                    case "Even":
                        {
                            g.serial.Parity = Parity.Even;
                        } break;
                    case "Mark":
                        {
                            g.serial.Parity = Parity.Mark;
                        } break;
                    case "None":
                        {
                            g.serial.Parity = Parity.None;
                        } break;
                    case "Odd":
                        {
                            g.serial.Parity = Parity.Odd;
                        } break;
                    case "Space":
                        {
                            g.serial.Parity = Parity.Space;
                        } break;
                    default:
                        {
                            throw new Exception("This Parity is not supported.");
                        }
                }

                switch (cfg.StopBits)
                {
                    case "1":
                        {
                            g.serial.StopBits = StopBits.One;
                        } break;
                    case "1.5":
                        {
                            g.serial.StopBits = StopBits.OnePointFive;
                        } break;
                    case "2":
                        {
                            g.serial.StopBits = StopBits.Two;
                        } break;
                    default:
                        {
                            throw new Exception("This Stop Bits is not supported.");
                        }
                }

                switch (cfg.Handshake)
                {
                    case "None":
                        {
                            g.serial.Handshake = Handshake.None;
                        } break;
                    case "RequestToSend":
                        {
                            g.serial.Handshake = Handshake.RequestToSend;
                        } break;
                    case "RequestToSendXOnXOff":
                        {
                            g.serial.Handshake = Handshake.RequestToSendXOnXOff;
                        } break;
                    case "XOnXOff":
                        {
                            g.serial.Handshake = Handshake.XOnXOff;
                        } break;
                    default:
                        {
                            throw new Exception("This HandShake is not supported.");
                        }
                }
                #endregion
                g.serial.ReadBufferSize = g.serial.BaudRate;
                g.serial.WriteBufferSize = g.serial.BaudRate;

                g.serial.Open();
                if (null != OnMsg)
                {
                    OnMsg(this, "CONNECTED", null);
                }
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
                if (null != g.serial)
                {
                    g.serial.Close();
                    if (null != OnMsg)
                    {
                        OnMsg(this, "DISCONNECTED", null);
                    }
                    return 0;
                }
                return -1;
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
                    return g.serial.IsOpen;
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
                    return (g.serial.IsOpen) ? g.serial.BytesToRead : 0;
                }
                catch
                {
                    throw;
                }
            }
        }

        override public object IOCtrl(string type, object cmd)
        {
            return 0;
        }

        void USART_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if(null != OnMsg)
                {
                    OnMsg(this, "READ", null);
                }
            }
            catch (Exception ex)
            {
                if (null != OnError)
                {
                    OnError(this, "USART_DataReceived", ex);
                }
            }
        }

        #region READ
        override public int Read(out byte datum)
        {
            try
            {
                int nCnt = g.serial.Read(g.pReadDatum, 0, 1);
                datum = g.pReadDatum[0];
                return nCnt;
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
                return g.serial.Read(buffer, offset, count);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region WRITE

        override public int Write(byte datum)
        {
            try
            {
                g.pWriteDatum[0] = datum;
                g.serial.Write(g.pWriteDatum, 0, 1);
                return 1;
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
                g.serial.Write(buffer, offset, count);
                return count;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
