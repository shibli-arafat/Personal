using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface ICourseTypeListView
    {
        bool IsPagePostBack { get; }
        void ViewDataInGUI(CourseTypeCollection ranks);
        void ShowEmptyMessage();

    }
}
