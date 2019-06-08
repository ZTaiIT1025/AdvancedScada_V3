using System;

namespace AdvancedScada.HMIException
{
    public static class Extension
    {
        public static string NameOf(this object o)
        {
            return o.GetType().Name;
        }
    }
   
    public class ScadaException : EventArgs
    {
        public static ConnectionPlc eventConnectionPlc;
        public static ScadaException eventGetErorrPLC;


        public ScadaException()
        {
        }

        public ScadaException(string classname, string errorMessage)
        {

            if (eventGetErorrPLC != null)
                eventGetErorrPLC(classname, errorMessage);
        }
        public ScadaException(bool bPLC)
        {


            if (eventConnectionPlc != null)
                eventConnectionPlc(bPLC);
        }
        public void Dispose()
        {
        }
    }

}
