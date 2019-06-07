using AdvancedScada.DriverBase.Devices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace AdvancedScada.Dao.TagManagers
{
    public class TagDA : LocalBaseDAO
	{
		public const string TableName = "[Tag]";

		public const string TagId = "TagId";

		public const string DataBlockId = "DataBlockId";

		public const string DeviceId = "DeviceId";

		public const string ChannelId = "ChannelId";

		public const string TagName = "TagName";

		public const string TagPrefix = "TagPrefix";

		public const string Address = "Address";

		public const string DataType = "DataType";

		public const string Size = "Size";

		public const string Description = "Description";

		public int Insert(Tag objTag)
		{
			 
			try
			{
				string[] columnNames = new string[10]
				{
					"TagId",
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"TagName",
					"TagPrefix",
					"Address",
					"DataType",
					"Size",
					"Description"
				};
				object[] values = new object[10]
				{
					objTag.TagId,
					objTag.DataBlockId,
					objTag.DeviceId,
					objTag.ChannelId,
					objTag.TagName,
					objTag.TagPrefix,
					objTag.Address,
					objTag.DataType,
					objTag.Size,
					objTag.Description
				};
				return LocalBaseDAO.InsertTable("[Tag]", columnNames, values);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(Tag objTag)
		{
			 
			try
			{
				string[] columnNames = new string[6]
				{
					"TagName",
					"TagPrefix",
					"Address",
					"DataType",
					"Size",
					"Description"
				};
				object[] values = new object[6]
				{
					objTag.TagName,
					objTag.TagPrefix,
					objTag.Address,
					objTag.DataType,
					objTag.Size,
					objTag.Description
				};
				string[] keyColumns = new string[4]
				{
					"TagId",
					"DataBlockId",
					"DeviceId",
					"ChannelId"
				};
				object[] keyValues = new object[4]
				{
					objTag.TagId,
					objTag.DataBlockId,
					objTag.DeviceId,
					objTag.ChannelId
				};
				return LocalBaseDAO.UpdateTable("[Tag]", columnNames, values, keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(object idOld, Tag objTag)
		{
			 
			try
			{
				string[] columnNames = new string[7]
				{
					"TagId",
					"TagName",
					"TagPrefix",
					"Address",
					"DataType",
					"Size",
					"Description"
				};
				object[] values = new object[7]
				{
					objTag.TagId,
					objTag.TagName,
					objTag.TagPrefix,
					objTag.Address,
					objTag.DataType,
					objTag.Size,
					objTag.Description
				};
				string[] keyColumns = new string[4]
				{
					"TagId",
					"DataBlockId",
					"DeviceId",
					"ChannelId"
				};
				object[] keyValues = new object[4]
				{
					idOld,
					objTag.DataBlockId,
					objTag.DeviceId,
					objTag.ChannelId
				};
				return LocalBaseDAO.UpdateTable("[Tag]", columnNames, values, keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int DeleteByDataBlock(DataBlock db)
		{
			
			try
			{
				string[] keyColumns = new string[3]
				{
					"ChannelId",
					"DeviceId",
					"DataBlockId"
				};
				object[] keyValues = new object[3]
				{
					db.ChannelId,
					db.DeviceId,
					db.DataBlockId
				};
				return LocalBaseDAO.DeleteTable("[Tag]", keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(Tag objTag)
		{
			
			try
			{
				string[] keyColumns = new string[4]
				{
					"TagId",
					"DataBlockId",
					"DeviceId",
					"ChannelId"
				};
				object[] keyValues = new object[4]
				{
					objTag.TagId,
					objTag.DataBlockId,
					objTag.DeviceId,
					objTag.ChannelId
				};
				return LocalBaseDAO.DeleteTable("[Tag]", keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Tag> Select()
		{
			 
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0}", "[Tag]");
				string[] collectionNames = new string[10]
				{
					"TagId",
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"TagName",
					"TagPrefix",
					"Address",
					"DataType",
					"Size",
					"Description"
				};
				string[] columnNames = new string[10]
				{
					"TagId",
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"TagName",
					"TagPrefix",
					"Address",
					"DataType",
					"Size",
					"Description"
				};
				return LocalBaseDAO.SelectCollection<Tag>(collectionNames, columnNames, sqlCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public short GetIdNew(DataBlock db)
		{
            short GetInt = 0;

            try
			{
				using (SQLiteConnection sqlConnection = new SQLiteConnection(LocalBaseDAO.ConnectionString))
				{
                    SQLiteCommand sqlCommand = new SQLiteCommand();
					sqlCommand.Connection = sqlConnection;
					sqlCommand.CommandType = CommandType.Text;
					sqlCommand.CommandText = string.Format("SELECT MAX(TagId) FROM {0} WHERE {1} = {2} AND {3} = {4} AND {5} = {6}", "[Tag]", "ChannelId", db.ChannelId, "DeviceId", db.DeviceId, "DataBlockId", db.DataBlockId);
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
					return (short)(GetInt + 1);
				}
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
		}

		public List<Tag> GetByDataBlock(DataBlock db)
		{
		 
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4} AND {5} = @{6}", "[Tag]", "ChannelId", "ChannelId", "DeviceId", "DeviceId", "DataBlockId", "DataBlockId");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = db.ChannelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = db.DeviceId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DataBlockId"), DbType.Int32).Value = db.DataBlockId;
				string[] array = new string[10]
				{
					"TagId",
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"TagName",
					"TagPrefix",
					"Address",
					"DataType",
					"Size",
					"Description"
				};
				return LocalBaseDAO.SelectCollection<Tag>(array, array, sqlCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Tag GetByName(Tag objTag)
		{
			Tag result = null;
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4} AND {5} = @{6} AND {7} = @{8}", "[Tag]", "ChannelId", "ChannelId", "DeviceId", "DeviceId", "DataBlockId", "DataBlockId", "TagName", "TagName");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = objTag.ChannelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = objTag.DeviceId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DataBlockId"), DbType.Int32).Value = objTag.DataBlockId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "TagName"), DbType.String).Value = objTag.TagName;
				string[] array = new string[10]
				{
					"TagId",
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"TagName",
					"TagPrefix",
					"Address",
					"DataType",
					"Size",
					"Description"
				};
				List<Tag> list = LocalBaseDAO.SelectCollection<Tag>(array, array, sqlCommand);
				if (list.Count > 0)
				{
					return list[0];
				}
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Tag GetByAddress(Tag objTag)
		{
			Tag result = null;
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4} AND {5} = @{6} AND {7} = @{8} AND {9} = @{10}", "[Tag]", "ChannelId", "ChannelId", "DeviceId", "DeviceId", "DataBlockId", "DataBlockId", "Address", "Address", "DataType", "DataType");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = objTag.ChannelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = objTag.DeviceId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DataBlockId"), DbType.Int32).Value = objTag.DataBlockId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "Address"), DbType.String).Value = objTag.Address;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DataType"), DbType.Int32).Value = objTag.DataType;
				string[] array = new string[10]
				{
					"TagId",
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"TagName",
					"TagPrefix",
					"Address",
					"DataType",
					"Size",
					"Description"
				};
				List<Tag> list = LocalBaseDAO.SelectCollection<Tag>(array, array, sqlCommand);
				if (list.Count > 0)
				{
					return list[0];
				}
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool Existed(Tag objTag)
		{
			bool result = false;
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4} AND {5} = @{6} AND {7} = @{8} AND {9} = @{10}", "[Tag]", "ChannelId", "ChannelId", "DeviceId", "DeviceId", "DataBlockId", "DataBlockId", "TagId", "TagId", "DataType", "DataType");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = objTag.ChannelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = objTag.DeviceId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DataBlockId"), DbType.Int32).Value = objTag.DataBlockId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "TagId"), DbType.Int32).Value = objTag.TagId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DataType"), DbType.Int32).Value = objTag.DataType;
				string[] array = new string[10]
				{
					"TagId",
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"TagName",
					"TagPrefix",
					"Address",
					"DataType",
					"Size",
					"Description"
				};
				if (LocalBaseDAO.SelectCollection<Tag>(array, array, sqlCommand).Count > 0)
				{
					return true;
				}
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Tag GetByTag(Tag objTag)
		{
			Tag result = null;
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4} AND {5} = @{6} AND {7} = @{8}", "[Tag]", "ChannelId", "ChannelId", "DeviceId", "DeviceId", "DataBlockId", "DataBlockId", "TagId", "TagId");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = objTag.ChannelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = objTag.DeviceId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DataBlockId"), DbType.Int32).Value = objTag.DataBlockId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "TagId"), DbType.Int32).Value = objTag.TagId;
				string[] array = new string[10]
				{
					"TagId",
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"TagName",
					"TagPrefix",
					"Address",
					"DataType",
					"Size",
					"Description"
				};
				List<Tag> list = LocalBaseDAO.SelectCollection<Tag>(array, array, sqlCommand);
				if (list.Count > 0)
				{
					return list[0];
				}
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
