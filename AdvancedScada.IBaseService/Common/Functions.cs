using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace AdvancedScada.IBaseService.Common
{
    public class Functions
    {
        private static readonly object mutex = new object();
        private static Functions _instance;
        public static ChannelCount EventChannelCount;

        public static Functions GetFunctions()
        {
            lock (mutex)
            {
                if (_instance == null) _instance = new Functions();
            }

            return _instance;
        }
      


       

      
    }
}