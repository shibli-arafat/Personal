using System;
using System.Xml.Serialization;

namespace ArmyTraining.Model
{
    [Serializable]
    [XmlType("trainingBkg")]
    public class TrainingBackground
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
