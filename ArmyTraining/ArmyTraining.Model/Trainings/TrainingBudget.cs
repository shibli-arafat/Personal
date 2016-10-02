using System;
using System.Xml.Serialization;

namespace ArmyTraining.Model.Trainings
{
    [Serializable]
    [XmlType("budget")]
    public class TrainingBudget
    {
        public int Id { get; set; }
        [XmlAttribute("year")]
        public string BudgetYear { get; set; }
        [XmlAttribute("expence")]
        public decimal Expenditure { get; set; }
    }
}
