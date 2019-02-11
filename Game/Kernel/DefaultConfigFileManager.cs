using System;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
namespace Game.Kernel
{
	public class DefaultConfigFileManager
	{
		private static string m_configfilepath;
		private static IConfigInfo m_configinfo = null;
		private static object m_lockHelper = new object();
		public static string ConfigFilePath
		{
			get
			{
				return DefaultConfigFileManager.m_configfilepath;
			}
			set
			{
				DefaultConfigFileManager.m_configfilepath = value;
			}
		}
		public static IConfigInfo ConfigInfo
		{
			get
			{
				return DefaultConfigFileManager.m_configinfo;
			}
			set
			{
				DefaultConfigFileManager.m_configinfo = value;
			}
		}
		public static IConfigInfo DeserializeInfo(string configfilepath, Type configtype)
		{
			FileStream fileStream = null;
			IConfigInfo result;
			try
			{
				fileStream = new FileStream(configfilepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				XmlSerializer xmlSerializer = new XmlSerializer(configtype);
				result = (IConfigInfo)xmlSerializer.Deserialize(fileStream);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}
			return result;
		}
		protected static IConfigInfo LoadConfig(ref DateTime fileoldchange, string configFilePath, IConfigInfo configinfo)
		{
			return DefaultConfigFileManager.LoadConfig(ref fileoldchange, configFilePath, configinfo, true);
		}
		protected static IConfigInfo LoadConfig(ref DateTime fileoldchange, string configFilePath, IConfigInfo configinfo, bool checkTime)
		{
			DefaultConfigFileManager.m_configfilepath = configFilePath;
			IConfigInfo result = configinfo;
			if (checkTime)
			{
				DateTime lastWriteTime = File.GetLastWriteTime(configFilePath);
				if (fileoldchange != lastWriteTime)
				{
					fileoldchange = lastWriteTime;
					object lockHelper;
					Monitor.Enter(lockHelper = DefaultConfigFileManager.m_lockHelper);
					try
					{
						result = DefaultConfigFileManager.DeserializeInfo(configFilePath, configinfo.GetType());
					}
					finally
					{
						Monitor.Exit(lockHelper);
					}
				}
				return result;
			}
			object lockHelper2;
			Monitor.Enter(lockHelper2 = DefaultConfigFileManager.m_lockHelper);
			IConfigInfo result2;
			try
			{
				result2 = DefaultConfigFileManager.DeserializeInfo(configFilePath, configinfo.GetType());
			}
			finally
			{
				Monitor.Exit(lockHelper2);
			}
			return result2;
		}
		public virtual bool SaveConfig()
		{
			return true;
		}
		public bool SaveConfig(string configFilePath, IConfigInfo configinfo)
		{
			bool result = false;
			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(configFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
				new XmlSerializer(configinfo.GetType()).Serialize(fileStream, configinfo);
				result = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}
			return result;
		}
	}
}
