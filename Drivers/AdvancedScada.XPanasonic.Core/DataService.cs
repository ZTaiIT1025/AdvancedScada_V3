using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Comm;
using AdvancedScada.DriverBase.Core.DataTypes;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService;
using AdvancedScada.XPanasonic.Core.Comm;
using AdvancedScada.XPanasonic.Core.Drivers;

namespace AdvancedScada.XPanasonic.Core
{
    public class DataService : IServiceDriver
    {
        #region Fiald


        public static List<Channel> Channels = new List<Channel>();
        private static Dictionary<string, PanasonicSerialReader> mbe = new Dictionary<string, PanasonicSerialReader>();
         
        private static int COUNTER;
        private static Task[] taskArray;
        private static bool IsConnected;
        public static readonly ManualResetEvent SendDone = new ManualResetEvent(true);
        public static RequestAndResponseMessage _RequestAndResponseMessage = null;
        #endregion
        #region IServiceDriver 
        public void InitializeService(Channel ch)
        {
            try
            {
                Channels.Add(ch);



                if (Channels == null) return;




                PanasonicSerialReader modbus = null;
               
                foreach (var dv in ch.Devices)
                {

                    switch (ch.ConnectionType)
                    {
                        case "SerialPort":
                            var dis = (DISerialPort)ch;
                            var sp = new SerialPort(dis.PortName, dis.BaudRate, dis.Parity, dis.DataBits, dis.StopBits);
                            sp.Handshake = dis.Handshake;
                          

                            modbus = new PanasonicSerialReader(dv.SlaveId,  sp);
                            mbe.Add(ch.ChannelName, (PanasonicSerialReader)modbus);
                            break;

                    }
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
            catch (Exception ex)
            {
                var err = new HMIException.ScadaException(this.GetType().Name, ex.Message);
            }
        }
        public void Connect()
        {
            try
            {
                IsConnected = true;
                Console.WriteLine("STARTED: {0}", ++COUNTER);
                taskArray = new Task[Channels.Count];
                if (taskArray == null) throw new NullReferenceException("No Data");
                for (var i = 0; i < Channels.Count; i++)
                {
                    taskArray[i] = new Task(chParam =>
                    {
                        PanasonicSerialReader modbus = null;
                        var ch = (Channel)chParam;

                        modbus = mbe[ch.ChannelName];
                        modbus.Connection();
                        IsConnected = modbus.IsConnected;
                        while (IsConnected)
                            foreach (var dv in ch.Devices)
                                foreach (var db in dv.DataBlocks)
                                {

                                    if (!IsConnected) break;
                                    SendPackage(modbus, dv, db);
                                }
                    }, Channels[i]);
                    taskArray[i].Start();
                }
            }
            catch (Exception ex)
            {
                var err = new HMIException.ScadaException(this.GetType().Name, ex.Message);
                IsConnected = false;
            }
        }
        public void Disconnect()
        {
            IsConnected = false;
        }
     
        #endregion


        public static List<Tag> GetTagByDataBlock(DataBlock db)
        {
            var tagDataBlock = new List<Tag>();
            try
            {
                if (Channels != null)
                    foreach (var ch in Channels)
                        foreach (var dv in ch.Devices)
                            foreach (var item in dv.DataBlocks)
                                if (db.DataBlockId == item.DataBlockId && db.DeviceId == item.DeviceId
                                                                       && db.ChannelId == item.ChannelId)
                                    tagDataBlock = item.Tags;
                return tagDataBlock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        #region SendPackage

     
        private void SendPackage(PanasonicSerialReader modbus, Device dv, DataBlock db)
        {
            try
            {
                switch (db.DataType)
                {
                    case "Bit":

                        lock (modbus)
                        {

                            bool[] bitRs = modbus.Read<bool>($"{db.MemoryType}{2 * db.StartAddress}", db.Length);

                            int length = bitRs.Length;
                            if (bitRs.Length > db.Tags.Count) length = db.Tags.Count;
                            for (int j = 0; j < length; j++)
                            {
                                db.Tags[j].Value = bitRs[j];
                                db.Tags[j].Checked = bitRs[j];
                                db.Tags[j].Enabled = bitRs[j];
                                db.Tags[j].Visible = bitRs[j];
                                db.Tags[j].ValueSelect1 = bitRs[j];
                                db.Tags[j].ValueSelect2 = bitRs[j];
                                db.Tags[j].Timestamp = DateTime.Now;
                            }
                        }
                        break;
                    case "Int":

                        lock (modbus)
                        {
                            short[] IntRs = modbus.Read<Int16>($"{db.MemoryType}{2 * db.StartAddress}", db.Length);
                            if (IntRs.Length > db.Tags.Count) return;
                            for (int j = 0; j < IntRs.Length; j++)
                            {
                                if (db.Tags[j].IsScaled)
                                {
                                    db.Tags[j].Value = Util.Interpolation(IntRs[j], db.Tags[j].AImin, db.Tags[j].AImax, db.Tags[j].RLmin, db.Tags[j].RLmax);
                                }
                                else
                                {
                                    db.Tags[j].Value = IntRs[j];
                                }

                                db.Tags[j].Timestamp = DateTime.Now;
                            }
                        }
                        break;
                    case "DInt":

                        lock (modbus)
                        {
                            int[] DIntRs = modbus.Read<Int32>($"{db.MemoryType}{2 * db.StartAddress}", db.Length);
                            if (DIntRs.Length > db.Tags.Count) return;
                            for (int j = 0; j < DIntRs.Length; j++)
                            {
                                db.Tags[j].Value = DIntRs[j];
                                db.Tags[j].Timestamp = DateTime.Now;
                            }
                        }
                        break;
                    case "Word":

                        lock (modbus)
                        {
                            var wdRs = modbus.Read<UInt16>($"{db.MemoryType}{2 * db.StartAddress}", db.Length);
                            if (wdRs == null) return;
                            if (wdRs.Length > db.Tags.Count) return;
                            for (int j = 0; j < wdRs.Length; j++)
                            {
                                if (db.Tags[j].IsScaled)
                                {
                                    db.Tags[j].Value = Util.Interpolation(wdRs[j], db.Tags[j].AImin, db.Tags[j].AImax, db.Tags[j].RLmin, db.Tags[j].RLmax);
                                }
                                else
                                {
                                    db.Tags[j].Value = wdRs[j];
                                }
                                db.Tags[j].Timestamp = DateTime.Now;
                            }
                        }
                        break;
                    case "DWord":

                        lock (modbus)
                        {
                            uint[] dwRs = modbus.Read<UInt32>($"{db.MemoryType}{2 * db.StartAddress}", (ushort)db.Length);

                            for (int j = 0; j < dwRs.Length; j++)
                            {
                                db.Tags[j].Value = dwRs[j];
                                db.Tags[j].Timestamp = DateTime.Now;
                            }
                        }
                        break;
                    case "Real1":

                        lock (modbus)
                        {
                            float[] rl1Rs = modbus.Read<float>($"{db.MemoryType}{2 * db.StartAddress}", (ushort)db.Length);

                            for (int j = 0; j < rl1Rs.Length; j++)
                            {
                                db.Tags[j].Value = rl1Rs[j];
                                db.Tags[j].Timestamp = DateTime.Now;
                            }
                        }
                        break;
                    case "Real2":

                        lock (modbus)
                        {
                            double[] rl2Rs = modbus.Read<double>($"{db.MemoryType}{2 * db.StartAddress}", (ushort)db.Length);

                            for (int j = 0; j < rl2Rs.Length; j++)
                            {
                                db.Tags[j].Value = rl2Rs[j];
                                db.Tags[j].Timestamp = DateTime.Now;
                            }
                        }
                        break;
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
             }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }
        public void WriteTag(string tagName, dynamic value)
        {
            try
            {
                string[] ary = tagName.Split('.');
                string tagDevice = string.Format("{0}.{1}", ary[0], ary[1]);
                foreach (Channel ch in Channels)
                {
                    foreach (Device dv in ch.Devices)
                    {

                        if (string.Format("{0}.{1}", ch.ChannelName, dv.DeviceName).Equals(tagDevice))
                        {
                            PanasonicSerialReader modbus = null;

                            modbus = mbe[ch.ChannelName];
                            
                            var obj = modbus;
                            if (modbus == null) return;
                            lock (modbus)
                                switch (TagCollection.Tags[tagName].DataType)
                                {
                                    case "Bit":
                                        modbus.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), value == "1" ? true : false);
                                        break;
                                    case "Int":
                                        modbus.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), short.Parse(value));
                                        break;
                                    case "Word":
                                        modbus.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), ushort.Parse(value));
                                        break;
                                    case "DInt":
                                        modbus.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), short.Parse(value));
                                        break;
                                    case "DWord":
                                        modbus.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), ushort.Parse(value));
                                        break;
                                    case "Real1":
                                        modbus.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), float.Parse(value));
                                        break;
                                    case "Real2":
                                        modbus.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), double.Parse(value));
                                        break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
