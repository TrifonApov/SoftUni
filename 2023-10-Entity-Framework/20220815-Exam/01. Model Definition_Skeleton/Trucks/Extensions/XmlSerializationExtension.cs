using System.Text;
using System.Xml.Serialization;

<<<<<<< HEAD
namespace Trucks.Extensions
=======
namespace Boardgames.Extensions
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
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

<<<<<<< HEAD
            return result;
=======
            return result.TrimEnd();
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
        }

        public static T DeserializeFromXml<T>(this string xmlString, string rootName)
        {
            var xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            T result = default(T);

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                result = (T)xmlSerializer.Deserialize(ms);
            }

            return result;
        }
    }
}
