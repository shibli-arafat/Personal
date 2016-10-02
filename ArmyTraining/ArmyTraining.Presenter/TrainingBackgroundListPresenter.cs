using ArmyTraining.Internal;
using ArmyTraining.Model;

namespace ArmyTraining.Presenter
{
    public class TrainingBackgroundListPresenter
    {
        private TrainingBackgroundInternal _Internal;

        public TrainingBackgroundListPresenter()
        {
            _Internal = new TrainingBackgroundInternal();
        }

        public TrainingBackgroundCollection GetTrainingBackgrounds()
        {
            return _Internal.GetTrainingBackgrounds();
        }

        public void DeleteTrainingBackground(int id)
        {
            _Internal.DeleteTrainingBackground(id);
        }
    }
}
