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
                throw ex;
                
            }

        }
        public bool GetStartService()
        {
            var objChannelManager = ChannelManager.GetChannelManager();
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
                var err = new HMIException.ScadaException(GetType().Name, ex.Message);
            }

            return true;
        }

        public bool GetStopService()
        {
            try
            {

               

                    driverHelper.Disconnect();

               
            }
            catch (System.Exception ex)
            {

                var err = new HMIException.ScadaException(this.GetType().Name, ex.Message);
            }
            return true;
        }
    }
}
