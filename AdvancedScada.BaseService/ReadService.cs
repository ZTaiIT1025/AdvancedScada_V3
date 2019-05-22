using AdvancedScada.DriverBase;
using AdvancedScada.IBaseService;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.Management.BLManager;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using System.Timers;
using static AdvancedScada.IBaseService.Common.Functions;

namespace AdvancedScada.BaseService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession)]
    public class ReadService : IReadService
    {
        private bool RUN_APPLICATION;
      
        public IServiceCallback EventDataChanged;
        public IServiceDriver iServiceDriver = null;
        readonly Functions frame = Functions.GetFunctions();
        private static object mutex = new object();
        private static ReadService _instance;
        object mutexStop = new object();
        object mutexUpdate = new object();
        object mutexStart = new object();
        object mutexDispose = new object();
        object mutexWrite = new object();
        private ChannelManager objChannelManager;

        public static ReadService GetReadService()
        {
            lock (mutex)
            {
                if (_instance == null)
                {
                    _instance = new ReadService();
                }
            }

            return _instance;
        }
      
        public ReadService()
        {
           
            objChannelManager = ChannelManager.GetChannelManager();
            
        }
        public IServiceDriver GetAssemblyDrivers(string ChannelTypes)
        {
            try
            {


                iServiceDriver = frame.GetAssembly($@"\AdvancedScada.{ChannelTypes}.Core.dll",
                    $"AdvancedScada.{ChannelTypes}.Core.DataService");
            }
            catch (System.Exception ex)
            {

                var err = new HMIException.ScadaException(this.GetType().Name, ex.Message);
            }
            return iServiceDriver;
        }
       
        public void Connection()
        {
            try
            {
                lock (mutexStart)
                {

                    EventDataChanged = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
                    EventChannelCount?.Invoke(1, true);
                    RUN_APPLICATION = true;
                }
                ThreadPool.QueueUserWorkItem(delegate
                {
                    while (RUN_APPLICATION)
                    {
                        try
                        {
                            if (EventDataChanged != null)
                            {
                                // Query the channel state. For example:-

                                var state = (EventDataChanged as IChannel).State;
                                if (state == CommunicationState.Closed || state == CommunicationState.Faulted)
                                {
                                    // Channel has closed, or has faulted...
                                    EventDataChanged = null;
                                    EventChannelCount?.Invoke(1, false);
                                }
                                else
                                {

                                    EventDataChanged?.DataTags(TagCollection.Tags);
                                }
                            }
                            Thread.Sleep(100);
                        }
                        catch (Exception ex)
                        {
                            RUN_APPLICATION = false;
                            var err = new HMIException.ScadaException(this.GetType().Name, ex.Message);
                        }
                    }
                });
            }
            catch (System.Exception ex)
            {

                var err = new HMIException.ScadaException(this.GetType().Name, ex.Message);
            }

        }

        public void Disconnection()
        {
            try
            {
                RUN_APPLICATION = false;
                EventDataChanged = null;
                EventChannelCount?.Invoke(1, false);
                
            }
            catch (System.Exception ex)
            {

                var err = new HMIException.ScadaException(this.GetType().Name, ex.Message);
            }

        }

        public void WriteTag(string tagName, dynamic value)
        {
            try
            {
                if (objChannelManager == null) return;
                lock (mutexWrite)
                {


                    var strArrays = tagName.Split('.');
                    var str = $"{strArrays[0]}.{strArrays[1]}";
                    foreach (var Channels in objChannelManager.Channels)
                    {
                        foreach (var dv in Channels.Devices)
                        {
                            var bEquals = $"{Channels.ChannelName}.{dv.DeviceName}".Equals(str);
                            if (bEquals)
                            {
                                iServiceDriver = GetAssemblyDrivers(Channels.ChannelTypes.Insert(0, "X"));

                                iServiceDriver?.WriteTag(tagName, value);

                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {

                var err = new HMIException.ScadaException(this.GetType().Name, ex.Message);
            }

        }
      
       
    }
}
