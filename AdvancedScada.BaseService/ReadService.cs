using AdvancedScada.DriverBase;
using AdvancedScada.IBaseService;
using AdvancedScada.IODriver;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.BaseService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession)]
    public class ReadService : IReadService
    {
        private bool RUN_APPLICATION;

       
        DriverHelper driverHelper = new DriverHelper();

        public void Connect(Machine mac)
        {
            try
            {


                IServiceCallback EventDataChanged = OperationContext.Current.GetCallbackChannel<IServiceCallback>();
                eventLoggingMessage?.Invoke(string.Format("Added Callback Channel: {0}, IP Address: {1}.", mac.MachineName, mac.IPAddress));
                EventChannelCount?.Invoke(1, true);
                    RUN_APPLICATION = true;

                ThreadPool.QueueUserWorkItem((WaitCallback)delegate
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

                            eventLoggingMessage?.Invoke(string.Format("Removed Callback Channel: {0}, IP Address: {1}| Message Exception: {2}.", mac.MachineName, mac.IPAddress, ex.Message));

                           EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                        }
                    }
                });
            }
            catch (System.Exception ex)
            {
               
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        public void Disconnect(Machine mac)
        {
            
            try
            {
                RUN_APPLICATION = false;
                EventChannelCount?.Invoke(1, false);
                OperationContext.Current.GetCallbackChannel<IServiceCallback>();
                eventLoggingMessage?.Invoke(string.Format("Removed Callback Channel: {0}, IP Address: {1}.", mac.MachineName, mac.IPAddress));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Disconnect-Removed Callback Channel: {0}", ex.Message);
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
            finally
            {
                GC.SuppressFinalize(this);
            }
        }

        public void WriteTag(string tagName, dynamic value)
        {
            try
            {




                driverHelper?.WriteTag(tagName, value);

            }
            catch (System.Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
    }
}
        
     