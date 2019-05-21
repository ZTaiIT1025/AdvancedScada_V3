using System;

namespace AdvancedScada.Logger
{


    public delegate void GetLoggerPLC(int _Id, string _logType, string _time, string _message);
    public class ScadaLogger : EventArgs
    {

        public static GetLoggerPLC eventGetLoggerPLC;


        public ScadaLogger()
        {
        }

        public ScadaLogger(int _Id, string _logType, string _time, string _message)
        {

            if (eventGetLoggerPLC != null)
                eventGetLoggerPLC(_Id, _logType, _time, _message);
        }

         
    }
}
