using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace AdvancedScada.Studio.DB
{
    public class UtilsTableSQLite
    {
        public static DataTable AddDatabases(string teServer)
        {
            DataTable dtable;
            dtable = new DataTable("DatabaseName");
            //set columns names
            dtable.Columns.Add("DBID", typeof(short));
            dtable.Columns.Add("DatabaseName", typeof(string));
            dtable.Columns.Add("State", typeof(string));


            //Add Rows
            var drow = dtable.NewRow();
            drow["DBID"] = 1;
            drow["DatabaseName"] = System.IO.Path.GetFileNameWithoutExtension(teServer);
            drow["State"] = "Open";
            dtable.Rows.Add(drow);


            return dtable;
        }
        public static DataTable AddTableListBox(string DBListLookUpEdit)
        {
           
            var adapter = new SQLiteDataAdapter();
            var ds = new DataTable();
          

 
            try
            {
                



                SQLiteConnection conn = new SQLiteConnection("data source=" + DBListLookUpEdit);

                // These is how you list the schema of an SQLite database
                SQLiteCommand comm = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' ORDER BY name", conn);
                conn.Open();
                adapter.SelectCommand = comm;
                adapter.Fill(ds);
                adapter.Dispose();
                comm.Dispose();
                conn.Close();
               



                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static List<string> GetListTables(string DBListLookUpEdit)
        {
            List<string> tables = new List<string>();
            using (SQLiteConnection con =  new SQLiteConnection("data source=" + DBListLookUpEdit))
            {
                con.Open();
                DataTable dt = con.GetSchema("Tables");
                foreach (DataRow row in dt.Rows)
                {
                    string tablename = (string)row[2];
                    tables.Add(tablename);
                }
                con.Close();
            }
            return tables;
        }
        
        /// <summary>
        /// Checks if the given table contains a column with the given name.
        /// </summary>
        /// <param name="tableName">The table in this database to check.</param>
        /// <param name="columnName">The column in the given table to look for.</param>
        /// <param name="connection">The SQLiteConnection for this database.</param>
        /// <returns>True if the given table contains a column with the given name.</returns>
        public static DataTable ColumnExists(string tableName, string columnName)
        {
            var ds = new DataTable();
            DataTable dtable;
            dtable = new DataTable("DatabaseName");
            //set columns names
            dtable.Columns.Add("ColumnName", typeof(string));
            dtable.Columns.Add("DataType", typeof(string));
            dtable.Columns.Add("MaxLength", typeof(string));
            dtable.Columns.Add("Precision", typeof(string));
            dtable.Columns.Add("Scale", typeof(string));
            dtable.Columns.Add("IsNullable", typeof(bool));
            dtable.Columns.Add("PrimaryKey", typeof(bool));


            using (SQLiteConnection connection = new SQLiteConnection("data source=" + columnName))
            {
                connection.Open();
                var cmd = new SQLiteCommand("PRAGMA table_info(" + tableName + ")", connection);
                var dr = cmd.ExecuteReader();


                
                for (var i = 0; i < dr.FieldCount; i++)
                {
                    Console.WriteLine(dr.GetName(i));
                }
                while (dr.Read())//loop through the various columns and their info
                {
                    var value = dr.GetValue(4);//column 1 from the result contains the column names
                    //Add Rows
                    var drow = dtable.NewRow();
                    drow["ColumnName"] = dr.GetValue(1).ToString();
                    drow["DataType"] = dr.GetValue(2).ToString();
                    drow["IsNullable"] =Convert.ToBoolean( dr.GetValue(3));
                    drow["PrimaryKey"] = Convert.ToBoolean(dr.GetValue(5));
                    dtable.Rows.Add(drow);
                  
                }

                dr.Close();
                connection.Close();
            }
            return dtable;
        }
        
    }
}
