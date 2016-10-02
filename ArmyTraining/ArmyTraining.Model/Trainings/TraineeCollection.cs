using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ArmyTraining.Model.Trainings
{
    [Serializable]
    [XmlType("trainees")]
    public class TraineeCollection : List<Trainee>
    {
        public Trainee GetTraineeByPersonId(int personId)
        {
            return Find(x => x.PersonId == personId);
        }

        public void UpdatePersonDoc(int personId, string docName)
        {
            foreach (Trainee trainee in this)
            {
                if (trainee.PersonId == personId)
                {
                    trainee.DocName = docName;
                }
            }
        }
    }
}
