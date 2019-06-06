using AdvancedScada.DriverBase.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedScada.IBaseService
{
    [ServiceContract]
    public  interface IChannelService
    {
        [OperationContract]
        List<Channel> GetChannelsWcf();
    }
}
