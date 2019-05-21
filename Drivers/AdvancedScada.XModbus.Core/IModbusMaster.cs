using AdvancedScada.DriverBase;
using HslCommunication;
using System.Threading.Tasks;

namespace AdvancedScada.XModbus.Core
{
    public  interface IModbusMaster : IDriverAdapter
    {

       
       
        OperateResult<bool[]> ReadDiscrete(string address, ushort length);

        new bool Write(string address, dynamic value);

    }
}