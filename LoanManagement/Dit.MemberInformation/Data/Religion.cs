using System.Xml.Serialization;

namespace Dit.Lms.Api
{
    public enum Religion
    {
        [XmlEnum("1")]
        Islam = 1,
        [XmlEnum("2")]
        Hinduism = 2,
        [XmlEnum("3")]
        Christianity = 3,
        [XmlEnum("4")]
        Buddhism = 4
    }
}
