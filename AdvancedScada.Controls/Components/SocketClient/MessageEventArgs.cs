using AdvancedScada;
using AdvancedScada.Controls;
using System;

namespace AdvancedScada.Controls.Components.SocketClient
{
    public class MessageEventArgs : System.EventArgs
    {
        public MessageEventArgs() : base()
        {
        }

        public MessageEventArgs(string message) : this()
        {
            m_Message = message;
        }

        private string m_Message;
        public string Message
        {
            get
            {
                return m_Message;
            }
            set
            {
                m_Message = value;
            }
        }
    }
}