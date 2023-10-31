using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CH.XML
{
    public class Convert
    {
        public static TData Clone<TData>(TData data) where TData : class
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(TData));
                string serializedText = ObjectToXmlString(xs, (TData)data);
                return (TData)XmlStringToObject<TData>(serializedText);
            }
            catch
            {
                throw;
            }
        }

        public static string ObjectToXmlString(object data)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(data.GetType());
                return ObjectToXmlString(xs, data);
            }
            catch
            {
                throw;
            }
        }

        public static string ObjectToXmlString(XmlSerializer xs, object data)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                XmlTextWriter xtw = new XmlTextWriter(sw);

                xs.Serialize(xtw, data);
                xtw.Flush();

                return sb.ToString();
            }
            catch
            {
                throw;
            }
        }

        public static TData XmlStringToObject<TData>(string data) where TData : class
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(TData));
                StringReader sr = new StringReader(data);
                XmlTextReader wtr = new XmlTextReader(sr);

                return (TData)xs.Deserialize(wtr);
            }
            catch
            {
                throw;
            }
        }
    }
}
