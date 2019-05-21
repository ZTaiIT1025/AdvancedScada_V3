using System.ComponentModel;

namespace AdvancedScada.DriverBase.Core.DataTypes
{
    public class Memory<T>
    {
        public Memory()
        {
        }

        public Memory(string address, T value)
        {
            Address = address;
            Value = value;
        }

        [DisplayName("Địa chỉ vùng nhớ")] public string Address { get; set; }

        [DisplayName("Nội dung vùng nhớ")] public T Value { get; set; }
    }
}