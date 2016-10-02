using System;
using ArmyTraining.DataMapper;
using ArmyTraining.Model;

namespace ArmyTraining.Internal
{
    public class TrainingBackgroundInternal
    {
        private TrainingBackgroundDataMapper _Data;

        public TrainingBackgroundInternal()
        {
            _Data = new TrainingBackgroundDataMapper();
        }

        public TrainingBackground GetTrainingBackground(int Id)
        {
            return _Data.GetTrainingBackground(Id);
        }

        public TrainingBackgroundCollection GetTrainingBackgrounds()
        {
            return _Data.GetTrainingBackgrounds();
        }

        public void UpdateTrainingBackground(TrainingBackground trainingBkg)
        {
            if (_Data.IsDuplicate(trainingBkg.Id, trainingBkg.Name))
                throw new ArgumentException(string.Format("The training background {0} already exist.", trainingBkg.Name));
            _Data.UpdateTrainingBackground(trainingBkg);
        }

        public void AddTrainingBackground(TrainingBackground trainingBkg)
        {
            if (_Data.IsDuplicate(trainingBkg.Id, trainingBkg.Name))
                throw new ArgumentException(string.Format("The decoration {0} already exist.", trainingBkg.Name));
            _Data.AddTrainingBackground(trainingBkg);
        }

        public void DeleteTrainingBackground(int id)
        {
            _Data.DeleteTrainingBackground(id);
        }
    }
}
