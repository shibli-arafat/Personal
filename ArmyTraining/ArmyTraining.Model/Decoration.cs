
using System;
using System.Xml.Serialization;
namespace ArmyTraining.Model
{
    [Serializable]
    [XmlType("decoration")]
    public class Decoration
    {
        [XmlAttribute("deco")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
