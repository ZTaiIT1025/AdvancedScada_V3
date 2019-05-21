using System;
using System.Collections.Generic;
using System.Xml;
using AdvancedScada.DriverBase.Devices;

namespace AdvancedScada.Management.BLManager

{

    public class DeviceManager
    {
        public const string DEVICE = "Device";
        public const string DEVICE_ID = "DeviceId";
        public const string DEVICE_NAME = "DeviceName";
        public const string SLAVE_ID = "SlaveId";
        private static readonly object mutex = new object();
        private static DeviceManager _instance;

        private readonly DataBlockManager objDataBlockManager;
        public DeviceManager()
        {
            objDataBlockManager = new DataBlockManager();
        }

        public static DeviceManager GetDeviceManager()
        {
            lock (mutex)
            {
                if (_instance == null) _instance = new DeviceManager();
            }

            return _instance;
        }
        /// <summary>
        ///     Thêm mới thiết bị.
        /// </summary>
        /// <param name="ch">Kênh</param>
        /// <param name="ch">Thiết bị</param>
        public void Add(Channel ch, Device dv)
        {
            try
            {
                if (dv == null) throw new NullReferenceException("The device is null reference exception");
                var fDv = IsExisted(ch, dv);
                if (fDv != null) throw new Exception($"Device name: '{dv.DeviceName}' is existed");
                ch.Devices.Add(dv);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Cập nhật thiết bị.
        /// </summary>
        /// <param name="ch">Kênh</param>
        /// <param name="dv">Thiết bị</param>
        public void Update(Channel ch, Device dv)
        {
            try
            {
                if (dv == null) throw new NullReferenceException("The Device is null reference exception");
                var fCh = IsExisted(ch, dv);
                if (fCh != null) throw new Exception($"Device name: '{dv.DeviceName}' is existed");
                foreach (var item in ch.Devices)
                    if (item.DeviceId == dv.DeviceId)
                    {
                        item.DeviceId = dv.DeviceId;
                        item.DeviceName = dv.DeviceName;
                        item.SlaveId = dv.SlaveId;
                        item.Description = dv.Description;
                        item.DataBlocks = dv.DataBlocks;
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Xóa kênh.
        /// </summary>
        /// <param name="ch">Kênh</param>
        /// <param name="chId">Mã thiết bị</param>
        public void Delete(Channel ch, int chId)
        {
            try
            {
                var result = GetByDeviceId(ch, chId);
                if (result == null) throw new KeyNotFoundException("Device Id is not found exception");
                ch.Devices.Remove(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Xóa kênh.
        /// </summary>
        /// <param name="ch">Kênh</param>
        /// <param name="chName">Tên thiết bị</param>
        public void Delete(Channel ch, string chName)
        {
            try
            {
                var result = GetByDeviceName(ch, chName);
                if (result == null) throw new KeyNotFoundException("Device name is not found exception");
                ch.Devices.Remove(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Xóa thiết bị.
        /// </summary>
        /// <param name="ch">Kênh</param>
        /// <param name="dv">thiết bị</param>
        public void Delete(Channel ch, Device dv)
        {
            try
            {
                if (dv == null) throw new NullReferenceException("The Device is null reference exception");
                foreach (var item in ch.Devices)
                    if (item.DeviceId == dv.DeviceId)
                    {
                        ch.Devices.Remove(item);
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Phương thức kiểm tra thiết bị đã tồn tại chưa?
        /// </summary>
        /// <param name="ch">Kênh</param>
        /// <param name="dv">Thiết bị</param>
        /// <returns>Thiết bị</returns>
        public Device IsExisted(Channel ch, Device dv)
        {
            Device result = null;
            try
            {
                foreach (var item in ch.Devices)
                    if (item.DeviceId != dv.DeviceId && item.DeviceName.Equals(dv.DeviceName))
                    {
                        result = item;
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        ///     Tìm kiếm kênh theo mã thiết bị.
        /// </summary>
        /// <param name="ch">Kênh</param>
        /// <param name="chId">Mã kênh</param>
        /// <returns>Thiết bị</returns>
        public Device GetByDeviceId(Channel ch, int chId)
        {
            Device result = null;
            try
            {
                foreach (var item in ch.Devices)
                    if (item.DeviceId == chId)
                    {
                        result = item;
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        ///     Tìm kiếm kênh theo tên thiết bị.
        /// </summary>
        /// <param name="ch">Kênh</param>
        /// <param name="chName">Tên kênh</param>
        /// <returns>Thiết bị</returns>
        public Device GetByDeviceName(Channel ch, string chName)
        {
            Device result = null;
            try
            {
                foreach (var item in ch.Devices)
                    if (item.DeviceName.Equals(chName))
                    {
                        result = item;
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        ///     Hàm đọc danh sách các thiết bị.
        /// </summary>
        /// <param name="chNode">XmlNode</param>
        /// <returns>Danh sách thiết bị</returns>
        public List<Device> GetDevices(XmlNode chNode)
        {
            var dvList = new List<Device>();
            try
            {
                foreach (XmlNode dvNode in chNode)
                {
                    var newDevice = new Device();
                    newDevice.DeviceId = int.Parse(dvNode.Attributes[DEVICE_ID].Value);
                    newDevice.DeviceName = dvNode.Attributes[DEVICE_NAME].Value;
                    newDevice.SlaveId = short.Parse(dvNode.Attributes[SLAVE_ID].Value);
                    newDevice.Description = dvNode.Attributes[ChannelManager.DESCRIPTION].Value;
                    newDevice.DataBlocks = objDataBlockManager.GetDataBlocks(dvNode);
                    dvList.Add(newDevice);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dvList;
        }
    }
}