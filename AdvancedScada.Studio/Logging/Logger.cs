using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedScada.Studio.Logging
{
  public   class Logger: INotifyPropertyChanged
    
  {
      public static BindingList<Logger> Loggers = new BindingList<Logger>();
      private int _ID;

      public int ID
      {
          get { return _ID; }
          set
          {
              _ID = value;
              OnPropertyChanged("ID");
          }
      }
      private string _LogType;

      public string LogType
      {
          get { return _LogType; }
          set 
          {
              _LogType = value;
              OnPropertyChanged("LogType");
          }
      }
      private string _TIME;

      public string TIME
      {
          get { return _TIME; }
          set
          {
              _TIME = value;
              OnPropertyChanged("TIME");
          }
      }
      private string _MESSAGE;

      public string MESSAGE
      {
          get { return _MESSAGE; }
          set 
          {
              _MESSAGE = value;
              OnPropertyChanged("MESSAGE");
          }
      }
      public Logger() { }
      public Logger(int _Id, string _logType, string _time, string _message)
      { 
          Logger log=new Logger();
          log.ID = Loggers.Count+1;
         log. LogType = _logType;
         log. TIME = _time;
         log. MESSAGE = _message;

         Loggers.Add(log);
          
      }
      public void WriteToLog(string text)
      {
          Logger.Log(text);
      }
        internal static void Log(string message)
        {
            try
            {
                using (var w = File.AppendText(@"C:\wip\log.txt"))
                {
                    Log(message, w);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(newName));
          
        }
  }
}
