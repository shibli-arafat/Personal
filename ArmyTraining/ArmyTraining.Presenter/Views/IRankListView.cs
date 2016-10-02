using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface IRankListView
    {
        bool IsPagePostBack { get; }
        void ViewDataInGUI(RankCollection ranks);
        void ShowEmptyMessage();
    }
}
