using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArmyTraining.Model
{
    [Serializable]
    [XmlType("trainingBkgs")]
    public class TrainingBackgroundCollection : List<TrainingBackground>
    {
        public TrainingBackground GetById(int id)
        {
            return this.Find(x => x.Id == id);
        }
    }
}
