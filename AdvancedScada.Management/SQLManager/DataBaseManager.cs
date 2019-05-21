using System;
using System.Collections.Generic;
using System.Xml;

namespace AdvancedScada.Management.SQLManager
{
    public class DataBaseManager
    {
        public const string DataBase = "DataBase";
        public const string DataBase_ID = "DataBaseId";
        public const string DataBase_NAME = "DataBaseName";

        private static readonly object mutex = new object();
        private static DataBaseManager _instance;

        public static DataBaseManager GetDataBaseManager()
        {
            lock (mutex)
            {
                if (_instance == null) _instance = new DataBaseManager();
            }

            return _instance;
        }
        /// <summary>
        ///     Thêm mới thiết bị.
        /// </summary>
        /// <param name="ch">Kênh</param>
        /// <param name="ch">Thiết bị</param>
        public static void Add(Server ch, DataBase dv)
        {
            try
            {
                if (dv == null) throw new NullReferenceException("The device is null reference exception");
                var fDv = IsExisted(ch, dv);
                if (fDv != null) throw new Exception($"Device name: '{dv.DataBaseName}' is existed");
                ch.DataBase.Add(dv);
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
        public static void Update(Server ch, DataBase dv)
        {
            try
            {
                if (dv == null) throw new NullReferenceException("The Device is null reference exception");
                var fCh = IsExisted(ch, dv);
                if (fCh != null) throw new Exception($"Device name: '{dv.DataBaseName}' is existed");
                foreach (var item in ch.DataBase)
                    if (item.DataBaseId == dv.DataBaseId)
                    {
                        item.DataBaseId = dv.DataBaseId;
                        item.DataBaseName = dv.DataBaseName;
                        item.Description = dv.Description;
                        item.Description = dv.Description;
                        // item.DataBlocks = dv.DataBlocks;
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
        public static void Delete(Server ch, int chId)
        {
            try
            {
                var result = GetByDeviceId(ch, chId);
                if (result == null) throw new KeyNotFoundException("Device Id is not found exception");
                ch.DataBase.Remove(result);
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
        public static void Delete(Server ch, string chName)
        {
            try
            {
                var result = GetByDataBaseName(ch, chName);
                if (result == null) throw new KeyNotFoundException("Device name is not found exception");
                ch.DataBase.Remove(result);
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
        public static void Delete(Server ch, DataBase dv)
        {
            try
            {
                if (dv == null) throw new NullReferenceException("The Device is null reference exception");
                foreach (var item in ch.DataBase)
                    if (item.DataBaseId == dv.DataBaseId)
                    {
                        ch.DataBase.Remove(item);
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
        public static DataBase IsExisted(Server ch, DataBase dv)
        {
            DataBase result = null;
            try
            {
                foreach (var item in ch.DataBase)
                    if (item.DataBaseId != dv.DataBaseId && item.DataBaseName.Equals(dv.DataBaseName))
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
        public static DataBase GetByDeviceId(Server ch, int chId)
        {
            DataBase result = null;
            try
            {
                foreach (var item in ch.DataBase)
                    if (item.DataBaseId == chId)
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
        public static DataBase GetByDataBaseName(Server ch, string chName)
        {
            DataBase result = null;
            try
            {
                foreach (var item in ch.DataBase)
                    if (item.DataBaseName.Equals(chName))
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
        public static List<DataBase> GetDevices(XmlNode chNode)
        {
            var dvList = new List<DataBase>();
            try
            {
                foreach (XmlNode dvNode in chNode)
                {
                    var newDataBase = new DataBase();
                    newDataBase.DataBaseId = int.Parse(dvNode.Attributes[DataBase_ID].Value);
                    newDataBase.DataBaseName = dvNode.Attributes[DataBase_NAME].Value;
                    newDataBase.Description = dvNode.Attributes[ServerManager.DESCRIPTION].Value;
                    newDataBase.Tables = TableManager.GetTables(dvNode);
                    dvList.Add(newDataBase);
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