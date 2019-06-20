using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IODriverV2.Sharp7plus.Comm;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static AdvancedScada.IBaseService.Common.XCollection;

namespace AdvancedScada.IODriverV2.Sharp7plus
{
    public class DataService
    {
        #region Flad

        private static Dictionary<string, Profinet.Plc> _PLCS7;
        public static readonly ManualResetEvent SendDone = new ManualResetEvent(true);

        IPLCS7Master PLC_S7 = null;
        public static Channel Channels;

        private static int COUNTER;

        private static Task taskArray;

        public static bool IsConnected;

        #endregion

        #region IServiceDriver

        public void InitializeService(Channel chns)
        {
            try
            {
                Channels = chns;

                _PLCS7 = new Dictionary<string, Profinet.Plc>();

                if (Channels == null) return;



                foreach (Device dv in Channels.Devices)
                {
                    var die = (DIEthernet)Channels;
                    PLC_S7 = new Profinet.Plc(die.IPAddress, (short)Channels.Rack, (short)Channels.Slot);
                    _PLCS7.Add(Channels.ChannelName, (Profinet.Plc)PLC_S7);
                    foreach (DataBlock db in dv.DataBlocks)
                    {
                        foreach (Tag tg in db.Tags)
                        {
                            TagCollection.Tags.Add(string.Format("{0}.{1}.{2}.{3}", Channels.ChannelName, dv.DeviceName, db.DataBlockName,
                                                                    tg.TagName), tg);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        readonly static object myLockRead = new object();

        public void Connect()
        {
            try
            {
                lock (myLockRead)
                {

                    Console.WriteLine("STARTED: {0}", ++COUNTER);

                    taskArray = new Task((chParam) =>
                    {

                        var ch = (Channel)chParam;

                        PLC_S7 = _PLCS7[ch.ChannelName];

                        if (PLC_S7 != null)
                        {
                            PLC_S7.Connection();
                            IsConnected = PLC_S7.IsConnected;
                            while (IsConnected)
                                foreach (var dv in ch.Devices)
                                    foreach (var db in dv.DataBlocks)
                                        SendPackage(PLC_S7, dv, db);
                        }
                    }, Channels);
                    taskArray.Start();

                }

            }
            catch (Exception ex)
            {
                Disconnect();
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);


            }
        }
        public void Disconnect()
        {
            IsConnected = false;
        }

        public void WriteTag(string tagName, dynamic value)
        {

            SendDone.Reset();
            var strArrays = tagName.Split('.');
            var dataPacket = new List<byte>();
            try
            {
                var str = string.Format("{0}.{1}", strArrays[0], strArrays[1]);
                foreach (var dv in Channels.Devices)
                {
                    var flag = string.Format("{0}.{1}", Channels.ChannelName, dv.DeviceName).Equals(str);
                    if (flag)
                    {

                        PLC_S7 = _PLCS7[Channels.ChannelName];

                        if (PLC_S7 == null) return;
                        var obj = PLC_S7;
                        lock (obj)
                        {

                            switch (TagCollection.Tags[tagName].DataType)
                            {
                                case "Bit":

                                    PLC_S7.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), TagCollection.Tags[tagName].DataType, value == "1" ? true : false);


                                    break;
                                case "Word":
                                case "Int":

                                    short db1IntVariable = short.Parse(value);
                                    PLC_S7.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), TagCollection.Tags[tagName].DataType, db1IntVariable.ConvertToUshort());

                                    break;
                                case "Real":

                                    double db1RealVariable = double.Parse(value);
#pragma warning disable CS0618 // Type or member is obsolete
                                    PLC_S7.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), TagCollection.Tags[tagName].DataType, db1RealVariable.ConvertToUInt());
#pragma warning restore CS0618 // Type or member is obsolete

                                    break;
                                case "String":
                                    string db1stringVariable = string.Format("{0}", value);

                                    PLC_S7.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), TagCollection.Tags[tagName].DataType, db1stringVariable);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //* Return an error code
                Console.WriteLine("Data Error : " + ex.Message);
            }
            finally
            {
                SendDone.Set();
            }
        }

        #endregion



        #region SendPackage
        private static void SendPackage(IPLCS7Master xgt3, Device dv, DataBlock db)
        {

            try
            {
                SendDone.WaitOne(-1);
                var ibyteArray1 = xgt3.ReadStruct(db, db.StartAddress);


            }

            catch (Exception ex)
            {
                //IsConnected = false;
                EventscadaException?.Invoke("SendPackage", ex.Message);

            }
        }
        #endregion





    }
}
