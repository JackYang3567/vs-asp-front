using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Game.Utils
{
	public static class TextLogger
	{
		public class SortDateTime : IComparable
		{
			public DateTime dateTime;
			public SortDateTime(DateTime oneDateTime)
			{
				this.dateTime = oneDateTime;
			}
			public int CompareTo(object obj)
			{
				TextLogger.SortDateTime sortDateTime = obj as TextLogger.SortDateTime;
				if (sortDateTime.dateTime > this.dateTime)
				{
					return 1;
				}
				if (sortDateTime.dateTime < this.dateTime)
				{
					return -1;
				}
				return 0;
			}
		}
		public static readonly string APP_LOG_DIRECTORY = Utility.GetAppLogDirectory;
		private static string LOG_SUFFIX = "Log.config";
		private static readonly bool WRITE_APP_LOG = Utility.GetWriteAppLog;
		public static bool DeleteFile(string path)
		{
			bool result = false;
			try
			{
				new FileInfo(path).Delete();
				result = true;
			}
			catch (Exception ex)
			{
				TextLogger.Write(ex.ToString());
			}
			return result;
		}
		public static SortedList<TextLogger.SortDateTime, string> GetFileList()
		{
			SortedList<TextLogger.SortDateTime, string> sortedList = new SortedList<TextLogger.SortDateTime, string>();
			DirectoryInfo directoryInfo = new DirectoryInfo(TextLogger.APP_LOG_DIRECTORY);
			FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos();
			for (int i = 0; i < fileSystemInfos.Length; i++)
			{
				FileSystemInfo fileSystemInfo = fileSystemInfos[i];
				if (fileSystemInfo.Attributes != FileAttributes.Directory)
				{
					sortedList.Add(new TextLogger.SortDateTime(fileSystemInfo.LastWriteTime), fileSystemInfo.Name);
				}
			}
			return sortedList;
		}
		public static List<TextLoggerEntity> GetTextLogger()
		{
			string filePath = "";
			if (TextLogger.GetFileList().Count > 0)
			{
				filePath = Path.Combine(TextLogger.APP_LOG_DIRECTORY, TextLogger.GetFileList().Values[0]);
			}
			return TextLogger.GetTextLogger(filePath);
		}
		public static List<TextLoggerEntity> GetTextLogger(string filePath)
		{
			List<TextLoggerEntity> list = new List<TextLoggerEntity>();
			string[] array = TextLogger.LoadFile(filePath).Split(new char[]
			{
				'\n'
			}, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'|'
				});
				list.Add(new TextLoggerEntity(DateTime.Parse(array2[0].Trim()), array2[1], array2[2], array2[3]));
			}
			return list;
		}
		public static string LoadFile(string path)
		{
			if (!File.Exists(path))
			{
				return "";
			}
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
			if (fileStream == null)
			{
				throw new IOException("Unable to open the file: " + path);
			}
			StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			return result;
		}
		public static bool Write(string logContent)
		{
			return TextLogger.Write(logContent, "AppError");
		}
		public static bool Write(string logContent, string fileName)
		{
			bool result = true;
			if (string.IsNullOrEmpty(fileName))
			{
				fileName = "AppError";
			}
			try
			{
				string text = Path.Combine(TextLogger.APP_LOG_DIRECTORY, DateTime.Now.ToString("yyyyMMdd") + fileName + TextLogger.LOG_SUFFIX);
				FileInfo fileInfo = new FileInfo(text);
				if (fileInfo.Exists && fileInfo.Length >= 800000L)
				{
					fileInfo.CopyTo(text.Replace(TextLogger.LOG_SUFFIX, TextUtility.CreateRandomNum(5) + TextLogger.LOG_SUFFIX));
					File.Delete(text);
				}
				FileStream fileStream = new FileStream(text, FileMode.Append, FileAccess.Write, FileShare.Read);
				StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("{0:yyyy'/'MM'/'dd' 'HH':'mm':'ss}", DateTime.Now);
				stringBuilder.Append("|");
				if (TextLogger.WRITE_APP_LOG)
				{
					stringBuilder.Append(logContent.Replace("\r", "").Replace("\n", "<br />"));
					stringBuilder.Append("|");
					stringBuilder.Append(GameRequest.GetUserIP());
					stringBuilder.Append("|");
					stringBuilder.Append(GameRequest.GetUrl());
				}
				else
				{
					stringBuilder.Append(logContent);
				}
				stringBuilder.Append("\r\n");
				streamWriter.Write(stringBuilder.ToString());
				streamWriter.Flush();
				streamWriter.Close();
				streamWriter.Dispose();
				fileStream.Close();
				fileStream.Dispose();
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public static bool Write(string logContent, string classUrl, string funcName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (!string.IsNullOrEmpty(classUrl))
			{
				stringBuilder.Append(classUrl);
			}
			if (!string.IsNullOrEmpty(funcName))
			{
				stringBuilder.Append("/");
				stringBuilder.Append(funcName);
			}
			if (!string.IsNullOrEmpty(logContent))
			{
				if (TextLogger.WRITE_APP_LOG)
				{
					stringBuilder.Append("<br />");
				}
				else
				{
					stringBuilder.Append("\r\n\t");
				}
				stringBuilder.Append(logContent);
			}
			return TextLogger.Write(stringBuilder.ToString(), "AppDebug");
		}
		public static bool Write(Type cType, string funcName, string text)
		{
			return TextLogger.Write(cType.Namespace + cType.Name, funcName, text);
		}
	}
}
