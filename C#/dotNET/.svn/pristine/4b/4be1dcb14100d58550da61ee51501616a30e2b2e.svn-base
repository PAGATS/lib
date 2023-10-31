using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CH.XML
{
    public class Registry
    {
        public static void Write<TData>(string path, TData data, Type[] extraTypes) where TData : class
        {
            try
            {
                StreamWriter stw = new StreamWriter(path);
                XmlWriter xw = XmlWriter.Create(stw);
                XmlSerializer xs = new XmlSerializer(typeof(TData), extraTypes);
                xs.Serialize(xw, data);
                xw.Flush();
                xw.Close();
                stw.Close();
            }
            catch
            {
                throw;
            }
        }

        public static void Write<TData>(string path, TData data) where TData : class
        {
            try
            {
                StreamWriter stw = new StreamWriter(path);
                XmlWriter xw = XmlWriter.Create(stw);
                XmlSerializer xs = new XmlSerializer(typeof(TData));
                xs.Serialize(xw, data);
                xw.Flush();
                xw.Close();
                stw.Close();
            }
            catch
            {
                throw;
            }
        }

        public static void TryToRead<TData>(string path, ref TData data) where TData : class
        {
            try
            {
                TData result;
                Read<TData>(path, out result);
                data = result;
            }
            catch
            {
                try
                {
                    Write<TData>(path, data);
                }
                catch
                {
                    throw;
                }
            }
        }

        public static void TryToRead<TData>(string path, ref TData data, Type[] extraTypes) where TData : class
        {
            try
            {
                TData result;
                Read<TData>(path, out result, extraTypes);
                data = result;
            }
            catch
            {
                try
                {
                    Write<TData>(path, data, extraTypes);
                }
                catch
                {
                    throw;
                }
            }
        }

        public static void Read<TData>(string path, out TData data) where TData : class
        {
            try
            {
                StreamReader str = new StreamReader(path);
                XmlReader xr = XmlReader.Create(str);
                XmlSerializer xs = new XmlSerializer(typeof(TData));
                data = (TData)xs.Deserialize(xr);
                xr.Close();
                str.Close();
            }
            catch
            {
                throw;
            }
        }

        public static void Read<TData>(string path, out TData data, Type[] extraTypes) where TData : class
        {
            try
            {
                StreamReader str = new StreamReader(path);
                XmlReader xr = XmlReader.Create(str);
                XmlSerializer xs = new XmlSerializer(typeof(TData), extraTypes);
                data = (TData)xs.Deserialize(xr);
                xr.Close();
                str.Close();
            }
            catch
            {
                throw;
            }

        }
    }

    public class XMLConverter
    {
        public static TData Clone<TData>(TData data) where TData : class
        {
            if (data == null)
            {
                return null;
            }

            XmlSerializer xs = new XmlSerializer(typeof(TData));

            string serializedText = ObjectToXmlString(xs, (TData)data);
            return (TData)XmlStringToObject<TData>(serializedText);
        }

        public static string ObjectToXmlString(object data)
        {
            XmlSerializer xs = new XmlSerializer(data.GetType());
            return ObjectToXmlString(xs, data);
        }

        public static string ObjectToXmlString(XmlSerializer xs, object data)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            XmlTextWriter xtw = new XmlTextWriter(sw);

            xs.Serialize(xtw, data);
            xtw.Flush();

            return sb.ToString();
        }

        public static TData XmlStringToObject<TData>(string text) where TData : class
        {
            XmlSerializer xs = new XmlSerializer(typeof(TData));
            StringReader sr = new StringReader(text);
            XmlTextReader wtr = new XmlTextReader(sr);

            return (TData)xs.Deserialize(wtr);
        }
    }
}
