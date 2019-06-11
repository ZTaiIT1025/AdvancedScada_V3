using AdvancedScada.DriverBase;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace AdvancedScada.IBaseService.Common
{
    public static class Extension
    {
        public static string NameOf(this object o)
        {
            return o.GetType().Name;
        }
    }
    public class XCollection
    {
        public static ScadaException EventscadaException;
        public static ScadaLogger EventscadaLogger;
        public static ChannelCount EventChannelCount;
        public static EventLoggingMessage eventLoggingMessage;
        public static Machine CURRENT_MACHINE = null;






    }
}