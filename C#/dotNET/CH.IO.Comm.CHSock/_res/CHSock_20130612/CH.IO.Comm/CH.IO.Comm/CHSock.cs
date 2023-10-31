using System;
using System.Threading;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;


namespace CH.IO.Comm
{
    public class CHSock : DEVICE
    {
        /*
        ****************************************************************
        * override event implementation
        ****************************************************************
        */
        public override event MsgEventHandler OnMsg = null;
        public override event ErrorEventHandler OnError = null;

        /*
        ****************************************************************
        * Definition of Global Variable
        ****************************************************************
        */
        private class Variable
        {
            public SockState sockState = SockState.Connecting;
            public Socket sock = null;
            public CONFIG config = null;
            public CQBuf<byte> rxQ = null;
            public byte[] rxTmp = null;
            public bool notifyReconnection = true;
            public Exception err;

            public BackgroundWorker thConn = null;
            public bool isContinue = false;
        }

        private enum SockState
        {
            Connecting, Connected, Close
        }

        Variable g;

        /*
        ****************************************************************
        * CHSock Configuration & Messages
        ****************************************************************
        */
        public class CONFIG : DEVICE_CONFIG
        {
            // Server(Receiver) or Client(Caller)
            public bool isServer = false;
            // If disconnection break out, how many does CHSock try to reconnect?
            public int numReconnect = 10;
            // Delay time between reconnection trials
            public int delayReconnect = 500;
            // Tx Buffer Size: Socket Buffer Size
            public int txBufSize = 65535;
            // Rx Buffer Size: Socket Buffer Size and RxQ Size
            public int rxBufSize = 65535;
            // Tx Timeout
            public int txTimeout = 5000;
            // Rx Timeout
            public int rxTimeout = 5000;
            // Port number
            public int port = 50000;
            // IP Address
            public string ip = "127.0.0.1";
        }

        /// <summary>
        /// Messages[CONNECTED, CONNECTING, CLOSE, READ]
        ///  - CONNECTED: Socket Connected to Remote Socket
        ///  - CONNECTING: Currently, Socket is not connected, so CHSock is trying to connect
        ///  - CLOSE: Socket is closed normally
        ///  - READ: CHSock have received data
        /// </summary>
        public static string[] Message =
        {
            "CONNECTED", "CONNECTING", "CLOSE", "READ"
        };

        /*
        ****************************************************************
        * Constructor
        ****************************************************************
        */
        public CHSock()
        {
        }

        /*
        ****************************************************************
        * override function implementation
        ****************************************************************
        */
        override public int Open(DEVICE_CONFIG config)
        {
            CONFIG cfg = (CONFIG)config;
            Close();
            InitVR(cfg);

            try
            {
                g.isContinue = true;
                g.thConn = new BackgroundWorker();
                g.thConn.DoWork += new DoWorkEventHandler(DoWork);
                g.thConn.ProgressChanged +=
                    new ProgressChangedEventHandler(ProgressChanged);
                g.thConn.WorkerReportsProgress = true;
                g.thConn.RunWorkerAsync();

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
                if (g != null && g.sock != null)
                {
                    g.sockState = SockState.Close;
                    g.sock.Shutdown(SocketShutdown.Both);
                    g.sock.Close();
                    g.sock = null;
                }
                Thread.Sleep(250); // wait until thread is finished //

                return 0;
            }
            catch(Exception e)
            {
                Trace.WriteLine("CHSock.Close().Err= " + e.Message);
                throw;
            }
        }

        override public int Read(out byte datum)
        {
            try
            {
                return g.rxQ.Dequeue(out datum);
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
                return g.rxQ.Dequeue(buffer, offset, count);
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
                if (g.sockState != SockState.Connected)
                    return 0;

                byte[] dt = new byte[] { datum };
                return g.sock.Send(dt, SocketFlags.None);
            }
            catch (SocketException ex)
            {
                Trace.WriteLine("CHSock.Write().Err= " + ex.Message);
                this.Reconnecting(ex);
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
                if (g.sockState != SockState.Connected)
                    return 0;

                return g.sock.Send(buffer, offset, count, 
                    SocketFlags.None);
            }
            catch (SocketException ex)
            {
                Trace.WriteLine("CHSock.Write().Err= " + ex.Message);
                this.Reconnecting(ex);
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
                return null;
            }
            catch
            {
                throw;
            }
        }

        /*
        ****************************************************************
        * override properties implementation
        ****************************************************************
        */
        override public bool IsOpen
        {
            get
            {
                if (g.sockState == SockState.Connected)
                    return true;
                else return false;
            }
        }

        override public int ByteToRead
        {
            get { return g.rxQ.Count; }
        }

        /*
        ****************************************************************
        * Utilities
        ****************************************************************
        */
        private void InitVR(CONFIG cfg)
        {
            try
            {
                LookCfg(cfg);

                g = new Variable();
                g.config = cfg;
                g.rxQ = new CQBuf<byte>(cfg.rxBufSize);
                g.rxTmp = new byte[cfg.rxBufSize];
            }
            catch
            {
                throw;
            }
        }

        private void LookCfg(CONFIG cfg)
        {
            if (cfg.rxBufSize == 0 || cfg.txBufSize == 0)
                throw new Exception("BufSize cannot be 0");
        }

        private void Connect()
        {
            try
            {
                if (g.sock != null)
                    g.sock.Close();

                g.sock = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);
                //
                // setting properties of socket
                g.sock.SendBufferSize = g.config.txBufSize;
                g.sock.ReceiveBufferSize = g.config.rxBufSize;
                if(g.config.txTimeout > 0)
                    g.sock.SendTimeout = g.config.txTimeout;
                if(g.config.rxTimeout > 0)
                    g.sock.ReceiveTimeout = g.config.rxTimeout;

                g.sock.Connect(new IPEndPoint(
                    IPAddress.Parse(g.config.ip),
                    g.config.port));

                g.sockState = SockState.Connected;                
            }
            catch(Exception ex)
            {
                Trace.WriteLine("CHSock.Connect().Err= " + ex.Message);
                throw;
            }
        }

        private void Accept()
        {
            try
            {
                if (g.sock != null) g.sock.Close();

                Socket listen = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);
                listen.Bind(new IPEndPoint(IPAddress.Any,
                    g.config.port));
                listen.Listen(1);

                g.sock = listen.Accept(); // waiting //
                //
                // setting properties of socket
                g.sock.SendBufferSize = g.config.txBufSize;
                g.sock.ReceiveBufferSize = g.config.rxBufSize;
                if(g.config.txTimeout > 0)
                    g.sock.SendTimeout = g.config.txTimeout;
                if(g.config.rxTimeout > 0)
                    g.sock.ReceiveTimeout = g.config.rxTimeout;

                g.sockState = SockState.Connected;
                g.notifyReconnection = true;
                
                listen.Close();
                listen = null;
            }
            catch(Exception ex)
            {
                Trace.WriteLine("CHSock.Accept().Err= " + ex.Message);
                throw;
            }
        }

        private void Receiving()
        {
            int size = 0;

            try
            {
                if ((size = g.sock.Receive(g.rxTmp)) > 0)
                    g.rxQ.Enqueue(g.rxTmp, 0, size);
                else // Normal Close //
                {
                    g.sockState = SockState.Close;
                }
            }
            catch (SocketException se) // Socket Exception //
            {
                switch (se.ErrorCode)
                {
                    case 10004: //////////////// interrupt //
                        Trace.WriteLine(
                            "CHSock.Receiving().SockErr(10004)= " 
                            + se.Message);
                        break;

                    case 10060: ////////////////// timeout //
                        Trace.WriteLine("10060");
                        g.err = new Exception("Timeout-Rx(10060)");
                        g.err.Source = "CHSock.Notify";
                        break;

                    default: /////// Not handled Exception //
                        g.err = se;
                        g.err.Source = "CHSock.Receiving.SockErr";
                        g.sockState = SockState.Connecting;
                        break;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine("CHSock: " + e.Message);
                g.err = e;
                g.err.Source = "CHSock.Receiving.Err";
                g.sockState = SockState.Close;
            }
        }

        private void Reconnecting(Exception e)
        {
            try
            {
                if (g.sock != null) 
                    g.sock.Close();

                g.sockState = SockState.Connecting;

                OnMsg(this, Message[1], e.Message);
            }
            catch(Exception ex)
            {
                Trace.WriteLine("CHSock.Reconnecting().Err= " + ex.Message);
                throw;
            }
        }

        /*
        ****************************************************************
        * Thread Implementation
        ****************************************************************
        */
        private void DoWork(object sender, EventArgs e)
        {
            while (g.isContinue == true)
            {
                switch (g.sockState) //////////
                {
                    case SockState.Connected: /**** Socket State is Connected */
                        try
                        {
                            Receiving();
                            if(g.sockState == SockState.Connected)
                                if (g.rxQ.Count > 0)
                                {
                                    g.thConn.ReportProgress(1);
                                }
                            
                            if (g.err != null)
                                g.thConn.ReportProgress(1);
                        }
                        catch(Exception ex)
                        {
                            g.err = ex;
                            g.sockState = SockState.Close;
                            g.thConn.ReportProgress(1);
                        }
                        break;

                    case SockState.Connecting:/** Socket is trying to connect */
                        if (g.config.isServer == true) ///////// Server //
                        {
                            try
                            {
                                Accept();
                                g.thConn.ReportProgress(1);
                            }
                            catch
                            {
                                g.sockState = SockState.Close;
                            }
                        }
                        else /////////////////////////////////// Client //
                        {
                            int n = g.config.numReconnect;
                            for (int i = 0; i < n; i++)
                                try
                                {
                                    Connect();
                                    if (g.sockState == SockState.Connected)
                                    {
                                        g.notifyReconnection = true;
                                        g.thConn.ReportProgress(1);
                                        break;
                                    }
                                }
                                catch (SocketException ex)
                                {
                                    // fail to reconnect //
                                    Trace.WriteLine(
                                        "CHSock.DoWork().Connecting.Err= " 
                                        + ex.Message);

                                    g.thConn.ReportProgress(1);
                                    Thread.Sleep(g.config.delayReconnect);
                                }
                                catch (Exception)
                                {
                                    throw;
                                }

                            if (g.sockState == SockState.Connecting)
                                g.sockState = SockState.Close;
                        }
                        break;

                    case SockState.Close: /*** The Connection is over totally */
                        g.isContinue = false;
                        Close();
                        g.thConn.ReportProgress(1);
                        break;
                } // End of switch ////////////
                Thread.Sleep(100);
            } // while //
        }

        private void ProgressChanged(object sender, EventArgs e)
        {
            switch (g.sockState)
            {
                case SockState.Close: //////////////////////////
                    try
                    {
                        OnMsg(this, Message[2], null);
                        if (g.err != null)
                        {
                            OnError(this, g.err.Source, g.err);
                            g.err = null;
                        }
                    }
                    catch(Exception ex)
                    {
                        OnError(this, ex.Message, ex);
                    }
                    break;

                case SockState.Connecting: ////////////////////
                    try
                    {
                        OnMsg(this, Message[1], null);
                        if (g.err != null)
                        {
                            OnError(this, g.err.Source, g.err);
                            g.err = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        OnError(this, ex.Message, ex);
                    }
                    break;

                case SockState.Connected: //////////////////////
                    try
                    {
                        if (g.notifyReconnection == true)
                        {
                            g.notifyReconnection = false;
                            OnMsg(this, Message[0], null);
                        }
                        if (g.rxQ.Count > 0)
                        {
                            OnMsg(this, Message[3], null);
                        }
                        if (g.err != null)
                        {
                            OnError(this, g.err.Source, g.err);
                            g.err = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        OnError(this, ex.Message, ex);
                    }
                    break;
            } // switch //
        } // End of ProgressChanged() //
    }
}
