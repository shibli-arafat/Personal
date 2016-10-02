using System;
using System.Collections.Generic;
using DefenseTraining.Dal;
using DefenseTraining.Model;

namespace DefenseTraining.Bol
{
    public class CourseBol
    {
        private CourseDal _Dal;

        public CourseBol()
        {
            _Dal = new CourseDal();
        }

        public List<Course> GetCourses(int eventTypeId, string keyword)
        {
            return _Dal.GetCourses(eventTypeId, keyword);
        }

        public Course GetCourse(int id)
        {
            return _Dal.GetCourse(id);
        }

        public void DeleteCourse(int id)
        {
            _Dal.DeleteCourse(id);
        }

        public Course SaveCourse(Course rank)
        {
            if (_Dal.CourseExists(rank.Id, rank.Name))
            {
                throw new Exception("Course with the same name already exists. Please enter unique course name.");
            }
            rank.Id = _Dal.SaveCourse(rank);
            return rank;
        }
    }
}
