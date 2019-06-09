using AdvancedScada.DriverBase;
using AdvancedScada.IBaseService;
using AdvancedScada.IODriver;
using AdvancedScada.Management.BLManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.BaseService
{
    public class DriverService : BaseBinding
    {
        DriverHelper driverHelper = new DriverHelper();
        public ServiceHost InitializeReadService()
        {
            ServiceHost serviceHost = null;
           
            try
            {
                string address = string.Format(URI_DRIVER, Environment.MachineName, PORT, "Driver");
                NetTcpBinding netTcpBinding = GetNetTcpBinding();
                serviceHost = new ServiceHost(typeof(ReadService));
                serviceHost.AddServiceEndpoint(typeof(IReadService), netTcpBinding, address);
               
                 return serviceHost;
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                
            }
            return serviceHost;
        }
        public bool GetStartService()
        {
            var objChannelManager = ChannelService.GetChannelManager();
            try
            {

                var xmlFile = objChannelManager.ReadKey(objChannelManager.XML_NAME_DEFAULT);
                if (string.IsNullOrEmpty(xmlFile) || string.IsNullOrWhiteSpace(xmlFile)) return false;

             
                    objChannelManager.Channels.Clear();
                    TagCollection.Tags.Clear();
                    var channels = objChannelManager.GetChannels(xmlFile);


                    driverHelper.InitializeService(channels);
                    driverHelper.Connect();



                    return true;

               
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
            return true;

        }

        public bool GetStopService()
        {
            try
            {

               

                    driverHelper.Disconnect();

               return true;
            }
            catch (System.Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
            return true;
        }
    }
}
