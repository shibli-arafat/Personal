using System.IO;
using System.Xml.Serialization;

namespace ArmyTraining.Model
{
    public class XmlSerializeHelper<T>
    {
        public static string Serialize(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        public static T Deserialize(string str)
        {
            if (string.IsNullOrEmpty(str)) return default(T);
            using (TextReader reader = new StringReader(str))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
