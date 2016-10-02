using ArmyTraining.Model;

namespace ArmyTraining.Presenter.Views
{
    public interface ICourseDetailView
    {
        bool IsPagePostBack { get; }
        int CourseId { get; }
        Course PopulateCourseFromGui();
        void PopulateGuiFromCourse(Course course);
        void BindCourseTypes(CourseTypeCollection types);
        void BindTrainingBackgrounds(TrainingBackgroundCollection trBackgrounds);
    }
}
