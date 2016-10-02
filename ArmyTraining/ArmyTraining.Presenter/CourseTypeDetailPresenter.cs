using ArmyTraining.Internal;
using ArmyTraining.Model;
using ArmyTraining.Presenter.Views;

namespace ArmyTraining.Presenter
{
    public class CourseTypeDetailPresenter
    {
        private CourseTypeInternal _Internal;
        private ICourseTypeDetail _View;
        public CourseTypeDetailPresenter(ICourseTypeDetail view)
        {
            _Internal = new CourseTypeInternal();
            _View = view;
        }

        public void OnPageLoad()
        {
            if (!_View.IsPagePostBack)
            {
                CourseType courseType = new CourseType();
                if (_View.CourseTypeId > 0)
                {
                    courseType = _Internal.GetCourseType(_View.CourseTypeId);
                }
                _View.PopulateGUIFromCourseType(courseType);
            }
        }

        public void HandleSave()
        {
            CourseType courseType = _View.PopulateCourseTypeFromGUI();
            if (_View.CourseTypeId == 0)
            {
                AddCourseType(courseType);
            }
            else
            {
                UpdateCourseType(courseType);
            }
        }

        private void AddCourseType(CourseType courseType)
        {
            _Internal.AddCourseType(courseType);
        }

        private void UpdateCourseType(CourseType courseType)
        {
            courseType.Id = _View.CourseTypeId;
            _Internal.UpdateCourseType(courseType);
        }

        public CourseType LoadCourseType()
        {
            return _Internal.GetCourseType(_View.CourseTypeId);
        }
    }
}
