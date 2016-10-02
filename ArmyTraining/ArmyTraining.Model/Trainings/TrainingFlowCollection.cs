using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmyTraining.Model.Trainings
{
    public class TrainingFlowCollection : List<TrainingFlow>
    {
        public TrainingFlow GetCurrentFlow()
        {
            return Find(x => x.IsInCurrent);
        }

        public TrainingFlow GetTrainingFlowById(int id)
        {
            return Find(x => x.Id == id);
        }
    }
}
