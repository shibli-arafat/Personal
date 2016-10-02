using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface ICourseListView
    {
        bool IsPagePostBack { get; }
        void DisplayListInGUI(CourseSearchResult courses, CourseFilter filter);
        void ShowEmptyRow();
        void BindCourseTypes(CourseTypeCollection types);
        void BindTriningBkgs(TrainingBackgroundCollection backgrounds);
    }
}
