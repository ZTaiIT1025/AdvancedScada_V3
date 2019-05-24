using System;
using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Description;
using AdvancedScada.DriverBase;
using AdvancedScada.IBaseService;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.Management.BLManager;
using Microsoft.Win32;

namespace AdvancedScada.BaseService
{
    public class ServiceBase : IGetServiceBase
    {

        IServiceDriver iServiceDriverAll = null;
        private static readonly object mutex = new object();
        private ushort _SerialNo;
        object mutexStop = new object();
        public ServiceBase()
        {
            objChannelManager = ChannelManager.GetChannelManager();
            RequestsDriver = new Dictionary<string, IServiceDriver>(1024);
        }

        public Dictionary<string, IServiceDriver> RequestsDriver { get; set; }

        public IServiceDriver GetStartService()
        {
           
            try
            {
                HOST = $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "IPAddress", null)}";
                PORT = ushort.Parse(
                    $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "Port", null)}");

                var xmlFile = objChannelManager.ReadKey(objChannelManager.XML_NAME_DEFAULT);
                if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile))
                    return null;
                lock (mutex)
                {
                    RequestsDriver.Clear();
                    objChannelManager.Channels.Clear();
                    TagCollection.Tags.Clear();
                    var channels = objChannelManager.GetChannels(xmlFile);
                    var frame = Functions.GetFunctions();
                    foreach (var item in channels)
                    {
                        iServiceDriverAll =
                            frame.GetAssembly($@"\AdvancedScada.{item.ChannelTypes.Insert(0, "X")}.Core.dll",
                                $"AdvancedScada.{item.ChannelTypes.Insert(0, "X")}.Core.DataService");

                        if (iServiceDriverAll != null)
                            iServiceDriverAll.InitializeService(item);
                    }

                    foreach (var item in channels)
                    {
                        _SerialNo = (ushort) (_SerialNo++ % 255 + 1);
                        iServiceDriverAll =
                            frame.GetAssembly($@"\AdvancedScada.{item.ChannelTypes.Insert(0, "X")}.Core.dll",
                                $"AdvancedScada.{item.ChannelTypes.Insert(0, "X")}.Core.DataService");

                        if (RequestsDriver.ContainsKey(item.ChannelTypes))
                        {
                        }
                        else
                        {
                            RequestsDriver.Add(item.ChannelTypes, iServiceDriverAll);
                            if (iServiceDriverAll != null)
                                iServiceDriverAll.Connect();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var err = new HMIException.ScadaException(GetType().Name, ex.Message);
            }

            return iServiceDriverAll;
        }
        public IServiceDriver GetAssemblyDrivers(string ChannelTypes)
        {
            try
            {

                var frame = Functions.GetFunctions();
                iServiceDriverAll = frame.GetAssembly($@"\AdvancedScada.{ChannelTypes}.Core.dll",
                    $"AdvancedScada.{ChannelTypes}.Core.DataService");
            }
            catch (System.Exception ex)
            {

                var err = new HMIException.ScadaException(this.GetType().Name, ex.Message);
            }
            return iServiceDriverAll;
        }
        public IServiceDriver GetStopService()
        {
            try
            {
                if (objChannelManager == null) return null;
                lock (mutexStop)
                {
                    RequestsDriver.Clear();
                    var channels = objChannelManager.Channels;
                    foreach (var Ch in channels)
                    {
                        iServiceDriverAll = GetAssemblyDrivers(Ch.ChannelTypes.Insert(0, "X"));
                        if (RequestsDriver.ContainsKey(Ch.ChannelTypes))
                        {

                        }
                        else
                        {
                            RequestsDriver.Add(Ch.ChannelTypes, iServiceDriverAll);

                            iServiceDriverAll?.Disconnect();
                        }

                    }


                }
            }
            catch (System.Exception ex)
            {

                var err = new HMIException.ScadaException(this.GetType().Name, ex.Message);
            }
            return iServiceDriverAll;
        }

        public NetTcpBinding GetNetTcpBinding()
        {
            // Create a channel factory.
            NetTcpBinding b;
            b = new NetTcpBinding
            {
                Security =
                {
                    Mode = SecurityMode.Transport,
                    Transport =
                    {
                        ClientCredentialType = TcpClientCredentialType.Windows,
                        ProtectionLevel = ProtectionLevel.EncryptAndSign
                    }
                },
                MaxBufferSize = 1000000,
                MaxBufferPoolSize = 1000000,
                MaxReceivedMessageSize = 2147483647L,
                ReceiveTimeout = TimeSpan.FromMinutes(2.0),
                SendTimeout = TimeSpan.FromMinutes(2.0),
                OpenTimeout = TimeSpan.FromDays(15.0),
                CloseTimeout = TimeSpan.FromDays(15.0)
               
            };
            return b;
        }

        #region Filed

        public const string Driver = "Driver";
        public const string CHANNEL = "Channel";
        public const string DEVICE = "Device";
        public const string DATABLOCK = "DataBlock";
        public const string TAG = "Tag";

        public static ushort PORT = 8090;
        public static string HOST = "localhost";

        public static string UriString = "net.Tcp://{0}:{1}/AdvancedScada/";
        public static IReadService Modbusclient;

        public static bool data = false;
        private readonly ChannelManager objChannelManager;

        #endregion


        #region CreateChannel

        public ServiceHost GetServiceHostHttp()

        {
            ServiceHost Gethost = null;

            Type serviceType = null;
            try
            {
                HOST =
                    $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "IPAddress", null)}";
                PORT = ushort.Parse(
                    $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "Port", null)}");

                serviceType = typeof(ReadService);

                var baseAddresses = new Uri[2]
                {
                    new Uri($"net.Tcp://{HOST}:{PORT}/AdvancedScada/"),
                    new Uri("http://localhost/AdvancedScada")
                };


                Gethost = new ServiceHost(serviceType, baseAddresses);
                var throttle = Gethost.Description.Behaviors.Find<ServiceThrottlingBehavior>();
                if (throttle == null)
                {
                    throttle = new ServiceThrottlingBehavior();
                    throttle.MaxConcurrentCalls = int.MaxValue;
                    throttle.MaxConcurrentSessions = int.MaxValue;
                    throttle.MaxConcurrentInstances = int.MaxValue;
                    Gethost.Description.Behaviors.Add(throttle);
                }


                Gethost.AddServiceEndpoint(typeof(IReadService), GetNetTcpBinding(), Driver);
                Gethost.AddServiceEndpoint(typeof(IReadService), GetNetTcpBinding(), CHANNEL);

                ////Enable metadata exchange
                var smb = new ServiceMetadataBehavior();
                smb.HttpGetUrl = new Uri("http://localhost/AdvancedScada/Driver");
                smb.HttpGetEnabled = true;
                Gethost.Description.Behaviors.Add(smb);
            }
            catch (CommunicationException ex)
            {
                var err = new HMIException.ScadaException(GetType().Name, ex.Message);
            }

            return Gethost;
        }


        public IReadService CreateChannelRealTime()
        {
            try
            {
                InstanceContext ic = null;

                HOST =
                    $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "IPAddress", null)}";
                PORT = ushort.Parse(
                    $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "Port", null)}");

                ic = new InstanceContext(new ReadServiceCallbackClient());

                var endPoint =
                    new EndpointAddress(
                        new Uri($"net.Tcp://{HOST}:{PORT}/AdvancedScada/{Driver}"));
                var factory = new DuplexChannelFactory<IReadService>(ic, GetNetTcpBinding(), endPoint);
                Modbusclient = factory.CreateChannel();
            }
            catch (CommunicationException ex)
            {
                var err = new HMIException.ScadaException(GetType().Name, ex.Message);
            }

            return Modbusclient;
        }

        public IReadService CreateChannel()
        {
            try
            {
                InstanceContext ic = null;
                HOST =
                    $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "IPAddress", null)}";
                PORT = ushort.Parse(
                    $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "Port", null)}");


                ic = new InstanceContext(new ReadServiceCallbackClient());

                var endPoint =
                    new EndpointAddress(
                        new Uri($"net.Tcp://{HOST}:{PORT}/AdvancedScada/{Driver}"));
                var factory = new DuplexChannelFactory<IReadService>(ic, GetNetTcpBinding(), endPoint);
                Modbusclient = factory.CreateChannel();
            }
            catch (CommunicationException ex)
            {
                var err = new HMIException.ScadaException(GetType().Name, ex.Message);
            }

            return Modbusclient;
        }

        #endregion
    }
}