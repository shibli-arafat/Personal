using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArmyTraining.Model.Trainings
{
    [Serializable]
    [XmlType("budgets")]
    public class TrainingBudgetCollection : List<TrainingBudget>
    {
    }
}
