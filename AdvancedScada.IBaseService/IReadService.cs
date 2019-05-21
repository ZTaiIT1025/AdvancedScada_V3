using System.ServiceModel;

namespace AdvancedScada.IBaseService
{
    public delegate void ChannelCount(int channelCount, bool isNew);

    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IServiceCallback))]
    public interface IReadService
    {
        [OperationContract(IsOneWay = true)]
        void Connection();

        [OperationContract(IsOneWay = true)]
        void Disconnection();

        [OperationContract(IsOneWay = true)]
        void WriteTag(string tagName, dynamic value);
    }
}