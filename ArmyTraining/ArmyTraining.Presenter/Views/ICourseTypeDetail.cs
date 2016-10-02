using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface ICourseTypeDetail
    {
        CourseType PopulateCourseTypeFromGUI();
        int CourseTypeId { get; }
        bool IsPagePostBack { get; }
        void PopulateGUIFromCourseType(CourseType service);
    }
}
