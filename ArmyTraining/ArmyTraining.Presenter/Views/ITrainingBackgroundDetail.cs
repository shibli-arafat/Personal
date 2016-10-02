using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface ITrainingBackgroundDetail
    {
        TrainingBackground PopulateTrainingBackgroundFromGui();
        int TrainingBackgroundId { get; }
        bool IsPagePostBack { get; }
        void PopulateGuiFromTrainingBackground(TrainingBackground trainingBkg);
    }
}
