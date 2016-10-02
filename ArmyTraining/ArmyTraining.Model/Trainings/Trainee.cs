using System;
using System.Xml.Serialization;

namespace ArmyTraining.Model.Trainings
{
    [Serializable]
    [XmlType("trainee")]
    public class Trainee
    {
        public Trainee()
        {
            Sponsor = string.Empty;
        }

        public Trainee(int personId)
        {
            Sponsor = string.Empty;
            this.PersonId = personId;
        }

        public int Id { get; set; }
        [XmlAttribute("person")]
        public int PersonId { get; set; }
        [XmlAttribute("expence")]
        public decimal Expenditure { get; set; }
        [XmlAttribute("otherExpence")]
        public decimal OtherExpenditure { get; set; }
        [XmlAttribute("sponsor")]
        public string Sponsor { get; set; }
        [XmlAttribute("docName")]
        public string DocName { get; set; }
        [XmlAttribute("rankId")]
        public int RankId { get; set; }
    }
}
