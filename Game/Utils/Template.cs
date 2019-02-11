using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
namespace Game.Utils
{
	public class Template
	{
		private Regex variableGrammarRegex = new Regex("{#= \\w+?#}", RegexOptions.Compiled | RegexOptions.Singleline);
		private Regex forStatementGrammarRegex = new Regex("{# for \\w+ in \\w+#}.*?{# endfor#}", RegexOptions.Compiled | RegexOptions.Singleline);
		private string _templateCode;
		private Dictionary<string, object> _variableDataScoureList;
		private Dictionary<string, DataTable> _forDataScoureList;
		public string TemplateCode
		{
			get
			{
				return this._templateCode;
			}
			set
			{
				this._templateCode = value;
			}
		}
		public Dictionary<string, object> VariableDataScoureList
		{
			get
			{
				return this._variableDataScoureList;
			}
			set
			{
				this._variableDataScoureList = value;
			}
		}
		public Dictionary<string, DataTable> ForDataScoureList
		{
			get
			{
				return this._forDataScoureList;
			}
			set
			{
				this._forDataScoureList = value;
			}
		}
		public Template(string templatePath)
		{
			string file = HttpContext.Current.Server.MapPath(templatePath);
			this._templateCode = FileManager.ReadFile(file);
			this._variableDataScoureList = new Dictionary<string, object>();
			this._forDataScoureList = new Dictionary<string, DataTable>();
		}
		public string OutputHTML()
		{
			if (this._variableDataScoureList.Count > 0)
			{
				foreach (Match match in this.variableGrammarRegex.Matches(this._templateCode))
				{
					string key = match.Value.Replace("{#= ", "").Replace("#}", "");
					this._templateCode = this._templateCode.Replace(match.Value, this._variableDataScoureList[key].ToString());
				}
			}
			if (this._forDataScoureList.Count > 0)
			{
				Regex regex = new Regex("{# for \\w+? in", RegexOptions.Compiled);
				Regex regex2 = new Regex("{# for {1}\\w+? in \\w+?#}", RegexOptions.Compiled);
				string text = string.Empty;
				foreach (Match match2 in this.forStatementGrammarRegex.Matches(this._templateCode))
				{
					Match match3 = regex2.Match(match2.Value);
					Match match4 = regex.Match(match2.Value);
					if (match3.Success && match4.Success)
					{
						string text2 = match4.Value.Replace("{# for ", "").Replace(" in", "");
						string text3 = match3.Value.Replace("{# for ", "").Replace(text2, "").Replace(" in ", "").Replace("#}", "");
						string text4 = match2.Value.Replace("{# endfor#}", "").Replace(string.Concat(new string[]
						{
							"{# for ",
							text2,
							" in ",
							text3,
							"#}"
						}), "");
						Regex regex3 = new Regex("{# " + text2 + ".\\w+?#}", RegexOptions.Compiled);
						DataTable dataTable = this._forDataScoureList[text3];
						foreach (DataRow dataRow in dataTable.Rows)
						{
							string text5 = text4;
							foreach (Match match5 in regex3.Matches(text4))
							{
								string columnName = match5.Value.Replace("{# " + text2 + ".", "").Replace("#}", "");
								text5 = text5.Replace(match5.Value, dataRow[columnName].ToString());
							}
							text += text5;
						}
					}
					if (!string.IsNullOrEmpty(text))
					{
						this._templateCode = this._templateCode.Replace(match2.Value, text);
					}
					text = string.Empty;
				}
			}
			return this._templateCode;
		}
	}
}
