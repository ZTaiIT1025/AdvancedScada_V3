using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


namespace Core.DataTypes
{
    public class Memory<T>
    {
        
        private string _Address;

        private T _Value;

        public Memory() { }

        public Memory(string address, T value) 
        {
            this.Address = address;
            this.Value = value;
        }

        [DisplayName("Địa chỉ vùng nhớ")]
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        [DisplayName("Nội dung vùng nhớ")]
        public T Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
}
