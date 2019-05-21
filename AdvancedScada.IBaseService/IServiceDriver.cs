using AdvancedScada.DriverBase.Devices;

namespace AdvancedScada.IBaseService
{
    public interface IServiceDriver
    {
        void InitializeService(Channel ch);
        void Connect();
        void Disconnect();
        void WriteTag(string TagName, dynamic Value);
    }
}