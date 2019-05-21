using AdvancedScada;
using AdvancedScada.Controls;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
//**********************************************************************************************
//* Generic TCp Client
//*
//* Archie Jacobs
//* Manufacturing Automation, LLC
//* support@advancedhmi.com
//* 19-JAN-18
//*
//* This client will connect to a TCP server and listen for data
//* When data is received, it will buffer until receing the value
//* specified by TerminatingByteValue. At that point it will fire the
//* DataReceived event and send the received data
//* 
//* Copyright 2018 Archie Jacobs
//* Licensed under GPL v3
//*
//* Reference : 
//*
//**********************************************************************************************
namespace AdvancedScada.Controls.Components.SocketClient
{
    [System.ComponentModel.DefaultEvent("DataReceived")]
    public class HMIGenericTCPClient : System.ComponentModel.Component, IDisposable, System.ComponentModel.ISupportInitialize
    {
        private System.Net.Sockets.Socket WorkSocket;

        public event EventHandler<GenericTcpEventArgs> DataReceived;
        public event EventHandler ConnectionClosed;
        public event EventHandler ConnectionEstablished;
        public event EventHandler<MessageEventArgs> ComError;

        private System.Threading.SynchronizationContext m_synchronizationContext;

        private System.Threading.Tasks.Task TestConnectionTask;
        private System.Threading.CancellationTokenSource EndTaskToken = new System.Threading.CancellationTokenSource();




        #region Constructor/Destructors
        public HMIGenericTCPClient()
        {
            //DataReceivedCallBackDelegate = New AsyncCallback(AddressOf DataReceivedCallback)
            m_ProtocolType = System.Net.Sockets.ProtocolType.Tcp;
            m_synchronizationContext = System.Windows.Forms.WindowsFormsSynchronizationContext.Current;
        }



        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                EndTaskToken.Cancel(true);
                TestConnectionTask.Wait();

                CloseConnection();

                if (EndTaskToken != null)
                {
                    EndTaskToken.Dispose();
                }
            }
        }
        #endregion

        #region Properties
        private string m_IPAddress = "192.168.0.1"; //* this is a deafult value
        public string IPAddress
        {
            get
            {
                return m_IPAddress.ToString();
            }
            set
            {
                System.Net.IPAddress address = new System.Net.IPAddress(0);
                if (System.Net.IPAddress.TryParse(m_IPAddress, out address) && System.Net.IPAddress.TryParse(value, out address))
                {
                    if (!(System.Net.IPAddress.Parse(m_IPAddress).Equals(System.Net.IPAddress.Parse(value))))
                    {
                        //* if the address is changed, be sure to disconnect first
                        if (WorkSocket != null && WorkSocket.Connected)
                        {
                            CloseConnection();
                        }
                    }
                }
                else
                {
                    if (m_IPAddress != value)
                    {
                        //* if the address is changed, be sure to disconnect first
                        if (WorkSocket != null && WorkSocket.Connected)
                        {
                            CloseConnection();
                        }
                    }
                }
                m_IPAddress = value;

            }
        }

        private ushort m_Port = 23;
        public ushort Port
        {
            get
            {
                return m_Port;
            }
            set
            {
                if (m_Port != value)
                {
                    if (WorkSocket != null && WorkSocket.Connected)
                    {
                        CloseConnection();
                    }
                    m_Port = value;
                }
            }
        }

        private ProtocolType m_ProtocolType { get; set; } = ProtocolType.Tcp;
        public ProtocolType ProtocolType
        {
            get
            {
                return m_ProtocolType;
            }
            set
            {
                m_ProtocolType = value;
            }
        }

        private byte m_TerminatingByteValue = 13;
        public byte TerminatingByteValue
        {
            get
            {
                return m_TerminatingByteValue;
            }
            set
            {
                m_TerminatingByteValue = value;
            }
        }

        private bool m_AutoConnect = true;
        public bool AutoConnect
        {
            get
            {
                return m_AutoConnect;
            }
            set
            {
                m_AutoConnect = value;
            }
        }
        #endregion


        #region Private Methods
        //*********************************************
        //* Connect to the socket and begin listening
        //* for responses
        //********************************************
        private void Connect()
        {
            System.Net.IPEndPoint endPoint = null;
            System.Net.IPHostEntry IP = null;

            System.Net.IPAddress address = new System.Net.IPAddress(0);
            if (System.Net.IPAddress.TryParse(m_IPAddress, out address))
            {
                endPoint = new System.Net.IPEndPoint(address, m_Port);
            }
            else
            {
                try
                {
                    IP = System.Net.Dns.GetHostEntry(m_IPAddress);
                    //* Ethernet/IP uses port AF12 (44818)
                    endPoint = new System.Net.IPEndPoint(IP.AddressList[0], m_Port);
                }
                catch (Exception ex)
                {
                    throw new FormatException("Can't resolve the address " + m_IPAddress);
                    return;
                }
            }


            if (WorkSocket == null || !WorkSocket.Connected)
            {
                if (m_ProtocolType == System.Net.Sockets.ProtocolType.Tcp)
                {
                    WorkSocket = new System.Net.Sockets.Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    //* Comment these out for Compact Framework
                    WorkSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, 5000);
                    WorkSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                }
                else
                {
                    WorkSocket = new System.Net.Sockets.Socket(endPoint.AddressFamily, SocketType.Dgram, m_ProtocolType);
                }

                WorkSocket.SendTimeout = 2000;
                WorkSocket.ReceiveBufferSize = 0x5000;
            }

            try
            {
                try
                {
                    WorkSocket.Connect(endPoint);
                }
                catch (SocketException ex)
                {
                    //* Return an error code
                    OnComError("Could Not Connect to Server : " + ex.Message);

                    CloseConnection();
                    throw;
                }


                OnConnectionEstablished(System.EventArgs.Empty);

                StartTestThread();
            }
            catch (SocketException ex)
            {
                // 10035 == WSAEWOULDBLOCK
                if (ex.NativeErrorCode.Equals(10035))
                {
                    //Throw
                }
                else
                {
                    throw; //New Exception(m_IPAddress & " " & ex.Message)
                }
            }


            WorkSocket.Blocking = true;
            if (m_ProtocolType == System.Net.Sockets.ProtocolType.Tcp)
            {
                WorkSocket.LingerState = new System.Net.Sockets.LingerOption(true, 1000);
            }


            //* Don't buffer the data, so it goes out immediately
            //* Otherwise packets send really fast will get grouped
            //* And the PLC will not respond to all of them
            WorkSocket.SendBufferSize = 1;

            SocketStateObject so = new SocketStateObject();
            so.WorkSocket = WorkSocket;

            WorkSocket.BeginReceive(so.data, 0, so.data.Length, SocketFlags.None, DataReceivedCallback, so);
        }

        private void StartTestThread()
        {
            if (TestConnectionTask == null || (!(TestConnectionTask.Status == System.Threading.Tasks.TaskStatus.Created) && !(TestConnectionTask.Status == System.Threading.Tasks.TaskStatus.Running) && !(TestConnectionTask.Status == System.Threading.Tasks.TaskStatus.WaitingToRun)))
            {
                TestConnectionTask = System.Threading.Tasks.Task.Factory.StartNew(TestConnection, EndTaskToken.Token);
            }
        }

        //* Runs as a background task to reconnect if connection is lost
        private void TestConnection(object cancelToken)
        {
            System.Threading.CancellationToken token = (System.Threading.CancellationToken)cancelToken;

            while (!token.IsCancellationRequested)
            {
                //Console.WriteLine("Top of While")
                if (AutoConnect)
                {
                    if (WorkSocket != null)
                    {
                        if ((WorkSocket.Poll(2000, SelectMode.SelectRead)) && (WorkSocket.Available == 0))
                        {
                            try
                            {
                                CloseConnection();
                                Connect();
                            }
                            catch (Exception ex)
                            {
                            }
                            //Console.WriteLine(Now & "Open again")
                        }
                    }
                    else
                    {
                        try
                        {
                            Connect();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

                token.WaitHandle.WaitOne(3000);
                //Threading.Thread.SpinWait(2000)
            }
        }

        //************************************************************
        //* Call back procedure - called when data comes back
        //* This is the procedure pointed to by the BeginWrite method
        //************************************************************
        private List<byte> ReceivedDataPacketBuilder = new List<byte>();
        private object DataReceivedLock = new object();
        private void DataReceivedCallback(System.IAsyncResult ar)
        {
            // Retrieve the state object and the client socket 
            // from the asynchronous state object.
            SocketStateObject StateObject = (SocketStateObject)ar.AsyncState;


            //* If the socket was closed, then we cannot do anything
            if (!StateObject.WorkSocket.Connected)
            {
                return;
            }

            //* Get the number of bytes read and add it to the state object accumulator
            try
            {
                //* Add the byte count to the state object
                StateObject.CurrentIndex += StateObject.WorkSocket.EndReceive(ar);
            }
            catch (Exception ex)
            {
                //* Return an error code
                OnComError("Socket Error : " + ex.Message);
                return;
            }

            lock (DataReceivedLock)
            {
                // Console.WriteLine("DataReceived Received - Index=" & StateObject.CurrentIndex)

                //*************************************************************************************************************************
                int i = 0;
                byte CurrentByte = 0;

                while (i < StateObject.CurrentIndex)
                {
                    CurrentByte = StateObject.data[i];

                    if (CurrentByte == m_TerminatingByteValue)
                    {
                        byte[] dataArray = ReceivedDataPacketBuilder.ToArray();
                        string dataString = string.Empty;
                        for (var index2 = 0; index2 < dataArray.Length; index2++)
                        {
                            if (dataArray[index2] >= 32 && dataArray[index2] < 128)
                            {
                                dataString += Microsoft.VisualBasic.Strings.Chr(dataArray[index2]).ToString();
                            }
                        }
                        OnDataReceived(new GenericTcpEventArgs(dataArray, dataString));

                        CurrentByte = 0; //make sure last byte isn't falsely 16
                        ReceivedDataPacketBuilder.Clear();

                    }
                    else
                    {
                        ReceivedDataPacketBuilder.Add(CurrentByte);
                    }

                    i += 1;
                }
            }

            SocketStateObject so = new SocketStateObject(WorkSocket);

            WorkSocket.BeginReceive(so.data, 0, so.data.Length, SocketFlags.None, DataReceivedCallback, so);
        }



        #endregion

        #region Public Methods
        public void CloseConnection()
        {
            try
            {
                if (WorkSocket != null)
                {
                    if (WorkSocket.Connected)
                    {
                        try
                        {
                            WorkSocket.Shutdown(System.Net.Sockets.SocketShutdown.Send);
                        }
                        catch (Exception ex)
                        {
                        }
                        WorkSocket.Close();
                        OnConnectionClosed(System.EventArgs.Empty);
                    }
                    if (WorkSocket != null)
                    {
                        WorkSocket.Dispose();
                        WorkSocket = null;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        //*********************************
        //* Send data out the tcp socket
        //*********************************
        public void SendPacket(byte[] data) //As Boolean ' System.IAsyncResult
        {
            //* connect if it has not been already
            if (data != null)
            {
                if (WorkSocket == null || !WorkSocket.Connected)
                {
                    Connect();
                }


                try
                {
                    WorkSocket.Send(data, data.Length, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    CloseConnection();
                    throw;
                }
            }
        }

        public void SendString(string s)
        {
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(s + Convert.ToString(Microsoft.VisualBasic.Strings.Chr(m_TerminatingByteValue)));
            SendPacket(data);
        }

        public void BeginInit()
        {
        }

        public void EndInit()
        {
            try
            {
                if (!DesignMode && AutoConnect)
                {
                    StartTestThread();
                    //Connect()
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Events
        protected void OnDataReceived(GenericTcpEventArgs e)
        {
            if (m_synchronizationContext != null)
            {
                try
                {
                    m_synchronizationContext.Post(DataReceivedSync, e);
                }
                catch
                {
                }
            }
            else
            {
                if (DataReceived != null)
                    DataReceived(this, e);
            }
        }

        private void DataReceivedSync(object e)
        {
            try
            {
                GenericTcpEventArgs e1 = (GenericTcpEventArgs)e;
                if (DataReceived != null)
                    DataReceived(this, e1);
            }
            catch (Exception ex)
            {
                //Dim dbg = 0
            }
        }


        protected virtual void OnComError(string description)
        {
            if (ComError != null)
                ComError(this, new MessageEventArgs(description));
        }

        protected virtual void OnConnectionClosed(EventArgs e)
        {
            if (ConnectionClosed != null)
                ConnectionClosed(this, e);
        }

        protected virtual void OnConnectionEstablished(EventArgs e)
        {
            if (ConnectionEstablished != null)
                ConnectionEstablished(this, e);
        }
        #endregion
    }
}