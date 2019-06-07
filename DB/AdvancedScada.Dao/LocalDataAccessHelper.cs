using AdvancedScada.Dao.TagManagers;
using System;

namespace AdvancedScada.Dao
{
    public static class LocalDataAccessHelper
	{
		public static ChannelDA GetChannelDA()
		{
			return (ChannelDA)Activator.CreateInstance(Type.GetType(" AdvancedScada.Dao.TagManagers.ChannelDA"));
		}

		public static DeviceDA GetDeviceDA()
		{
			return (DeviceDA)Activator.CreateInstance(Type.GetType(" AdvancedScada.Dao.TagManagers.DeviceDA"));
		}

		public static DataBlockDA GetDataBlockDA()
		{
			return (DataBlockDA)Activator.CreateInstance(Type.GetType(" AdvancedScada.Dao.TagManagers.DataBlockDA"));
		}

		public static TagDA GetTagDA()
		{
			return (TagDA)Activator.CreateInstance(Type.GetType(" AdvancedScada.Dao.TagManagers.TagDA"));
		}

		 
	}
}
