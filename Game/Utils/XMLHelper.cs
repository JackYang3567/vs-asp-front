using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Game.Utils
{
    public class XMLHelper
    {
        public XMLHelper()
        {
        }

        public static bool FileSerialize(string FilePath, string obj)
        {
            bool flag = true;
            if (!File.Exists(FilePath))
            {
                flag = false;
            }
            else
            {
                try
                {
                    using (StreamWriter streamWriter = new StreamWriter(FilePath, false, Encoding.UTF8))
                    {
                        streamWriter.Write(obj);
                    }
                }
                catch
                {
                    flag = false;
                }
            }
            return flag;
        }

        public static string GetNode(XmlDocument docXml, string node)
        {
            XmlNodeList elementsByTagName = docXml.GetElementsByTagName(node);
            return elementsByTagName.Item(0).InnerText.ToString();
        }

        public static XmlNode GetNodePlatform()
        {
            XmlNode xmlNodes;
            try
            {
                string str = ApplicationSettings.Get("adminurl");
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(string.Concat(str, "/AppData/PlatformInfo.xml"));
                xmlNodes = xmlDocument.SelectSingleNode("/Platforms/Platform");
            }
            catch (Exception exception)
            {
                xmlNodes = null;
            }
            return xmlNodes;
        }

        public static DataSet GetXml(string XmlPath)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(XmlPath);
            return dataSet;
        }

        public static object LoadFromXml(string filePath, Type type)
        {
            object obj = null;
            if (File.Exists(filePath))
            {
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    obj = (new XmlSerializer(type)).Deserialize(streamReader);
                }
            }
            return obj;
        }

        public static string LoadNode(string XmlPath, string Node)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(XmlPath);
            XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(Node);
            return elementsByTagName.Item(0).InnerText.ToString();
        }

        public static string LoadXmlNode(string XmlPath, string Node)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(XmlPath);
            XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(Node);
            return elementsByTagName.Item(0).InnerText.ToString();
        }

        public static string ObjToXML(Type type, object obj)
        {
            MemoryStream memoryStream = new MemoryStream();
            (new XmlSerializer(type)).Serialize(memoryStream, obj);
            memoryStream.Position = (long)0;
            string end = "";
            using (StreamReader streamReader = new StreamReader(memoryStream))
            {
                end = streamReader.ReadToEnd();
            }
            return end;
        }

        public static void XmlNodeReplace(string xmlPath, string Node, string Content)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            xmlDocument.SelectSingleNode(Node).InnerText = Content;
            xmlDocument.Save(xmlPath);
        }
    }
}