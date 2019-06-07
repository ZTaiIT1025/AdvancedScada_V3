using AdvancedScada.DriverBase.Devices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace AdvancedScada.Dao.TagManagers
{
    public class ChannelDA : LocalBaseDAO
	{
		public const string TableName = "[Channel]";

		public const string ChannelId = "ChannelId";

		public const string ChannelName = "ChannelName";

		public const string Description = "Description";

		public int Insert(Channel param)
		{
			 
			try
			{
				string[] columnNames = new string[3]
				{
					"ChannelId",
					"ChannelName",
					"Description"
				};
				object[] values = new object[3]
				{
					param.ChannelId,
					param.ChannelName,
					param.Description
				};
				return LocalBaseDAO.InsertTable("[Channel]", columnNames, values);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(Channel param)
		{
			
			try
			{
				string[] columnNames = new string[3]
				{
					"ChannelId",
					"ChannelName",
					"Description"
				};
				object[] values = new object[3]
				{
					param.ChannelId,
					param.ChannelName,
					param.Description
				};
				string[] keyColumns = new string[1]
				{
					"ChannelId"
				};
				object[] keyValues = new object[1]
				{
					param.ChannelId
				};
				return LocalBaseDAO.UpdateTable("[Channel]", columnNames, values, keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(object idOld, Channel param)
		{
			
			try
			{
				string[] columnNames = new string[3]
				{
					"ChannelId",
					"ChannelName",
					"Description"
				};
				object[] values = new object[3]
				{
					param.ChannelId,
					param.ChannelName,
					param.Description
				};
				string[] keyColumns = new string[1]
				{
					"ChannelId"
				};
				object[] keyValues = new object[1]
				{
					idOld
				};
				return LocalBaseDAO.UpdateTable("[Channel]", columnNames, values, keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(object param)
		{
			
			try
			{
				string[] keyColumns = new string[1]
				{
					"ChannelId"
				};
				object[] keyValues = new object[1]
				{
					param
				};
				return LocalBaseDAO.DeleteTable("[Channel]", keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(Channel param)
		{
			try
			{
				string[] keyColumns = new string[1]
				{
					"ChannelId"
				};
				object[] keyValues = new object[1]
				{
					param.ChannelId
				};
				return LocalBaseDAO.DeleteTable("[Channel]", keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Channel> Select()
		{
			 
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0}", "[Channel]");
				string[] collectionNames = new string[3]
				{
					"ChannelId",
					"ChannelName",
					"Description"
				};
				string[] columnNames = new string[3]
				{
					"ChannelId",
					"ChannelName",
					"Description"
				};
				return LocalBaseDAO.SelectCollection<Channel>(collectionNames, columnNames, sqlCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Channel> GetById(int id)
		{
			List<Channel> list = new List<Channel>();
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2}", "[Channel]", "ChannelId", "ChannelId");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = id;
				string[] array = new string[3]
				{
					"ChannelId",
					"ChannelName",
					"Description"
				};
				return LocalBaseDAO.SelectCollection<Channel>(array, array, sqlCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Channel> GetByName(string channelName)
		{
			List<Channel> list = new List<Channel>();
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2}", "[Channel]", "ChannelName", "ChannelName");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelName"), DbType.String).Value = channelName;
				string[] array = new string[3]
				{
					"ChannelId",
					"ChannelName",
					"Description"
				};
				return LocalBaseDAO.SelectCollection<Channel>(array, array, sqlCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public short GetNewId()
		{
			
			try
			{
				return LocalBaseDAO.GetNewId("[Channel]", "ChannelId");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	 
	}
}
