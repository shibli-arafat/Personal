using System;
using ArmyTraining.DataMapper;
using ArmyTraining.Model;

namespace ArmyTraining.Internal
{
    public class CourseTypeInternal
    {
        private CourseTypeDataMapper _Data;

        public CourseTypeInternal()
        {
            _Data = new CourseTypeDataMapper();
        }
        public CourseTypeCollection GetCourseTypes()
        {
            return _Data.GetCourseTypes();
        }

        public CourseType GetCourseType(int Id)
        {
            return _Data.GetCourseType(Id);
        }

        public void UpdateCourseType(CourseType courseType)
        {
            if (_Data.IsDuplicate(courseType.Id, courseType.Name))
                throw new ArgumentException(string.Format("The course type {0} already exist.", courseType.Name));
            _Data.UpdateCourseType(courseType);
        }

        public void AddCourseType(CourseType courseType)
        {
            if (_Data.IsDuplicate(courseType.Id, courseType.Name))
                throw new ArgumentException(string.Format("The course type {0} already exist.", courseType.Name));
            _Data.AddCourseType(courseType);
        }

        public void DeleteCourseType(int id)
        {
            _Data.DeleteCourseType(id);
        }
    }
}
