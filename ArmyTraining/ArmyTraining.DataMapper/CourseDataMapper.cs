using System.Data;
using ArmyTraining.Model;
using DatabaseAccess;
using SqlDatabaseAccess;

namespace ArmyTraining.DataMapper
{
    public class CourseDataMapper
    {
        IDatabaseAccess _Db;
        public CourseDataMapper()
        {
            _Db = new SqlDatabaseAccessor(Configurations.ConnectionString);
        }

        public CourseSearchResult GetCourses(CourseFilter filter)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("TypeId", filter.CourseTypeId));
            parameters.Add(new QueryParameter("Keyword", string.Format("{0}", filter.Keyword)));
            parameters.Add(new QueryParameter("PageNumber", filter.PageNumber));
            parameters.Add(new QueryParameter("Count", filter.Count));
            parameters.Add(new QueryParameter("TrainingBkgId", filter.TrainingBkgId));
            parameters.Add(new QueryParameter("TotalCount", 0, true));

            DataSet ds = _Db.GetDataSet(StoredProcedureNames.CourseGetAll, parameters);
            CourseSearchResult result = new CourseSearchResult();
            foreach (DataRow drCource in ds.Tables[0].Rows)
            {
                Course course = new Course();
                course.Id = (int)drCource["Id"];
                course.Name = string.Format("{0}", drCource["Name"]);
                course.Description = string.Format("{0}", drCource["Description"]);
                course.Level = new CourseType();
                course.Level.Id = (int)drCource["CourseTypeId"];
                course.Level.Name = string.Format("{0}", drCource["CourseTypeName"]);
                int trBkgId = 0;
                int.TryParse(string.Format("{0}", drCource["TrainingBkgId"]), out trBkgId);
                course.TrainingBkg.Id = trBkgId;
                course.TrainingBkg.Name = string.Format("{0}", drCource["TrainingBkgName"]);
                result.Courses.Add(course);
            }
            result.TotalCount = (int)parameters.GetParameterByName("TotalCount").Value;
            return result;

        }

        public Course GetCourse(int id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            DataSet ds = _Db.GetDataSet(StoredProcedureNames.CourseGet, parameters);

            foreach (DataRow drCource in ds.Tables[0].Rows)
            {
                Course course = new Course();
                course.Id = (int)drCource["Id"];
                course.Name = string.Format("{0}", drCource["Name"]);
                course.Description = string.Format("{0}", drCource["Description"]);
                course.Level = new CourseType();
                course.Level.Id = (int)drCource["CourseTypeId"];
                course.Level.Name = string.Format("{0}", drCource["CourseTypeName"]);
                int trBkgId = 0;
                int.TryParse(string.Format("{0}", drCource["TrainingBkgId"]), out trBkgId);
                course.TrainingBkg.Id = trBkgId;
                course.TrainingBkg.Name = string.Format("{0}", drCource["TrainingBkgName"]);
                return course;
            }
            return null;
        }

        public void DeleteCourse(int id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));

            _Db.ExecuteNonQuery(StoredProcedureNames.CourseDelete, parameters);
        }

        public void AddCourse(Course course)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();

            parameters.Add(new QueryParameter("Name", course.Name));
            parameters.Add(new QueryParameter("Description", course.Description));
            parameters.Add(new QueryParameter("CourseTypeId", course.Level.Id));
            parameters.Add(new QueryParameter("TrainingBkgId", course.TrainingBkg.Id));
            _Db.ExecuteNonQuery(StoredProcedureNames.CourseAdd, parameters);
        }

        public void UpdateCourse(Course course)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();

            parameters.Add(new QueryParameter("Id", course.Id));
            parameters.Add(new QueryParameter("Name", course.Name));
            parameters.Add(new QueryParameter("Description", course.Description));
            parameters.Add(new QueryParameter("TrainingBkgId", course.TrainingBkg.Id));
            parameters.Add(new QueryParameter("CourseTypeId", course.Level.Id));
            _Db.ExecuteNonQuery(StoredProcedureNames.CourseUpdate, parameters);
        }

        public bool IsDuplicate(int id, string name)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            parameters.Add(new QueryParameter("Name", name));
            DataTable table = _Db.GetDataTable("CourseDuplicateCheck", parameters);
            return (int)table.Rows[0]["IsDuplicate"] == 1;
        }
    }
}
