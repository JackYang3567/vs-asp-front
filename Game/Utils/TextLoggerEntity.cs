using System;
namespace Game.Utils
{
	public class TextLoggerEntity : IComparable
	{
		public string LogContent
		{
			get;
			set;
		}
		public DateTime LogDateTime
		{
			get;
			set;
		}
		public string LogErrorUrl
		{
			get;
			set;
		}
		public string LogIp
		{
			get;
			set;
		}
		public TextLoggerEntity(DateTime logDateTime, string logContent, string logIp, string logErrorUrl)
		{
			this.LogDateTime = logDateTime;
			this.LogContent = logContent;
			this.LogIp = logIp;
			this.LogErrorUrl = logErrorUrl;
		}
		public int CompareTo(object obj)
		{
			TextLoggerEntity textLoggerEntity = obj as TextLoggerEntity;
			if (textLoggerEntity.LogDateTime > this.LogDateTime)
			{
				return 1;
			}
			if (textLoggerEntity.LogDateTime < this.LogDateTime)
			{
				return -1;
			}
			return 0;
		}
	}
}
