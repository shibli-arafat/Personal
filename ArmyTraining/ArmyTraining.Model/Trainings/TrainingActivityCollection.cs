using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArmyTraining.Model.Trainings
{
    [XmlType("activities")]
    public class TrainingActivityCollection 
    {
        public TrainingActivityCollection()
        {
            Items = new List<TrainingActivity>();
        }

        [XmlElement("add")]
        public List<TrainingActivity> Items { get; set; }
    }
}
