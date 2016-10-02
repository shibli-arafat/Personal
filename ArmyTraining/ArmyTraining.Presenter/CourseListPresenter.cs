using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class CourseListPresenter
    {
        ICourseListView _View;
        CourseInternal _Internal;

        public CourseListPresenter(ICourseListView view)
        {
            _View = view;
            _Internal = new CourseInternal();
        }

        public void OnViewLoaded()
        {
            if (!_View.IsPagePostBack)
            {
                _View.BindCourseTypes(new CourseTypeInternal().GetCourseTypes());
                _View.BindTriningBkgs(new TrainingBackgroundInternal().GetTrainingBackgrounds());
            }
        }

        public void BindItems(CourseFilter filter)
        {
            CourseSearchResult result = _Internal.GetCourses(filter);
            if (result.Courses.Count > 0)
            {
                _View.DisplayListInGUI(result, filter);
            }
            else
            {
                _View.ShowEmptyRow();
            }
        }

        public void Delete(int id, CourseFilter filter)
        {
            _Internal.DeleteCourse(id);
            BindItems(filter);
        }
    }
}
