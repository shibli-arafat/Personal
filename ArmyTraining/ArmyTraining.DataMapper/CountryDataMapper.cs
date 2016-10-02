using System.Data;
using ArmyTraining.Model;
using DatabaseAccess;
using SqlDatabaseAccess;

namespace ArmyTraining.DataMapper
{
    public class CountryDataMapper
    {
        IDatabaseAccess _Db;
        public CountryDataMapper()
        {
            _Db = new SqlDatabaseAccessor(Configurations.ConnectionString);
        }

        public CountryCollection GetCountries()
        {
            DataTable table = _Db.GetDataTable(StoredProcedureNames.CountryGetAll, new QueryParameterCollection());
            CountryCollection result = new CountryCollection();
            foreach (DataRow item in table.Rows)
            {
                Country data = new Country();
                data.Id = (int)item["Id"];
                data.Name = string.Format("{0}", item["Name"]);
                result.Add(data);
            }
            return result;
        }

        public Country GetCountry(int Id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", Id));
            DataTable table = _Db.GetDataTable(StoredProcedureNames.CountryGet, parameters);
            if (table.Rows.Count == 0) return null;
            Country data = new Country();
            data.Id = (int)table.Rows[0]["Id"];
            data.Name = string.Format("{0}", table.Rows[0]["Name"]);
            return data;
        }

        public void UpdateCountry(Country country)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", country.Id));
            parameters.Add(new QueryParameter("Name", country.Name));
            _Db.ExecuteNonQuery(StoredProcedureNames.CountryUpdate, parameters);
        }

        public void AddCountry(Country country)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Name", country.Name));
            _Db.ExecuteNonQuery(StoredProcedureNames.CountryAdd, parameters);
        }

        public void DeleteCountry(int id)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            _Db.ExecuteNonQuery(StoredProcedureNames.CountryDelete, parameters);
        }

        public CountryCollection GetCountriesByCourse(int courseId)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("CourseId", courseId));
            DataTable table = _Db.GetDataTable(StoredProcedureNames.CountryGetByCourseId, parameters);
            CountryCollection result = new CountryCollection();
            foreach (DataRow item in table.Rows)
            {
                Country data = new Country();
                data.Id = (int)item["Id"];
                data.Name = string.Format("{0}", item["Name"]);
                result.Add(data);
            }
            return result;

        }

        public bool IsDuplicate(int id, string name)
        {
            QueryParameterCollection parameters = new QueryParameterCollection();
            parameters.Add(new QueryParameter("Id", id));
            parameters.Add(new QueryParameter("Name", name));
            DataTable table = _Db.GetDataTable("CountryDuplicateCheck", parameters);
            return (int)table.Rows[0]["IsDuplicate"] == 1;
        }
    }
}
