using AdvancedScada.DriverBase.Devices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;

namespace AdvancedScada.Dao.TagManagers
{
    public class DataBlockDA : LocalBaseDAO
	{
		public const string TableName = "[DataBlock]";

		public const string DataBlockId = "DataBlockId";

		public const string DeviceId = "DeviceId";

		public const string ChannelId = "ChannelId";

		public const string DataBlockName = "DataBlockName";

		public const string MemoryType = "MemoryType";

		public const string DBNumber = "DBNumber";

		public const string Description = "Description";

		public int Insert(DataBlock param)
		{
			
			try
			{
				string[] columnNames = new string[7]
				{
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"DataBlockName",
					"MemoryType",
					"DBNumber",
					"Description"
				};
				object[] values = new object[7]
				{
					param.DataBlockId,
					param.DeviceId,
					param.ChannelId,
					param.DataBlockName,
					param.MemoryType,
					param.StartAddress,
					param.Description
				};
				return LocalBaseDAO.InsertTable("[DataBlock]", columnNames, values);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(DataBlock param)
		{
			
			try
			{
				string[] columnNames = new string[4]
				{
					"DataBlockName",
					"MemoryType",
					"DBNumber",
					"Description"
				};
				object[] values = new object[4]
				{
					param.DataBlockName,
					param.MemoryType,
					param.StartAddress,
					param.Description
				};
				string[] keyColumns = new string[3]
				{
					"DataBlockId",
					"DeviceId",
					"ChannelId"
				};
				object[] keyValues = new object[3]
				{
					param.DataBlockId,
					param.DeviceId,
					param.ChannelId
				};
				return LocalBaseDAO.UpdateTable("[DataBlock]", columnNames, values, keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(object idOld, DataBlock param)
		{
			
			try
			{
				string[] columnNames = new string[7]
				{
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"DataBlockName",
					"MemoryType",
					"DBNumber",
					"Description"
				};
				object[] values = new object[7]
				{
					param.DataBlockId,
					param.DeviceId,
					param.ChannelId,
					param.DataBlockName,
					param.MemoryType,
					param.StartAddress,
					param.Description
				};
				string[] keyColumns = new string[1]
				{
					"DataBlockId"
				};
				object[] keyValues = new object[1]
				{
					idOld
				};
				return LocalBaseDAO.UpdateTable("[DataBlock]", columnNames, values, keyColumns, keyValues);
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
					"DataBlockId"
				};
				object[] keyValues = new object[1]
				{
					param
				};
				return LocalBaseDAO.DeleteTable("[DataBlock]", keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(DataBlock param)
		{
			
			try
			{
				string[] keyColumns = new string[3]
				{
					"DataBlockId",
					"DeviceId",
					"ChannelId"
				};
				object[] keyValues = new object[3]
				{
					param.DataBlockId,
					param.DeviceId,
					param.ChannelId
				};
				return LocalBaseDAO.DeleteTable("[DataBlock]", keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<DataBlock> Select()
		{
			 
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0}", "[DataBlock]");
				string[] collectionNames = new string[7]
				{
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"DataBlockName",
					"MemoryType",
					"DBNumber",
					"Description"
				};
				string[] columnNames = new string[7]
				{
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"DataBlockName",
					"MemoryType",
					"DBNumber",
					"Description"
				};
				return LocalBaseDAO.SelectCollection<DataBlock>(collectionNames, columnNames, sqlCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<DataBlock> GetByDevice(Device dv)
		{
		 
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4}", "[DataBlock]", "ChannelId", "ChannelId", "DeviceId", "DeviceId");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = dv.ChannelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = dv.DeviceId;
				string[] array = new string[7]
				{
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"DataBlockName",
					"MemoryType",
					"DBNumber",
					"Description"
				};
				return LocalBaseDAO.SelectCollection<DataBlock>(array, array, sqlCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<DataBlock> GetByDevice(short channelId, short deviceId)
		{
			 
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4}", "[DataBlock]", "ChannelId", "ChannelId", "DeviceId", "DeviceId");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = channelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = deviceId;
				string[] array = new string[7]
				{
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"DataBlockName",
					"MemoryType",
					"DBNumber",
					"Description"
				};
				return LocalBaseDAO.SelectCollection<DataBlock>(array, array, sqlCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public DataBlock GetById(DataBlock db)
		{
			DataBlock result = null;
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4} AND {5} = @{6}", "[DataBlock]", "ChannelId", "ChannelId", "DeviceId", "DeviceId", "DataBlockId", "DataBlockId");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = db.ChannelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = db.DeviceId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DataBlockId"), DbType.Int32).Value = db.DataBlockId;
				string[] array = new string[7]
				{
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"DataBlockName",
					"MemoryType",
					"DBNumber",
					"Description"
				};
				List<DataBlock> list = LocalBaseDAO.SelectCollection<DataBlock>(array, array, sqlCommand);
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

		public DataBlock GetByIds(short channelId, short deviceId, short dataBlockId)
		{
			DataBlock result = null;
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4} AND {5} = @{6}", "[DataBlock]", "ChannelId", "ChannelId", "DeviceId", "DeviceId", "DataBlockId", "DataBlockId");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = channelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = deviceId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DataBlockId"), DbType.Int32).Value = dataBlockId;
				string[] array = new string[7]
				{
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"DataBlockName",
					"MemoryType",
					"DBNumber",
					"Description"
				};
				List<DataBlock> list = LocalBaseDAO.SelectCollection<DataBlock>(array, array, sqlCommand);
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

		public DataBlock GetByName(DataBlock db)
		{
			DataBlock result = null;
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4} AND {5} = @{6}", "[DataBlock]", "ChannelId", "ChannelId", "DeviceId", "DeviceId", "DataBlockName", "DataBlockName");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = db.ChannelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = db.DeviceId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DataBlockName"), DbType.String).Value = db.DataBlockName;
				string[] array = new string[7]
				{
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"DataBlockName",
					"MemoryType",
					"DBNumber",
					"Description"
				};
				List<DataBlock> list = LocalBaseDAO.SelectCollection<DataBlock>(array, array, sqlCommand);
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

		public List<DataBlock> GetByDBNumberInDevice(DataBlock db)
		{
		 
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4} AND {5} = @{6} AND {7} = @{8}", "[DataBlock]", "ChannelId", "ChannelId", "DeviceId", "DeviceId", "MemoryType", "MemoryType", "DBNumber", "DBNumber");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = db.ChannelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = db.DeviceId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "MemoryType"), DbType.Int32).Value = db.MemoryType;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DBNumber"), DbType.Int32).Value = db.StartAddress;
				string[] array = new string[7]
				{
					"DataBlockId",
					"DeviceId",
					"ChannelId",
					"DataBlockName",
					"MemoryType",
					"DBNumber",
					"Description"
				};
				return LocalBaseDAO.SelectCollection<DataBlock>(array, array, sqlCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public short GetIdNew(Device dv)
		{
            short GetInt = 0;
            try
			{
				List<DataBlock> byDevice = GetByDevice(dv);
                GetInt = (short)((byDevice != null) ? ((byDevice.Count != 0) ? byDevice.Max((DataBlock db) => db.DataBlockId) : 0) : 0);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return (short)(GetInt + 1);
		}

		public short GetIdNew(short channelId, short deviceId)
		{
            short GetInt = 0;
            try
			{
				List<DataBlock> byDevice = GetByDevice(channelId, deviceId);
                GetInt = (short)((byDevice != null) ? ((byDevice.Count != 0) ? byDevice.Max((DataBlock db) => db.DataBlockId) : 0) : 0);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return (short)(GetInt + 1);
		}
	}
}
