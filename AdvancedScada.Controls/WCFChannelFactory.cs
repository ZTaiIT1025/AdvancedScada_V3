using AdvancedScada.BaseService;
using AdvancedScada.BaseService.Client;
using AdvancedScada.DriverBase.Core;
using AdvancedScada.IBaseService;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.Utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;

namespace AdvancedScada.Controls
{
    /// <inheritdoc />
    public class WCFChannelFactory
    {
        private static IReadService client;
        public const string Driver = "Driver";
        public static ushort PORT = 8090;
        public static string HOST = "localhost";
        private static string ChannelTypes = string.Empty;
        static object myLockRead = new object();
        
        public static void Write(string PLCAddressClick, dynamic Value)
        {
            try
            {
                lock (myLockRead)
                {
                    ChannelTypes =
                        $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "ChannelTypes", null)}";
                    var frame = Functions.GetFunctions();
                    IGetServiceBase iServiceDriver = frame.GetAssemblyService(@"\AdvancedScada.BaseService.dll", "AdvancedScada.BaseService.ServiceBase");
                    if (iServiceDriver != null)
                        client = ServiceBaseClient.CreateChannelTools();
                    client.WriteTag(PLCAddressClick, Value);
                }

                Thread.Sleep(50);
            }
            catch (Exception ex)
            {

                var err = new HMIException.ScadaException(typeof(WCFChannelFactory).Name, ex.Message);
            }

        }




    }
}