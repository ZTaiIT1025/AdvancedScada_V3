using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.XModbus.Core.ASCII;
using AdvancedScada.XModbus.Core.Comm;
using AdvancedScada.XModbus.Core.RTU;
using AdvancedScada.XModbus.Core.TCP;
using Core.DataTypes;
using IODriverV2;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using static AdvancedScada.IBaseService.Common.XCollection;
namespace AdvancedScada.XModbus.Core
{

    public class DataService 
    {
        private static List<Channel> Channels = new List<Channel>();
        private static Dictionary<string, ModbusTCPMaster> mbe = new Dictionary<string, ModbusTCPMaster>();
        private static Dictionary<string, ModbusRTUMaster> rtu = new Dictionary<string, ModbusRTUMaster>();
        private static Dictionary<string, ModbusASCIIMaster> ascii = new Dictionary<string, ModbusASCIIMaster>();
        private static int COUNTER;
        private static Task[] taskArray;
        private static bool IsConnected;
        private static readonly ManualResetEvent SendDone = new ManualResetEvent(true);
       // public static RequestAndResponseMessage _RequestAndResponseMessage = null;


        #region IServiceDriver


        public void InitializeService(Channel ch)
        {
            try
            {
                lock (this)
                {


                    Channels.Add(ch);

                    if (Channels == null) return;



                    #region Tạo đối tượng modbus.

                    IModbusMaster modbus = null;
                    switch (ch.ConnectionType)
                    {
                        case "SerialPort":
                            var dis = (DISerialPort)ch;
                            var sp = new SerialPort(dis.PortName, dis.BaudRate, dis.Parity, dis.DataBits, dis.StopBits);
                            sp.Handshake = dis.Handshake;
                            var spAdaper = new SerialPortAdapter(sp);
                            switch (dis.Mode)
                            {
                                case "RTU":
                                    modbus = new ModbusRTUMaster();
                                    modbus.AllSerialPortAdapter(spAdaper);
                                    rtu.Add(ch.ChannelName, (ModbusRTUMaster)modbus);
                                    break;
                                case "ASCII":
                                    modbus = new ModbusASCIIMaster();
                                    modbus.AllSerialPortAdapter(spAdaper);
                                    ascii.Add(ch.ChannelName, (ModbusASCIIMaster)modbus);
                                    break;
                            }

                            break;
                        case "Ethernet":
                            var die = (DIEthernet)ch;
                            modbus = new ModbusTCPMaster(die.IPAddress, die.Port, 3000);
                            mbe.Add(ch.ChannelName, (ModbusTCPMaster)modbus);
                            break;
                    }

                    #endregion Kết thúc

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
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name + " XModbus.InitializeService", ex.Message);
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
                        IModbusMaster modbus = null;
                        var ch = (Channel)chParam;
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
                EventscadaException?.Invoke(this.GetType().Name + "   XModbus.Connect", ex.Message);
                IsConnected = false;
            }
        }

        public void Disconnect()
        {
            
            IsConnected = false;
            
        }
        public void WriteTag(string TagName, dynamic Value)
        {
            SendDone.Reset();
            try
            {
                var strArrays = TagName.Split('.');
                var str = $"{strArrays[0]}.{strArrays[1]}";
                foreach (var ch in Channels)
                    foreach (var dv in ch.Devices)
                    {
                        var bEquals = $"{ch.ChannelName}.{dv.DeviceName}".Equals(str);
                        if (bEquals)
                        {
                            IModbusMaster modbusMaster = null;
                            switch (ch.Mode)
                            {
                                case "RTU":
                                    modbusMaster = rtu[ch.ChannelName];
                                    break;
                                case "ASCII":
                                    modbusMaster = ascii[ch.ChannelName];
                                    break;
                                case "TCP":
                                    modbusMaster = mbe[ch.ChannelName];
                                    break;
                            }

                            var bmodbus = modbusMaster == null;
                            if (bmodbus) return;
                            var obj = modbusMaster;
                            lock (obj)
                            {
                                switch (TagCollection.Tags[TagName].DataType)
                                {
                                    case "Bit":
                                        if (Value == "1")
                                            modbusMaster.WriteSingleCoil((byte)dv.SlaveId,
                                                $"{TagCollection.Tags[TagName].Address}", true);
                                        else
                                            modbusMaster.WriteSingleCoil((byte)dv.SlaveId,
                                                $"{TagCollection.Tags[TagName].Address}", false);
                                        break;
                                    case "Int":
                                        {
                                            break;
                                        }
                                    case "DInt":
                                        {
                                            break;
                                        }
                                    case "Word":
                                        {
                                            string[] DataAsArray = { Value };
                                            var dataPacket = new List<byte>();
                                            var x = new byte[2];
                                            for (var i = 0; i < DataAsArray.Length; i++)
                                            {
                                                x = BitConverter.GetBytes(Convert.ToInt16(DataAsArray[i]));

                                                dataPacket.Add(x[1]);
                                                dataPacket.Add(x[0]);
                                            }

                                            modbusMaster.WriteSingleRegister((byte)dv.SlaveId,
                                                $"{TagCollection.Tags[TagName].Address}",
                                                dataPacket.ToArray());
                                            break;
                                        }
                                    case "DWord":
                                        {
                                            break;
                                        }
                                    case "Real":
                                        {
                                            break;
                                        }

                                }
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name + "   XModbus.WriteTag", ex.Message);
            }
            finally
            {
                SendDone.Set();
            }
        }
        #endregion


        private void SendPackage(IModbusMaster modbus, Device dv, DataBlock db)
        {
            try
            {
                SendDone.WaitOne(-1);

                switch (db.DataType)
                {
                    case "Bit":
                        byte[] bitArys = null;
                        switch (db.TypeOfRead)
                        {
                            case "ReadCoilStatus":
                                bitArys = modbus.ReadCoilStatus((byte)dv.SlaveId, $"{db.StartAddress}",
                              db.Length);
                                break;
                            case "ReadInputStatus":
                                bitArys = modbus.ReadInputStatus((byte)dv.SlaveId, $"{db.StartAddress}",
                           db.Length);
                                break;
                            default:
                                break;
                        }
                        var BitRs = Bit.ToArray(bitArys);
                        if (bitArys.Length > db.Tags.Count) return;
                        for (var j = 0; j < db.Tags.Count; j++)
                        {
                            db.Tags[j].Value = BitRs[j];
                            db.Tags[j].Checked = BitRs[j];
                            db.Tags[j].Enabled = BitRs[j];
                            db.Tags[j].Visible = BitRs[j];
                            db.Tags[j].ValueSelect1 = BitRs[j];
                            db.Tags[j].ValueSelect2 = BitRs[j];
                            db.Tags[j].Timestamp = DateTime.Now;
                        }
                        break;
                    case "Int":
                        var IntArys = modbus.ReadHoldingRegisters((byte)dv.SlaveId,
                            $"{db.StartAddress}", db.Length);
                        var IntRs = Int.ToArray(IntArys);
                        if (IntRs.Length > db.Tags.Count) return;
                        for (var j = 0; j < IntRs.Length; j++)
                        {
                            db.Tags[j].Value = IntRs[j];
                            db.Tags[j].Timestamp = DateTime.Now;
                        }
                        break;
                    case "DInt":
                        var DIntArys = modbus.ReadHoldingRegisters((byte)dv.SlaveId,
                            $"{db.StartAddress}", db.Length);
                        var DIntRs = Int.ToArray(DIntArys);
                        if (DIntRs.Length > db.Tags.Count) return;
                        for (var j = 0; j < DIntRs.Length; j++)
                        {
                            db.Tags[j].Value = DIntRs[j];
                            db.Tags[j].Timestamp = DateTime.Now;
                        }
                        break;
                    case "Word":
                        byte[] wdArys = null;
                        switch (db.TypeOfRead)
                        {
                            case "ReadHoldingRegisters":
                                wdArys = modbus.ReadHoldingRegisters((byte)dv.SlaveId, $"{db.StartAddress}", db.Length);

                                break;
                            case "ReadInputRegisters":
                                wdArys = modbus.ReadInputRegisters((byte)dv.SlaveId, $"{db.StartAddress}", db.Length);

                                break;
                            default:
                                break;
                        }
                        var wdRs = Word.ToArray(wdArys);
                        if (wdRs.Length > db.Tags.Count) return;

                        for (var j = 0; j < wdRs.Length; j++)
                        {
                            db.Tags[j].Value = wdRs[j];
                            db.Tags[j].Timestamp = DateTime.Now;
                        }
                        break;
                    case "DWord":
                        var dwArys = modbus.ReadHoldingRegisters((byte)dv.SlaveId,
                            $"{db.StartAddress}", db.Length);
                        var dwRs = DWord.ToArray(dwArys);
                        for (var j = 0; j < dwRs.Length; j++)
                        {
                            db.Tags[j].Value = dwRs[j];
                            db.Tags[j].Timestamp = DateTime.Now;
                        }
                        break;
                    case "Real":
                        var rl1Arys = modbus.ReadHoldingRegisters((byte)dv.SlaveId,
                            $"{db.StartAddress}", db.Length);
                        var rl1Rs = Real.ToArray(rl1Arys);
                        for (var j = 0; j < rl1Rs.Length; j++)
                        {
                            db.Tags[j].Value = rl1Rs[j];
                            db.Tags[j].Timestamp = DateTime.Now;
                        }

                        break;

                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                EventscadaException?.Invoke(this.GetType().Name + "   XModbus.SendPackage", ex.Message);
            }
        }


    }
}