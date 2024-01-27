﻿using System.Text;
using System.Xml.Serialization;

namespace Medicines.Extensions
{
    public static class XmlSerializationExtension
    {
        public static string SerializeToXml<T>(this T obj, string rootName)
        {
            var xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            string result = null;

            using (MemoryStream ms = new MemoryStream())
            {
                xmlSerializer.Serialize(ms, obj, namespaces);

                result = Encoding.UTF8.GetString(ms.ToArray());
            }

            return result.TrimEnd();
        }

        public static T DeserializeFromXml<T>(this string xmlString, string rootName)
        {
            var xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            T result = default;

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                result = (T)xmlSerializer.Deserialize(ms);
            }

            return result;
        }
    }
}
