using System;
using ArmyTraining.DataMapper;
using ArmyTraining.Model;

namespace ArmyTraining.Internal
{
    public class CourseInternal
    {
        private CourseDataMapper _Data;

        public CourseInternal()
        {
            _Data = new CourseDataMapper();
        }
        public CourseSearchResult GetCourses(CourseFilter filter)
        {
            return _Data.GetCourses(filter);
        }

        public Course GetCourseById(int Id)
        {
            return _Data.GetCourse(Id);
        }

        public void UpdateCourse(Course course)
        {
            if (_Data.IsDuplicate(course.Id, course.Name))
                throw new ArgumentException(string.Format("The course {0} already exists.", course.Name));
            _Data.UpdateCourse(course);
        }

        public void AddCourse(Course course)
        {
            if (_Data.IsDuplicate(course.Id, course.Name))
                throw new ArgumentException(string.Format("The course {0} already exists.", course.Name));
            _Data.AddCourse(course);
        }

        public void DeleteCourse(int id)
        {
            _Data.DeleteCourse(id);
        }


        //public CourseCollection GetCoursesByType(int courseTypeId)
        //{
        //    return _Data.GetCourseByTypeId(courseTypeId);
        //}
    }
}
