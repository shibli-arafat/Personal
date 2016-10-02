using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class CourseDetailPresenter
    {
        ICourseDetailView _View;
        CourseInternal _Internal;

        public CourseDetailPresenter(ICourseDetailView view)
        {
            _View = view;
            _Internal = new CourseInternal();
        }

        public void OnViewLoaded()
        {
            if (!_View.IsPagePostBack)
            {
                Course course = new Course();
                if (_View.CourseId > 0)
                {
                    course = _Internal.GetCourseById(_View.CourseId);
                }
                _View.BindTrainingBackgrounds(new TrainingBackgroundInternal().GetTrainingBackgrounds());
                _View.BindCourseTypes(new CourseTypeInternal().GetCourseTypes());
                _View.PopulateGuiFromCourse(course);
            }
        }

        public void HandleSave()
        {
            Course course = _View.PopulateCourseFromGui();
            if (_View.CourseId > 0)
            {
                UpdateCourse(course);
            }
            else
            {
                AddCourse(course);
            }
        }

        private void AddCourse(Course course)
        {
            _Internal.AddCourse(course);
        }

        private void UpdateCourse(Course course)
        {
            course.Id = _View.CourseId;
            _Internal.UpdateCourse(course);
        }
    }
}
