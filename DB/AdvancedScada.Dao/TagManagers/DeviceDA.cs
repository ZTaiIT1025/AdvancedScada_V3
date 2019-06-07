using AdvancedScada.DriverBase.Devices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace AdvancedScada.Dao.TagManagers
{
    public class DeviceDA : LocalBaseDAO
	{
		public const string TableName = "[Device]";

		public const string DeviceId = "DeviceId";

		public const string ChannelId = "ChannelId";

		public const string DeviceName = "DeviceName";

		public const string CPUType = "CPUType";

		public const string IPAddress = "IPAddress";

		public const string Rack = "Rack";

		public const string Slot = "Slot";

		public const string Description = "Description";

		public const string IsActived = "IsActived";

		public int Insert(Device objDevice)
		{
			
			try
			{
				string[] columnNames = new string[9]
				{
					"DeviceId",
					"ChannelId",
					"DeviceName",
					"CPUType",
					"IPAddress",
					"Rack",
					"Slot",
					"Description",
					"IsActived"
				};
				object[] values = new object[9]
				{
					objDevice.DeviceId,
					objDevice.ChannelId,
					objDevice.DeviceName,
					objDevice.CPUType,
					objDevice.IPAddress,
					objDevice.Rack,
					objDevice.Slot,
					objDevice.Description,
					objDevice.IsActived
				};
				return LocalBaseDAO.InsertTable("[Device]", columnNames, values);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(Device objDevice)
		{
			
			try
			{
				string[] columnNames = new string[7]
				{
					"DeviceName",
					"CPUType",
					"IPAddress",
					"Rack",
					"Slot",
					"Description",
					"IsActived"
				};
				object[] values = new object[7]
				{
					objDevice.DeviceName,
					objDevice.CPUType,
					objDevice.IPAddress,
					objDevice.Rack,
					objDevice.Slot,
					objDevice.Description,
					objDevice.IsActived
				};
				string[] keyColumns = new string[2]
				{
					"DeviceId",
					"ChannelId"
				};
				object[] keyValues = new object[2]
				{
					objDevice.DeviceId,
					objDevice.ChannelId
				};
				return LocalBaseDAO.UpdateTable("[Device]", columnNames, values, keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Update(object idOld, Device objDevice)
		{
			
			try
			{
				string[] columnNames = new string[9]
				{
					"DeviceId",
					"ChannelId",
					"DeviceName",
					"CPUType",
					"IPAddress",
					"Rack",
					"Slot",
					"Description",
					"IsActived"
				};
				object[] values = new object[9]
				{
					objDevice.DeviceId,
					objDevice.ChannelId,
					objDevice.DeviceName,
					objDevice.CPUType,
					objDevice.IPAddress,
					objDevice.Rack,
					objDevice.Slot,
					objDevice.Description,
					objDevice.IsActived
				};
				string[] keyColumns = new string[1]
				{
					"DeviceId"
				};
				object[] keyValues = new object[1]
				{
					idOld
				};
				return LocalBaseDAO.UpdateTable("[Device]", columnNames, values, keyColumns, keyValues);
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
					"DeviceId"
				};
				object[] keyValues = new object[1]
				{
					param
				};
				return LocalBaseDAO.DeleteTable("[Device]", keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int Delete(Device objDevice)
		{
			
			try
			{
				string[] keyColumns = new string[2]
				{
					"DeviceId",
					"ChannelId"
				};
				object[] keyValues = new object[2]
				{
					objDevice.DeviceId,
					objDevice.ChannelId
				};
				return LocalBaseDAO.DeleteTable("[Device]", keyColumns, keyValues);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Device> Select()
		{
			
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0}", "[Device]");
				string[] collectionNames = new string[9]
				{
					"DeviceId",
					"ChannelId",
					"DeviceName",
					"CPUType",
					"IPAddress",
					"Rack",
					"Slot",
					"Description",
					"IsActived"
				};
				string[] columnNames = new string[9]
				{
					"DeviceId",
					"ChannelId",
					"DeviceName",
					"CPUType",
					"IPAddress",
					"Rack",
					"Slot",
					"Description",
					"IsActived"
				};
				return LocalBaseDAO.SelectCollection<Device>(collectionNames, columnNames, sqlCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Device GetByIPAddress(string ipAddress = "127.0.0.1")
		{
			Device result = null;
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2}", "[Device]", "IPAddress", "IPAddress");
				sqlCommand.Parameters.Add(string.Format("@{0}", "IPAddress"), DbType.String).Value = ipAddress;
				string[] array = new string[9]
				{
					"DeviceId",
					"ChannelId",
					"DeviceName",
					"CPUType",
					"IPAddress",
					"Rack",
					"Slot",
					"Description",
					"IsActived"
				};
				List<Device> list = LocalBaseDAO.SelectCollection<Device>(array, array, sqlCommand);
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

		public bool Existed(Device objDevice)
		{
			bool result = false;
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4}", "[Device]", "ChannelId", "ChannelId", "DeviceId", "DeviceId");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = objDevice.ChannelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = objDevice.DeviceId;
				string[] array = new string[9]
				{
					"DeviceId",
					"ChannelId",
					"DeviceName",
					"CPUType",
					"IPAddress",
					"Rack",
					"Slot",
					"Description",
					"IsActived"
				};
				if (LocalBaseDAO.SelectCollection<Device>(array, array, sqlCommand).Count > 0)
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

		public Device GetById(Device objDevice)
		{
			Device result = null;
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4}", "[Device]", "ChannelId", "ChannelId", "DeviceId", "DeviceId");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = objDevice.ChannelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = objDevice.DeviceId;
				string[] array = new string[9]
				{
					"DeviceId",
					"ChannelId",
					"DeviceName",
					"CPUType",
					"IPAddress",
					"Rack",
					"Slot",
					"Description",
					"IsActived"
				};
				List<Device> list = LocalBaseDAO.SelectCollection<Device>(array, array, sqlCommand);
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

		public Device GetByIds(short channelId, short deviceId)
		{
			Device result = null;
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4}", "[Device]", "ChannelId", "ChannelId", "DeviceId", "DeviceId");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = channelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceId"), DbType.Int32).Value = deviceId;
				string[] array = new string[9]
				{
					"DeviceId",
					"ChannelId",
					"DeviceName",
					"CPUType",
					"IPAddress",
					"Rack",
					"Slot",
					"Description",
					"IsActived"
				};
				List<Device> list = LocalBaseDAO.SelectCollection<Device>(array, array, sqlCommand);
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

		public Device GetByName(Device objDevice)
		{
			Device result = null;
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2} AND {3} = @{4}", "[Device]", "ChannelId", "ChannelId", "DeviceName", "DeviceName");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = objDevice.ChannelId;
				sqlCommand.Parameters.Add(string.Format("@{0}", "DeviceName"), DbType.String).Value = objDevice.DeviceName;
				string[] array = new string[9]
				{
					"DeviceId",
					"ChannelId",
					"DeviceName",
					"CPUType",
					"IPAddress",
					"Rack",
					"Slot",
					"Description",
					"IsActived"
				};
				List<Device> list = LocalBaseDAO.SelectCollection<Device>(array, array, sqlCommand);
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

		public List<Device> GetByChannel(Channel ch)
		{
			
			try
			{
                SQLiteCommand sqlCommand = new SQLiteCommand();
				sqlCommand.CommandType = CommandType.Text;
				sqlCommand.CommandText = string.Format("SELECT * FROM {0} WHERE {1} = @{2}", "[Device]", "ChannelId", "ChannelId");
				sqlCommand.Parameters.Add(string.Format("@{0}", "ChannelId"), DbType.Int32).Value = ch.ChannelId;
				string[] array = new string[9]
				{
					"DeviceId",
					"ChannelId",
					"DeviceName",
					"CPUType",
					"IPAddress",
					"Rack",
					"Slot",
					"Description",
					"IsActived"
				};
				return LocalBaseDAO.SelectCollection<Device>(array, array, sqlCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public short GetIdNew(Channel ch)
		{
			 
			try
			{
				return LocalBaseDAO.GetIdByParentId("[Device]", "DeviceId", "ChannelId", ch.ChannelId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public short GetIdNew(short channelId)
		{
			
			try
			{
				return LocalBaseDAO.GetIdByParentId("[Device]", "DeviceId", "ChannelId", channelId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
