using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IODriverV2
{
     
    public class SerialPortAdapter
    {

        private const int READ_BUFFER_SIZE = 1024; // .

        private const int WRITE_BUFFER_SIZE = 1024; // .

        private byte[] bufferReceiver = null;

        private string bufferMsgReceiver = null;

        private SerialPort serialPort;

        public SerialPortAdapter(SerialPort serialPort)
        {
            bufferReceiver = new byte[READ_BUFFER_SIZE];
            this.serialPort = serialPort;
        }

        public bool Connect()
        {
            if (this.serialPort.IsOpen) this.serialPort.Close();
            this.serialPort.Open();
            return true;
        }

        public void Close()
        {
            if (this.serialPort.IsOpen) this.serialPort.Close();
        }

        public byte[] Read()
        {
            if (this.serialPort.BytesToRead >= 5)
            {
                bufferReceiver = new byte[this.serialPort.BytesToRead];
                int result = this.serialPort.Read(bufferReceiver, 0, this.serialPort.BytesToRead);
                this.serialPort.DiscardInBuffer();
            }
            return bufferReceiver;
        }

        public string ReadLine()
        {
            if (this.serialPort.BytesToRead >= 11)
            {
                bufferMsgReceiver = this.serialPort.ReadLine();
                this.serialPort.DiscardInBuffer();
            }
            return bufferMsgReceiver;
        }

        public void Write(byte[] data, int offset, int size)
        {
            this.serialPort.Write(data, offset, size);
            this.serialPort.DiscardOutBuffer();
        }

        public void WriteLine(string data)
        {
            this.serialPort.WriteLine(data);
            this.serialPort.DiscardOutBuffer();
        }

        internal string ReadExisting()
        {
            throw new NotImplementedException();
        }
    }
    public  class EthernetAdapter
    {
        private const int READ_BUFFER_SIZE = 2048; // .

        private const int WRITE_BUFFER_SIZE = 2048; // .

        private byte[] bufferReceiver = null;
        private byte[] bufferSender = null;

        //private IPEndPoint server = null;

        private Socket mSocket = null;

        private string IP = "127.0.0.1";
        private int Port = 502;
        private int ConntectTimeout = 3000;


        public EthernetAdapter(string ip = "127.0.0.1", int port = 502)
        {
            this.IP = ip;
            this.Port = port;

        }

        public EthernetAdapter(string ip, short port, int conntectTimeout)
            : this(ip, port)
        {
            this.SetTimeout(conntectTimeout);
        }

        public bool  Connect()
        {
            try
            {
                this.mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.bufferReceiver = new byte[READ_BUFFER_SIZE];
                this.bufferSender = new byte[WRITE_BUFFER_SIZE];
                this.mSocket.SendBufferSize = READ_BUFFER_SIZE;
                this.mSocket.ReceiveBufferSize = WRITE_BUFFER_SIZE;
                IPEndPoint server = new IPEndPoint(IPAddress.Parse(this.IP), this.Port);
                this.mSocket.Connect(server);
                ////this.mSocket.NoDelay = false;
                //newsock.BeginConnect(server, new AsyncCallback(Connected), newsock);                
            }
            catch (SocketException ex)
            {
                throw ex;
            }
            return true;
        }

        public void Close()
        {
            if (this.mSocket == null) return;
            if (this.mSocket.Connected)
            {
                this.mSocket.Close();
            }
        }

        public void SetTimeout(int conntectTimeout)
        {
            this.ConntectTimeout = conntectTimeout;
        }

        public int Write(byte[] frame)
        {
            try
            {
                return this.mSocket.Send(frame, frame.Length, SocketFlags.None);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public byte[] Read()
        {
            try
            {
                NetworkStream ns = new NetworkStream(this.mSocket);

                if (ns.CanRead)
                {
                    int rs = this.mSocket.Receive(this.bufferReceiver, this.bufferReceiver.Length, SocketFlags.None);
                }
                return this.bufferReceiver;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        private Socket client;

        private void Connected(IAsyncResult iar)
        {
            client = (Socket)iar.AsyncState;
            try
            {
                client.EndConnect(iar);
                //conStatus.Text = "Connected to: " + client.RemoteEndPoint.ToString();
                client.BeginReceive(bufferReceiver, 0, READ_BUFFER_SIZE, SocketFlags.None,
                              new AsyncCallback(ReceiveData), client);
            }
            catch (SocketException ex)
            {
                throw ex;
            }
        }

        private void ReceiveData(IAsyncResult iar)
        {
            try
            {
                Socket remote = (Socket)iar.AsyncState;
                int recv = remote.EndReceive(iar);
                //string stringData = Encoding.ASCII.GetString(data, 0, recv);
                //results.Items.Add(stringData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SendData(IAsyncResult iar)
        {
            try
            {
                Socket remote = (Socket)iar.AsyncState;
                int sent = remote.EndSend(iar);
                remote.BeginReceive(this.bufferSender, 0, WRITE_BUFFER_SIZE, SocketFlags.None,
                              new AsyncCallback(ReceiveData), remote);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
