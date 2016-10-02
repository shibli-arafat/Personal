using System.IO;
using System.Xml.Serialization;

namespace Dit.Common
{
    public class SerializeHelper
    {
        public static string Serialize(object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, obj);
            writer.Close();
            return writer.ToString();
        }

        public static T Deserialize<T>(string data)
        {
            if (string.IsNullOrEmpty(data)) return default(T);
            TextReader reader = new StringReader(data);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(reader);
        }
    }
}
