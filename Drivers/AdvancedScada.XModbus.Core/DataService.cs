using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Comm;
using AdvancedScada.DriverBase.Core.DataTypes;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService;
using AdvancedScada.XModbus.Core.ASCII;
using AdvancedScada.XModbus.Core.RTU;
using AdvancedScada.XModbus.Core.TCP;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;

namespace AdvancedScada.XModbus.Core
{
    public delegate void CatchExceptionDelegate(Exception ex);
    public class DataService : IServiceDriver
    {
        private static List<Channel> Channels = new List<Channel>();
        private static Dictionary<string, ModbusTCPMaster> mbe = new Dictionary<string, ModbusTCPMaster>();
        private static Dictionary<string, ModbusRTUMaster> rtu = new Dictionary<string, ModbusRTUMaster>();
        private static Dictionary<string, ModbusASCIIMaster> ascii = new Dictionary<string, ModbusASCIIMaster>();
        private static int COUNTER;
         private static bool IsConnected;
         public static RequestAndResponseMessage _RequestAndResponseMessage = null;


        #region IServiceDriver


        public void InitializeService(Channel ch)
        {
            try
            {
                lock (this)
                {


                    Channels.Add(ch);

                    if (Channels == null) return;


                    IDriverAdapter modbus = null;
                  

               

                    foreach (var dv in ch.Devices)
                    {
                        switch (ch.ConnectionType)
                        {
                            case "SerialPort":
                                var dis = (DISerialPort)ch;
                                var sp = new SerialPort(dis.PortName, dis.BaudRate, dis.Parity, dis.DataBits, dis.StopBits);
                                sp.Handshake = dis.Handshake;
                               
                                switch (dis.Mode)
                                {
                                    case "RTU":
                                        modbus = new ModbusRTUMaster(dv.SlaveId,sp);
                                       
                                        rtu.Add(ch.ChannelName, (ModbusRTUMaster)modbus);
                                        break;
                                    case "ASCII":
                                        modbus = new ModbusASCIIMaster(dv.SlaveId, sp);
                                     
                                        ascii.Add(ch.ChannelName, (ModbusASCIIMaster)modbus);
                                        break;
                                }

                                break;
                            case "Ethernet":
                                var die = (DIEthernet)ch;
                                modbus = new ModbusTCPMaster(dv.SlaveId,die.IPAddress, die.Port);
                                mbe.Add(ch.ChannelName, (ModbusTCPMaster)modbus);
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
            }
            catch (Exception ex)
            {
                var err = new HMIException.ScadaException(this.GetType().Name + " XModbus.InitializeService", ex.Message);
            }
        }

         
        private static Thread[] threads;
        public void Connect()
        {
            try
            {
                IsConnected = true;
                Console.WriteLine(string.Format("STARTED: {0}", ++COUNTER));
                threads = new Thread[Channels.Count];
                if (threads == null) throw new NullReferenceException("No Data");
                for (int i = 0; i < Channels.Count; i++)
                {
                    threads[i] = new Thread((chParam) =>
                    {
                        IDriverAdapter modbus = null;
                        Channel ch = (Channel)chParam;
                        switch (ch.Mode)
                        {
                            case "RTU":
                                modbus = rtu[ch.ChannelName];
                                break;
                            case "ASCII":
                                modbus = ascii[ch.ChannelName];
                                break;
                            case "TCP":
                                modbus = mbe[ch.ChannelName];
                                break;
                        }
                        modbus.Connection();
                        IsConnected = modbus.IsConnected;
                        while (IsConnected)
                        {
                            foreach (Device dv in ch.Devices)
                            {
                                foreach (DataBlock db in dv.DataBlocks)
                                {
                                    if (!IsConnected) break;
                                    SendPackage(modbus, dv, db);
                                }
                            }
                        }

                    });
                    threads[i].IsBackground = true;
                    threads[i].Start(Channels[i]);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Disconnect()
        {

            IsConnected = false;

        }
         
        #endregion

        public static CatchExceptionDelegate eventCatchExceptionDelegate = null;
        private void SendPackage(IDriverAdapter modbus, Device dv, DataBlock db)
        {
            try
            {
                 
                switch (db.DataType)
                {
                    case "Bit":
                        
                        lock (modbus)
                        {

                            bool[] bitRs = modbus.Read<bool>($"{db.StartAddress}", db.Length);

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
                            short[] IntRs = modbus.Read<Int16>($"{db.StartAddress}", db.Length);
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
                            int[] DIntRs = modbus.Read<Int32>(string.Format("{0}", db.StartAddress), db.Length);
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
                            var wdRs = modbus.Read<UInt16>($"{db.StartAddress}", db.Length);
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
                            uint[] dwRs = modbus.Read<UInt32>( string.Format("{0}", db.StartAddress), (ushort)db.Length);
                           
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
                            float[] rl1Rs = modbus.Read<float>(string.Format("{0}", db.StartAddress), (ushort)db.Length);
                            
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
                            double[] rl2Rs = modbus.Read<double>(string.Format("{0}", db.StartAddress), (ushort)db.Length);

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
                if (eventCatchExceptionDelegate != null && IsConnected == true) eventCatchExceptionDelegate(new Exception("IP Address is invalid with reason " + ex.Message));
                Disconnect();
                //throw new Exception("IP Address is invalid with reason " + ex.Message);
            }
            catch (Exception ex)
            {
                if (eventCatchExceptionDelegate != null && IsConnected == true) eventCatchExceptionDelegate(new Exception("ERROR " + ex.Message));
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
                            IDriverAdapter modbus = null;
                            switch (ch.Mode)
                            {
                                case "RTU":
                                    modbus = rtu[ch.ChannelName];
                                    break;
                                case "ASCII":
                                    modbus = ascii[ch.ChannelName];
                                    break;
                                case "TCP":
                                    modbus = mbe[ch.ChannelName];
                                    break;
                            }
                            if (modbus == null) return;
                            lock (modbus)
                                switch (TagCollection.Tags[tagName].DataType)
                                {
                                    case "Bit":
                                        modbus.Write( string.Format("{0}", TagCollection.Tags[tagName].Address), value == "1" ? true : false);
                                        break;
                                    case "Int":
                                        modbus.Write( string.Format("{0}", TagCollection.Tags[tagName].Address), short.Parse(value));
                                        break;
                                    case "Word":
                                        modbus.Write( string.Format("{0}", TagCollection.Tags[tagName].Address), ushort.Parse(value));
                                        break;
                                    case "DInt":
                                        modbus.Write( string.Format("{0}", TagCollection.Tags[tagName].Address), short.Parse(value));
                                        break;
                                    case "DWord":
                                        modbus.Write( string.Format("{0}", TagCollection.Tags[tagName].Address), ushort.Parse(value));
                                        break;
                                    case "Real1":
                                        modbus.Write( string.Format("{0}", TagCollection.Tags[tagName].Address), float.Parse(value));
                                        break;
                                    case "Real2":
                                        modbus.Write( string.Format("{0}", TagCollection.Tags[tagName].Address), double.Parse(value));
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

         


    }
}