using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Game.Utils.Utils
{
    public static class Serializer
    {
        /// <summary>
        /// 将对象序列化为JSON格式
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>json字符串</returns>
        public static string SerializeToJson(object o)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
          //  settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            string json = JsonConvert.SerializeObject(o, Newtonsoft.Json.Formatting.Indented, settings).Replace("\r\n", ""); ;
            return json;
        }

        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串(eg.{"ID":"112","Name":"石子儿"})</param>
        /// <returns>对象实体</returns>
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            T t = o as T;
            return t;
        }

        /// <summary>
        /// 解析JSON数组生成对象实体集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json数组字符串(eg.[{"ID":"112","Name":"石子儿"}])</param>
        /// <returns>对象实体集合</returns>
        public static List<T> DeserializeJsonToList<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            List<T> list = o as List<T>;
            return list;
        }

        /// <summary>
        /// 反序列化JSON到给定的匿名对象.
        /// </summary>
        /// <typeparam name="T">匿名对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <param name="anonymousTypeObject">匿名对象</param>
        /// <returns>匿名对象</returns>
        public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject)
        {
            T t = JsonConvert.DeserializeAnonymousType(json, anonymousTypeObject);
            return t;
        }

        #region XML

        /// <summary>
        /// 将指定类型的对象序列化为XML
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t">需要序列化的对象</param>
        /// <returns>XML字符串</returns>
        public static string XmlSerialize(object o, bool hasNamespaces = false, bool hasXmlHead = false)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            //去除xml声明
            if (!hasXmlHead)
            {
                settings.OmitXmlDeclaration = true;
            }
            settings.Encoding = Encoding.Default;
            System.IO.MemoryStream mem = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(mem, settings))
            {
                //去除默认命名空间xmlns:xsd和xmlns:xsi
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                if (!hasNamespaces)
                {
                    ns.Add("", "");
                }
                XmlSerializer formatter = new XmlSerializer(o.GetType());
                formatter.Serialize(writer, o, ns);
            }
            return Encoding.Default.GetString(mem.ToArray());

        }

        /// <summary>
        /// 反序列化XML字符串为对象
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns>对象T</returns>
        public static T XmlDeserialize<T>(string xml) where T : class
        {
            using (var sr = new StringReader(xml))
            {
                var xz = new XmlSerializer(typeof(T));
                return (T)xz.Deserialize(sr);
            }
        }

        /// <summary>
        /// 反序列化XML文件为对象
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="filepath">XML文件路径</param>
        /// <returns>对象T</returns>
        public static T XmlFileDeserialize<T>(string filePath) where T : class
        {
            string xml = string.Empty;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    xml = sr.ReadToEnd();
                }
            }
            using (var sr = new StringReader(xml))
            {
                var xz = new XmlSerializer(typeof(T));
                return (T)xz.Deserialize(sr);
            }
        }

        public static string DictionaryToXml(Dictionary<string, string> dic)
        {
            var sb = new StringBuilder();
            sb.Append("<xml>");
            var akeys = new ArrayList(dic.Keys);
            foreach (string k in akeys)
            {
                var v = (string)dic[k];
                if (Regex.IsMatch(v, @"^[0-9.]$"))
                {
                    sb.Append("<" + k + ">" + v + "</" + k + ">");
                }
                else
                {
                    sb.Append("<" + k + "><![CDATA[" + v + "]]></" + k + ">");
                }
            }
            sb.Append("</xml>");
            return sb.ToString();
        }

        public static List<T> XmlToObjextList<T>(string xml, string headtag)
            where T : new()
        {
            List<T> list = new List<T>();
            XmlDocument doc = new XmlDocument();
            PropertyInfo[] propinfos = null;
            doc.LoadXml(xml);
            XmlNodeList nodelist = doc.GetElementsByTagName(headtag);
            foreach (XmlNode node in nodelist)
            {
                T entity = new T();
                //初始化propertyinfo
                if (propinfos == null)
                {
                    Type objtype = entity.GetType();
                    propinfos = objtype.GetProperties();
                }
                //填充entity类的属性
                foreach (PropertyInfo propinfo in propinfos)
                {
                    //实体类字段首字母变成小写的
                    //  string name = propinfo.Name.Substring(0, 1) + propinfo.Name.Substring(1, propinfo.Name.Length - 1);
                    string name = propinfo.Name;
                    XmlNode cnode = node.SelectSingleNode(name);
                    string v = cnode.InnerText;
                    if (v != null)
                        propinfo.SetValue(entity, Convert.ChangeType(v, propinfo.PropertyType), null);
                }
                list.Add(entity);
            }
            return list;
        }

        #endregion XML
    }
}