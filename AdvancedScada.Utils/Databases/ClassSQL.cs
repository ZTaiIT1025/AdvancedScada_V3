using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.ServiceProcess;
using System.Windows.Forms;
using static AdvancedScada.IBaseService.Common.XCollection;
namespace AdvancedScada.Utils.Databases
{
    public class ClassSQL
    {
        // متغير التحكم بالخدمة
        private readonly ServiceController SqlServiceCon = new ServiceController("MSSQL$SQLEXPRESS");

        public void FillComboServers(ComboBox Combo)
        {
            var SqlEnumerator = SqlDataSourceEnumerator.Instance;
            var dTable = SqlEnumerator.GetDataSources();
            foreach (DataRow Dr in dTable.Rows) Combo.Items.Add(Dr[0]);
        }

        public List<string> GetSQLInstances()
        {
            var Instances = new List<string>();
            var s = SqlDataSourceEnumerator.Instance;
            var ta = s.GetDataSources();
            foreach (DataRow row in ta.Rows) Instances.Add(row[1].ToString());
            return Instances;
        }

        public static void CREATE_DATABASE(string connectionstring, string Databasename)
        {
            var strSQL = $"CREATE DATABASE {Databasename}";
            var stringconnectionstring =
                $"Server={connectionstring};DataBase=master;Integrated Security=SSPI";
            var northwindConnection = new SqlConnection(stringconnectionstring);

            // A SqlCommand object is used to execute the SQL commands. 
            var cmd = new SqlCommand(strSQL, northwindConnection);
            northwindConnection.Open();
            cmd.ExecuteNonQuery();
            northwindConnection.Close();
        }

        public static void CREATE_TABLE(string connectionstring, string Databasename, string strSQL)
        {
            var stringconnectionstring = $"Server={connectionstring};DataBase={Databasename};Integrated Security=SSPI";
            var northwindConnection = new SqlConnection(stringconnectionstring);
            // A SqlCommand object is used to execute the SQL commands. 
            var cmd = new SqlCommand(strSQL, northwindConnection);
            northwindConnection.Open();
            cmd.ExecuteNonQuery();
            northwindConnection.Close();
        }

        public void CREATE_PROCEDURE(string stringconnectionstring)
        {
            var northwindConnection = new SqlConnection(stringconnectionstring);
            northwindConnection.Open();
            var strSQL = string.Empty;
            var cmd = new SqlCommand(strSQL, northwindConnection);
            cmd.CommandText = "CREATE PROCEDURE AddSeafood AS" + Environment.NewLine +
                              "INSERT INTO NW_Seafood" + Environment.NewLine +
                              "(ProductID, ProductName, QuantityPerUnit, UnitPrice)" +
                              "SELECT ProductID, ProductName, QuantityPerUnit, UnitPrice " +
                              "FROM Northwind.dbo.Products " +
                              "WHERE CategoryID = 8";

            cmd.ExecuteNonQuery();
            northwindConnection.Close();
        }

        public static byte[] GetPhoto(string FilePath)
        {
            var Fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            var Br = new BinaryReader(Fs);
            var Photo = Br.ReadBytes((int)Fs.Length);
            Br.Close();
            Fs.Close();
            return Photo;
        }

        private void BackUp()
        {
            var bBackUpStatus = true;

            if (Directory.Exists(@"directory loction"))
            {
                if (File.Exists(@"filelocation"))
                {
                    if (MessageBox.Show(@"Do you want to replace it?", "Back", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        File.Delete(@"file loction");
                    else
                        bBackUpStatus = false;
                }
            }
            else
            {
                Directory.CreateDirectory(@"dirctorylocation");
            }

            if (bBackUpStatus)
            {
                //Connect to DB 
                SqlConnection connect;
                var con = "Connectionn String";
                connect = new SqlConnection(con);
                connect.Open();
                //---------------------------------------------------------------------------------------------------- 

                //Execute SQL--------------- 
                SqlCommand command;
                command = new SqlCommand(@"backup database databaseName to disk ='DatabaseLocation' with init,stats=10",
                    connect);
                command.ExecuteNonQuery();
                //------------------------------------------------------------------------------------------------------------------------------- 

                connect.Close();

                MessageBox.Show("The support of the database was successfully performed", "Back", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Restore()
        {
            try
            {
                if (File.Exists(@"FILE LOCAITON"))
                {
                    if (MessageBox.Show("Are you sure you restore?", "Back", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Connect SQL----------- 
                        SqlConnection connect;
                        var con = "CONNECTION STRING";
                        connect = new SqlConnection(con);
                        connect.Open();
                        //----------------------------------------------------------------------------------------- 

                        //Excute SQL---------------- 
                        SqlCommand command;
                        command = new SqlCommand("use master", connect);
                        command.ExecuteNonQuery();
                        command = new SqlCommand(@"restore database DatabaseName from disk = 'FILE LOCATION'", connect);
                        command.ExecuteNonQuery();
                        //-------------------------------------------------------------------------------------------------------- 
                        connect.Close();

                        MessageBox.Show("Has been restored database", "Restoration", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(@"Do not make any endorsement above (or is not in the correct path)", "Restoration",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }


        public void CreateDatabase(string connString, string dbName, bool dropExistent = true)
        {
            var cn = new SqlConnection(connString);
            try
            {
                // the command for creating the DB 
                var cmdCreate = new SqlCommand("CREATE DATABASE [" + dbName + "]", cn);

                cn.Open();
                if (dropExistent)
                {
                    // drop the existent DB with the same name 
                    var cmdDrop =
                        new SqlCommand(
                            "IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = @name ) DROP DATABASE [" +
                            dbName + "]", cn);
                    cmdDrop.Parameters.AddWithValue("@name", dbName);

                    cmdDrop.ExecuteNonQuery();
                }
                // create the DB;

                cmdCreate.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }
        }

        public void DropDataBase(string constring, string DbName, bool DropExistent = true)
        {
            var cn = new SqlConnection(constring);
            try
            {
                cn.Open();
                if (DropExistent)
                {
                    var cmd = new SqlCommand(
                        "IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = @name)  DROP DATABASE [" +
                        DbName + "]", cn);

                    cmd.Parameters.AddWithValue("@name", DbName);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                cn.Close();
            }
        }

        #region  SQl Express Service Functions 

        // إجراء بدء الخدمة
        private void StartSQLExpress()
        {
            try
            {
                SqlServiceCon.Refresh();
                if (SqlServiceCon.Status != ServiceControllerStatus.Running &&
                    SqlServiceCon.Status != ServiceControllerStatus.StartPending) SqlServiceCon.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(this.GetType().Name, ex.Message);
            }
        }

        // إجراء إنهاء الخدمة
        private void StopSQLExpress()
        {
            try
            {
                SqlServiceCon.Refresh();
                if (SqlServiceCon.CanStop) SqlServiceCon.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
    public class UtilsTable
    {

        public static List<string> List = new List<string>();
        public static List<DBTableNames> ListDBNames = new List<DBTableNames>();

        public DataTable spaceObjectsTable = null;

        #region void

        public static  string GetServerConnectionString(string teServer)
        {
            var connectionString = $"data source={teServer};integrated security=SSPI";
            //if (radioGroup1.SelectedIndex == 1)
            //    connectionString = String.Format("data source={0};user id={1};password={2}", Settings.Default.teServer, Settings.Default.teLogin, Settings.Default.tePassword);
            return connectionString;
        }



        public List<string> AddDatabaseNames(string teServer)
        {
            var cbDatabase = new List<string>();
            using (var connection = new SqlConnection(GetServerConnectionString(teServer)))
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    return null;
                }

                using (var command = new SqlCommand("select name from master..sysdatabases", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        cbDatabase.Clear();
                        while (reader.Read())
                        {
                            var name = reader.GetString(0);
                            if ("master;model;tempdb;msdb;pubs".IndexOf(name) < 0)
                                cbDatabase.Add(name);
                        }
                    }
                }

                connection.Close();
            }

            return cbDatabase;
        }

        public DataTable AddTable(string teServer, string Databasename)
        {
            DataTable dtable;
            dtable = new DataTable("TableName");
            //set columns names
            dtable.Columns.Add("TableNameID", typeof(short));
            dtable.Columns.Add("TableName", typeof(string));
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            var adapter = new SqlDataAdapter();
            var ds = new DataTable();
            string sql = null;
            var i = 0;
            connetionString = $"Data Source={teServer};Initial Catalog={Databasename};Integrated Security=True";
            sql = "Select DISTINCT(name) FROM sys.Tables";

            connection = new SqlConnection(connetionString);
            try
            {
                ds.Clear();
                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();


                for (i = 0; i <= ds.Rows.Count - 1; i++)
                {
                    //Add Rows
                    var drow = dtable.NewRow();
                    drow["TableNameID"] = i + 1;
                    drow["TableName"] = ds.Rows[i].ItemArray[0].ToString();
                    dtable.Rows.Add(drow);
                }

                return dtable;
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
            return dtable;
        }

        public DataTable AddColumnID(string TableLookUpEdit, string teServer,
            string Databasename)
        {
            string connetionString = null;
            SqlConnection sqlCnn;
            SqlCommand command;
            var adapter = new SqlDataAdapter();
            var ds = new DataTable();

            string sql = null;
            connetionString = $"Data Source={teServer};Initial Catalog={Databasename};Integrated Security=True";
            sql = $"Select BatchNo from {TableLookUpEdit}";

            sqlCnn = new SqlConnection(connetionString);
            try
            {
                sqlCnn.Open();
                command = new SqlCommand(sql, sqlCnn);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                sqlCnn.Close();
                return ds;
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
            return ds;
        }

        public DataTable AddColumn(string TableLookUpEdit, string teServer, string Databasename)

        {
            string connetionString = null;
            SqlConnection sqlCnn;
            SqlCommand sqlCmd;
            string sql = null;
            DataTable schemaTable=null;
            connetionString = $"Data Source={teServer};Initial Catalog={Databasename};Integrated Security=True";
            sql = $"Select * from {TableLookUpEdit}";

            sqlCnn = new SqlConnection(connetionString);
            try
            {
                sqlCnn.Open();
                sqlCmd = new SqlCommand(sql, sqlCnn);
                var sqlReader = sqlCmd.ExecuteReader();
                  schemaTable = sqlReader.GetSchemaTable();

                foreach (DataRow row in schemaTable.Rows)
                    foreach (DataColumn column in schemaTable.Columns)
                    {
                        var Columnstr = $"{column.ColumnName}  =   {row[column]}";
                        List.Add(Columnstr);
                    }



                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return schemaTable;
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }
            return schemaTable;
        }

        public static  DataTable AddDatabases(string teServer)
        {
            DataTable dtable = null;
            try
            {

                dtable = new DataTable("DatabaseName");
                //set columns names
                dtable.Columns.Add("DBID", typeof(short));
                dtable.Columns.Add("DatabaseName", typeof(string));
                dtable.Columns.Add("State", typeof(string));
                var connetionString = GetServerConnectionString(teServer);
                SqlConnection connection;
                SqlCommand command;
                var adapter = new SqlDataAdapter();
                var ds = new DataTable();
                string sql = null;
                var i = 0;
                // DBListLookUpEdit.Items.Clear();
                connection = new SqlConnection(connetionString);
                sql = "Select DISTINCT(name) FROM sys.databases";

                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();

                for (i = 0; i <= ds.Rows.Count - 1; i++)
                {
                    //Add Rows
                    var drow = dtable.NewRow();
                    drow["DBID"] = i + 1;
                    drow["DatabaseName"] = ds.Rows[i].ItemArray[0].ToString();
                    drow["State"] = "Open";
                    dtable.Rows.Add(drow);
                }


            }
            catch (Exception ex)
            {
               EventscadaException?.Invoke("SQL", ex.Message);

            }
            return dtable;
        }

        public static DataTable AddTableListBox(string DBListLookUpEdit, string teServer)
        {

            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            var adapter = new SqlDataAdapter();
            var ds = new DataTable();
            string sql = null;


            connetionString = $"Data Source={teServer};Initial Catalog={DBListLookUpEdit};Integrated Security=True";
            sql = "Select DISTINCT(name) FROM sys.Tables";

            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();


                return ds;
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke("SQL", ex.Message);
            }
            return ds;
        }

        public static DataTable AddColumnGrid(string DBListLookUpEdit, string TableNamesListBox, string teServer)
        {
            DataTable dtable;
            dtable = new DataTable("DatabaseName");
            //set columns names
            dtable.Columns.Add("ColumnName", typeof(string));
            dtable.Columns.Add("DataType", typeof(string));
            dtable.Columns.Add("MaxLength", typeof(string));
            dtable.Columns.Add("Precision", typeof(short));
            dtable.Columns.Add("Scale", typeof(string));
            dtable.Columns.Add("IsNullable", typeof(bool));
            dtable.Columns.Add("PrimaryKey", typeof(bool));


            string connetionString = null;
            SqlConnection sqlCnn;
            SqlCommand sqlCmd;
            string sql = null;
            var ds = new DataTable();
            connetionString = $"Data Source={teServer};Initial Catalog={DBListLookUpEdit};Integrated Security=True";
            sql = $"Select * from {TableNamesListBox}";

            sqlCnn = new SqlConnection(connetionString);
            try
            {
                sqlCnn.Open();
                sqlCmd = new SqlCommand(sql, sqlCnn);
                var sqlReader = sqlCmd.ExecuteReader();
                ds = sqlReader.GetSchemaTable();

                foreach (DataRow row in ds.Rows)
                {
                    //Add Rows
                    var drow = dtable.NewRow();
                    drow["ColumnName"] = row["ColumnName"].ToString();
                    drow["DataType"] = row["DataTypeName"].ToString();
                    drow["MaxLength"] = row["ColumnSize"].ToString();
                    drow["Precision"] = row["NumericPrecision"].ToString();
                    drow["Scale"] = row["NumericScale"].ToString();
                    drow["IsNullable"] = row["AllowDBNull"].ToString();
                    drow["PrimaryKey"] = row["IsKey"];
                    dtable.Rows.Add(drow);
                }


                sqlReader.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
                return dtable;
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }

    public class TableNames
    {
        public int TableNameID { get; set; }

        public string TableName { get; set; }
    }
    public class DBTableNames
    {
        public string DatabaseName { get; set; }
        public int DBID { get; set; }
        public string CreateDate { get; set; }
        public string State { get; set; }
    }
}
