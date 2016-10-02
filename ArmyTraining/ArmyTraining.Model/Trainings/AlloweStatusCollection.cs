using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArmyTraining.Model.Trainings
{
    [XmlType("allowedstatuses")]
    public class AlloweStatusCollection
    {
        public AlloweStatusCollection()
        {
            Items = new List<AllowedStatus>();
        }

        [XmlElement("add")]
        public List<AllowedStatus> Items { get; set; }
    }
}
