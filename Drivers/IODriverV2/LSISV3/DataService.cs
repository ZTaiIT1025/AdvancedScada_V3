using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Devices;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using AdvancedScada.XLSIS.Core.Comm;
using AdvancedScada.XLSIS.Core.Drivers.Cnet;
using AdvancedScada.XLSIS.Core.Drivers.FENET;
using static AdvancedScada.IBaseService.Common.XCollection;
using IODriverV2;
using Core.DataTypes;

namespace AdvancedScada.XLSIS.Core
{

    public class DataService 
    {
        #region Flad

        private static Dictionary<string, LS_CNET> _cnet = new Dictionary<string, LS_CNET>();
        private static Dictionary<string, LS_FENET> FENET = new Dictionary<string, LS_FENET>();
        public static readonly ManualResetEvent SendDone = new ManualResetEvent(true);
        readonly static object myLockRead = new object();
      //  private static RequestAndResponseMessage _RequestAndResponseMessage = null;
        private object LockObject = new object();


        public static List<Channel> Channels = new List<Channel>();

        private static int COUNTER;

        private static Task[] taskArray;

        private static bool IsConnected;
       
        #endregion

        #region IServiceDriver
        public void InitializeService(Channel ch)
        {
            try
            {
                lock (this)
                {


                    Channels.Add(ch);

                    
                   
                    if (Channels == null) return;
                    // Initialize


                    #region XGT.

                    IPLC_LS_Master PLC_LS = null;
                    switch (ch.ConnectionType)
                    {
                        case "SerialPort":
                            var dis = (DISerialPort)ch;
                            var sp = new SerialPort(dis.PortName, dis.BaudRate, dis.Parity, dis.DataBits, dis.StopBits);
                            sp.Handshake = dis.Handshake;
                            var spAdaper = new SerialPortAdapter(sp);
                            PLC_LS = new LS_CNET();
                            PLC_LS.AllSerialPortAdapter(spAdaper);
                            _cnet.Add(ch.ChannelName, (LS_CNET)PLC_LS);
                            break;
                        case "Ethernet":
                            var die = (DIEthernet)ch;
                            PLC_LS = new LS_FENET(die.IPAddress, die.Port, 500);
                            FENET.Add(ch.ChannelName, (LS_FENET)PLC_LS);
                            break;
                    }

                    #endregion Initialize

                    foreach (var dv in ch.Devices)
                    {
                        foreach (var db in dv.DataBlocks)
                        {

                            foreach (var tg in db.Tags)
                            {

                                TagCollection.Tags.Add(
                                    $"{ch.ChannelName}.{dv.DeviceName}.{db.DataBlockName}.{tg.TagName}", tg);

                            }
                        }
                    }
                }
            }
            catch (CommunicationException ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }
        public void Connect()
        {
            try
            {
                lock (myLockRead)
                {

                    Console.WriteLine("STARTED: {0}", ++COUNTER);
                    taskArray = new Task[Channels.Count];
                    if (taskArray == null) throw new NullReferenceException("No Data");
                    for (var i = 0; i < Channels.Count; i++)
                    {
                        taskArray[i] = new Task((chParam) =>
                        {
                            IPLC_LS_Master PLC_LS = null;
                            var ch = (Channel)chParam;
                            switch (ch.ConnectionType)
                            {
                                case "SerialPort":
                                    PLC_LS = _cnet[ch.ChannelName];
                                    break;

                                case "Ethernet":
                                    PLC_LS = FENET[ch.ChannelName];
                                    break;
                            }

                            if (PLC_LS != null)
                            {
                                PLC_LS.Connection();
                                IsConnected = PLC_LS.IsConnected;
                                while (IsConnected)
                                {
                                    foreach (var dv in ch.Devices)
                                    {
                                        foreach (var db in dv.DataBlocks)
                                        {

                                            if (!IsConnected) break;
                                            SendPackage(PLC_LS, ch, dv, db);
                                        }

                                    }


                                }

                            }
                        }, Channels[i]);
                        taskArray[i].Start();
                    }
                }

            }
            catch (Exception ex)
            {
                Disconnect();
                EventscadaException?.Invoke(this.GetType().Name+ "  XLSIS.Connect", ex.Message);
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
                var str = $"{strArrays[0]}.{strArrays[1]}";
                foreach (var ch in Channels)
                    foreach (var dv in ch.Devices)
                    {
                        var bEquals = $"{ch.ChannelName}.{dv.DeviceName}".Equals(str);
                        if (bEquals)
                        {
                            IPLC_LS_Master PLC_LS = null;
                            switch (ch.ConnectionType)
                            {
                                case "SerialPort":
                                    PLC_LS = _cnet[ch.ChannelName];
                                    break;
                                case "Ethernet":
                                    PLC_LS = FENET[ch.ChannelName];
                                    break;
                            }
                            if (PLC_LS == null) return;
                            var obj = PLC_LS;
                            lock (obj)
                            {
                                byte[] x;
                                switch (TagCollection.Tags[tagName].DataType)
                                {
                                    case "Bit":

                                        PLC_LS.BeginWrite(dv.SlaveId, $"{TagCollection.Tags[tagName].Address}", 0, value == "1" ? "1" : "0");
                                        break;
                                    case "Word":
                                        string[] dataAsArray = { value };
                                        foreach (var t in dataAsArray)
                                        {
                                            x = BitConverter.GetBytes(Convert.ToInt16(t));
                                            dataPacket.Add(x[1]);
                                            dataPacket.Add(x[0]);
                                        }
                                        PLC_LS.BeginWrite(dv.SlaveId, $"{TagCollection.Tags[tagName].Address}", 0, value);
                                        break;
                                }
                            }
                        }
                    }
            }
            catch (Exception ex)
            {

                EventscadaException?.Invoke(this.GetType().Name+ "XLSIS.WriteTag", ex.Message);
            }
            finally
            {
                SendDone.Set();
            }
        }
        #endregion



        #region SendPackage


        public void SendPackage(IPLC_LS_Master PLC_LS, Channel ch, Device dv, DataBlock db)
        {

            try
            {
                SendDone.WaitOne(-1);
                lock (LockObject)
                {
                    switch (db.DataType)
                    {
                        case "Byte":
                        case "Bit":
                            var bitArys = PLC_LS.BeginRead(dv.SlaveId, db.MemoryType.Substring(0, 1) == "M" ? "MB" : "PB", 2 * db.StartAddress, 2 * db.Length, db.DataBlockName);
                            if (bitArys == null || bitArys.Length == 0) return;
                            switch (ch.ConnectionType)
                            {
                                case "SerialPort":
                                    //Array.Reverse(bitArys);
                                    break;

                                case "Ethernet":
                                    Array.Reverse(bitArys);
                                    break;
                            }

                            var bitRs = Bit.ToArray(bitArys);
                            if (bitRs.Length > db.Tags.Count)
                                return;
                            for (var j = 0; j <= db.Tags.Count - 1; j++)
                            {
                                db.Tags[j].Value = bitRs[j];
                                db.Tags[j].Visible = bitRs[j];
                                db.Tags[j].Enabled = bitRs[j];
                                db.Tags[j].Timestamp = DateTime.Now;
                            }

                            break;
                        case "Word":
                            byte[] wdArys = PLC_LS.BeginRead(dv.SlaveId, db.MemoryType.Substring(0, 1) == "D" ? "DB" : "TB", 2 * db.StartAddress, 2 * db.Length, db.DataBlockName);
                            if (wdArys == null || wdArys.Length == 0) return;
                            switch (ch.ConnectionType)
                            {
                                case "SerialPort":

                                    break;

                                case "Ethernet":
                                    Array.Reverse(wdArys);
                                    break;
                            }
                            Word.ToArray(wdArys);
                           
                            if (wdArys.Length > db.Tags.Count)
                                return;
                            for (var i = 0; i < db.Tags.Count; i++)
                            {
                                db.Tags[i].Value = wdArys[i];
                                db.Tags[i].Timestamp = DateTime.Now;
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Hex Character Count Not Even") return;
                IsConnected = false;
                EventscadaException?.Invoke(this.GetType().Name + "  XLSIS.SendPackage", ex.Message);

            }
        }
        #endregion


        

    }
}