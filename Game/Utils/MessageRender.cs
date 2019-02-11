using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Game.Utils
{
	public class MessageRender
	{
		private const string variableBegin = "\\{";
		private const string variableEnd = "\\}";
		private Dictionary<string, string> replaceVariables = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		public string this[string key]
		{
			get
			{
				return this.replaceVariables[key];
			}
			set
			{
				this.RegisterVariable(key, value);
			}
		}
		public MessageRender()
		{
			this.RegisterVariable("datetime", TextUtility.FormatDateTime(DateTime.Now.ToString(), 4));
		}
		public void RegisterVariable(string varName, string value)
		{
			if (varName != null)
			{
				if (this.replaceVariables.ContainsKey(varName))
				{
					this.replaceVariables[varName] = value;
					return;
				}
				this.replaceVariables.Add(varName, value);
			}
		}
		public string Render(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			foreach (KeyValuePair<string, string> current in this.replaceVariables)
			{
				if (!string.IsNullOrEmpty(current.Key) && text.IndexOf(current.Key, StringComparison.OrdinalIgnoreCase) != -1)
				{
					text = Regex.Replace(text, string.Format("{0}{1}{2}", "\\{", current.Key, "\\}"), (current.Value == null) ? "" : current.Value, RegexOptions.IgnoreCase);
				}
			}
			return text;
		}
	}
}
