using AdvancedScada.DriverBase;
using System.ServiceModel;

namespace AdvancedScada.IBaseService
{
    public delegate void ChannelCount(int channelCount, bool isNew);
    public delegate void EventLoggingMessage(string message);

    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IServiceCallback))]
    public interface IReadService
    {
        [OperationContract(IsOneWay = true)]
        void Connect(Machine mac);

        [OperationContract(IsOneWay = true)]
        void Disconnect(Machine mac);

        [OperationContract(IsOneWay = true)]
        void WriteTag(string tagName, dynamic value);
    }
}