using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class CourseTypeListPresenter
    {
        CourseTypeInternal _Internal;
        ICourseTypeListView _View;

        public CourseTypeListPresenter(ICourseTypeListView view)
        {
            _Internal = new CourseTypeInternal();
            _View = view;
        }

        public void OnViewLoaded()
        {
            if (!_View.IsPagePostBack)
            {
                BindCourseTypes();
            }
        }

        public void Delete(int id)
        {
            _Internal.DeleteCourseType(id);
            BindCourseTypes();
        }

        public void BindCourseTypes()
        {
            CourseTypeCollection ranks = _Internal.GetCourseTypes();
            if (ranks.Count > 0) _View.ViewDataInGUI(ranks);
            else _View.ShowEmptyMessage();
        }

    }
}
