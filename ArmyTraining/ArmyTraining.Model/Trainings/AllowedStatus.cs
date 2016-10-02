using System.Xml.Serialization;

namespace ArmyTraining.Model.Trainings
{
    public class AllowedStatus
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
