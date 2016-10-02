using System.Data;
using ArmyTraining.Model;
using DatabaseAccess;
using SqlDatabaseAccess;

namespace ArmyTraining.DataMapper
{
    public class CourseTypeDataMapper
    {
        IDatabaseAccess _Db;
        public CourseTypeDataMapper()
        {
            _Db = new SqlDatabaseAccessor(Configurations.ConnectionString);
        }

        public CourseTypeCollection GetCourseTypes()
        {
            DataTable table = _Db.GetDataTable(StoredProcedureNames.CourseTypeGetAll, new QueryParameterCollection());
            CourseTypeCollection result = new CourseTypeCollection();
            foreach (DataRow item in table.Rows)
            {
                CourseType data = new CourseType();
                data.Id = (int)item["Id"];
                data.Name = string.Format("{0}", item["Name"]);
                result.Add(data);
            }
            return result;
        }

        public CourseType GetCourseType(int Id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", Id));
            DataTable table = _Db.GetDataTable(StoredProcedureNames.CourseTypeGet, parameters);
            if (table.Rows.Count == 0) return null;
            CourseType data = new CourseType();
            data.Id = (int)table.Rows[0]["Id"];
            data.Name = string.Format("{0}", table.Rows[0]["Name"]);
            return data;
        }

        public void UpdateCourseType(CourseType courseLevel)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", courseLevel.Id));
            parameters.Add(new QueryParameter("Name", courseLevel.Name));
            _Db.ExecuteNonQuery(StoredProcedureNames.CourseTypeUpdate, parameters);
        }

        public void AddCourseType(CourseType courseLevel)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Name", courseLevel.Name));
            _Db.ExecuteNonQuery(StoredProcedureNames.CourseTypeAdd, parameters);
        }

        public void DeleteCourseType(int id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            _Db.ExecuteNonQuery(StoredProcedureNames.CourseTypeDelete, parameters);
        }

        public bool IsDuplicate(int id, string name)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            parameters.Add(new QueryParameter("Name", name));
            DataTable table = _Db.GetDataTable("CourseTypeDuplicateCheck", parameters);
            return (int)table.Rows[0]["IsDuplicate"] == 1;
        }
    }
}
