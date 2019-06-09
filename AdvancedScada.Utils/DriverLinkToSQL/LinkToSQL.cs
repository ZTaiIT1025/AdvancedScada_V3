using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static AdvancedScada.IBaseService.Common.XCollection;
namespace AdvancedScada.Utils.DriverLinkToSQL
{
    public class LinkToSQL
    {
        public static List<string> List = new List<string>();
        public static string GetServerConnectionString(string teServer)
        {
            string connectionString = $"data source={teServer};integrated security=SSPI";
            //if (radioGroup1.SelectedIndex == 1)
            //    connectionString = String.Format("data source={0};user id={1};password={2}", Settings.Default.teServer, Settings.Default.teLogin, Settings.Default.tePassword);
            return connectionString;
        }
        public static List<string> AddDatabaseNames(string teServer)
        {
            List<string> cbDatabase = new List<string>();
            using (SqlConnection connection = new SqlConnection(GetServerConnectionString(teServer)))
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    return null;
                }
                using (SqlCommand command = new SqlCommand("select name from master..sysdatabases", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        cbDatabase.Clear();
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            if ("master;model;tempdb;msdb;pubs".IndexOf(name) < 0)
                                cbDatabase.Add(name);
                        }
                    }
                }
                connection.Close();
            }
            return cbDatabase;
        }
        public List<string> AddTable(string teServer, string Databasename)
        {
            List<string> cbTable = new List<string>();
            try
            {
                string connetionString =
                    $"Data Source={teServer};Initial Catalog={Databasename};Integrated Security=True";


                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch
                    {
                        return null;
                    }
                    using (SqlCommand command = new SqlCommand("Select DISTINCT(name) FROM sys.Tables", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            cbTable.Clear();
                            while (reader.Read())
                            {
                                string name = reader.GetString(0);
                                if ("master;model;tempdb;msdb;pubs".IndexOf(name) < 0)
                                    cbTable.Add(name);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

               EventscadaException?.Invoke(this.GetType().Name, ex.Message);
            }


            return cbTable;
        }
        public DataTable AddColumn(string Table, string teServer, string Databasename)
        {
            string connetionString = null;
            SqlConnection sqlCnn;
            SqlCommand sqlCmd;
            string sql = null;
            DataTable schemaTable = null;
            try
            {
                connetionString = $"Data Source={teServer};Initial Catalog={Databasename};Integrated Security=True";
                sql = $"Select * from {Table}";

                sqlCnn = new SqlConnection(connetionString);
                try
                {
                    sqlCnn.Open();
                    sqlCmd = new SqlCommand(sql, sqlCnn);
                    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                    schemaTable = sqlReader.GetSchemaTable();

                    sqlReader.Close();
                    sqlCmd.Dispose();
                    sqlCnn.Close();
                }
                catch (Exception ex)
                {
                   EventscadaException?.Invoke(this.GetType().Name, ex.Message);

                }
            }
            catch (Exception)
            {

                throw;
            }

            return schemaTable;
        }

    }
}
