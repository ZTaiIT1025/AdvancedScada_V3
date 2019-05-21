using System.Collections.Generic;
using System.ServiceModel;
using AdvancedScada.DriverBase.Devices;

namespace AdvancedScada.IBaseService
{
    [ServiceContract]
    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void DataTags(Dictionary<string, Tag> Tags);
    }
}