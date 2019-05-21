using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Comm;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.HMIException;
using AdvancedScada.IBaseService;
using AdvancedScada.XSiemens.Core.Profinet;
using HslCommunication.Profinet.Siemens;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using XSiemens.Core.Comm;

namespace XSiemens.Core
{/// <summary>
/// 
/// </summary>
    public class DataService : IServiceDriver
    {
        #region Flad
        private static List<Channel> Channels = new List<Channel>();
        private static Dictionary<string, SiemensNet> _PLCS7 = new Dictionary<string, SiemensNet>();
        private static Dictionary<string, SiemensComPPI> _PLCPPI = new Dictionary<string, SiemensComPPI>();
        public static readonly ManualResetEvent SendDone = new ManualResetEvent(true);
        private static int COUNTER;
        public static bool IsConnected;
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
                    IPLCS7Master ISiemens = null;


                   

                    foreach (var dv in ch.Devices)
                    {
                        switch (ch.ConnectionType)
                        {
                            case "SerialPort":
                                var dis = (DISerialPort)ch;
                                var sp = new SerialPort(dis.PortName, dis.BaudRate, dis.Parity, dis.DataBits, dis.StopBits);
                                sp.Handshake = dis.Handshake;
                                
                                ISiemens = new SiemensComPPI(dv.SlaveId, sp);
                               
                                _PLCPPI.Add(ch.ChannelName, (SiemensComPPI)ISiemens);
                                break;
                            case "Ethernet":
                                var die = (DIEthernet)ch;
                                var cpu = (SiemensPLCS)Enum.Parse(typeof(SiemensPLCS), die.CPU);

                                ISiemens = new SiemensNet(cpu, die.IPAddress, (short)die.Rack, (short)die.Slot);
                                _PLCS7.Add(ch.ChannelName, (SiemensNet)ISiemens);
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
                var err = new ScadaException(this.GetType().Name + " XModbus.InitializeService", ex.Message);
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
                        IPLCS7Master ISiemens = null;
                        Channel ch = (Channel)chParam;
                        switch (ch.ConnectionType)
                        {
                            case "SerialPort":
                                ISiemens = _PLCPPI[ch.ChannelName];
                                break;
                            case "Ethernet":
                                ISiemens = _PLCS7[ch.ChannelName];
                                break;
                        }
                        ISiemens.Connection();
                        IsConnected = ISiemens.IsConnected;
                        while (IsConnected)
                        {
                            foreach (Device dv in ch.Devices)
                            {
                                foreach (DataBlock db in dv.DataBlocks)
                                {
                                    if (!IsConnected) break;
                                    SendPackage(ISiemens, dv, db);
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


        private void SendPackage(IPLCS7Master ISiemens, Device dv, DataBlock db)
        {
            try
            {

                switch (db.DataType)
                {
                    case "Bit":

                        lock (ISiemens)
                        {

                            bool[] bitRs = ISiemens.Read<bool>($"{db.MemoryType}{db.StartAddress}", db.Length);

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

                        lock (ISiemens)
                        {
                            short[] IntRs = ISiemens.Read<Int16>($"{db.MemoryType}{db.StartAddress}", db.Length);
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

                        lock (ISiemens)
                        {
                            int[] DIntRs = ISiemens.Read<Int32>($"{db.MemoryType}{db.StartAddress}", db.Length);
                            if (DIntRs.Length > db.Tags.Count) return;
                            for (int j = 0; j < DIntRs.Length; j++)
                            {
                                db.Tags[j].Value = DIntRs[j];
                                db.Tags[j].Timestamp = DateTime.Now;
                            }
                        }
                        break;
                    case "Word":

                        lock (ISiemens)
                        {
                            var wdRs = ISiemens.Read<UInt16>($"{db.MemoryType}{db.StartAddress}", db.Length);
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

                        lock (ISiemens)
                        {
                            uint[] dwRs = ISiemens.Read<UInt32>($"{db.MemoryType}{db.StartAddress}", (ushort)db.Length);

                            for (int j = 0; j < dwRs.Length; j++)
                            {
                                db.Tags[j].Value = dwRs[j];
                                db.Tags[j].Timestamp = DateTime.Now;
                            }
                        }
                        break;
                    case "Real1":

                        lock (ISiemens)
                        {
                            float[] rl1Rs = ISiemens.Read<float>($"{db.MemoryType}{db.StartAddress}", (ushort)db.Length);

                            for (int j = 0; j < rl1Rs.Length; j++)
                            {
                                db.Tags[j].Value = rl1Rs[j];
                                db.Tags[j].Timestamp = DateTime.Now;
                            }
                        }
                        break;
                    case "Real2":

                        lock (ISiemens)
                        {
                            double[] rl2Rs = ISiemens.Read<double>($"{db.MemoryType}{db.StartAddress}", (ushort)db.Length);

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
                Disconnect();
                Console.WriteLine(ex.Message); 
            }
            catch (Exception ex)
            {
                Disconnect();
                Console.WriteLine(ex.Message);
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
                            IPLCS7Master ISiemens = null;
                            switch (ch.ConnectionType)
                            {
                                case "SerialPort":
                                    ISiemens = _PLCPPI[ch.ChannelName];
                                    break;
                                case "Ethernet":
                                    ISiemens = _PLCS7[ch.ChannelName];
                                    break;
                            }
                            if (ISiemens == null) return;
                            lock (ISiemens)
                                switch (TagCollection.Tags[tagName].DataType)
                                {
                                    case "Bit":
                                        ISiemens.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), value == "1" ? true : false);
                                        break;
                                    case "Int":
                                        ISiemens.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), short.Parse(value));
                                        break;
                                    case "Word":
                                        ISiemens.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), ushort.Parse(value));
                                        break;
                                    case "DInt":
                                        ISiemens.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), short.Parse(value));
                                        break;
                                    case "DWord":
                                        ISiemens.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), ushort.Parse(value));
                                        break;
                                    case "Real1":
                                        ISiemens.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), float.Parse(value));
                                        break;
                                    case "Real2":
                                        ISiemens.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), double.Parse(value));
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
