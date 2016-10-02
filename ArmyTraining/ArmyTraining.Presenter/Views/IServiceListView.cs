using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface IServiceListView
    {
        bool IsPagePostBack { get; }
        void ViewDataInGUI(ServiceCollection ranks);
        void ShowEmptyMessage();

    }
}
