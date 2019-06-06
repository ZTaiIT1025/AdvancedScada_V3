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
      
        static object myLockRead = new object();
        
        public static void Write(string PLCAddressClick, dynamic Value)
        {
            try
            {
                lock (myLockRead)
                {
                    client= DriverHelper.GetInstance().GetReadService();
                    if(client != null)
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