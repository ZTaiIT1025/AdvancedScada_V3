using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Comm;
using AdvancedScada.DriverBase.Core.DataTypes;
using AdvancedScada.DriverBase.Devices;
using AdvancedScada.IBaseService;
using AdvancedScada.XFATEK.Core.Comm;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedScada.XFATEK.Core
{
    public class DataService : IServiceDriver
    {
        #region Fiald


        public static List<Channel> Channels = new List<Channel>();
        private static Dictionary<string, FatekCommunication> mbe = new Dictionary<string, FatekCommunication>();
        //private static Dictionary<string, DVPRTUMaster> rtu = new Dictionary<string, DVPRTUMaster>();
        //private static Dictionary<string, DVPASCIIMaster> ascii = new Dictionary<string, DVPASCIIMaster>();
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




                FatekCommunication modbus = null;
                switch (ch.ConnectionType)
                {
                    case "SerialPort":
                        var dis = (DISerialPort)ch;
                        var sp = new SerialPort(dis.PortName, dis.BaudRate, dis.Parity, dis.DataBits, dis.StopBits);
                        sp.Handshake = dis.Handshake;
                      

                        modbus = new FatekCommunication(sp);
                        mbe.Add(ch.ChannelName, (FatekCommunication)modbus);
                        break;

                }
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
                        FatekCommunication modbus = null;
                        var ch = (Channel)chParam;

                        modbus = mbe[ch.ChannelName];
                        modbus.Connect();
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
        public void WriteTag(string TagName, dynamic Value)
        {
           

            SendDone.Reset();
            try
            {
                var strArrays = TagName.Split('.');
                var str = $"{strArrays[0]}.{strArrays[1]}.{strArrays[2]}";
                foreach (var ch in Channels)
                    foreach (var dv in ch.Devices)
                    {
                        foreach (var db in dv.DataBlocks)
                        {
                            var bEquals = $"{ch.ChannelName}.{dv.DeviceName}.{db.DataBlockName}".Equals(str);
                            if (bEquals)
                            {
                                FatekCommunication modbusMaster = null;

                                modbusMaster = mbe[ch.ChannelName];
                                var bmodbus = modbusMaster == null;
                                if (bmodbus) return;
                                var obj = modbusMaster;
                                DataType dataType = (DataType)Enum.Parse(typeof(DataType), TagCollection.Tags[TagName].DataType);
                                MemoryType memoryType = (MemoryType)Enum.Parse(typeof(MemoryType), db.MemoryType);
                                lock (obj)
                                {
                                    switch (TagCollection.Tags[TagName].DataType)
                                    {
                                        case "BOOL":
                                            if (Value == "1")
                                                modbusMaster.WriteSingleDiscrete((byte)dv.SlaveId, CommandCode.SINGLE_DISCRETE_CONTROL, RunningCode.Set, memoryType, ushort.Parse(TagCollection.Tags[TagName].Address), dataType);

                                            else
                                                modbusMaster.WriteSingleDiscrete((byte)dv.SlaveId, CommandCode.SINGLE_DISCRETE_CONTROL, RunningCode.Reset, memoryType, ushort.Parse(TagCollection.Tags[TagName].Address), dataType);

                                            break;
                                        
                                        case "INT":
                                        case "DINT":
                                        case "WORD":
                                        case "DWORD":
                                        case "REAL":
                                            {
                                                string[] DataAsArray = { Value };
                                                var dataPacket = new List<object>();
                                                var x = new byte[2];
                                                for (var i = 0; i < DataAsArray.Length; i++)
                                                {
                                                    x = BitConverter.GetBytes(Convert.ToInt16(DataAsArray[i]));

                                                    dataPacket.Add(x[1]);
                                                    dataPacket.Add(x[0]);
                                                }


                                                modbusMaster.WriteMultipeRegisters((byte)dv.SlaveId, 1, memoryType, ushort.Parse(TagCollection.Tags[TagName].Address), dataType, dataPacket.ToArray());

                                                break;
                                            }
                                        
                                    }
                                }
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                var err = new HMIException.ScadaException(this.GetType().Name + "   XModbus.WriteTag", ex.Message);
            }
            finally
            {
                SendDone.Set();
            }
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

        private void SendPackage(FatekCommunication modbus, Device dv, DataBlock db)
        {
            try
            {
                SendDone.WaitOne(-1);
                DataType dataType = (DataType)Enum.Parse(typeof(DataType), db.DataType);
                MemoryType memoryType = (MemoryType)Enum.Parse(typeof(MemoryType), db.MemoryType);

                switch (db.DataType)
                {
                    case "BOOL":
                        bool[] BitRs = null;
                        switch (db.TypeOfRead)
                        {
                            case "ReadCoilStatus":
                                BitRs = modbus.ReadDiscretes((byte)dv.SlaveId, db.Length, memoryType, db.StartAddress, dataType);

                                break;
                            case "ReadInputStatus":
                                //     bitArys = modbus.ReadInputStatus((byte)dv.SlaveId, $"{db.StartAddress}",
                                //db.Length);
                                break;
                            default:
                                break;
                        }

                        if (BitRs.Length > db.Tags.Count) return;
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
                    case "INT":
                    case "DINT":
                    case "WORD":
                    case "DWORD":
                    case "REAL":
                        object[] wdArys = null;
                        switch (db.TypeOfRead)
                        {
                            case "ReadHoldingRegisters":
                                wdArys = modbus.ReadRegisters((byte)dv.SlaveId, db.Length, memoryType, db.StartAddress, dataType);

                                break;
                            case "ReadInputRegisters":
                                //wdArys = modbus.ReadInputRegisters((byte)dv.SlaveId, $"{db.StartAddress}", db.Length);

                                break;
                            default:
                                break;
                        }

                        if (wdArys.Length > db.Tags.Count) return;

                        for (var j = 0; j < wdArys.Length; j++)
                        {
                            db.Tags[j].Value = wdArys[j];
                            db.Tags[j].Timestamp = DateTime.Now;
                        }
                        break;
                    
                }
            }
            catch (Exception ex)
            {
                IsConnected = false;
                var err = new HMIException.ScadaException(this.GetType().Name + "   XFATEK.SendPackage", ex.Message);
            }
        }

        #endregion
    }
}
