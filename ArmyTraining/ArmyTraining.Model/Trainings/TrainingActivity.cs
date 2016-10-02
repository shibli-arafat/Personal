using System.Xml.Serialization;

namespace ArmyTraining.Model.Trainings
{
    public class TrainingActivity
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
