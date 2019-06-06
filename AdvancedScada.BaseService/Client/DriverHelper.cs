using AdvancedScada.IBaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedScada.BaseService.Client
{
    public class DriverHelper : BaseBinding
    {
        private static DriverHelper objDriverHelper = null;

        public static string IP_ADDRESS = "127.0.0.1";

        public static string USER_NAME = "";

        public static string PASSWORD = "";

        

        public static DriverHelper GetInstance()
        {
            if (objDriverHelper != null)
            {
                return objDriverHelper;
            }
            return new DriverHelper();
        }

        public IReadService GetReadService()
        {
            try
            {
                InstanceContext callbackInstance = new InstanceContext(new ReadServiceCallbackClient());
                NetTcpBinding netTcpBinding = GetNetTcpBinding();
                EndpointAddress remoteAddress = new EndpointAddress(string.Format(URI_DRIVER, IP_ADDRESS, PORT, "Driver"));
                DuplexChannelFactory<IReadService> duplexChannelFactory = new DuplexChannelFactory<IReadService>(callbackInstance, netTcpBinding, remoteAddress);
                duplexChannelFactory.Credentials.Windows.ClientCredential.UserName = USER_NAME;
                duplexChannelFactory.Credentials.Windows.ClientCredential.Password = PASSWORD;
                return duplexChannelFactory.CreateChannel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IReadService GetReadService(InstanceContext callbackInstance)
        {
            try
            {
                
                NetTcpBinding netTcpBinding = GetNetTcpBinding();
                EndpointAddress remoteAddress = new EndpointAddress(string.Format(URI_DRIVER, IP_ADDRESS, PORT, "Driver"));
                DuplexChannelFactory<IReadService> duplexChannelFactory = new DuplexChannelFactory<IReadService>(callbackInstance, netTcpBinding, remoteAddress);
                duplexChannelFactory.Credentials.Windows.ClientCredential.UserName = USER_NAME;
                duplexChannelFactory.Credentials.Windows.ClientCredential.Password = PASSWORD;
                return duplexChannelFactory.CreateChannel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
