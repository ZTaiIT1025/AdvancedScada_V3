using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;

namespace AdvancedScada.Dao
{
	public class LocalBaseDAO
	{
 
		private static string _ConnectionString;

		public static string ConnectionString
		{
			get
			{
				return _ConnectionString;
			}
			set
			{
				_ConnectionString = value;
			}
		}
        public void CreatFile(string pathXml)
        {
            try
            {
                if (File.Exists(pathXml)) File.Delete(pathXml);

                // To create a new SQLite data base using existing.sql file (DDL script):-

                string strConnection = string.Format("Data Source={0}", pathXml);
                _ConnectionString = strConnection;
                string strCommand = Properties.Resources.TagCollection; // .sql file path

                using (SQLiteConnection objConnection = new SQLiteConnection(strConnection))
                {
                    using (SQLiteCommand objCommand = objConnection.CreateCommand())
                    {
                        objConnection.Open();
                        objCommand.CommandText = strCommand;
                        objCommand.ExecuteNonQuery();
                        objConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //EventscadaException?.Invoke(this.GetType().Name, ex.Message);
                throw ex;
            }
        }
        protected static int InsertTableWithReturnID(string tableName, string[] columnNames, object[] values, out int autoID)
		{
            int GetInt = 0;
            autoID = 0;
			try
			{
				using (SQLiteConnection sqlConnection = new SQLiteConnection(ConnectionString))
				{
                    SQLiteCommand sqlCommand = new SQLiteCommand();
					sqlCommand.Connection = sqlConnection;
					sqlCommand.CommandType = CommandType.Text;
					string text = "Insert into " + tableName + "(";
					string text2 = " Values(";
					for (int i = 0; i < columnNames.Length; i++)
					{
						if (values[i] != null)
						{
							text = text + columnNames[i] + ",";
							text2 = text2 + "@" + columnNames[i] + ",";
						}
					}
					text = text.Remove(text.Length - 1);
					text2 = text2.Remove(text2.Length - 1);
					text = text + ")" + text2 + ")";
					string text4 = sqlCommand.CommandText = text + "; SET @AutoID = SCOPE_IDENTITY()";
					text = text4;
					for (int j = 0; j < columnNames.Length; j++)
					{
						if (values[j] != null)
						{
							sqlCommand.Parameters.AddWithValue(columnNames[j], values[j]);
						}
					}
                    SQLiteParameter sqlParameter = new SQLiteParameter("@AutoID", DbType.Int32);
					sqlParameter.Direction = ParameterDirection.Output;
					sqlCommand.Parameters.Add(sqlParameter);
					sqlConnection.Open();
                    GetInt = sqlCommand.ExecuteNonQuery();
					try
					{
						if (sqlParameter.Value == null)
						{
							return GetInt;
						}
						autoID = (int)sqlParameter.Value;
						return GetInt;
					}
					catch (Exception)
					{
						return GetInt;
					}
				}
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
		}

		protected static int InsertTable(string tableName, string[] columnNames, object[] values)
		{
			 
			try
			{
				using (SQLiteConnection sqlConnection = new SQLiteConnection(ConnectionString))
				{
                    SQLiteCommand sqlCommand = new SQLiteCommand();
					sqlCommand.Connection = sqlConnection;
					sqlCommand.CommandType = CommandType.Text;
					string text = "Insert into " + tableName + "(";
					string text2 = " Values(";
					for (int i = 0; i < columnNames.Length; i++)
					{
						if (values[i] != null)
						{
							text = text + columnNames[i] + ",";
							text2 = text2 + "@" + columnNames[i] + ",";
						}
					}
					text = text.Remove(text.Length - 1);
					text2 = text2.Remove(text2.Length - 1);
					string text4 = sqlCommand.CommandText = text + ")" + text2 + ")";
					text = text4;
					for (int j = 0; j < columnNames.Length; j++)
					{
						if (values[j] != null)
						{
							sqlCommand.Parameters.AddWithValue(columnNames[j], values[j]);
						}
					}
					sqlConnection.Open();
					return sqlCommand.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		protected static int UpdateTable(string tableName, string[] columnNames, object[] values, string[] keyColumns, object[] keyValues)
		{
			 
			try
			{
				using (SQLiteConnection sqlConnection = new SQLiteConnection(ConnectionString))
				{
                    SQLiteCommand sqlCommand = new SQLiteCommand();
					sqlCommand.Connection = sqlConnection;
					sqlCommand.CommandType = CommandType.Text;
					string text = "Update " + tableName + " set ";
					for (int i = 0; i < columnNames.Length; i++)
					{
						text = text + columnNames[i] + "=@" + columnNames[i] + ",";
					}
					text = text.Remove(text.Length - 1);
					string text2 = " Where ";
					for (int j = 0; j < keyColumns.Length; j++)
					{
						text2 = text2 + keyColumns[j] + "=@Original_" + keyColumns[j] + " AND ";
					}
					text2 = text2.Remove(text2.Length - 4);
					sqlCommand.CommandText = text + text2;
					for (int k = 0; k < columnNames.Length; k++)
					{
						if (values[k] != null)
						{
							sqlCommand.Parameters.AddWithValue(columnNames[k], values[k]);
						}
						else
						{
							sqlCommand.Parameters.AddWithValue(columnNames[k], DBNull.Value);
						}
					}
					for (int l = 0; l < keyColumns.Length; l++)
					{
						sqlCommand.Parameters.AddWithValue("@Original_" + keyColumns[l], keyValues[l]);
					}
					sqlConnection.Open();
					return sqlCommand.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		protected static int DeleteTable(string tableName, string[] keyColumns, object[] keyValues)
		{
			 
			try
			{
				using (SQLiteConnection sqlConnection = new SQLiteConnection(ConnectionString))
				{
                    SQLiteCommand sqlCommand = new SQLiteCommand();
					sqlCommand.Connection = sqlConnection;
					sqlCommand.CommandType = CommandType.Text;
					string str = "Delete " + tableName;
					string text = " Where ";
					for (int i = 0; i < keyColumns.Length; i++)
					{
						text = text + keyColumns[i] + "=@" + keyColumns[i] + " AND ";
					}
					text = text.Remove(text.Length - 4);
					sqlCommand.CommandText = str + text;
					for (int j = 0; j < keyColumns.Length; j++)
					{
						sqlCommand.Parameters.AddWithValue(keyColumns[j], keyValues[j]);
					}
					sqlConnection.Open();
					return sqlCommand.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		protected static int RecordExisted(string tableName, string primaryColumnName, object value)
		{
			try
			{
				int result = 0;
				try
				{
					using (SQLiteConnection sqlConnection = new SQLiteConnection(ConnectionString))
					{
						if (value.GetType().ToString().Equals("System.String"))
						{
							value = "'" + value + "'";
						}
                        SQLiteCommand sqlCommand = new SQLiteCommand
                        {
							Connection = sqlConnection,
							CommandType = CommandType.Text,
							CommandText = $"Select count(*) from {tableName} where {primaryColumnName}={value}"
						};
						sqlConnection.Open();
						result = (int)sqlCommand.ExecuteScalar();
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				return result;
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
		}

		protected static short GetNewId(string tableName, string columnName)
        {
            short GetInt = 0;
            try
			{
				
				try
				{
					using (SQLiteConnection sqlConnection = new SQLiteConnection(ConnectionString))
					{
                        SQLiteCommand sqlCommand = new SQLiteCommand
                        {
							Connection = sqlConnection,
							CommandType = CommandType.Text,
							CommandText = $"SELECT MAX({columnName}) FROM {tableName}"
						};
						sqlConnection.Open();
                        SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
						while (sqlDataReader.Read())
						{
							try
							{
								GetInt = sqlDataReader.GetInt16(0);
							}
							catch (Exception)
							{
                                GetInt = 0;
							}
						}
                        GetInt = (short)(GetInt + 1);
					}
				}
				catch (Exception ex2)
				{
					throw ex2;
				}
				return GetInt;
			}
			catch (Exception ex3)
			{
				throw ex3;
			}
		}

		protected static short GetIdByParentId(string tableName, string colId, string parentId, int value)
		{
            short GetInt = 0;
            try
			{
				
				try
				{
					using (SQLiteConnection sqlConnection = new SQLiteConnection(ConnectionString))
					{
                        SQLiteCommand sqlCommand = new SQLiteCommand();
						sqlCommand.Connection = sqlConnection;
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandText = $"SELECT MAX({colId}) FROM {tableName} WHERE {parentId} = {value}";
						sqlConnection.Open();
                        SQLiteDataReader sqlDataReader = sqlCommand.ExecuteReader();
						while (sqlDataReader.Read())
						{
							try
							{
                                GetInt = sqlDataReader.GetInt16(0);
							}
							catch (Exception)
							{
                                GetInt = 0;
							}
						}
                        GetInt = (short)(GetInt + 1);
					}
				}
				catch (Exception ex2)
				{
					throw ex2;
				}
				return GetInt;
			}
			catch (Exception ex3)
			{
				throw ex3;
			}
		}

		protected static List<T> SelectCollection<T>(string[] collectionNames, string[] columnNames, SQLiteCommand cmd) where T : new()
		{
			List<T> list = new List<T>();
           
            try
			{
				using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
				{
					cmd.Connection = connection;
					DataTable dataTable = new DataTable();
					new SQLiteDataAdapter(cmd).Fill(dataTable);
					foreach (DataRow row in dataTable.Rows)
					{
						T val = new T();
						Type type = val.GetType();
						for (int i = 0; i < columnNames.Length; i++)
						{
							if (row[columnNames[i]] != DBNull.Value)
							{
								 
								type.GetProperty(columnNames[i]).SetValue(val, row[columnNames[i]], null);
							}
						}
						list.Add(val);
					}
					return list;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		protected static DataTable SelectCollection(string tableName, SQLiteCommand cmd)
		{
			try
			{
				DataTable dataTable = new DataTable(tableName);
				using (SQLiteConnection sqlConnection = new SQLiteConnection(ConnectionString))
				{
					cmd.Connection = sqlConnection;
					sqlConnection.Open();
					new SQLiteDataAdapter(cmd).Fill(dataTable);
				}
				return dataTable;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
