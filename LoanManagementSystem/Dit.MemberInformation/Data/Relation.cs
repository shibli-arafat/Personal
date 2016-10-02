using System.Xml.Serialization;

namespace Dit.Lms.Api
{
    public enum Relation
    {
        [XmlEnum("1")]
        Father = 1,
        [XmlEnum("2")]
        Mother = 2,
        [XmlEnum("3")]
        Sister = 3,
        [XmlEnum("4")]
        Brother = 4,
        [XmlEnum("5")]
        Husband = 5,
        [XmlEnum("6")]
        Wife = 6,
        [XmlEnum("7")]
        Uncle = 7,
        [XmlEnum("8")]
        Friend = 8,
        [XmlEnum("9")]
        Coleague = 9,
        [XmlEnum("10")]
        Nephew = 10,
        [XmlEnum("11")]
        Niece = 11,
        [XmlEnum("12")]
        FatherInLaw = 12,
        [XmlEnum("13")]
        MotherInLaw = 13,
        [XmlEnum("14")]
        BrotherInLaw = 14,
        [XmlEnum("15")]
        SisterInLaw = 15,
        [XmlEnum("16")]
        GrandFather = 16,
        [XmlEnum("17")]
        GrandMother = 17,
        [XmlEnum("18")]
        Son = 18,
        [XmlEnum("19")]
        Daughter = 19
    }
}
