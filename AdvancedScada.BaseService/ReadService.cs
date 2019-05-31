using AdvancedScada.DriverBase;
using AdvancedScada.IBaseService;
using AdvancedScada.IBaseService.Common;
using AdvancedScada.IODriver;
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
        DriverHelper driverHelper = new DriverHelper();
        readonly Functions frame = Functions.GetFunctions();
        private static object mutex = new object();
        
        object mutexStop = new object();
        object mutexUpdate = new object();
        object mutexStart = new object();
        object mutexDispose = new object();
        object mutexWrite = new object();
        private ChannelManager objChannelManager;

       
      
        public ReadService()
        {
           
            objChannelManager = ChannelManager.GetChannelManager();
            
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
               
                lock (mutexWrite)
                {


                    driverHelper?.WriteTag(tagName, value);
                }
            }
            catch (System.Exception ex)
            {

                var err = new HMIException.ScadaException(this.GetType().Name, ex.Message);
            }

        }
      
       
    }
}
