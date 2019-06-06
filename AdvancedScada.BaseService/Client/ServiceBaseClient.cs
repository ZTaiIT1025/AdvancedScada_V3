using System;
using System.Net.Security;
using System.ServiceModel;
using AdvancedScada.DriverBase.Client;
using AdvancedScada.IBaseService;
using AdvancedScada.Management.BLManager;
using Microsoft.Win32;

namespace AdvancedScada.BaseService.Client
{
    
    public class ServiceBaseClient
    {
        public const string CHANNEL = "Channel";
        public static string DriverTypes;
        private static string HOST;
        private static ushort PORT;
        private static ChannelManager objChannelManager;
        private static IReadService Channelclient;
        private static readonly object mutex = new object();
        private static readonly object mutexStartClient = new object();
        private static readonly object mutexCreateChannel = new object();
        private static ServiceBaseClient _instance;

        public ServiceBaseClient()
        {
            objChannelManager = ChannelManager.GetChannelManager();
        }

        public static ServiceBaseClient GetServiceBaseClient()
        {
            lock (mutex)
            {
                if (_instance == null) _instance = new ServiceBaseClient();
            }

            return _instance;
        }

        public static bool LoadTagCollection()
        {
            lock (mutexStartClient)
            {
                objChannelManager = ChannelManager.GetChannelManager();

                try
                {
                  
                    var xmlFile = objChannelManager.ReadKey(objChannelManager.XML_NAME_DEFAULT);
                    if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile))
                    {
                        return false;
                    }

                    objChannelManager.Channels.Clear();
                    TagCollectionClient.Tags.Clear();
                    var channels = objChannelManager.GetChannels(xmlFile);

                    foreach (var ch in channels)
                    foreach (var dv in ch.Devices)
                    foreach (var db in dv.DataBlocks)
                    foreach (var tg in db.Tags)
                        TagCollectionClient.Tags.Add(
                            $"{ch.ChannelName}.{dv.DeviceName}.{db.DataBlockName}.{tg.TagName}", tg);
                }
                catch (Exception ex)
                {
                    var err = new HMIException.ScadaException("ServiceBaseClient", ex.Message);
                }
            }

            return true;
        }

        public static IReadService CreateChannelTools()
        {
            lock (mutexCreateChannel)
            {
                try
                {
                    if (Channelclient != null) return Channelclient;
                    InstanceContext ic = null;
                    HOST = $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "IPAddress", null)}";
                    if (Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "Port", null) == null)
                        return null;
                    PORT = ushort.Parse(
                        $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "Port", null)}");

                    ic = new InstanceContext(new ReadServiceCallbackClient());
                    // Create a channel factory.
                    var b = new NetTcpBinding();
                    b.Security.Mode = SecurityMode.Transport;
                    b.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
                    b.Security.Transport.ProtectionLevel = ProtectionLevel.EncryptAndSign;

                    b.MaxBufferSize = 1000000;
                    b.MaxBufferPoolSize = 1000000;
                    b.MaxReceivedMessageSize = 1000000;
                    b.OpenTimeout = TimeSpan.FromMinutes(2);
                    b.SendTimeout = TimeSpan.FromMinutes(2);
                    b.ReceiveTimeout = TimeSpan.FromMinutes(10);

                    var endPoint =
                        new EndpointAddress(
                            new Uri($"net.Tcp://{HOST}:{PORT}/AdvancedScada/{CHANNEL}"));
                    var factory = new DuplexChannelFactory<IReadService>(ic, b, endPoint);
                    Channelclient = factory.CreateChannel();
                }
                catch (CommunicationException ex)
                {
                    var err = new HMIException.ScadaException("ServiceBaseClient", ex.Message);
                }
            }

            return Channelclient;
        }
    }
}