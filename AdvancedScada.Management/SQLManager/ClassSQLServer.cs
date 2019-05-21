using System.Collections.Generic;

namespace AdvancedScada.Management.SQLManager
{
    public class Server
    {
        public Server()
        {
            DataBase = new List<DataBase>();
        }
        public Server(int ServerId, string ServerName, string desp = null)
            : this()
        {
            this.ServerId = ServerId;
            this.ServerName = ServerName;
            Description = desp;
        }

        public int ServerId { get; set; }
        public string UserName { get; set; }
        public string ServerName { get; set; }
        public int Passwerd { get; set; }
        public string Description { get; set; }
        public List<DataBase> DataBase { get; set; }

        public DataBase this[string DataBaseName]
        {
            get
            {
                foreach (var item in DataBase)
                    if (DataBaseName.Equals(item.DataBaseName))
                        return item;
                return null;
            }
        }
    }
    public class DataBase
    {

        public DataBase()
        {
            Tables = new List<Table>();
        }
        public int DataBaseId { get; set; }
        public string DataBaseName { get; set; }
        public string Description { get; set; }
        public List<Table> Tables { get; set; }
    }
    public class Table
    {

        public Table()
        {
            Columns = new List<Column>();
        }
        public int TableId { get; set; }
        public string TableName { get; set; }
        public string Description { get; set; }

        public List<Column> Columns { get; set; }
    }
    public class Column
    {
        public int ColumnId { get; set; }
        public string ColumnName { get; set; }
        public string TagName { get; set; }
        public string DataBlock { get; set; }
        public string Device { get; set; }
        public string Channel { get; set; }
        public string Mode { get; set; }
        public string TriggerType { get; set; }
        public string Description { get; set; }
    }
}