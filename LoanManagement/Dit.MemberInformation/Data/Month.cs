using System.Xml.Serialization;

namespace Dit.Lms.Api
{
    public enum Month
    {
        [XmlEnum("1")]
        January = 1,
        [XmlEnum("2")]
        February = 2,
        [XmlEnum("3")]
        March = 3,
        [XmlEnum("4")]
        April = 4,
        [XmlEnum("5")]
        May = 5,
        [XmlEnum("6")]
        June = 6,
        [XmlEnum("7")]
        July = 7,
        [XmlEnum("8")]
        August = 8,
        [XmlEnum("9")]
        September = 9,
        [XmlEnum("10")]
        October = 10,
        [XmlEnum("11")]
        November = 11,
        [XmlEnum("12")]
        December = 12
    }
}
