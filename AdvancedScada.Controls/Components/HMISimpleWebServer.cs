using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AdvancedScada.Controls.Components
{
    public class HMISimpleWebServer : System.ComponentModel.Component, System.ComponentModel.ISupportInitialize
    {
        private bool InstanceFieldsInitialized = false;

        private void InitializeInstanceFields()
        {
            dcc = CaptureForm;
        }

        private System.Net.Sockets.TcpListener server;
        private bool StopThread;
        private System.Threading.SynchronizationContext m_synchronizationContext;



        #region Constructor
        public HMISimpleWebServer()
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            m_synchronizationContext = System.Windows.Forms.WindowsFormsSynchronizationContext.Current;
        }

        public HMISimpleWebServer(System.Windows.Forms.Form p) : this()
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }

            m_SourceForm = p;
        }


        #endregion

        #region Properties
        private int m_TCPPort = 80;
        public int TCPPort
        {
            get
            {
                return m_TCPPort;
            }
            set
            {
                m_TCPPort = value;
            }
        }

        private bool m_AutoStart = true;
        public bool AutoStart
        {
            get
            {
                return m_AutoStart;
            }
            set
            {
                m_AutoStart = value;
            }
        }

        private int m_RefreshTime = 10;
        public int RefreshTime
        {
            get
            {
                return m_RefreshTime;
            }
            set
            {
                m_RefreshTime = Math.Max(0, value);
            }
        }

        private System.Windows.Forms.Form m_SourceForm;
        public System.Windows.Forms.Form SourceForm
        {
            get
            {
                return m_SourceForm;
            }
            set
            {
                m_SourceForm = value;
            }
        }

        protected ISynchronizeInvoke m_SynchronizingObject;
        //* do not let this property show up in the property window
        // <System.ComponentModel.Browsable(False)> _
        public System.ComponentModel.ISynchronizeInvoke SynchronizingObject
        {
            get
            {
                System.ComponentModel.Design.IDesignerHost host1 = null;
                if ((m_SynchronizingObject == null) && base.DesignMode)
                {
                    host1 = (System.ComponentModel.Design.IDesignerHost)this.GetService(typeof(System.ComponentModel.Design.IDesignerHost));
                    if (host1 != null)
                    {
                        m_SynchronizingObject = (System.ComponentModel.ISynchronizeInvoke)host1.RootComponent;
                    }
                }

                return m_SynchronizingObject;
            }

            set
            {
                if (value != null)
                {
                    m_SynchronizingObject = value;
                }
            }
        }
        #endregion

        #region Public Methods
        public void StartServer()
        {
            if (m_SourceForm == null)
            {
                m_SynchronizingObject = m_SourceForm;
            }

            //* Find the IPV4 address of this computer
            string LocalComputerName = System.Net.Dns.GetHostName(); //* same as My.Computer.Name
            System.Net.IPAddress localAddr = GetIPv4Address(LocalComputerName);

            if (localAddr == null)
            {
                localAddr = System.Net.IPAddress.Parse("127.0.0.1");
            }

            try
            {
                server = new TcpListener(localAddr, m_TCPPort);
                server.Start();
                server.BeginAcceptTcpClient(ConnectionAccepted, server);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        public void StopServer()
        {
            StopThread = true;
            server.Stop();
        }

        #endregion

        #region Private Methods
        public static System.Net.IPAddress GetIPv4Address(string HostName)
        {
            //Check first to see if an IpAddress is being passed
            if (HostName != null && (string.Compare(HostName, string.Empty) != 0))
            {
                try
                {
                    System.Net.IPAddress IPAddress = new System.Net.IPAddress(0);
                    if (System.Net.IPAddress.TryParse(HostName, out IPAddress))
                    {
                        return IPAddress;
                    }
                }
                catch (Exception ex)
                {
                }
            }



            //* If it is blank, then use this computer's name
            if (string.IsNullOrEmpty(HostName))
            {
                HostName = System.Net.Dns.GetHostName();
            }

            //* Get The IP Address list from the Host
            System.Net.IPHostEntry IP = System.Net.Dns.GetHostEntry(HostName);

            //* Find the IPv4 address of this PC and use those as the first 4 bytes of the 
            //* source AMS Net ID. Just to help find source of queries on TwinCAT pc
            int i = 0;
            int FirstFind = 0;
            while (FirstFind < IP.AddressList.Length && (IP.AddressList[FirstFind].GetAddressBytes().Length != 4))
            {
                FirstFind += 1;
            }

            //* Let's look for an IP on the same subnet
            i = FirstFind;
            while (i < IP.AddressList.Length && (IP.AddressList[i].GetAddressBytes().Length != 4))
            {
                i += 1;
            }

            if (i < IP.AddressList.Length)
            {
                return IP.AddressList[i];
            }
            else if (FirstFind < IP.AddressList.Length)
            {
                return IP.AddressList[FirstFind];
            }
            else
            {
                //Throw New MfgControl.AdvancedHMI.Drivers.Common.PLCDriverException("Un-resolvable address " & HostName)
            }

            return null;
        }

        private void ConnectionAccepted(IAsyncResult ar)
        {
            if (!StopThread)
            {
                // Dim listener As TcpListener = CType(ar.AsyncState, TcpListener)
                TcpClient client = server.EndAcceptTcpClient(ar);

                byte[] bytes = new byte[1025];

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                int i = stream.Read(bytes, 0, bytes.Length);


                string header = "<html xmlns : msxsl = \"urn:schemas-Microsoft - com: xslt\"  meta content=\"en-us\" http-equiv=\"Content-Language\" /> " + "<meta content=\"text/html; charset=utf-16\" http-equiv=\"Content-Type\" /> " + "<meta http-equiv=\"refresh\" content=\"" + m_RefreshTime.ToString() + "\"> ";

                header += "<img src=\"data:image/png;base64,";
                byte[] b = System.Text.ASCIIEncoding.Default.GetBytes(header);
                stream.Write(b, 0, b.Length);

                byte[] Imgbytes = null;
                bmpScreenCapture = new Bitmap(m_SourceForm.Width, m_SourceForm.Height);
                m_SourceForm.Invoke(dcc);
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    bmpScreenCapture.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    Imgbytes = ms.ToArray();
                }

                string s = Convert.ToBase64String(Imgbytes);
                Imgbytes = System.Text.ASCIIEncoding.Default.GetBytes(s);
                try
                {
                    stream.Write(Imgbytes, 0, Imgbytes.Length);

                    string trailer = " \"/>";
                    b = System.Text.ASCIIEncoding.Default.GetBytes(trailer);
                    stream.Write(b, 0, b.Length);


                    // Shutdown and end connection
                    client.Close();
                }
                catch (Exception ex)
                {
                }
            }

            if (!StopThread)
            {
                server.BeginAcceptTcpClient(ConnectionAccepted, server);
            }
        }

        private Bitmap bmpScreenCapture;
        public delegate void CaptureFormDelegate();
        private CaptureFormDelegate dcc;
        private void CaptureForm()
        {
            m_SourceForm.DrawToBitmap(bmpScreenCapture, new Rectangle(0, 0, m_SourceForm.Width, m_SourceForm.Height));

            //    CaptureScreen.
        }
        #endregion

        #region Initializing
        public void BeginInit()
        {
            //Throw New NotImplementedException()
        }

        public void EndInit()
        {
            if (!this.DesignMode && m_AutoStart)
            {
                StartServer();
            }
        }
        #endregion

    }
}
