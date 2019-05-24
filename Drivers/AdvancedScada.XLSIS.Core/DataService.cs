using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Comm;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService;
using AdvancedScada.XLSIS.Core.Drivers.Cnet;
using AdvancedScada.XLSIS.Core.Drivers.FENET;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net.Sockets;
using System.ServiceModel;
using System.Threading;

namespace AdvancedScada.XLSIS.Core
{

    public class DataService : IServiceDriver
    {
        #region Flad

        private static Dictionary<string, LS_CNET> _cnet = new Dictionary<string, LS_CNET>();
        private static Dictionary<string, LS_FENET> FENET = new Dictionary<string, LS_FENET>();
        public static readonly ManualResetEvent SendDone = new ManualResetEvent(true);
        readonly static object myLockRead = new object();
         private object LockObject = new object();
        public static List<Channel> Channels = new List<Channel>();
        private static int COUNTER;
        private static bool IsConnected;
        private static Thread[] threads;
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

                    IDriverAdapter ILSIS = null;
                   
                    #endregion Initialize

                    foreach (var dv in ch.Devices)
                    {
                        switch (ch.ConnectionType)
                        {
                            case "SerialPort":
                                var dis = (DISerialPort)ch;
                                var sp = new SerialPort(dis.PortName, dis.BaudRate, dis.Parity, dis.DataBits, dis.StopBits);
                                sp.Handshake = dis.Handshake;
                                ILSIS = new LS_CNET(dv.SlaveId, sp);
                                _cnet.Add(ch.ChannelName, (LS_CNET)ILSIS);
                                break;
                            case "Ethernet":
                                var die = (DIEthernet)ch;
                                ILSIS = new LS_FENET(die.IPAddress, die.Port, die.Slot);
                                FENET.Add(ch.ChannelName, (LS_FENET)ILSIS);
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
            catch (CommunicationException ex)
            {
                var err = new HMIException.ScadaException(this.GetType().Name, ex.Message);
            }
        }
        public void Connect()
        {
            try
            { 
                    Console.WriteLine("STARTED: {0}", ++COUNTER);
                    threads = new Thread[Channels.Count];
                    if (threads == null) throw new NullReferenceException("No Data");
                    for (var i = 0; i < Channels.Count; i++)
                    {
                        threads[i] = new Thread((chParam) =>
                        {
                            IDriverAdapter ILSIS = null;
                            var ch = (Channel)chParam;
                            switch (ch.ConnectionType)
                            {
                                case "SerialPort":
                                    ILSIS = _cnet[ch.ChannelName];
                                    break;

                                case "Ethernet":
                                    ILSIS = FENET[ch.ChannelName];
                                    break;
                            }

                            if (ILSIS != null)
                            {
                                ILSIS.Connection();
                                IsConnected = ILSIS.IsConnected;
                                while (IsConnected)
                                {
                                    foreach (var dv in ch.Devices)
                                    {
                                        foreach (var db in dv.DataBlocks)
                                        {

                                            if (!IsConnected) break;
                                            SendPackage(ILSIS, ch, dv, db);
                                        }

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
                Disconnect();
                var err = new HMIException.ScadaException(this.GetType().Name + "  XLSIS.Connect", ex.Message);
            }
        }


        public void Disconnect()
        {

            IsConnected = false;

        }
        #endregion
 
        private void SendPackage(IDriverAdapter ILSIS, Channel ch, Device dv, DataBlock db)
        {
            try
            {
                switch (db.DataType)
                {
                    case "Bit":

                        byte[] bitArys = null;
                        lock (ILSIS)
                            bitArys = ILSIS.BuildReadByte((byte)dv.SlaveId, $"{db.MemoryType.Substring(0, 1)}{2 * db.StartAddress}", (ushort)(2 * db.Length));
                        if (bitArys == null || bitArys.Length == 0) return;
                        
                        var bitRs = HslCommunication.BasicFramework.SoftBasic.ByteToBoolArray(bitArys);
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
                    case "Int":

                        lock (ILSIS)
                        {
                            short[] IntRs = ILSIS.Read<Int16>($"{db.MemoryType.Substring(0, 1)}{2 * db.StartAddress}", db.Length);
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

                        lock (ILSIS)
                        {
                            int[] DIntRs = ILSIS.Read<Int32>($"{db.MemoryType.Substring(0, 1)}{2 * db.StartAddress}", db.Length);
                            if (DIntRs.Length > db.Tags.Count) return;
                            for (int j = 0; j < DIntRs.Length; j++)
                            {
                                db.Tags[j].Value = DIntRs[j];
                                db.Tags[j].Timestamp = DateTime.Now;
                            }
                        }
                        break;
                    case "Word":

                        lock (ILSIS)
                        {
                            var wdRs = ILSIS.Read<Int16>($"{db.MemoryType.Substring(0, 1)}{2 * db.StartAddress}", db.Length);
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

                        lock (ILSIS)
                        {
                            uint[] dwRs = ILSIS.Read<UInt32>($"{db.MemoryType.Substring(0, 1)}{2 * db.StartAddress}", (ushort)db.Length);

                            for (int j = 0; j < dwRs.Length; j++)
                            {
                                db.Tags[j].Value = dwRs[j];
                                db.Tags[j].Timestamp = DateTime.Now;
                            }
                        }
                        break;
                    case "Real1":

                        lock (ILSIS)
                        {
                            float[] rl1Rs = ILSIS.Read<float>($"{db.MemoryType.Substring(0, 1)}{2 * db.StartAddress}", (ushort)db.Length);

                            for (int j = 0; j < rl1Rs.Length; j++)
                            {
                                db.Tags[j].Value = rl1Rs[j];
                                db.Tags[j].Timestamp = DateTime.Now;
                            }
                        }
                        break;
                    case "Real2":

                        lock (ILSIS)
                        {
                            double[] rl2Rs = ILSIS.Read<double>($"{db.MemoryType.Substring(0, 1)}{2 * db.StartAddress}", (ushort)db.Length);

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
                if (ex.Message == "Hex Character Count Not Even") return;
                IsConnected = false;
                var err = new HMIException.ScadaException(this.GetType().Name + "  XLSIS.SendPackage", ex.Message);

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
                            IDriverAdapter ILSIS = null;
                            switch (ch.ConnectionType)
                            {
                                case "SerialPort":
                                    ILSIS = _cnet[ch.ChannelName];
                                    break;
                                case "Ethernet":
                                    ILSIS = FENET[ch.ChannelName];
                                    break;
                            }
                            if (ILSIS == null) return;
                             
                            lock (ILSIS)
                                switch (TagCollection.Tags[tagName].DataType)
                                {
                                    case "Bit":
                                        ILSIS.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), value == "1" ? true : false);
                                        break;
                                    case "Int":
                                        ILSIS.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), short.Parse(value));
                                        break;
                                    case "Word":
                                        ILSIS.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), ushort.Parse(value));
                                        break;
                                    case "DInt":
                                        ILSIS.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), short.Parse(value));
                                        break;
                                    case "DWord":
                                        ILSIS.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), ushort.Parse(value));
                                        break;
                                    case "Real1":
                                        ILSIS.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), float.Parse(value));
                                        break;
                                    case "Real2":
                                        ILSIS.Write(string.Format("{0}", TagCollection.Tags[tagName].Address), double.Parse(value));
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