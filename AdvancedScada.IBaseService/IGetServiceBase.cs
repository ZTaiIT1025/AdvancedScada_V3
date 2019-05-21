using System.ServiceModel;

namespace AdvancedScada.IBaseService
{
    public interface IGetServiceBase
    {
        IServiceDriver GetStartService();
        IServiceDriver GetStopService();
        ServiceHost GetServiceHostHttp();
        IReadService CreateChannelRealTime();
        IReadService CreateChannel();
    }
}