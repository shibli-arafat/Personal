using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ArmyTraining.Model.Trainings
{
    public class TrainingStatus
    {
        public TrainingStatus()
        {
            Activities = new TrainingActivityCollection();
            TrainingActivity act = new TrainingActivity();
            Activities.Items.Add(act);
            AllowedStatuses = new AlloweStatusCollection();
            AllowedStatuses.Items.Add(new AllowedStatus());
        }
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("activities")]
        public TrainingActivityCollection Activities { get; set; }
        [XmlElement("allowessteps")]
        public AlloweStatusCollection AllowedStatuses { get; set; }
    }
}
