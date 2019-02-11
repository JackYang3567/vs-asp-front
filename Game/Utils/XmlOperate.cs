using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;
namespace Game.Utils
{
	public class XmlOperate
	{
		public enum OperateXmlMethod
		{
			XmlProperty,
			XmlNodes,
			All
		}
		private string _fileContent;
		private string _filePath;
		private XmlOperate.OperateXmlMethod _Method;
		private string _xPath;
		public string fileContent
		{
			get
			{
				return this._fileContent;
			}
			set
			{
				this._fileContent = value;
			}
		}
		public string filePath
		{
			get
			{
				return this._filePath;
			}
			set
			{
				this._filePath = value;
			}
		}
		public XmlOperate.OperateXmlMethod Method
		{
			get
			{
				return this._Method;
			}
			set
			{
				this._Method = value;
			}
		}
		public string xPath
		{
			get
			{
				return this._xPath;
			}
			set
			{
				this._xPath = value;
			}
		}
		public XmlOperate()
		{
		}
		public XmlOperate(string Path)
		{
			this.filePath = Path;
		}
		public bool CheckXml(string Name)
		{
			bool result = false;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.filePath);
			XmlElement xmlElement = (XmlElement)xmlDocument.SelectSingleNode(this.xPath);
			switch (this.Method)
			{
			case XmlOperate.OperateXmlMethod.XmlProperty:
				if (xmlElement.HasAttribute(Name))
				{
					result = true;
				}
				return result;
			case XmlOperate.OperateXmlMethod.XmlNodes:
				for (int i = 0; i < xmlElement.ChildNodes.Count; i++)
				{
					if (xmlElement.ChildNodes.Item(i).Name == Name)
					{
						result = true;
					}
				}
				return result;
			default:
				return result;
			}
		}
		public IList<string> GetXml(string name)
		{
			List<string> list = new List<string>();
			int num = 0;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.filePath);
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes(this.xPath);
			foreach (XmlNode xmlNode in xmlNodeList)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				switch (this.Method)
				{
				case XmlOperate.OperateXmlMethod.XmlProperty:
					if (xmlElement.HasAttribute(name))
					{
						list.Add(xmlElement.GetAttribute(name));
					}
					break;
				case XmlOperate.OperateXmlMethod.XmlNodes:
				{
					XmlNodeList childNodes = xmlElement.ChildNodes;
					foreach (XmlNode xmlNode2 in childNodes)
					{
						XmlElement xmlElement2 = (XmlElement)xmlNode2;
						if (xmlElement2.Name == name)
						{
							list.Add(xmlElement2.InnerText);
						}
					}
					break;
				}
				}
				num++;
			}
			return list;
		}
		public IList<string> GetXml(string nodes, int type, string name)
		{
			List<string> list = new List<string>();
			int num = 0;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.filePath);
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes(nodes);
			foreach (XmlNode xmlNode in xmlNodeList)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				switch (type)
				{
				case 0:
					if (xmlElement.HasAttribute(name))
					{
						list.Add(xmlElement.GetAttribute(name));
					}
					break;
				case 1:
				{
					XmlNodeList childNodes = xmlElement.ChildNodes;
					foreach (XmlNode xmlNode2 in childNodes)
					{
						XmlElement xmlElement2 = (XmlElement)xmlNode2;
						if (xmlElement2.Name == name)
						{
							list.Add(xmlElement2.InnerText);
						}
					}
					break;
				}
				}
				num++;
			}
			return list;
		}
		public XmlElement GetXmlElement(string nodes)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.filePath);
			return (XmlElement)xmlDocument.SelectSingleNode(nodes);
		}
		public XmlNodeList GetXmlNodeList(string nodes, int method)
		{
			XmlDocument xmlDocument = new XmlDocument();
			if (!string.IsNullOrEmpty(this.fileContent))
			{
				xmlDocument.LoadXml(this.fileContent);
			}
			else
			{
				xmlDocument.Load(this.filePath);
			}
			switch (method)
			{
			case 0:
				return xmlDocument.SelectSingleNode(nodes).ChildNodes;
			case 1:
				return xmlDocument.SelectNodes(nodes);
			default:
				return null;
			}
		}
		public void ChangeNode(DataTable dt)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.filePath);
			XmlNode xmlNode = xmlDocument.SelectSingleNode(this.xPath);
			if (xmlNode != null)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				for (int i = 0; i < dt.Columns.Count; i++)
				{
					if (dt.Columns[i].ColumnName.StartsWith("@"))
					{
						string name = dt.Columns[i].ColumnName.Replace("@", "");
						if (xmlElement.HasAttribute(name))
						{
							xmlElement.SetAttribute(name, dt.Rows[0][i].ToString());
						}
					}
					else
					{
						if (xmlElement.HasChildNodes)
						{
							XmlNodeList childNodes = xmlElement.ChildNodes;
							foreach (XmlNode xmlNode2 in childNodes)
							{
								XmlElement xmlElement2;
								try
								{
									xmlElement2 = (XmlElement)xmlNode2;
								}
								catch
								{
									continue;
								}
								try
								{
									if (xmlElement2.Name == dt.Columns[i].ColumnName)
									{
										try
										{
											xmlElement2.InnerXml = dt.Rows[0][i].ToString();
										}
										catch
										{
											xmlElement2.InnerText = dt.Rows[0][i].ToString();
										}
									}
								}
								catch
								{
									break;
								}
							}
						}
					}
				}
				xmlDocument.Save(this.filePath);
			}
		}
		public void ChangeNode(string parentNodeName, int type, string thename, string thevalue)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.filePath);
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes(parentNodeName);
			foreach (XmlNode xmlNode in xmlNodeList)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				if (type == 0)
				{
					if (xmlElement.HasAttribute(thename))
					{
						xmlElement.SetAttribute(thename, thevalue);
					}
				}
				else
				{
					if (type == 1)
					{
						XmlNodeList childNodes = xmlElement.ChildNodes;
						foreach (XmlNode xmlNode2 in childNodes)
						{
							XmlElement xmlElement2 = (XmlElement)xmlNode2;
							if (xmlElement2.Name == thename)
							{
								try
								{
									xmlElement2.InnerXml = thevalue;
								}
								catch
								{
									xmlElement2.InnerText = thevalue;
								}
							}
						}
					}
				}
			}
			xmlDocument.Save(this.filePath);
		}
		public DataTable ConvertXmlNodeListDataTable(XmlNodeList xlist)
		{
			DataTable dataTable = new DataTable();
			for (int i = 0; i < xlist.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				XmlElement xmlElement = (XmlElement)xlist.Item(i);
				for (int j = 0; j < xmlElement.Attributes.Count; j++)
				{
					if (!dataTable.Columns.Contains("@" + xmlElement.Attributes[j].Name))
					{
						dataTable.Columns.Add("@" + xmlElement.Attributes[j].Name);
					}
					dataRow["@" + xmlElement.Attributes[j].Name] = xmlElement.Attributes[j].Value;
				}
				for (int j = 0; j < xmlElement.ChildNodes.Count; j++)
				{
					if (!dataTable.Columns.Contains(xmlElement.ChildNodes.Item(j).Name))
					{
						dataTable.Columns.Add(xmlElement.ChildNodes.Item(j).Name);
					}
					dataRow[xmlElement.ChildNodes.Item(j).Name] = xmlElement.ChildNodes.Item(j).InnerText;
				}
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}
		public DataTable ConvertXmlNodeListDataTable(XmlNodeList xlist, int type)
		{
			DataTable dataTable = new DataTable();
			for (int i = 0; i < xlist.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				XmlElement xmlElement = (XmlElement)xlist.Item(i);
				if (type == 0)
				{
					for (int j = 0; j < xmlElement.Attributes.Count; j++)
					{
						if (!dataTable.Columns.Contains("@" + xmlElement.Attributes[j].Name))
						{
							dataTable.Columns.Add("@" + xmlElement.Attributes[j].Name);
						}
						dataRow["@" + xmlElement.Attributes[j].Name] = xmlElement.Attributes[j].Value;
					}
				}
				else
				{
					if (type == 1)
					{
						for (int j = 0; j < xmlElement.ChildNodes.Count; j++)
						{
							if (!dataTable.Columns.Contains(xmlElement.ChildNodes.Item(j).Name))
							{
								dataTable.Columns.Add(xmlElement.ChildNodes.Item(j).Name);
							}
							dataRow[xmlElement.ChildNodes.Item(j).Name] = xmlElement.ChildNodes.Item(j).InnerText;
						}
					}
				}
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}
		public void CreateNode(string nodeName, DataTable dt)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.filePath);
			XmlNode xmlNode = xmlDocument.SelectSingleNode(this.xPath);
			XmlElement xmlElement = xmlDocument.CreateElement(nodeName);
			XmlElement xmlElement2 = null;
			if (!object.Equals(dt, null))
			{
				for (int i = 0; i < dt.Columns.Count; i++)
				{
					if (dt.Columns[i].ColumnName.StartsWith("@"))
					{
						string name = dt.Columns[i].ColumnName.Replace("@", "");
						xmlElement.SetAttribute(name, dt.Rows[0][i].ToString());
					}
					else
					{
						xmlElement2 = xmlDocument.CreateElement(dt.Columns[i].ColumnName);
						try
						{
							xmlElement2.InnerXml = dt.Rows[0][i].ToString();
						}
						catch
						{
							xmlElement2.InnerText = dt.Rows[0][i].ToString();
						}
						xmlElement.AppendChild(xmlElement2);
					}
				}
			}
			xmlNode.AppendChild(xmlElement);
			xmlDocument.Save(this.filePath);
		}
		public void CreateNodes(string nodeName, DataTable dt)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.filePath);
			XmlNode xmlNode = xmlDocument.SelectSingleNode(this.xPath);
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				XmlElement xmlElement = xmlDocument.CreateElement(nodeName);
				XmlElement xmlElement2 = null;
				if (!object.Equals(dt, null))
				{
					for (int j = 0; j < dt.Columns.Count; j++)
					{
						if (dt.Columns[j].ColumnName.StartsWith("@"))
						{
							string name = dt.Columns[j].ColumnName.Replace("@", "");
							xmlElement.SetAttribute(name, dt.Rows[i][j].ToString());
						}
						else
						{
							xmlElement2 = xmlDocument.CreateElement(dt.Columns[j].ColumnName);
							try
							{
								xmlElement2.InnerXml = dt.Rows[i][j].ToString();
							}
							catch
							{
								xmlElement2.InnerText = dt.Rows[i][j].ToString();
							}
							xmlElement.AppendChild(xmlElement2);
						}
					}
				}
				xmlNode.AppendChild(xmlElement);
			}
			xmlDocument.Save(this.filePath);
		}
		public void CreateNodes(string nodeName, DataTable dt, bool CreateNull)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.filePath);
			XmlNode xmlNode = xmlDocument.SelectSingleNode(this.xPath);
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				XmlElement xmlElement = xmlDocument.CreateElement(nodeName);
				XmlElement xmlElement2 = null;
				if (!object.Equals(dt, null))
				{
					for (int j = 0; j < dt.Columns.Count; j++)
					{
						if (dt.Columns[j].ColumnName.StartsWith("@"))
						{
							string name = dt.Columns[j].ColumnName.Replace("@", "");
							if (CreateNull)
							{
								xmlElement.SetAttribute(name, dt.Rows[i][j].ToString());
							}
							else
							{
								if (dt.Rows[i][j].ToString() != "")
								{
									xmlElement.SetAttribute(name, dt.Rows[i][j].ToString());
								}
							}
						}
						else
						{
							xmlElement2 = xmlDocument.CreateElement(dt.Columns[j].ColumnName);
							if (CreateNull)
							{
								try
								{
									xmlElement2.InnerXml = dt.Rows[i][j].ToString();
								}
								catch
								{
									xmlElement2.InnerText = dt.Rows[i][j].ToString();
								}
								xmlElement.AppendChild(xmlElement2);
							}
							else
							{
								if (dt.Rows[i][j].ToString() != "")
								{
									try
									{
										xmlElement2.InnerXml = dt.Rows[i][j].ToString();
									}
									catch
									{
										xmlElement2.InnerText = dt.Rows[i][j].ToString();
									}
									xmlElement.AppendChild(xmlElement2);
								}
							}
						}
					}
				}
				xmlNode.AppendChild(xmlElement);
			}
			xmlDocument.Save(this.filePath);
		}
		public void CreateXml()
		{
			FileManager.Create(this.filePath, FsoMethod.File);
			XmlTextWriter xmlTextWriter = new XmlTextWriter(this.filePath, Encoding.GetEncoding("gb2312"))
			{
				Formatting = Formatting.Indented,
				Indentation = 3
			};
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.Flush();
			xmlTextWriter.Close();
		}
		public void CreateXml(string rootNodeName)
		{
			FileManager.Create(this.filePath, FsoMethod.File);
			XmlTextWriter xmlTextWriter = new XmlTextWriter(this.filePath, Encoding.GetEncoding("gb2312"))
			{
				Formatting = Formatting.Indented,
				Indentation = 3
			};
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement(rootNodeName);
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Flush();
			xmlTextWriter.Close();
		}
		public void DeleteNode(string nodeName)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(this.filePath);
			XmlNode xmlNode = xmlDocument.SelectSingleNode(this.xPath);
			XmlNode xmlNode2 = xmlNode.SelectSingleNode(nodeName);
			if (xmlNode2 != null)
			{
				xmlNode.RemoveChild(xmlNode2);
				xmlDocument.Save(this.filePath);
			}
		}
	}
}
