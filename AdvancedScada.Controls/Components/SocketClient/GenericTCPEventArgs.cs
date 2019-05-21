using AdvancedScada;
using AdvancedScada.Controls;
using System;

namespace AdvancedScada.Controls.Components.SocketClient
{
    public class GenericTcpEventArgs : System.EventArgs
    {
        public GenericTcpEventArgs()
        {
        }

        public GenericTcpEventArgs(byte[] data)
        {
            m_Data = data;
        }

        public GenericTcpEventArgs(byte[] data, string receivedString) : this(data)
        {
            m_DataAsString = receivedString;
        }

        private byte[] m_Data;
        public byte[] Data
        {
            get
            {
                return m_Data;
            }
            set
            {
                m_Data = value;
            }
        }

        private string m_DataAsString;
        public string DataAsString
        {
            get
            {
                return m_DataAsString;
            }
            set
            {
                m_DataAsString = value;
            }
        }
    }
}