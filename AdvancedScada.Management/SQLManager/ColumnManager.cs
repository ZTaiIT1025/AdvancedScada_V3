using System;
using System.Collections.Generic;
using System.Xml;

namespace AdvancedScada.Management.SQLManager
{
    public class ColumnManager
    {
        public const string Column = "Column";
        public const string Column_ID = "ColumnId";
        public const string Column_NAME = "ColumnName";
        public const string TAG_NAME = "TagName";
        public const string Channel = "Channel";
        public const string Device = "Device";
        public const string DataBlock = "DataBlock";
        public const string Mode = "Mode";
        public const string TriggerType = "TriggerType";
        public const string DESCRIPTION = "Description";
        private static readonly object mutex = new object();
        private static ColumnManager _instance;

        public static ColumnManager GetColumnManager()
        {
            lock (mutex)
            {
                if (_instance == null) _instance = new ColumnManager();
            }

            return _instance;
        }
        /// <summary>
        ///     Thêm mới gói dữ liệu.
        /// </summary>
        /// <param name="db">gói dữ liệu</param>
        /// <param name="db">gói dữ liệu</param>
        public static void Add(Table db, Column tg)
        {
            try
            {
                if (tg == null) throw new NullReferenceException("The Tag is null reference exception");
                IsExisted(db, tg);
                db.Columns.Add(tg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Cập nhật gói dữ liệu.
        /// </summary>
        /// <param name="db">Thiết bị</param>
        /// <param name="tg">gói dữ liệu</param>
        public static void Update(Table db, Column tg)
        {
            try
            {
                if (tg == null) throw new NullReferenceException("The Tag is null reference exception");
                IsExisted(db, tg);
                foreach (var item in db.Columns)
                    if (item.ColumnId == tg.ColumnId)
                    {
                        item.ColumnId = tg.ColumnId;
                        item.TagName = tg.TagName;
                        item.ColumnName = tg.ColumnName;
                        item.Channel = tg.Channel;
                        item.Device = tg.Device;
                        item.DataBlock = tg.DataBlock;
                        item.Mode = tg.Mode;
                        item.TriggerType = tg.TriggerType;
                        item.Description = tg.Description;
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Xóa gói dữ liệu.
        /// </summary>
        /// <param name="db">Thiết bị</param>
        /// <param name="tgId">Mã gói dữ liệu</param>
        public static void Delete(Table db, int tgId)
        {
            try
            {
                var result = GetByTagId(db, tgId);
                if (result == null) throw new KeyNotFoundException("Tag Id is not found exception");
                db.Columns.Remove(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Xóa gói dữ liệu.
        /// </summary>
        /// <param name="db">Thiết bị</param>
        /// <param name="dbName">Tên gói dữ liệu</param>
        public static void Delete(Table db, string dbName)
        {
            try
            {
                var result = GetByTagName(db, dbName);
                if (result == null) throw new KeyNotFoundException("Tag name is not found exception");
                db.Columns.Remove(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Xóa gói dữ liệu.
        /// </summary>
        /// <param name="db">Thiết bị</param>
        /// <param name="tg">gói dữ liệu</param>
        public static void Delete(Table db, Column tg)
        {
            try
            {
                if (tg == null) throw new NullReferenceException("The Tag is null reference exception");
                foreach (var item in db.Columns)
                    if (item.ColumnId == tg.ColumnId)
                    {
                        db.Columns.Remove(item);
                        break;
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Phương thức kiểm tra gói dữ liệu đã tồn tại chưa?
        /// </summary>
        /// <param name="db">Thiết bị</param>
        /// <param name="tg">gói dữ liệu</param>
        /// <returns>gói dữ liệu</returns>
        public static Column IsExisted(Table db, Column tg)
        {
            Column result = null;
            try
            {
                foreach (var item in db.Columns)
                {
                    if (item.ColumnId != tg.ColumnId && item.TagName.Equals(tg.TagName))
                        throw new InvalidOperationException($"Tag name: '{tg.TagName}' is existed");
                    if (item.ColumnId != tg.ColumnId && item.ColumnName.Equals(tg.ColumnName))
                        throw new InvalidOperationException($"Tag address: '{tg.ColumnName}' is existed");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        ///     Tìm kiếm gói dữ liệu theo mã gói dữ liệu.
        /// </summary>
        /// <param name="db">Thiết bị</param>
        /// <param name="tgId">Mã gói dữ liệu</param>
        /// <returns>Gói dữ liệu</returns>
        public static Column GetByTagId(Table db, int tgId)
        {
            Column result = null;
            try
            {
                foreach (var item in db.Columns)
                    if (item.ColumnId == tgId)
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
        ///     Tìm kiếm gói dữ liệu theo tên gói dữ liệu.
        /// </summary>
        /// <param name="db">Thiết bị</param>
        /// <param name="tgName">Tên gói dữ liệu</param>
        /// <returns>Gói dữ liệu</returns>
        public static Column GetByTagName(Table db, string tgName)
        {
            Column result = null;
            try
            {
                foreach (var item in db.Columns)
                    if (item.TagName.Equals(tgName))
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
        ///     Tìm kiếm gói dữ liệu theo tên gói dữ liệu.
        /// </summary>
        /// <param name="db">Gói dữ liệu</param>
        /// <param name="tgAddress">địa chỉ tag</param>
        /// <returns>Gói dữ liệu</returns>
        public static Column GetByAddress(Table db, ushort tgAddress)
        {
            Column result = null;
            try
            {
                foreach (var item in db.Columns)
                    if (item.ColumnName.Equals(tgAddress))
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
        ///     Hàm đọc danh sách các gói dữ liệu.
        /// </summary>
        /// <param name="dbNote">XmlNode</param>
        /// <returns>Danh sách gói dữ liệu</returns>
        public static List<Column> GetTags(XmlNode dbNote)
        {
            var dbList = new List<Column>();
            try
            {
                foreach (XmlNode item in dbNote)
                {
                    var tg = new Column();
                    tg.ColumnId = int.Parse(item.Attributes[Column_ID].Value);
                    tg.TagName = item.Attributes[TAG_NAME].Value;
                    tg.ColumnName = item.Attributes[Column_NAME].Value;
                    tg.Channel = item.Attributes[Channel].Value;
                    tg.Device = item.Attributes[Device].Value;
                    tg.DataBlock = item.Attributes[DataBlock].Value;
                    tg.Mode = item.Attributes[Mode].Value;
                    tg.TriggerType = item.Attributes[TriggerType].Value;
                    tg.Description = item.Attributes[DESCRIPTION].Value;
                    dbList.Add(tg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dbList;
        }
    }
}