using System;
using System.Collections.Generic;
using System.Xml;

namespace AdvancedScada.Management.SQLManager
{
    public class TableManager
    {
        public const string Tabled = "Tabled";
        public const string Table_ID = "TableId";
        public const string Table_NAME = "TableName";
        public const string Description = "Description";
        private static readonly object mutex = new object();
        private static TableManager _instance;

        public static TableManager GetTableManager()
        {
            lock (mutex)
            {
                if (_instance == null) _instance = new TableManager();
            }

            return _instance;
        }
        /// <summary>
        ///     Thêm mới gói dữ liệu.
        /// </summary>
        /// <param name="dv">gói dữ liệu</param>
        /// <param name="dv">gói dữ liệu</param>
        public static void Add(DataBase dv, Table db)
        {
            try
            {
                if (db == null) throw new NullReferenceException("The Table is null reference exception");
                var fDv = IsExisted(dv, db);
                if (fDv != null)
                    throw new Exception($"Table name: '{db.TableName}' is existed");
                dv.Tables.Add(db);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Cập nhật gói dữ liệu.
        /// </summary>
        /// <param name="dv">Thiết bị</param>
        /// <param name="db">gói dữ liệu</param>
        public static void Update(DataBase dv, Table db)
        {
            try
            {
                if (db == null) throw new NullReferenceException("The Table is null reference exception");
                var fCh = IsExisted(dv, db);
                if (fCh != null)
                    throw new Exception($"Table name: '{db.TableName}' is existed");
                foreach (var item in dv.Tables)
                    if (item.TableId == db.TableId)
                    {
                        item.TableId = db.TableId;
                        item.TableName = db.TableName;
                        item.Description = db.Description;

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
        /// <param name="dv">Thiết bị</param>
        /// <param name="dbId">Mã gói dữ liệu</param>
        public static void Delete(DataBase dv, int dbId)
        {
            try
            {
                var result = GetTablekId(dv, dbId);
                if (result == null) throw new KeyNotFoundException("Table Id is not found exception");
                dv.Tables.Remove(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Xóa gói dữ liệu.
        /// </summary>
        /// <param name="dv">Thiết bị</param>
        /// <param name="dbName">Tên gói dữ liệu</param>
        public static void Delete(DataBase dv, string dbName)
        {
            try
            {
                var result = GetByTableName(dv, dbName);
                if (result == null) throw new KeyNotFoundException("Table name is not found exception");
                dv.Tables.Remove(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Xóa gói dữ liệu.
        /// </summary>
        /// <param name="dv">Thiết bị</param>
        /// <param name="db">gói dữ liệu</param>
        public static void Delete(DataBase dv, Table db)
        {
            try
            {
                if (db == null) throw new NullReferenceException("The Table is null reference exception");
                foreach (var item in dv.Tables)
                    if (item.TableId == db.TableId)
                    {
                        dv.Tables.Remove(item);
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
        /// <param name="dv">Thiết bị</param>
        /// <param name="db">gói dữ liệu</param>
        /// <returns>gói dữ liệu</returns>
        public static Table IsExisted(DataBase dv, Table db)
        {
            Table result = null;
            try
            {
                foreach (var item in dv.Tables)
                    if (item.TableId != db.TableId && item.TableName.Equals(db.TableName))
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
        ///     Tìm kiếm gói dữ liệu theo mã gói dữ liệu.
        /// </summary>
        /// <param name="ch">Thiết bị</param>
        /// <param name="chId">Mã gói dữ liệu</param>
        /// <returns>Gói dữ liệu</returns>
        public static Table GetTablekId(DataBase ch, int chId)
        {
            Table result = null;
            try
            {
                foreach (var item in ch.Tables)
                    if (item.TableId == chId)
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
        /// <param name="ch">Thiết bị</param>
        /// <param name="chName">Tên gói dữ liệu</param>
        /// <returns>Gói dữ liệu</returns>
        public static Table GetByTableName(DataBase ch, string chName)
        {
            Table result = null;
            try
            {
                foreach (var item in ch.Tables)
                    if (item.TableName.Equals(chName))
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
        /// <param name="dvNode">XmlNode</param>
        /// <returns>Danh sách gói dữ liệu</returns>
        public static List<Table> GetTables(XmlNode dvNode)
        {
            var dbList = new List<Table>();
            try
            {
                foreach (XmlNode dbNote in dvNode)
                {
                    var db = new Table();
                    db.TableId = int.Parse(dbNote.Attributes[Table_ID].Value);
                    db.TableName = dbNote.Attributes[Table_NAME].Value;
                    db.Description = dbNote.Attributes[Description].Value;
                    db.Columns = ColumnManager.GetTags(dbNote);
                    dbList.Add(db);
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