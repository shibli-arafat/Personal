using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class TrainingBackgroundDetailPresenter
    {
        private TrainingBackgroundInternal _Internal;
        private ITrainingBackgroundDetail _View;

        public TrainingBackgroundDetailPresenter(ITrainingBackgroundDetail view)
        {
            _Internal = new TrainingBackgroundInternal();
            _View = view;
        }

        public void OnPageLoad()
        {
            if (!_View.IsPagePostBack)
            {
                TrainingBackground trainingBkgs = new TrainingBackground();
                if (_View.TrainingBackgroundId > 0)
                {
                    trainingBkgs = _Internal.GetTrainingBackground(_View.TrainingBackgroundId);
                }
                _View.PopulateGuiFromTrainingBackground(trainingBkgs);
            }
        }

        public void HandleSave()
        {
            TrainingBackground trainingBkg = _View.PopulateTrainingBackgroundFromGui();
            if (_View.TrainingBackgroundId == 0)
            {
                AddTrainingBackground(trainingBkg);
            }
            else
            {
                UpdateTrainingBackground(trainingBkg);
            }
        }

        private void AddTrainingBackground(TrainingBackground trainingBkg)
        {
            _Internal.AddTrainingBackground(trainingBkg);
        }

        private void UpdateTrainingBackground(TrainingBackground trainingBkg)
        {
            trainingBkg.Id = _View.TrainingBackgroundId;
            _Internal.UpdateTrainingBackground(trainingBkg);
        }

        public TrainingBackground LoadTrainingBackground()
        {
            return _Internal.GetTrainingBackground(_View.TrainingBackgroundId);
        }
    }
}
