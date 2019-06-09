using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Transactions;
using System.Xml;
using System.Xml.Linq;
using AdvancedScada.DriverBase;
using AdvancedScada.DriverBase.Devices;
using Microsoft.Win32;
using System.Linq;
using static AdvancedScada.IBaseService.Common.XCollection;
namespace AdvancedScada.Management.BLManager
{
    
    public class ChannelService : BaseBindingXML
    {

       

        public static List<Channel> _Channels;

        private static readonly object mutex = new object();
        private static ChannelService _instance;

        private readonly DeviceService objDeviceManager = new DeviceService();

        public string XML_NAME_DEFAULT = "TagCollection";

        public ChannelService()
        {
            _Channels = new List<Channel>();

        }

        public ChannelService(string xmlPath)
            : this()
        {
            XmlPath = xmlPath;
        }

        public Tag this[string tagName]
        {
            get
            {
                if (TagCollection.Tags.Count == 0) throw new NullReferenceException("No element");
                return TagCollection.Tags[tagName];
            }
        }

        [Browsable(false)]
        public string XmlPath { set; get; }
        [Browsable(false)]
        public List<Channel> Channels
        {
            get => _Channels;
            set => _Channels = value;
        }
        [Browsable(false)]
        public Channel CurrentChannel
        {
            set;
            get;
        }
        [Browsable(false)]
        public int NumberOfChannel => _Channels.Count;
        [Browsable(false)]
        public int LastChannelId
        {
            get
            {
                if (Channels.Count == 0) return 1;
                var last = Channels[0].ChannelId;
                foreach (var ch in Channels)
                {
                    if (ch.Devices == null) ch.Devices = new List<Device>();
                    if (ch.ChannelId > last) last = ch.ChannelId;
                }
                return last + 1;
            }
        }
        public void Dispose()
        {
        }

        public static ChannelService GetChannelManager()
        {
            lock (mutex)
            {
                if (_instance == null) _instance = new ChannelService();
            }

            return _instance;
        }


        /// <summary>
        ///     Thêm mới kênh.
        /// </summary>
        /// <param name="ch">Kênh</param>
        public void Add(Channel ch)
        {
            try
            {
                if (ch == null) throw new NullReferenceException("The Channel is null reference exception");
                var fCh = IsExisted(ch);
                if (fCh != null) throw new Exception($"Channel name: '{ch.ChannelName}' is existed");
                _Channels.Add(ch);
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        /// <summary>
        ///     Cập nhật kênh.
        /// </summary>
        /// <param name="ch">Kênh</param>
        public void Update(Channel ch)
        {
            try
            {
                if (ch == null) throw new NullReferenceException("The Channel is null reference exception");
                var fCh = IsExisted(ch);
                if (fCh != null) throw new Exception($"Channel name: '{ch.ChannelName}' is existed");
                foreach (var item in _Channels)
                    if (item.ChannelId == ch.ChannelId)
                    {
                        item.ChannelName = ch.ChannelName;
                        item.ChannelTypes = ch.ChannelTypes;
                        item.Description = ch.Description;
                        item.Mode = ch.Mode;
                        item.CPU = ch.CPU;
                        item.Rack = ch.Rack;
                        item.Slot = ch.Slot;
                        item.ConnectionType = ch.ConnectionType;
                        item.Devices = ch.Devices;
                        switch (ch.ConnectionType)
                        {
                            case "SerialPort":
                                var sp = (DISerialPort)item;
                                var spParam = (DISerialPort)ch;
                                sp.PortName = spParam.PortName;
                                sp.BaudRate = spParam.BaudRate;
                                sp.DataBits = spParam.DataBits;
                                sp.StopBits = spParam.StopBits;
                                sp.Parity = spParam.Parity;
                                sp.Handshake = spParam.Handshake;
                                break;
                            case "Ethernet":
                                var en = (DIEthernet)item;
                                var enParam = (DIEthernet)ch;
                                en.IPAddress = enParam.IPAddress;
                                en.Port = enParam.Port;
                                break;
                        }
                    }
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        /// <summary>
        ///     Xóa kênh.
        /// </summary>
        /// <param name="chId">Mã kênh</param>
        public void Delete(int chId)
        {
            try
            {
                var result = GetByChannelId(chId);
                if (result == null) throw new KeyNotFoundException("Channel Id is not found exception");
                _Channels.Remove(result);
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        /// <summary>
        ///     Xóa kênh.
        /// </summary>
        /// <param name="chName">Tên kênh</param>
        public void Delete(string chName)
        {
            try
            {
                var result = GetByChannelName(chName);
                if (result == null) throw new KeyNotFoundException("Channel name is not found exception");
                _Channels.Remove(result);
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        /// <summary>
        ///     Xóa kênh.
        /// </summary>
        /// <param name="ch">Kênh</param>
        public void Delete(Channel ch)
        {
            try
            {
                if (ch == null) throw new NullReferenceException("The Channel is null reference exception");
                foreach (var item in _Channels)
                    if (item.ChannelId == ch.ChannelId)
                    {
                        _Channels.Remove(item);
                        break;
                    }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        /// <summary>
        ///     Phương thức kiểm tra kênh đã tồn tại chưa?
        /// </summary>
        /// <param name="ch">Kênh</param>
        /// <returns>Kênh</returns>
        public Channel IsExisted(Channel ch)
        {
            Channel result = null;
            try
            {
                foreach (var item in _Channels)
                    if (item.ChannelId != ch.ChannelId && item.ChannelName.Equals(ch.ChannelName))
                    {
                        result = item;
                        break;
                    }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            return result;
        }

        /// <summary>
        ///     Tìm kiếm kênh theo mã kênh.
        /// </summary>
        /// <param name="chId">Mã kênh</param>
        /// <returns>Kênh</returns>
        public Channel GetByChannelId(int chId)
        {
            Channel result = null;
            try
            {
                foreach (var item in _Channels)
                    if (item.ChannelId == chId)
                    {
                        result = item;
                        break;
                    }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            return result;
        }

        /// <summary>
        ///     Tìm kiếm kênh theo tên kênh.
        /// </summary>
        /// <param name="chName">Tên kênh</param>
        /// <returns>Kênh</returns>
        public Channel GetByChannelName(string chName)
        {
            Channel result = null;
            try
            {
                foreach (var item in _Channels)
                    if (item.ChannelName.Equals(chName))
                    {
                        result = item;
                        break;
                    }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            return result;
        }

        /// <summary>
        ///     Hàm đọc danh sách các kênh.
        /// </summary>
        /// <returns></returns>
        public List<Channel> GetChannels(string XmlPath)
        {
            try
            {
                var xmlDoc = new XmlDocument();
                if (string.IsNullOrEmpty(XmlPath) || string.IsNullOrWhiteSpace(XmlPath))
                    XmlPath = ReadKey(XML_NAME_DEFAULT);
                xmlDoc.Load(XmlPath);
                var nodes = xmlDoc.SelectNodes(ROOT);
                foreach (XmlNode rootNode in nodes)
                {
                    var channelNodeList = rootNode.SelectNodes(CHANNEL);
                    foreach (XmlNode chNode in channelNodeList)
                    {
                        Channel newChannel = null;
                        var connType = chNode.Attributes[Connection_Type].Value;

                        switch (connType)
                        {
                            case "SerialPort":
                                newChannel = new DISerialPort();
                                var dis = (DISerialPort)newChannel;
                                dis.PortName = chNode.Attributes[PORT_NAME].Value;
                                dis.BaudRate = int.Parse(chNode.Attributes[BAUDRATE].Value);
                                dis.DataBits = int.Parse(chNode.Attributes[DATABITS].Value);
                                dis.Parity = (Parity)Enum.Parse(typeof(Parity), chNode.Attributes[PARITY].Value);
                                dis.StopBits =
                                    (StopBits)Enum.Parse(typeof(StopBits), chNode.Attributes[STOPBITS].Value);
                                dis.Handshake = (Handshake)Enum.Parse(typeof(Handshake),
                                    chNode.Attributes[HANDSHAKE].Value);
                                break;
                            case "Ethernet":
                                newChannel = new DIEthernet();
                                var die = (DIEthernet)newChannel;
                                die.IPAddress = chNode.Attributes[IP_ADDRESS].Value;
                                die.Port = short.Parse(chNode.Attributes[PORT].Value);
                                break;
                        }

                        if (newChannel != null)
                        {
                            newChannel.ChannelId = int.Parse(chNode.Attributes[CHANNEL_ID].Value);
                            newChannel.ChannelName = chNode.Attributes[CHANNEL_NAME].Value;
                            newChannel.ConnectionType = connType;
                            newChannel.ChannelTypes = chNode.Attributes[CHANNEL_Types].Value;
                            newChannel.CPU = chNode.Attributes[MODEL].Value;
                            newChannel.Rack = short.Parse(chNode.Attributes[RACK].Value);
                            newChannel.Slot = short.Parse(chNode.Attributes[SLOT].Value);
                            newChannel.Mode = chNode.Attributes[MODE].Value;
                            newChannel.Description = chNode.Attributes[DESCRIPTION].Value;
                            newChannel.Devices = objDeviceManager.GetDevices(chNode);
                            _Channels.Add(newChannel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            return _Channels;
        }

        #region CreatFile

        /// <summary>
        ///     Phương thức tạo file cấu hình.
        /// </summary>
        /// <param name="pathXml">Tên file</param>
        public void CreatFile(string pathXml)
        {
            try
            {
                if (File.Exists(pathXml)) File.Delete(pathXml);
                var element = new XElement(ROOT);
                var doc = new XDocument(element);
                doc.Save(pathXml);
                XmlPath = pathXml;
                WriteKey(XML_NAME_DEFAULT, pathXml);
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        /// <summary>
        ///     Phương thức đọc key.
        /// </summary>
        /// <param name="keyName">Tên key</param>
        /// <returns>Giá trị của key</returns>
        public string ReadKey(string keyName)
        {
            var result = string.Empty;
            try
            {
                RegistryKey regKey;
                regKey = Registry.CurrentUser.OpenSubKey(@"Software\IndustrialHMI"); //HKEY_CURRENR_USER\Software\VSSCD
                if (regKey != null) result = (string)regKey.GetValue(keyName);
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            return result;
        }

        /// <summary>
        ///     Phương thức ghi tên và giá trị của key
        /// </summary>
        /// <param name="keyName">Tên key</param>
        /// <param name="keyValue">Giá trị của key</param>
        public void WriteKey(string keyName, string keyValue)
        {
            try
            {
                RegistryKey regKey;
                regKey = Registry.CurrentUser.CreateSubKey(@"Software\IndustrialHMI");
                regKey.SetValue(keyName, keyValue);
                regKey.Close();
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }


        public void Save(string pathXml)
        {
            try
            {
                WriteKey(XML_NAME_DEFAULT, pathXml);
                CreatFile(pathXml);
                XmlPath = pathXml;
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(pathXml);
                var root = xmlDoc.SelectSingleNode(ROOT);

                // List Channels.
                foreach (var ch in Channels)
                {
                    var chElement = xmlDoc.CreateElement(CHANNEL);
                    chElement.SetAttribute(CHANNEL_ID, $"{ch.ChannelId}");
                    chElement.SetAttribute(CHANNEL_NAME, ch.ChannelName);
                    chElement.SetAttribute(CHANNEL_Types, ch.ChannelTypes);
                    chElement.SetAttribute(MODEL, $"{ch.CPU}");
                    chElement.SetAttribute(RACK, $"{ch.Rack}");
                    chElement.SetAttribute(SLOT, $"{ch.Slot}");
                    chElement.SetAttribute(Connection_Type, $"{ch.ConnectionType}");
                    chElement.SetAttribute(MODE, $"{ch.Mode}");
                    switch (ch.ConnectionType)
                    {
                        case "SerialPort":
                            var dis = (DISerialPort)ch;
                            chElement.SetAttribute(PORT_NAME, dis.PortName);
                            chElement.SetAttribute(BAUDRATE, $"{dis.BaudRate}");
                            chElement.SetAttribute(DATABITS, $"{dis.DataBits}");
                            chElement.SetAttribute(STOPBITS, $"{dis.StopBits}");
                            chElement.SetAttribute(PARITY, $"{dis.Parity}");
                            chElement.SetAttribute(HANDSHAKE, $"{dis.Handshake}");
                            break;
                        case "Ethernet":
                            var die = (DIEthernet)ch;
                            chElement.SetAttribute(IP_ADDRESS, die.IPAddress);
                            chElement.SetAttribute(PORT, $"{die.Port}");
                            break;
                    }

                    chElement.SetAttribute(DESCRIPTION, ch.Description);
                    root.AppendChild(chElement);
                    if (ch.Devices.Count == 0) continue;

                    // List Devices.
                    foreach (var dv in ch.Devices)
                    {
                        var dvElement = xmlDoc.CreateElement(DeviceService.DEVICE);
                        dvElement.SetAttribute(DeviceService.DEVICE_ID, $"{dv.DeviceId}");
                        dvElement.SetAttribute(DeviceService.DEVICE_NAME, dv.DeviceName);
                        dvElement.SetAttribute(DeviceService.SLAVE_ID, $"{dv.SlaveId}");
                        dvElement.SetAttribute(DESCRIPTION, dv.Description);
                        chElement.AppendChild(dvElement);
                        if (dv.DataBlocks.Count == 0) continue;
                        // List DataBlock.
                        foreach (var db in dv.DataBlocks)
                        {
                            var dbElement = xmlDoc.CreateElement(DataBlockService.DATABLOCK);
                            dbElement.SetAttribute(DataBlockService.CHANNEL_ID, $"{db.ChannelId}");
                            dbElement.SetAttribute(DataBlockService.DEVICE_ID, $"{db.DeviceId}");
                            dbElement.SetAttribute(DataBlockService.DATABLOCK_ID, $"{db.DataBlockId}");
                            dbElement.SetAttribute(DataBlockService.DATABLOCK_NAME, db.DataBlockName);
                            dbElement.SetAttribute(DataBlockService.TypeOfRead, $"{db.TypeOfRead}");
                            dbElement.SetAttribute(DataBlockService.START_ADDRESS, $"{db.StartAddress}");
                            dbElement.SetAttribute(DataBlockService.LENGTH, $"{db.Length}");
                            dbElement.SetAttribute(DataBlockService.DATA_TYPE, $"{db.DataType}");
                            dbElement.SetAttribute(DataBlockService.MemoryType, $"{db.MemoryType}");
                            dbElement.SetAttribute(DESCRIPTION, db.Description);
                            dvElement.AppendChild(dbElement);

                            // List Tags.
                            foreach (var tg in db.Tags)
                            {
                                var tgElement = xmlDoc.CreateElement(TagService.TAG);
                                tgElement.SetAttribute(DataBlockService.CHANNEL_ID, $"{db.ChannelId}");
                                tgElement.SetAttribute(DataBlockService.DEVICE_ID, $"{db.DeviceId}");
                                tgElement.SetAttribute(DataBlockService.DATABLOCK_ID, $"{db.DataBlockId}");
                                tgElement.SetAttribute(TagService.TAG_ID, $"{tg.TagId}");
                                tgElement.SetAttribute(TagService.TAG_NAME, tg.TagName);
                                tgElement.SetAttribute(TagService.ADDRESS, $"{tg.Address}");
                                tgElement.SetAttribute(TagService.DATA_TYPE, $"{tg.DataType}");
                                tgElement.SetAttribute(DESCRIPTION, tg.Description);
                                dbElement.AppendChild(tgElement);
                            }
                        }
                    }
                }

                xmlDoc.Save(pathXml);
            }
            catch (Exception ex)
            {
                EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
        }

        #endregion
        internal List<Device> GetByChannel(Channel channel)
        {
           List<Device> result = null;
            try
            {
                foreach (var item in _Channels)
                    if (item.ChannelName.Equals(channel.ChannelName))
                    {
                        result = item.Devices;
                        break;
                    }
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            return result;
        }

        internal object GetNewIPAddress()
        {
            throw new NotImplementedException();
        }
        internal List<Tag> GetByListTag(DataBlock db)
        {
            List<Tag> result = null;
            try
            {
                
             result = db.Tags;
            return result;
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                  
            }
            return result;

        }
        internal List<DataBlock> GetByListDataBlock(Device dv)
        {
            List<DataBlock> result = null;
            try
            {
                
           result = dv.DataBlocks;
                    
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }

            return result;
        }
        public Channel Copy(Channel source)
        {
            Channel ch = source.CopyObject<Channel>();
            try
            {
               
                if (ch != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        DeviceService deviceService = new DeviceService();
                        ch.Devices = GetByChannel(ch);
                        ch.ChannelId = GetNewId();
                        ch.ChannelName = $"{ch.ChannelName}New";
                      
                        if (ch.Devices != null)
                        {
                            DataBlockService dataBlockService = new DataBlockService();
                            TagService tagService = new TagService();
                            foreach (Device dv in ch.Devices.ToList())
                            {
                              
                                dv.ChannelId = ch.ChannelId;
                               
                                if (dv.DataBlocks != null)
                                {
                                    foreach (DataBlock db in dv.DataBlocks.ToList())
                                    {
                                      
                                        db.ChannelId = ch.ChannelId;
                                        db.DeviceId = dv.DeviceId;
                                        
                                        foreach (Tag tag in db.Tags.ToList())
                                        {
                                            tag.ChannelId = ch.ChannelId;
                                            tag.DeviceId = dv.DeviceId;
                                            tag.DataBlockId = db.DataBlockId;
                                            
                                        }
                                    }
                                }
                            }
                        }
                        transactionScope.Complete();
                    }
                }
                return ch;
            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
            return ch;
        }

        private int GetNewId()
        {
            short GetInt = 0;
            
            int max = _Channels.Max(r => r.ChannelId);
            GetInt = (short)(max + 1);
            return GetInt;
        }
    }
}