using Game.Utils;
using Game.Utils.Cache;
using System;
using System.IO;
using System.Text;
namespace Game.Facade
{
	public class Log
	{
		public const string LogFilePath = "/Log/Error/";
		public const int TimeInterval = 20;
		public static void Write(string content)
		{
			string key = "LastWritErrorLogTime";
			object obj = WHCache.Default.Get<AspNetCache>(key);
			if (obj == null || (System.DateTime.Now - System.Convert.ToDateTime(obj)).TotalMilliseconds > 20.0)
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				stringBuilder.Append(System.DateTime.Now);
				stringBuilder.Append(" 源：" + GameRequest.GetRawUrl());
				stringBuilder.Append(" IP：" + GameRequest.GetUserIP());
				stringBuilder.Append(" 描述：" + content + "\r\n");
				string mapPath = TextUtility.GetMapPath("/Log/Error/");
				if (!System.IO.Directory.Exists(mapPath))
				{
					System.IO.Directory.CreateDirectory(mapPath);
				}
				string text = mapPath + "ErrorLog" + System.DateTime.Now.ToString("yyyy-MM-dd") + ".log";
				int num = 0;
				text = FileManager.GetCurrentLogName(mapPath, text, ref num);
				if (System.IO.File.Exists(text))
				{
					System.IO.FileInfo fileInfo = new System.IO.FileInfo(text);
					if (fileInfo.Length > 31457280L)
					{
						text = string.Concat(new object[]
						{
							mapPath,
							"ErrorLog",
							System.DateTime.Now.ToString("yyyy-MM-dd"),
							"[",
							num,
							"].log"
						});
					}
				}
				System.IO.File.AppendAllText(text, stringBuilder.ToString(), System.Text.Encoding.Unicode);
				WHCache.Default.Save<AspNetCache>(key, System.DateTime.Now, new int?(1));
			}
		}
		public static void Write(string content, string path)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append(System.DateTime.Now);
			stringBuilder.Append(" 源：" + GameRequest.GetRawUrl());
			stringBuilder.Append(" IP：" + GameRequest.GetUserIP());
			stringBuilder.Append(" 描述：" + content + "\r\n");
			string mapPath = TextUtility.GetMapPath("/Log/Error/");
			if (!System.IO.Directory.Exists(mapPath))
			{
				System.IO.Directory.CreateDirectory(mapPath);
			}
			string text = mapPath + path + ".log";
			int num = 0;
			text = FileManager.GetCurrentLogName(mapPath, text, ref num);
			if (System.IO.File.Exists(text))
			{
				System.IO.FileInfo fileInfo = new System.IO.FileInfo(text);
				if (fileInfo.Length > 31457280L)
				{
					text = string.Concat(new object[]
					{
						mapPath,
						path,
						"[",
						num,
						"].log"
					});
				}
			}
			System.IO.File.AppendAllText(text, stringBuilder.ToString(), System.Text.Encoding.Unicode);
		}
	}
}
